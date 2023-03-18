''' <summary>
''' FSS Reporting Stations
''' </summary>
''' <remarks></remarks>
Public Class COM : Implements IFAALoader

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim RES As New Repository.COM

        RaiseEvent SetCount(lines.Count, "COM")
        For Each com As String In lines
            RaiseEvent NextLine()

            Dim ECOM As New Entity.COM
            With ECOM
                .icao = GetPart(com, 1, 4)
                .type = GetPart(com, 5, 7)
                .navaid_ident = GetPart(com, 12, 4)
                .navaid_type = GetPart(com, 16, 2)
                .navaid_city = GetPart(com, 18, 26)
                .navaid_state = GetPart(com, 44, 20)
                .navaid_name = GetPart(com, 64, 26)
                .navaid_latitude = LatLong_To_Degrees(GetPart(com, 90, 14))
                .navaid_longitude = LatLong_To_Degrees(GetPart(com, 104, 14))
                .com_city = GetPart(com, 118, 26)
                .com_state = GetPart(com, 144, 20)
                .com_regionname = GetPart(com, 164, 20)
                .com_regioncode = GetPart(com, 184, 3)
                .com_latitude = LatLong_To_Degrees(GetPart(com, 187, 14))
                .com_longitude = LatLong_To_Degrees(GetPart(com, 201, 14))
                .com_call = GetPart(com, 215, 26)
                .com_frequencies = GetPart(com, 241, 144)
                .fss_ident = GetPart(com, 385, 4)
                .fss_name = GetPart(com, 389, 30)
                .alt_fss_ident = GetPart(com, 419, 4)
                .alt_fss_name = GetPart(com, 423, 30)
                .operational_hours = GetPart(com, 453, 60)
                .owner_code = GetPart(com, 513, 1)
                .owner_name = GetPart(com, 514, 69)
                .operator_code = GetPart(com, 583, 1)
                .operator_name = GetPart(com, 584, 69)
                .time_zone = GetPart(com, 661, 2)
                .status = GetPart(com, 663, 20)
                .status_date = GetPart(com, 683, 11)
            End With
            RES.Add(ECOM)
        Next
        RES.Finish()

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "COM"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount

End Class
