Public Class PBC_Add

    Private TF As Boolean = False

    Private Sub PBC_Add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Teams()
        Fill_Status()
        Name_Box.Focus()
    End Sub

    Private Sub Fill_Status()
        PBC_Status.Items.Insert(General_Functions.PBC_Codes.Regular, "Regular")
        PBC_Status.Items.Insert(General_Functions.PBC_Codes.No_Cost, "No Cost")
        'PBC_Status.Items.Insert(3, "Refund")
        'PBC_Status.Items.Insert(4, "VOID")
        '5 = Redeemed
        PBC_Status.SelectedIndex = 0
    End Sub

    Private Sub Fill_Teams()
        Dim LDT As New PBCDataSet.LeagueDataTable
        Try
            LeagueTableAdapter.Fill(LDT)
            If LDT.Rows.Count > 0 Then
                For i As Short = 0 To LDT.Rows.Count - 1
                    League_List.Items.Add(LDT.Rows(i).Item("League_Name"))
                Next
                League_List.SelectedIndex = 0
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Load_Suc)
                TF = True
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
                Disable_Page()
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
                Team_List.SelectedIndex = 0
                TF = True
                Disable_Page(True)
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Team_Exist)
                Disable_Page()
            End If
            TeamsTableAdapter.Dispose()
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Disable_Page(Optional ByVal Stat As Boolean = False)
        TF = Stat
        'League_List.Enabled = False
        Team_List.Enabled = Stat
        Name_Box.Enabled = Stat
        PBC_Status.Enabled = Stat
        Card_ID.Enabled = Stat
        If Not TF Then
            Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_TL_ERROR)
        End If
    End Sub

    Private Sub Teams_Box_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Team_List.SelectedIndexChanged
        Name_Box.Focus()
    End Sub

    Private Sub League_List_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles League_List.SelectedIndexChanged
        Team_List.Focus()
        Fill_Names()
    End Sub

    Private Sub Name_Box_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Name_Box.KeyDown
        If e.KeyCode = Keys.Enter Then
            Card_ID.Focus()
        End If
    End Sub

    Private Sub Card_ID_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Card_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Insert_Card()
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

    Private Sub Name_Box_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name_Box.Enter
        Main.Gen.TextName = Name_Box.Name
    End Sub

    Private Sub Card_ID_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Card_ID.Enter
        Main.Gen.TextName = Card_ID.Name
    End Sub

    Private Sub Issue__Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Issue__Button.Click
        Insert_Card()
    End Sub

    Private Sub Insert_Card()
        If TF And Name_Box.Text.Length > 0 And Card_ID.Text.Length > 0 And Check_PBC_ID(Card_ID.Text) Then
            'Enter Card
            Try
                Master_SheetTableAdapter.InsertPBC(Card_ID.Text, Name_Box.Text, Team_List.Text, League_List.Text, Now(), Main.Gen.AdminName, PBC_Status.SelectedIndex)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_Add_Suc)
                Adjust_Card()
            Catch ex As Exception
                Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            End Try
        Else
            'Do Not Enter Card
            Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_Format)
            Adjust_Card()
        End If
    End Sub

    Private Sub Adjust_Card()
        Card_ID.Focus()
        Card_ID.ResetText()
        'For i As SByte = 0 To Card_ID.Text.Length
        'SendKeys.Send("{RIGHT}")
        'Next
        'SendKeys.Send("{BACKSPACE}")
    End Sub

    Private Function Check_PBC_ID(ByVal pbc As String)
        Try
            Dim DT As New PBCDataSet.Master_SheetDataTable
            Master_SheetTableAdapter.Check_PBC(DT, pbc.ToString())
            If DT.Rows(0).Item("CNT").ToString() > 0 Then
                'MsgBox("Exists")
                Return False
            Else
                'MsgBox("No Exists")
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
