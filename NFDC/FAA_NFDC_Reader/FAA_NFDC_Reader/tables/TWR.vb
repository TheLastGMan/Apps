Public Class TWR : Implements IFAALoader

    Public Function ParseFile(ByRef lines As System.Collections.Generic.List(Of String)) As IFAALoader.FAAResponse Implements IFAALoader.ParseFile
        Dim T1 As New TWR1
        Dim T1R As New Repository.TWR1
        Dim T2 As New TWR2
        Dim T2R As New Repository.TWR2
        Dim T3 As New TWR3
        Dim T3R As New Repository.TWR3
        Dim T4 As New TWR4
        Dim T4R As New Repository.TWR4
        Dim T7 As New TWR7
        Dim T7R As New Repository.TWR7
        Dim T8 As New TWR8
        Dim T8R As New Repository.TWR8
        Dim T9 As New TWR9
        Dim T9R As New Repository.TWR9

        RaiseEvent SetCount(GetLines(lines, "TWR1").Count, "TWR1")
        For Each twr As String In GetLines(lines, "TWR1")
            RaiseEvent NextLine()
            T1R.Add(T1.Process(twr))
        Next
        T1R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR2").Count, "TWR2")
        For Each twr As String In GetLines(lines, "TWR2")
            RaiseEvent NextLine()
            T2R.Add(T2.Process(twr))
        Next
        T2R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR3").Count, "TWR3")
        For Each twr As String In GetLines(lines, "TWR3")
            RaiseEvent NextLine()
            T3R.Add(T3.Process(twr))
        Next
        T3R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR4").Count, "TWR4")
        For Each twr As String In GetLines(lines, "TWR4")
            RaiseEvent NextLine()
            T4R.Add(T4.Process(twr))
        Next
        T4R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR7").Count, "TWR7")
        For Each twr As String In GetLines(lines, "TWR7")
            RaiseEvent NextLine()
            T7R.Add(T7.Process(twr))
        Next
        T7R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR8").Count, "TWR8")
        For Each twr As String In GetLines(lines, "TWR8")
            RaiseEvent NextLine()
            T8R.Add(T8.Process(twr))
        Next
        T8R.Finish()

        RaiseEvent SetCount(GetLines(lines, "TWR9").Count, "TWR9")
        For Each twr As String In GetLines(lines, "TWR9")
            RaiseEvent NextLine()
            T9R.Add(T9.Process(twr))
        Next
        T9R.Finish()

        Return IFAALoader.FAAResponse.Completed
    End Function

    Public Function ICAO(ByRef line As String) As String
        Return line.Substring(4, 4).Trim()
    End Function

    Public ReadOnly Property FileType As String Implements IFAALoader.FileType
        Get
            Return "TWR"
        End Get
    End Property

    Public Event NextLine() Implements IFAALoader.NextLine
    Public Event SetCount(ByRef count As Integer, ByRef section As String) Implements IFAALoader.SetCount
End Class
