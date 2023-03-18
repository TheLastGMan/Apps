Public Class PBC_Redeem

    Private history As New ArrayList()

    Private Sub PBC_Redeem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Status()
        Fill_RedBox()
        Card_ID.Focus()
    End Sub

    Private Sub Fill_Status()
        PBC_Status.Items.Insert(General_Functions.PBC_Codes.Regular, "Regular")
        PBC_Status.Items.Insert(General_Functions.PBC_Codes.No_Cost, "No Cost")
        PBC_Status.SelectedIndex = 0
    End Sub

    Private Sub Fill_RedBox()
        Red_Box.Items.Insert(0, "Redeem")
        Red_Box.Items.Insert(1, "No Cost")
        Red_Box.Items.Insert(2, "Refund")
        Red_Box.Items.Insert(3, "Void")
        Red_Box.Items.Insert(4, "Regular")
        Red_Box.SelectedIndex = 0
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

    Private Sub Card_ID_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Main.Gen.TextName = Card_ID.Name
    End Sub

    Private Sub Card_ID_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Card_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Redeem_Card()
        End If
    End Sub

    Private Sub Issue_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Redeem_Button.Click
        Redeem_Card()
    End Sub

    Private Sub Redeem_Card()
        If Card_ID.Text.Length > 0 Then
            Try
                Dim status As Byte = Main.Gen.Get_PBC_Int(Red_Box.Text)
                Master_SheetTableAdapter.Update_PBC(Now(), Main.Gen.AdminName, status, Card_ID.Text)
                Card_Status.Text = Card_ID.Text & Chr(13) & "Redeemed Successfully"
                Card_Status.BackColor = Color.Lime
                history.Add(Card_ID.Text.ToString())
                Card_ID.Focus()
                Card_ID.ResetText()
                Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_RED_Suc)
            Catch ex As Exception
                Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            End Try
        Else
            Card_ID.Focus()
            Card_Status.ResetText()
            Card_Status.BackColor = Color.Transparent
            Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_Format)
        End If
    End Sub

    Private Sub Undo_Redeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Undo_Redeem.Click
        Try
            If history.Count > 0 Then
                'MsgBox(history((history.Count - 1)).ToString() & " @ " & PBC_Status.SelectedIndex)
                Master_SheetTableAdapter.Update_PBC(Now(), Main.Gen.AdminName, PBC_Status.SelectedIndex, Card_ID.Text)
                Card_Status.Text = "Undo of " & history(history.Count - 1) & Chr(13) & "Successful"
                Card_Status.BackColor = Main.Gen.CSUC
                history.RemoveAt(history.Count - 1)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.PBC_RED_Suc)
            Else
                Card_Status.Text = "Cannot Undo" & Chr(13) & "Further"
                Card_Status.BackColor = Main.Gen.CERR
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

End Class
