Public Class Settings

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        AutoLogon.SelectedIndex = 1
        Try
            BarCode_ID.Text = My.Settings.Prod_Code
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Setting_Load_Suc)
            check_AutoLogon()
            check_RW()
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Setting_Load_Fail)
        End Try
        Fill_League()
    End Sub

    Private Sub check_AutoLogon()
        If Main.Gen.AdminRW Then
            League_Grid.Enabled = True
        Else
            League_Grid.Enabled = False
        End If
        AutoLogonText.Text = My.Settings.AutoLogon
    End Sub

    Private Sub check_RW()
        If My.Settings.AutoLogonTF Then
            AutoLogon.SelectedIndex = 0
            AutoLogonText.Enabled = True
        Else
            AutoLogon.SelectedIndex = 1
            AutoLogonText.Enabled = False
        End If
        If Not Main.Gen.AdminRW Then
            AutoLogon.Enabled = False
        End If
    End Sub

    Private Sub AutoLogon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoLogon.SelectedIndexChanged
        If AutoLogon.SelectedIndex = 0 Then
            AutoLogonText.Enabled = True
            My.Settings.AutoLogonTF = True
        Else
            AutoLogonText.Enabled = False
            My.Settings.AutoLogonTF = False
        End If
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
                'For i As Short = 0 To LDT.Rows.Count - 1
                'ID = LDT.Rows(i).Item("ID").ToString()
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



    Private Sub Remove_Team_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_Team.Click
        Try
            My.Settings.Prod_Code = Get_Barcode(BarCode_ID.Value)
            My.Settings.AutoLogon = AutoLogonText.Text
            Sets_League_Grid()
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Setting_Save_Suc)
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Setting_Save_Fail)
        End Try
    End Sub

    Private Function Get_Barcode(ByVal num As Short)
        Dim nums As Short = num
        If BarCode_ID.Value < 10 Then
            nums = "000" & num
        ElseIf BarCode_ID.Value < 100 Then
            nums = "00" & num
        ElseIf BarCode_ID.Value < 1000 Then
            nums = "0" & num
        Else
            nums = BarCode_ID.Value
        End If
        Return nums
    End Function

    Private Sub Sets_League_Grid()
        Dim ID As Integer
        Dim LN As String
        Dim CT As String
        If League_Grid.Rows.Count > 0 Then
            For i As Short = 0 To League_Grid.Rows.Count - 1
                ID = League_Grid.Rows(i).Cells("ID").Value.ToString
                LN = League_Grid.Rows(i).Cells("League_Name").Value.ToString
                CT = League_Grid.Rows(i).Cells("Cost").Value.ToString
                'MsgBox(ID & "-" & LN & "-" & CT)
                'MsgBox(LeagueTableAdapter.UpdateLeague(ID, LN, CT))
                LeagueTableAdapter.UpdateLeague(LN, CT, ID)
            Next
        Else

        End If
    End Sub

End Class
