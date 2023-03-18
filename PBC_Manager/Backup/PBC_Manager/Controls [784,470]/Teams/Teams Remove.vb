Public Class Teams_Remove

    Private Sub Teams_Remove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Teams()
    End Sub

    Private Sub Fill_Teams()
        Dim LDT As New PBCDataSet.LeagueDataTable
        Try
            LeagueTableAdapter.Fill(LDT)
            If LDT.Rows.Count > 0 Then
                For i As Short = 0 To LDT.Rows.Count - 1
                    League_List.Items.Add(LDT.Rows(i).Item("League_Name"))
                Next
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Load_Suc)
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
            End If
            LeagueTableAdapter.Dispose()
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Fill_Names()
        Dim TDT As New PBCDataSet.TeamsDataTable
        Team_List.ResetText()
        Team_List.Items.Clear()
        Try
            TeamsTableAdapter.FillByLeague(TDT, League_List.Text)
            If TDT.Rows.Count > 0 Then
                For i As Short = 0 To TDT.Rows.Count - 1
                    Team_List.Items.Add(TDT.Rows(i).Item("Team Name"))
                Next
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Team_Exist)
            End If
            TeamsTableAdapter.Dispose()
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Remove_League_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_Team.Click
        If Not League_List.Text = Nothing And Not Team_List.Text = Nothing Then
            Try
                TeamsTableAdapter.DeleteTeam(Team_List.Text, League_List.Text)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Rem_Suc)
                Fill_Names()
            Catch ex As Exception
                Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            End Try
        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Team)
        End If
    End Sub

    Private Sub League_Box_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Remove_Team.Focus()
    End Sub

    Private Sub League_List_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles League_List.SelectedIndexChanged
        Fill_Names()
    End Sub
End Class
