Public Class AWOS : Implements IFAALoader

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim A1 As New AWOS1
        Dim A1R As New Repository.AWOS1
        Dim A2 As New AWOS2
        Dim A2R As New Repository.AWOS2

        RaiseEvent SetCount(GetLines(lines, "AWOS1").Count, "AWOS1")
        For Each AWOS In GetLines(lines, "AWOS1")
            RaiseEvent NextLine()
            A1R.Add(A1.Process(AWOS))
        Next
        A1R.Finish()

        RaiseEvent SetCount(GetLines(lines, "AWOS2").Count, "AWOS2")
        For Each awos In GetLines(lines, "AWOS2")
            RaiseEvent NextLine()
            A2R.Add(A2.Process(awos))
        Next
        A2R.Finish()

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "AWOS"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount

End Class
