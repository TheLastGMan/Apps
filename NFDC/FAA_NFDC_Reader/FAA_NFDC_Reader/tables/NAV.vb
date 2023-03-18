Public Class NAV : Implements IFAALoader

    Private DT As New Data.DataTable("NAV")
    Private DTCols As String() = {"ICAO", "NavType", "Effective", "NavName", "NavCity", "NavState", "NavClass", "NavHours", "Latitude", "Longitude", "TACAN_Channel", "Frequency", "Weather_Hours", "Phone"}
    Private DT2 As New Data.DataTable("NAV2")
    Private DT2Cols As String() = {"ICAO", "Remarks"}

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim N1 As New NAV1
        Dim N1R As New Repository.NAV1
        Dim N2 As New NAV2
        Dim N2R As New Repository.NAV2

        RaiseEvent SetCount(GetLines(lines, "NAV1").Count, "NAV2")
        For Each nav As String In GetLines(lines, "NAV1")
            RaiseEvent NextLine()
            N1R.Add(N1.Process(nav))
        Next
        N1R.Finish()

        RaiseEvent SetCount(GetLines(lines, "NAV2").Count, "NAV2")
        For Each nav As String In GetLines(lines, "NAV2")
            RaiseEvent NextLine()
            N2R.Add(N2.Process(nav))
        Next
        N2R.Finish()

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "NAV"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount
End Class
