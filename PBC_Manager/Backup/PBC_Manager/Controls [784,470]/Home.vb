Public Class Home

    Private Status() As Short = {0, 0, 0, 0, 0}
    'Status(Regular, No Cost, Refund, Void, Redeemed)'
    Private Prices As New ArrayList
    Private DTS As New PBCDataSet.Master_SheetDataTable

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_League()
        Change_Stats()
    End Sub

    Private Sub Fill_League()
        Try
            Dim LDT As New PBCDataSet.LeagueDataTable
            LeagueTableAdapter.Fill(LDT)
            Prices.Insert(0, "0")
            LeagueBox.Items.Insert(0, "All")
            If LDT.Rows.Count > 0 Then
                For i As Short = 1 To LDT.Rows.Count
                    LeagueBox.Items.Add(LDT.Rows((i - 1)).Item("League_Name"))
                    'Prices(i) = LDT.Rows(i - 1).Item("Cost")
                    Prices.Insert(i, LDT.Rows(i - 1).Item("Cost"))
                Next
                LDT.Clear()
                LeagueBox.SelectedIndex = 1
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League_Exist)
            End If
            LeagueBox.SelectedIndex = 0
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
        End Try
    End Sub

    Private Sub Change_Stats()
        Fill_Status()
        Load_Form()
    End Sub

    Private Sub Fill_Status()
        Status(0) = 0
        Status(1) = 0
        Status(2) = 0
        Status(3) = 0
        Status(4) = 0
        Dim DT As New PBCDataSet.Master_SheetDataTable
        If LeagueBox.Text = "All" Then
            Master_SheetTableAdapter.FillByStatus(DT)
            DTS.Clear()
            Master_SheetTableAdapter.CountTeam(DTS)
        Else
            Master_SheetTableAdapter.FillByStatusLeague(DT, LeagueBox.Text)
            DTS.Clear()
            Master_SheetTableAdapter.CountTeamLeague(DTS, LeagueBox.Text)
        End If
        For i As Short = 0 To DT.Rows.Count - 1
            Status(DT.Rows(i).Item("Status")) += 1
        Next
    End Sub

    Private Sub Load_Form()
        Dim source As String = Main.Gen.Get_Local_Path() & "Reports\PBC_Stats.rdlc"
        'Try

        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportPath = source

        Dim actives As String = Status(General_Functions.PBC_Codes.Regular)
        Dim totals As String = Status(0) + Status(1) + Status(2) + Status(3) + Status(4)
        Dim total As String

        If LeagueBox.Items.Count() > 0 Then
            total = "$" & (Status(0) * Prices(LeagueBox.SelectedIndex)).ToString()
        Else
            total = "$0.00"
        End If
        If Not total.ToString().Contains(".") Then
            total = (total & ".00").ToString()
        End If
        If total.Substring(total.Length - 2).Contains(".") Then
            total &= "0"
        End If

        'Top 5 Team PBC Users
        Dim BSList As String = ""
        For x As SByte = 0 To 4
            'TMC
            Try
                BSList &= DTS.Rows(x).Item("Team") & "|" & DTS.Rows(x).Item("TMC") & "|"
            Catch ex As Exception
                BSList &= "- N/A -|-1|"
            End Try
        Next

        'Status(Regular, No Cost, Refund, Void, Redeemed)'
        Dim a As New ReportParameter("Dollars", total)
        Dim b As New ReportParameter("Active", actives)
        Dim c As New ReportParameter("Total", totals)
        Dim d As New ReportParameter("Redeemed", Status(General_Functions.PBC_Codes.Redeemed))
        Dim e As New ReportParameter("Void", Status(General_Functions.PBC_Codes.Void))
        Dim f As New ReportParameter("Refund", Status(General_Functions.PBC_Codes.Refund))
        Dim g As New ReportParameter("No_Cost", Status(General_Functions.PBC_Codes.No_Cost))
        Dim i As New ReportParameter("Cost", Prices(LeagueBox.SelectedIndex).ToString())
        Dim j As New ReportParameter("BSList", BSList)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {a, b, c, d, e, f, g, i, j})

        ReportViewer1.ProcessingMode = ProcessingMode.Local

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("PBCDataSet_Master_Sheet", DTS))

        ReportViewer1.RefreshReport()
        Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Suc)
        'Catch ex As Exception
        ''Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Fail)
        'End Try
        'End If
    End Sub

    Private Sub LeagueBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeagueBox.SelectedIndexChanged
        Change_Stats()
    End Sub
End Class
