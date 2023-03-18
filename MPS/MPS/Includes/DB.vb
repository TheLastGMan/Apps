Public Class DB

    Public BOWLA As New MPSDataSetTableAdapters.BowlersTableAdapter
    Public BOWLT As New MPSDataSet.BowlersDataTable
    Public DRILLA As New MPSDataSetTableAdapters.Drill_SheetTableAdapter
    Public DRILLT As New MPSDataSet.Drill_SheetDataTable

    Public Function Get_BID(ByVal Name As String) As Integer
        Return BOWLA.Get_BID(Name)
    End Function

    Public Function Get_Names() As String
        Dim ret As String = String.Empty
        BOWLT.Clear()
        BOWLA.All_Bowlers_Name_ASC(BOWLT)
        For i As Integer = 0 To BOWLT.Rows.Count - 1
            ret &= BOWLT.Rows(i).Item("BName") & "||"
        Next
        Return ret
    End Function

End Class
