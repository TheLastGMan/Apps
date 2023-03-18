Public Class League_View

    Private Sub League_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_League()
    End Sub

    Private Sub Fill_League()
        Dim LDT As New PBCDataSet.LeagueDataTable
        'Dim ID As Integer
        'Dim Name As String
        'Dim Cost As String
        Try
            LeagueTableAdapter.Fill(LDT)
            If LDT.Rows.Count > 0 Then
                League_Grid.DataSource = LDT
                ' For i As Short = 0 To LDT.Rows.Count - 1
                ' ID = LDT.Rows(i).Item("ID").ToString()
                'Name = LDT.Rows(i).Item("League_Name").ToString()
                'Cost = LDT.Rows(i).Item("Cost").ToString()
                'Cost = "$" & Cost.Substring(0, 2) & "." & Cost.Substring(2, 2)
                'League_Grid.Rows.Add(ID, Name, Cost)
                'Next
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

End Class
