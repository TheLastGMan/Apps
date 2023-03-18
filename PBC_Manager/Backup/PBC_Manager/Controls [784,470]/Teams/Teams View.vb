Public Class Teams_View

    Private Sub Teams_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        League_Grid.Columns.Add("Team_ID", "Team ID")
        League_Grid.Columns("Team_ID").Width = 100
        League_Grid.Columns.Add("League Name", "League Name")
        League_Grid.Columns("League Name").Width = 250
        League_Grid.Columns.Add("Team Name", "Team Name")
        League_Grid.Columns("Team Name").Width = 249
        Fill_Team()
    End Sub

    Private Sub Fill_Team()
        Dim TDT As New PBCDataSet.TeamsDataTable
        Dim ID As Integer
        Dim Name As String
        Dim League As String
        Try
            TeamsTableAdapter.Fill(TDT)
            If TDT.Rows.Count > 0 Then
                For i As Short = 0 To TDT.Rows.Count - 1
                    ID = TDT.Rows(i).Item("ID").ToString()
                    Name = TDT.Rows(i).Item("League Name").ToString()
                    League = TDT.Rows(i).Item("Team Name").ToString()
                    League_Grid.Rows.Add(ID, Name, League)
                Next
                Main.Gen.get_err_msg(General_Functions.Error_Codes.Team_Load_Suc)
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_Team_Exist)
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub
End Class
