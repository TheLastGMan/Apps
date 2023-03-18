Public Class Bowler_Info

    Public Shared _BID As Integer = -1

    Private Sub Bowler_Info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Functions.Log_Write("I", "Bowler_Info.Bowler_Info_Load")
        Main.FUNC.Change_Header("Bowler Information")
        Load_Bowlers()
        Main.ERS.Get_Error(Errors.Err_Codes.Bowler_Info_Load_OK)
    End Sub

    Private Sub Load_Bowlers()
        Functions.Log_Write("I", "Bowler_Info.Load_Bowlers")
        'Load Bowler Info
        DataGridView1.Rows.Clear()
        Dim BInfo As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_LName()
        If BInfo.Count = 0 Then
            'not bowlers found
            Functions.Log_Write("W", "Bowler_Info.Load_Bowlers", "No Bowlers exists")
        ElseIf BInfo(0) = "-1" Then
            Functions.Log_Write("E", "Bowler_Info.Load_Bowlers", "Error getting LName List: " & BInfo(1))
        Else
            Functions.Log_Write("S", "Bowler_Info.Load_Bowlers", "Success getting LName List")
            Dim s As String = ChrW(0)
            For i As Integer = 0 To BInfo.Count - 1 Step 5
                Dim data As String = BInfo(i) & s & BInfo(i + 1) & s & BInfo(i + 2) & s & BInfo(i + 3) & s & BInfo(i + 4)
                DataGridView1.Rows.Add(data.Split(s))
            Next
        End If
    End Sub

    Private Function DG(ByVal row As Integer, ByVal item As Integer) As String
        Return DataGridView1.Rows(row).Cells(item).Value
    End Function

    Private Sub Row_Edit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Functions.Log_Write("I", "Bowler_Info.Row_Edit")
        Dim r As Integer = e.RowIndex
        Dim updatex As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Update_By_ID(DG(r, 0), DG(r, 1), DG(r, 2), DG(r, 3), DG(r, 4))
        If updatex(0).ToString.Length > 1 Then
            'error
            Functions.Log_Write("E", "Bowler_Info.Row_Edit", "Could Not Update Bowler:")
            Main.ERS.Get_Error(Errors.Err_Codes.Bowler_Info_UPD_ERR)
        Else
            'success
            Functions.Log_Write("S", "Bowler_Info.Row_Edit", "Updated Bowler")
            Main.ERS.Get_Error(Errors.Err_Codes.Bowler_Info_UPD_OK)
        End If
    End Sub

    Private Sub Row_DClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Functions.Log_Write("I", "Bowler_Info.Row_DClick", "double clicked row index " & e.RowIndex)
        Main.FUNC.USBC_Search(0) = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        Main.FUNC.USBC_Search(1) = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        Main.FUNC.USBC_Search(2) = "1"
        Main.FUNC.USBC_Search(3) = "1"
        Main.FUNC.USBC_Search(4) = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        Main.FUNC.USBC_Search(5) = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        'Main.FUNC.Change_Cont()
    End Sub

    Private Sub Row_Click(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Functions.Log_Write("I", "Bowler_Info.Row_Click", "clicked row index " & e.RowIndex)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Functions.Log_Write("I", "Bowler_Info.Row_Click", "right mouse button, show delete option")
            'Show Delete Options
            ContextMenuStrip1.Items.Clear()
            'ContextMenuStrip1.Items.Add(DataGridView1.Rows(e.RowIndex).Cells(0).Value & "- Delete (" & DataGridView1.Rows(e.RowIndex).Cells(1).Value & ") From Program and From All Weeks")
            'ContextMenuStrip1.Show(New Point(MousePosition.X, MousePosition.Y))
        End If
    End Sub

    Private Sub Delete_Click(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        Functions.Log_Write("I", "Bowler_Info.Delete_Click")
        'Dim ID As String() = e.ClickedItem.Text.Split("-")

        'If e.ClickedItem.Text.Contains("Weeks") Then
        '    Functions.Log_Write("I Bowler_Info.Delete_Click: confirm delete")
        '    'Delete From All Weeks + Program
        '    If MsgBox("Are You Sure You Want To Delete bowler From Program And Every Week They Have Bowled?" & Chr(13) & "Their Scores Will Still Exist In The Tournament But Will Have A (Blank) Name", MsgBoxStyle.YesNo, "Are You Sure?") = MsgBoxResult.Yes Then
        '        Try
        '            Main.DB.BIDSA.Delete_by_ID(ID(0))
        '            Main.DB.SCORA.Delete_Bowler_ID(ID(0))
        '            Functions.Log_Write("S Bowler_Info.Delete_Click: global delete bowler")
        '            Main.ERS.Get_Error(Errors.Err_Codes.Bowler_Info_Del_OK)
        '            Load_Bowlers()
        '        Catch ex As Exception
        '            Functions.Log_Write("E Bowler_Info.Delete_Click: global delete bowler error - " & ex.Message)
        '            Main.ERS.Get_Error(Errors.Err_Codes.Bowler_Info_Del_ERR)
        '        End Try
        '    Else
        '        Functions.Log_Write("I Bowler_Info.Delete_Click: global dete bowler - did not delete")
        '    End If
        'End If
    End Sub

End Class
