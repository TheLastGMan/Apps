Public Module Common

    Function GetPart(ByRef str As String, ByVal start As Integer, ByVal length As Integer)
        Return str.Substring(start - 1, length).Trim()
    End Function

    Function GetLines(ByRef lines As List(Of String), ByVal startwith As String) As List(Of String)
        Return lines.Where(Function(f) f.StartsWith(startwith)).ToList
    End Function

    Function LatLong_DDDMMSS_Degrees(ByRef geo As String) As String
        Dim dir As String = geo.Substring(geo.Length - 1)
        Dim ss As String = geo.Substring(geo.Length - 3, 2)
        Dim mm As String = geo.Substring(geo.Length - 5, 2)
        Dim dd As String = geo.Substring(0, geo.Length - 5)

        Dim loc As Decimal = dd + mm * (1 / 60) + ss * (1 / 3600)
        If dir = "S" Or dir = "W" Then
            loc *= -1
        End If
        Return Math.Round(loc, 10)
    End Function

    Function LatLong_To_Degrees(ByRef geolocation As String) As String
        If geolocation.Length > 0 Then
            Dim cord As String = geolocation.Substring(geolocation.Length - 1, 1)

            If geolocation.Contains("-") And geolocation.Contains(".") Then
                geolocation = geolocation.Substring(0, geolocation.Length - 1)
                Dim geo As String() = geolocation.Split("-")

                If geo.Length = 3 Then
                    Dim loc As Decimal = geo(0) + geo(1) * (1 / 60) + geo(2) * (1 / 3600)
                    If cord.Contains("S") Or cord.Contains("W") Then
                        loc *= -1
                    End If
                    cord = Math.Round(loc, 10).ToString
                    Return cord
                Else
                    Return geolocation
                End If

            Else
                Return geolocation
            End If
        Else
            Return geolocation
        End If

    End Function

End Module
