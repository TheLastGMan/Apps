Public Class APT : Implements IFAALoader

    Private DT As New Data.DataTable("APT")
    Private DTcols As String() = {"ICAO", "Facility_Type", "Effective", "Airport_Name", "Latitude", "Longitude", "Elevation_MSL", "Magnetic_Variation", "TPA_agl", "Sectional", "Notam_Service", "Status", "Fuel", "Has_Tower", "UNICOM", "CTAF", "Non_Commercial_Fee"}

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim A1 As New APT1
        Dim A1R As New Repository.APT1

        RaiseEvent SetCount(GetLines(lines, "APT").Count, "APT")
        For Each apt In GetLines(lines, "APT")
            RaiseEvent NextLine()
            A1R.Add(A1.Process(apt))
        Next
        A1R.Finish()

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "APT"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount

End Class
