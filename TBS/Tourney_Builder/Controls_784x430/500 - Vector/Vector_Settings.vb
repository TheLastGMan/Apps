Public Class Vector_Settings
    Private chg As Integer = 0

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.FUNC.Change_Header("Scoring Monitor Settings")
        Load_Settings()
        For i As Byte = 0 To Controls.Count - 1
            AddHandler Controls(i).Leave, AddressOf Changed
        Next
        'Load Successfully
        Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Load_OK)
    End Sub

    Private Sub IPAddr_Keydown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles IP1.KeyDown, IP2.KeyDown, IP3.KeyDown, IP4.KeyDown
        If e.KeyCode = Keys.Decimal Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IPAddr_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles IP1.Enter, IP2.Enter, IP3.Enter, IP4.Enter
        SendKeys.Send("{RIGHT}")
        SendKeys.Send("{RIGHT}")
        SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub Load_Settings()
        Try
            'Load Vector Settings From DB
            Main.VDB.DB_Settings_Load()
            SMon.Text = Main.VDB.SMV
            IP1.Value = Main.VDB.IPAddr(0)
            IP2.Value = Main.VDB.IPAddr(1)
            IP3.Value = Main.VDB.IPAddr(2)
            IP4.Value = Main.VDB.IPAddr(3)
            IPPort.Value = Main.VDB.IPPort
            IUSRDb.Text = Main.VDB.IPName
            USRDb.Text = Main.VDB.DBUsrPsw(0)
            USRName.Text = Main.VDB.DBUsrPsw(1)
            USRPassword.Text = Main.VDB.DBUsrPsw(2)
            SSmon.SelectedIndex = Main.VDB.ChkSMon
            Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Set_Load_OK)
        Catch ex As Exception
            Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Set_Load_ERR)
        End Try
    End Sub

    Private Sub Changed(ByVal sender As Object, ByVal e As EventArgs)
        'Save Settings
        Try
            Main.VDB.SMV = SMon.Text
            Main.VDB.IPAddr(0) = IP1.Value
            Main.VDB.IPAddr(1) = IP2.Value
            Main.VDB.IPAddr(2) = IP3.Value
            Main.VDB.IPAddr(3) = IP4.Value
            Main.VDB.IPName = IUSRDb.Text
            Main.VDB.DBUsrPsw(0) = USRDb.Text
            Main.VDB.DBUsrPsw(1) = USRName.Text
            Main.VDB.DBUsrPsw(2) = USRPassword.Text
            Main.VDB.ChkSMon = SSmon.SelectedIndex
            Main.VDB.DB_Settings_Save()
            chg += 1
            Main.Error_Status.Text = "Settings Saved #" & chg & " - [" & Errors.Err_Codes.Vector_Settings_Set_Save_OK & "]"
            Main.Error_Status.BackColor = Main.ERS.OK
        Catch ex As Exception
            Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Set_Save_ERR)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Test Connection
        If Main.VDB.Test_Conn() Then
            MsgBox("Test Connection Successful")
        Else
            MsgBox("Failed Test Connection")
        End If
    End Sub

    Private Sub USRPasswd_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles USRPassword.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(New Point(MousePosition.X, MousePosition.Y))
        End If
    End Sub

    Private showpass As Boolean = False
    Private Sub ContextMenu1_Click(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        If e.ClickedItem.Text.Contains("show") Then
            USRPassword.PasswordChar = ""
        Else
            USRPassword.PasswordChar = "*"
        End If
        ContextMenuStrip1.Items.Clear()
        showpass = Not showpass
        ContextMenuStrip1.Items.Add(IIf(showpass, "hide", "show") & " password")
    End Sub
End Class
