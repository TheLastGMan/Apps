Public Class Admin_Add

    Private Sub Admin_Add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        check_changes()
        AdminTF.SelectedIndex = 1
    End Sub

    Private Sub check_changes()
        If Main.Gen.AdminRW Then
            Main.Gen.TextName = Name_Box.Name
            Name_Box.Enabled = True
            Name_Box.Focus()
            AdminTF.Enabled = True
            Pass1.Enabled = True
            Pass2.Enabled = True
        Else
            Name_Box.Enabled = False
            AdminTF.Enabled = False
            Pass1.Enabled = False
            Pass2.Enabled = False
        End If

    End Sub

    Private Sub Name_Box_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Name_Box.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Pass1.Focus()
        End If
    End Sub

    Private Sub Name_Box_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name_Box.Enter
        Main.Gen.TextName = Name_Box.Name
        'Name_Box.Focus()
        KeyboardForm.Focus()
    End Sub

    Private Sub Pass1_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pass1.Enter
        Main.Gen.TextName = Pass1.Name
        'Name_Box.Focus()
        KeyboardForm.Focus()
    End Sub

    Private Sub Pass1_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Pass1.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Pass2.Focus()
        End If
    End Sub

    Private Sub Pass2_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pass2.Enter
        Main.Gen.TextName = Pass2.Name
        'Name_Box.Focus()
        KeyboardForm.Focus()
    End Sub

    Private Sub Pass2_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Pass2.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Add_Admin.Focus()
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

    Private Sub Add_Admin_Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Add_Admin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Add_Admins()
        End If
    End Sub

    Private Sub Add_Admin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_Admin.Click
        Add_Admins()
    End Sub

    Private Sub Add_Admins()
        If Name_Box.Text.Length >= 3 And (Pass1.Text = Pass2.Text) Then
            If Check_Admin() Then
                'Try
                Dim Enc As New Encryption
                Dim asc As New ASCIIEncoding
                Dim pass = asc.GetString(Enc.Encrypt(Pass1.Text))
                Dim atf As Boolean = IIf(AdminTF.SelectedIndex = 0, True, False)
                Admin_UsersTableAdapter.Insert_Admin(Name_Box.Text, pass, AdminTF.Text)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Admin_Add_Suc)
                Name_Box.ResetText()
                Pass1.Text = ""
                Pass2.Text = ""
                Name_Box.Focus()
                Admin_UsersTableAdapter.Dispose()
                'Catch ex As Exception
                'Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
                'End Try
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Admin_Exist)
                Name_Box.Focus()
            End If
        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Admins)
            Name_Box.Focus()
        End If
    End Sub

    Private Function Check_Admin()
        Try
            Dim ADT As New PBCDataSet.Admin_UsersDataTable
            QueriesTableAdapter.Check_Admin(Name_Box.Text)
            If ADT.Rows.Count > 0 Then
                ADT.Dispose()
                Return False
            Else
                ADT.Dispose()
                Return True
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            Return False
        End Try
    End Function

End Class
