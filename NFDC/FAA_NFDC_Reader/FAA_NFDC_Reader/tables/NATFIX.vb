Public Class NATFIX : Implements IFAALoader

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "NATFIX"
        End Get
    End Property

    Public Function ParseFile(ByRef lines As List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        RaiseEvent SetCount(GetLines(lines, "I").Count, "NATFIX")
        Dim N1R As New Repository.NATFIX

        For Each line As String In GetLines(lines, "I")
            RaiseEvent NextLine()
            Dim nat As New Entity.NATFIX
            With nat
                .icao = GetPart(line, 3, 5)
                .latitude = LatLong_DDDMMSS_Degrees(GetPart(line, 9, 7))
                .longitude = LatLong_DDDMMSS_Degrees(GetPart(line, 17, 8))
                .artcc_id = GetPart(line, 27, 4)
                .state_code = GetPart(line, 32, 2)
                .region_code = GetPart(line, 35, 2)
                .type = GetPart(line, 38, 7)
            End With
            N1R.Add(nat)
        Next
        N1R.Finish()
        Return IFAALoader.FAAResponse.Completed
    End Function

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount
End Class
