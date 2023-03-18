Public Class Main

    Public Gen As New General_Functions

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		FOOTER.Text = FOOTER.Text.Replace("[NAME]", "Ryan Gau")
		FOOTER.Text = FOOTER.Text.Replace("[VER]", My.Settings.Version)
        MenuStrip1.Visible = False
        Gen.cont = New Login
        PANEL1.Controls.Add(Gen.cont)
        Gen.get_err_msg(General_Functions.Error_Codes.clean)
    End Sub

    'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    'MsgBox("KeyPress")
    'End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'File -> Exit
        Me.Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        'File -> LogOut
        MenuStrip1.Visible = False
        Gen.cont = New Login
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        'File -> BarCode Checker
        Gen.cont = New Settings
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub BarcodeCheckerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeCheckerToolStripMenuItem.Click
        Gen.cont = New BarCode_Checker
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        'League -> Add
        Gen.cont = New League_Add
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        'League -> Remove
        Gen.cont = New League_Remove
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem.Click
        'League -> View
        Gen.cont = New League_View
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub RemoveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem1.Click
        'Team -> Remove
        Gen.cont = New Teams_Remove
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        'Teams -> Add
        Gen.cont = New Teams_Add
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.Click
        'Teams -> View
        Gen.cont = New Teams_View
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub AddToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem2.Click
        'Admins -> Add
        Gen.cont = New Admin_Add
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub RemoveToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem2.Click
        'Admins -> Remove
        Gen.cont = New Admin_Remove
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub ViewToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem2.Click
        'Admins -> View
        Gen.cont = New Admin_View
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        'PBC -> Print Front
        Gen.cont = New PBC_Print_Front
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub ViewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem1.Click
        'PBC -> View List
        Gen.cont = New PBC_View
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub IssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueToolStripMenuItem.Click
        'PBC -> Add
        Gen.cont = New PBC_Add
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub RedeemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedeemToolStripMenuItem.Click
        'PBC -> Redeem
        Gen.cont = New PBC_Redeem
        Gen.Check_Controls(Gen.cont)
    End Sub

    Private Sub SaveLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveLogToolStripMenuItem.Click
        Gen.Save_DB()
    End Sub

    Private Sub DeleteLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteLogToolStripMenuItem.Click
        Delete.show()
    End Sub

    Private Sub OpenLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenLogToolStripMenuItem.Click
        Open.Show()
    End Sub

    Private Sub NewLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewLogToolStripMenuItem.Click
        Gen.New_DB()
    End Sub

    Private Sub RestoreLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreLogToolStripMenuItem.Click
        If MsgBox("Are you sure you want to Restore the Origional DB", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                File.Copy(Gen.Get_Local_Path() & "Database\PBC.org", Gen.Get_Local_Path() & "Database\PBC.accdb", True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem.Click
        Gen.cont = New Home
        Gen.Check_Controls(Gen.cont)
    End Sub
End Class
