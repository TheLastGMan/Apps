Public Class SaveDB

    Private DBpath As String = System.AppDomain.CurrentDomain.BaseDirectory & "DB\"
    Private FileTmp As String()

    Private Sub Delete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Delete_DB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_DB.Click
        If Not DBBox.Text = "MPS" And DBBox.Text.Length > 0 Then
            Try
                DBBox.Text = DBBox.Text.Replace(".", "-")
                IO.File.Copy(DBpath & "MPS.accdb", DBpath & DBBox.Text & ".accdb")
                Main.ERS.Get_Error(Errors.Err_Codes.Save_OK)
                Me.Close()
            Catch ex As Exception
                Main.ERS.Get_Error(Errors.Err_Codes.Save_Chr_WRN)
            End Try
        Else
            Main.ERS.Get_Error(Errors.Err_Codes.Save_ERR)
        End If
    End Sub
End Class