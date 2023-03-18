Public Class Admin_View

    Private Sub Admin_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_Admins()
    End Sub

    Private Sub Fill_Admins()
        Try
            Dim ADT As New PBCDataSet.Admin_UsersDataTable
            Admin_UsersTableAdapter.Fill(ADT)
            Admin_Grid.DataSource = ADT
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Admin_Get_Suc)
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

End Class
