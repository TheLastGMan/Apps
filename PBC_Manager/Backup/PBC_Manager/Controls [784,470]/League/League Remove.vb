Public Class League_Remove

    Private Sub League_Remove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Leagues()
    End Sub

    Private Sub Fill_Leagues()
        Try
            Dim LDT As New PBCDataSet.LeagueDataTable
            LeagueTableAdapter.Fill(LDT)
            If LDT.Rows.Count > 0 Then
                For i As Short = 1 To LDT.Rows.Count
                    LeagueBox.Items.Add(LDT.Rows((i - 1)).Item("League_Name"))
                Next
                LDT.Clear()
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Remove_League_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_League.Click
        If LeagueBox.Text.Length = 0 Then
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League)
        Else
            Try
                'MsgBox(LeagueBox.Text)
                LeagueTableAdapter.DeleteLeague(LeagueBox.Text)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.League_Rem_Suc)
                LeagueBox.ResetText()
                LeagueBox.Items.Clear()
                Fill_Leagues()
            Catch ex As Exception
                Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            End Try
        End If
    End Sub

End Class
