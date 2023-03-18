Public Class Teams_Add

    Private Sub Teams_Add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Main.Gen.TextName = Name_Box.Name
        Name_Box.Focus()
        Fill_League()
    End Sub

    Private Sub Fill_League()
        Dim LDT As New PBCDataSet.LeagueDataTable
        Try
            LeagueTableAdapter.Fill(LDT)
            If LDT.Rows.Count > 0 Then
                For i As Short = 0 To LDT.Rows.Count - 1
                    League_List.Items.Add(LDT.Rows(i).Item("League_Name"))
                Next
                League_List.SelectedIndex = 0
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Name_Box_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Name_Box.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Add_Team.Focus()
        End If
    End Sub

    Private Sub Name_Box_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name_Box.Enter
        Main.Gen.TextName = Name_Box.Name
        'Name_Box.Focus()
        KeyboardForm.Focus()
    End Sub

    Private Sub League_List_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles League_List.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Name_Box.Focus()
        End If
    End Sub

    Private Sub Show_KB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Show_KB.Click
        If Show_KB.Text.Contains("Show") Then
            Show_KB.Text = "Hide KeyBoard"
            KeyboardForm.Show()
        Else
            Show_KB.Text = "Show Keyboard"
            KeyboardForm.Close()
        End If
    End Sub

    Private Sub Add_Team_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Add_Team.KeyDown
        If e.KeyCode = Keys.Enter Then
            Add_Teams()
        End If
    End Sub

    Private Sub Add_Team_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_Team.Click
        Add_Teams()
    End Sub

    Private Sub Add_Teams()
        If Name_Box.Text.Length >= 2 And Not League_List.Text = "" Then
            If Check_Team() Then
                Try
                    TeamsTableAdapter.Insert(Name_Box.Text, League_List.Text)
                    Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Add_Suc)
                    Name_Box.ResetText()
                    League_List.ResetText()
                    Name_Box.Focus()
                    TeamsTableAdapter.Dispose()
                Catch ex As Exception
                    Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
                End Try
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Exists)
                Name_Box.Focus()
            End If
        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Team)
            Name_Box.Focus()
        End If
    End Sub

    Private Function Check_Team()
        Try
            If QueriesTableAdapter.Check_Team(Name_Box.Text, League_List.Text) = "0" Then
                QueriesTableAdapter.Dispose()
                Return True
            Else
                QueriesTableAdapter.Dispose()
                Return False
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            Return False
        End Try
    End Function

End Class
