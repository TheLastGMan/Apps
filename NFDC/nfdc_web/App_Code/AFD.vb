Public Class AFD

    Public Enum ArrDep As Byte
        Departure = 0
        Arrival = 1
    End Enum

    Public Structure LatLon
        Public Latitude As Decimal
        Public Longitude As Decimal
        Public Sub New(ByRef lat As Decimal, ByRef lon As Decimal)
            Latitude = lat
            Longitude = lon
        End Sub
    End Structure

    Public Structure CloseAirports
        Public ICAO As String
        Public Type As String
        Public Name As String
        Public LatLon As LatLon
        Public Distance As Decimal
    End Structure

    Public Structure CloseNav
        Public ICAO As String
        Public Type As String
        Public NavName As String
        Public LatLon As LatLon
        Public Frequency As String
        Public Distance As Decimal
    End Structure

    Private Shared _EFF As String

    Public Shared ReadOnly Property Effective As String
        Get
            If IsNothing(_EFF) Then
                Dim IC As Boolean = IsCurrent
            End If
            Return _EFF
        End Get
    End Property

    Public Shared ReadOnly Property IsCurrent As Boolean
        Get
            Dim DT As Data.DataTable = DB.EXECsql("SELECT DISTINCT DATEPART(MONTH, [Effective]) as m, DATEPART(DAY, [Effective]) as d, DATEPART(YEAR, [Effective]) as y FROM [APT]")
            If DT.Rows.Count > 0 Then
                Dim eff As New Date(DT.Rows(0).Item("y"), DT.Rows(0).Item("m"), DT.Rows(0).Item("d"))
                _EFF = eff.ToShortDateString
                Return IIf(Now.AddDays(-56) <= eff, True, False)
            Else
                Return False
            End If
        End Get
    End Property

    Public Function Airport_Communications(ByVal ICAO As String, ByVal Direction As ArrDep, Optional ByRef username As String = "", Optional ByRef password As String = "") As AirportCommunication
        Dim AC As New AirportCommunication

        If Exists(ICAO) Then
            'Local Communication
            Dim DT As Data.DataTable = DB.EXECsql("SELECT [UNICOM],[CTAF],[Elevation_MSL] FROM [APT] WHERE [ICAO] = '" & ICAO.Trim("'") & "'")
            With DT
                AC.UNICOM = DT.Rows(0).Item("UNICOM")
                AC.CTAF = DT.Rows(0).Item("CTAF")
                AC.Field_Elevation = DT.Rows(0).Item("Elevation_MSL")
            End With

            'AWOS_ATIS
            '>check if AWOS
            DT = DB.EXECsql("SELECT [Frequency] FROM [AWOS1] WHERE LEN([Frequency]) > 0 AND [ICAO] = '" & ICAO.Trim("'") & "'")
            If DT.Rows.Count > 0 Then
                'AWOS
                AC.ATIS_AWOS = DT.Rows(0).Item("Frequency")
            Else
                'possible ATIS
                Dim sql As String = "SELECT * FROM [TWR3] WHERE ([Frequency] BETWEEN '118' AND '136') AND (LEN([Uses]) > 0) AND ([Uses] Like '%ATIS%') AND ([ICAO] = '" & ICAO.Trim("'") & "')"
                DT = DB.EXECsql(sql)
                If DT.Rows.Count = 1 Then
                    AC.ATIS_AWOS = DT.Rows(0).Item("Frequency")
                ElseIf DT.Rows.Count > 0 Then
                    'more than 1, check for approach/departure
                    Dim dirx As String = IIf(Direction = ArrDep.Arrival, "(ARR)", "(DEP)")
                    If DT.Rows(0).Item("Frequency").ToString.Contains(dirx) Then
                        AC.ATIS_AWOS = DT.Rows(0).Item("Frequency").ToString.Substring(0, DT.Rows(0).Item("Frequency").ToString.IndexOf("("))
                    Else
                        AC.ATIS_AWOS = DT.Rows(1).Item("Frequency").ToString.Substring(0, DT.Rows(1).Item("Frequency").ToString.IndexOf("("))
                    End If
                Else
                    'no weather, find closes station
                    AC.ATIS_AWOS = Closest_AWOS(ICAO)
                End If
            End If

            'FSS
            DT = DB.EXECsql("SELECT [Frequencies], [FSS_Name] FROM [COM] WHERE [ComType] LIKE '%RCO%' AND [ICAO] = '" & ICAO.Trim("'") & "'")
            If DT.Rows.Count > 0 Then
                'FSS on field
                Dim freq As String = DT.Rows(0).Item("Frequencies")
                Dim freqs As New List(Of String)
                Dim start As Integer = 0
                While (start < freq.Length)
                    freqs.Add(freq.Substring(start, IIf(start + 9 > freq.Length, freq.Length - start, 9)).Trim())
                    start += 8
                End While
                For Each frex As String In (From fre As String In freqs Where fre >= "118" And fre <= "136" And Not fre = "121.5" Select fre).ToArray
                    If frex.Contains("R") Then
                        'find vor channel
                        AC.FSS_1 = frex.Substring(0, frex.IndexOf("R"))
                        AC.FSS_2 = DB.EXECsql("SELECT NAV1.Frequency AS RX FROM NAV1 INNER JOIN COM ON NAV1.ICAO = COM.ICAO WHERE (NAV1.ICAO = '" & ICAO.Trim("'") & "') AND (COM.Frequencies LIKE '%" & frex & "%')").Rows(0).Item("RX")
                    Else
                        'check for dual frequency

                        'RCO frequency
                        AC.FSS_1 = DT.Rows(0).Item("FSS_Name") 'GET NAME
                        AC.FSS_2 = frex
                    End If
                Next
            Else
                'Find closest one
                Dim RCO As DictionaryEntry = Closest_RCO(ICAO)
                AC.FSS_1 = RCO.Key
                AC.FSS_2 = RCO.Value
            End If

            'check for tower info
            DT = DB.EXECsql("SELECT TWR3.* FROM TWR3 WHERE [ICAO] = '" & ICAO.Trim("'") & "' and LEN([Uses]) > 0 AND [Frequency] BETWEEN '118' and '136'")
            Dim obj As Object
            If DT.Rows.Count > 0 Then
                'grab info

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Uses").ToString.Contains("LCL/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Tower = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Uses").ToString.Contains("GND/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Ground = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Uses").ToString.Contains("APCH/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Approach = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Uses").ToString.Contains("DEP/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Departure = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Uses").ToString.Contains("CD/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Clearance = obj.getValue(0)
                End If
            End If
            DT = DB.EXECsql("SELECT TWR7.* FROM TWR7 WHERE [ICAO] = '" & ICAO.Trim("'") & "' and LEN([Frequency_Use]) > 0 AND [Frequency] BETWEEN '118' and '136'")
            If DT.Rows.Count > 0 Then
                'satellite airport, approach / departure / clearance
                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Frequency_Use").ToString.Contains("CD/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Clearance = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Frequency_Use").ToString.Contains("DEP/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Departure = obj.getValue(0)
                End If

                obj = (From dr As Data.DataRow In DT.Rows Where dr.Item("Frequency_Use").ToString.Contains("APCH/P") Select dr.Item("Frequency")).ToArray
                If obj.length > 0 Then
                    AC.Approach = obj.getValue(0)
                End If
            End If


            AC.Tower = IIf(String.IsNullOrEmpty(AC.Tower), "", AC.Tower)
            AC.Ground = IIf(String.IsNullOrEmpty(AC.Ground), "", AC.Ground)
            AC.Approach = IIf(String.IsNullOrEmpty(AC.Approach), "", AC.Approach)
            AC.Departure = IIf(String.IsNullOrEmpty(AC.Departure), "", AC.Departure)
            AC.Clearance = IIf(String.IsNullOrEmpty(AC.Clearance), "", AC.Clearance)

        Else
            AC.SetError("Airport Not Found")
        End If

        Return AC
    End Function

    Public Function Exists(ByVal ICAO As String) As Boolean
        If DB.EXECsql("SELECT [ICAO] FROM [APT] WHERE [ICAO] = '" & ICAO.Trim("'") & "'").Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Airport_LatLong(ByVal airport As String) As LatLon
        Dim DI As New LatLon(0, 0)

        Dim sql As String = "SELECT [longitude], [latitude] FROM [APT] WHERE [ICAO] = '" & airport.Trim("'") & "'"
        Dim DT As Data.DataTable = DB.EXECsql(sql)

        If DT.Rows.Count > 0 Then
            DI.Longitude = DT.Rows(0).Item("longitude")
            DI.Latitude = DT.Rows(0).Item("latitude")
        End If

        Return DI
    End Function

    Public Function Closest_RCO(ByVal ICAO As String) As DictionaryEntry
        Dim DI As New DictionaryEntry("", "")

        Dim cords As LatLon = Airport_LatLong(ICAO.Trim("'")) 'key = Longitude | value = Latitude
        If cords.Latitude.ToString.Length > 0 Then
            Dim sql As String = "SELECT TOP 1 [COM].ICAO, [COM].Frequencies, [COM].FSS_Name, Round(geography::Point('" & cords.Latitude & "', '" & cords.Longitude & "', 4326).STDistance(geography::Point([COM].Latitude, [COM].longitude, 4326))* 0.000539956803,4) as Distance " & _
                                "FROM [COM] " & _
                                "WHERE [COM].[ComType] <> 'EFAS' AND [COM].Frequencies NOT LIKE '%R%' AND [COM].Frequencies NOT LIKE '%122.0%' " & _
                                "ORDER BY [Distance] ASC"
            Dim DT As Data.DataTable = DB.EXECsql(sql)
            If DT.Rows.Count > 0 Then
                DI.Key = DT.Rows(0).Item("FSS_Name")
                Dim freq As String = DT.Rows(0).Item("Frequencies").ToString
                DI.Value = freq.Substring(0, IIf(freq.Length < 9, freq.Length, 9)).Trim()
            End If
        End If

        Return DI
    End Function

    Public Function Closest_AWOS(ByVal ICAO As String) As String
        Dim freq As String = ""

        Dim cords As LatLon = Airport_LatLong(ICAO.Trim("'"))
        If cords.Latitude.ToString.Length > 0 Then
            Dim sql As String = "SELECT TOP 1 [APT].ICAO, [AWOS1].Frequency, Round(geography::Point('" & cords.Latitude & "', '" & cords.Longitude & "', 4326).STDistance(geography::Point([APT].Latitude, [APT].longitude, 4326))* 0.000539956803,4) as Distance " & _
                                "FROM [APT] INNER JOIN [AWOS1] ON [AWOS1].ICAO=[APT].ICAO " & _
                                "WHERE [AWOS1].Comissioned = 'Y' " & _
                                "ORDER BY [Distance] ASC"
            Dim DT As Data.DataTable = DB.EXECsql(sql)
            If DT.Rows.Count > 0 Then
                freq = DT.Rows(0).Item("ICAO") & " " & DT.Rows(0).Item("Frequency")
            End If
        End If

        Return freq
    End Function

    Public Function Close_Airports(ByVal ICAO As String) As List(Of CloseAirports)
        Dim lst As New List(Of CloseAirports)

        Dim cords As LatLon = Airport_LatLong(ICAO)
        Dim sql As String = "SELECT * FROM (" & _
        "SELECT ICAO, Facility_Type, Airport_Name, Latitude, Longitude, Round(geography::Point('" & cords.Latitude & "', '" & cords.Longitude & "', 4326).STDistance(geography::Point([APT].Latitude, [APT].Longitude, 4326))* 0.000539956803,4) as Distance " & _
        "FROM [APT] " & _
        "WHERE [ICAO] <> '" & ICAO.Trim("'") & "') as X " & _
        "WHERE X.Distance <= 550 " & _
        "ORDER BY [Distance] ASC"

        Dim DT As Data.DataTable = DB.EXECsql(sql)
        For Each row As Data.DataRow In DT.Rows
            Dim CA As New CloseAirports
            CA.ICAO = row.Item("ICAO")
            CA.Type = row.Item("Facility_Type")
            CA.Name = row.Item("Airport_Name")
            CA.LatLon = New LatLon(row.Item("Latitude"), row.Item("Longitude"))
            CA.Distance = Math.Round(row.Item("Distance"), 2) & " " & GetDirection(cords, CA.LatLon)
            lst.Add(CA)
        Next

        Return lst
    End Function

    Public Function Close_Navaids(ByVal latitude As Decimal, ByVal longitude As Decimal) As List(Of CloseNav)
        Dim lst As New List(Of CloseNav)

        Dim sql As String = "SELECT * FROM (" & _
            "SELECT [ICAO],[NavType],[NavName],[Latitude],[Longitude],[Frequency],Round(geography::Point('" & latitude & "', '" & longitude & "', 4326).STDistance(geography::Point([Latitude], [Longitude], 4326))* 0.000539956803,4) as Distance " & _
            "FROM [NAV1] " & _
            ") as X " & _
            "WHERE X.Distance <= 550 " & _
            "ORDER BY [Distance] ASC"
        Dim dt As Data.DataTable = DB.EXECsql(sql)
        For Each row As Data.DataRow In dt.Rows
            Dim N As New CloseNav
            N.ICAO = row.Item("ICAO")
            N.Type = row.Item("NavType")
            N.NavName = row.Item("NavName")
            N.LatLon = New LatLon(row.Item("Latitude"), row.Item("Longitude"))
            N.Frequency = row.Item("Frequency")
            N.Distance = row.Item("Distance")
        Next

        Return lst
    End Function

    Public Function Close_Navaids(ByVal ICAO As String) As List(Of CloseNav)
        Dim coords As LatLon = Airport_LatLong(ICAO.Trim("'"))
        Return Close_Navaids(coords.Latitude, coords.Longitude)
    End Function

    Public Function GetDirection(ByRef Source As LatLon, ByRef Destination As LatLon) As String
        Dim londif As Decimal = Decimal.Parse(Destination.Longitude) - Decimal.Parse(Source.Longitude)
        Dim latdif As Decimal = Decimal.Parse(Destination.Latitude) - Decimal.Parse(Source.Latitude)
        Dim deg As Decimal = Math.Round((Math.Atan(latdif / londif)), 4) * 57.2958
        Dim dir As String = ""
        If Destination.Longitude <= Source.Longitude And Destination.Latitude >= Source.Latitude Then
            'Q1
            If deg <= 11.25 Then
                dir = "E"
            ElseIf deg <= 33.75 Then
                dir = "ENE"
            ElseIf deg <= 56.25 Then
                dir = "NE"
            ElseIf deg <= 78.75 Then
                dir = "NNE"
            Else
                dir = "N"
            End If
        ElseIf Destination.Longitude <= Source.Longitude And Destination.Latitude <= Source.Latitude Then
            'Q4
            deg = Math.Abs(deg)
            If deg <= 11.25 Then
                dir = "E"
            ElseIf deg <= 33.75 Then
                dir = "ESE"
            ElseIf deg <= 56.25 Then
                dir = "SE"
            ElseIf deg <= 78.75 Then
                dir = "SSE"
            Else
                dir = "S"
            End If
        ElseIf Destination.Longitude >= Source.Longitude And Destination.Latitude >= Source.Latitude Then
            'Q2
            deg = Math.Abs(deg)
            If deg <= 11.25 Then
                dir = "W"
            ElseIf deg <= 33.75 Then
                dir = "WNW"
            ElseIf deg <= 56.25 Then
                dir = "NW"
            ElseIf deg <= 78.75 Then
                dir = "NNW"
            Else
                dir = "N"
            End If
        Else
            'Q3
            If deg <= 11.25 Then
                dir = "W"
            ElseIf deg <= 33.75 Then
                dir = "WSW"
            ElseIf deg <= 56.25 Then
                dir = "SW"
            ElseIf deg <= 78.75 Then
                dir = "SSW"
            Else
                dir = "S"
            End If
        End If
        Return dir
    End Function

    Public Sub Export_GPS_APT(ByRef location As String)
        Dim DT As Data.DataTable = DB.EXECsql("SELECT [ICAO], [Airport_Name], [Latitude], [Longitude] FROM [APT] ORDER BY [ICAO]")
        DT.WriteXml(location & "\APT.xml")
    End Sub

    Public Sub Export_GPS_AWOS(ByRef location As String)
        Dim sql As String = "SELECT [AWOS1].[ICAO] ,[APT].Airport_Name" & _
                            ",case when LEN([AWOS1].[Latitude]) = 0 then [APT].latitude else [AWOS1].Latitude end as Latitude" & _
                            ",case when LEN([AWOS1].[Longitude]) = 0 then [APT].Longitude else [AWOS1].Longitude end as Longitude" & _
                            ",[Frequency] ,[Telephone] " & _
                            "FROM [AWOS1] INNER JOIN [APT] ON [APT].ICAO=[AWOS1].ICAO " & _
                            "WHERE [AWOS1].Comissioned = 'Y' AND LEN([AWOS1].Frequency) > 0 " & _
                            "ORDER BY [AWOS1].ICAO"
        Dim DT As Data.DataTable = DB.EXECsql(sql)
        DT.WriteXml(location & "\AWOS.xml")
    End Sub

    Public Sub Export_GPS_NAV(ByRef location As String)
        Dim sql As String = "SELECT [ICAO],[NavName],[Latitude],[Longitude],[NavType],[Frequency] FROM [NAV1] ORDER BY [ICAO]"
        Dim DT As Data.DataTable = DB.EXECsql(sql)
        DT.WriteXml(location & "\NAV.xml")
    End Sub

    Public Function Export_ALL(ByRef location As String) As Boolean
        Export_GPS_APT(location)
        Export_GPS_AWOS(location)
        Export_GPS_NAV(location)
        Return True
    End Function

End Class