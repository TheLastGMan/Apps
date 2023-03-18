Public Class Admin_Remove

    Private Sub Admin_Remove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Admin()
    End Sub

    Private Sub Fill_Admin()
        Try
            Dim LDT As New PBCDataSet.Admin_UsersDataTable
            Admin_UsersTableAdapter.Fill(LDT)
            For i As Short = 1 To LDT.Rows.Count
                AdminBox.Items.Add(LDT.Rows((i - 1)).Item("Full Name"))
            Next
            LDT.Clear()
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Remove_Admin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_Admin.Click
        Dim MB As String = Main.Admin_Name.Text
        If Not MB.Substring(7, MB.Length - 7) = AdminBox.Text Then
            'MsgBox("No Admin Exists")
            Try
                Admin_UsersTableAdapter.Delete_Admin(AdminBox.Text)
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Admin_Rem_Suc)
                AdminBox.Items.Clear()
                AdminBox.ResetText()
                Fill_Admin()
            Catch ex As Exception
                Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            End Try
        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Admin_Rem_Fail)
        End If
    End Sub
End Class
