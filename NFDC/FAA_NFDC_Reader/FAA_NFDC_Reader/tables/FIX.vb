Public Class FIX : Implements IFAALoader

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim F1 As New FIX1
        Dim F1R As New Repository.FIX1

        RaiseEvent SetCount(GetLines(lines, "FIX1").Count, "FIX1")
        For Each fix In GetLines(lines, "FIX1")
            RaiseEvent NextLine()
            F1R.Add(F1.Process(fix))
        Next

        If Not F1R.Finish() Then
            Return IFAALoader.FAAResponse.DB_Error
        End If

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "FIX"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount

End Class
