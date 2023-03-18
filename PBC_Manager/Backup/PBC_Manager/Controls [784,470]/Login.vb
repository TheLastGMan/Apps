Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        check_DB()
        Try
            File.SetAttributes(Main.Gen.Get_Local_Path() & "Database\PBC.org", FileAttributes.Hidden + FileAttributes.ReadOnly)
            File.SetAttributes(Main.Gen.Get_Local_Path() & "DataBase\aORG.accdb", FileAttributes.ReadOnly)
            File.SetAttributes(Main.Gen.Get_Local_Path() & "DataBase\PBC.accdb", FileAttributes.Directory)
        Catch ex As Exception

        End Try
        Main.Gen.cont = New Keyboard
        Main.Gen.TextName = "PASSWORD"
        Panel1.Controls.Add(Main.Gen.cont)
        Check_AutoLogon()
        PASSWORD.Focus()
    End Sub

    Private Sub check_DB()
        If Not File.Exists(Main.Gen.Get_Local_Path() & "DataBase\PBC.accdb") Then
            Try
                File.Copy(Main.Gen.Get_Local_Path() & "DataBase\aORG.accdb", Main.Gen.Get_Local_Path() & "DataBase\PBC.accdb", True)
                check_DB()
            Catch ex As Exception
                MsgBox("File PBC.accdb can not be Found, Please Reinstall Program", MsgBoxStyle.OkOnly, "ERROR!!!")
                Main.Close()
            End Try
        End If
    End Sub

    Private Sub SUBMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBMIT.Click
        Check_Admin()
    End Sub

    Private Sub Check_AutoLogon()
        ''MsgBox(My.Settings.AutoLogonTF & "-" & My.Settings.AutoLogon)
        If My.Settings.AutoLogonTF Then
            PASSWORD.Text = My.Settings.AutoLogon
            Check_Admin()
        End If
    End Sub


    Private Sub Check_Admin()
        ''MsgBox(PASSWORD.Text)
        Dim Enc As New Encryption
        Dim asc As New ASCIIEncoding
        ''MsgBox(asc.GetString(Enc.Encrypt(PASSWORD.Text)).Length)
        'PASSWORD.PasswordChar = ""
        'PASSWORD.Text = asc.GetString(Enc.Encrypt(PASSWORD.Text))
        Dim pass = asc.GetString(Enc.Encrypt(PASSWORD.Text))

        If check_pass(pass) Then
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Login_Success)
            Main.MenuStrip1.Visible = True
            Main.Gen.cont = New Home
            Main.Gen.Check_Controls(Main.Gen.cont)
        Else
            PASSWORD.ResetText()
            PASSWORD.Focus.Equals(True)
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Admin)
        End If
    End Sub

    Private Function check_pass(ByVal pass As String)
        Try
            Dim ADT As New PBCDataSet.Admin_UsersDataTable
            Admin_UsersTableAdapter.Check_Admin(ADT, pass)
            If ADT.Rows.Count > 0 Then
                Main.Gen.AdminName = ADT.Rows(0).Item("Full Name")
                Main.Admin_Name.Text = "User : " & ADT.Rows(0).Item("Full Name")
                Main.Gen.AdminRW = ADT.Rows(0).Item("Change_Stats")
                ADT.Dispose()
                Return True
            Else
                ADT.Dispose()
                Return False
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            Return False
        End Try
    End Function

    Private Sub PASSWORD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PASSWORD.KeyDown
        If e.KeyCode = Keys.Enter Then
            Check_Admin()
        End If
    End Sub

End Class
