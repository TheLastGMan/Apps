Public Class PBC_View

    Private Prices As New ArrayList
    Private Status() As Short = {0, 0, 0, 0, 0}
    Private ds As New PBCDataSet.Master_SheetDataTable

    Private Sub PBC_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Fill_League()
        Load_Form()
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    Private Sub Fill_League()
        LeagueBox.Items.Add("All")
        Prices.Insert(0, "0.00")
        Try
            Dim LDT As New PBCDataSet.LeagueDataTable
            LeagueTableAdapter.Fill(LDT)
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

    Private Sub Fill_Status()
        Status(0) = 0
        Status(1) = 0
        Status(2) = 0
        Status(3) = 0
        Status(4) = 0
        Dim DT As New PBCDataSet.Master_SheetDataTable
        If LeagueBox.SelectedIndex = 0 Then
            Master_SheetTableAdapter.FillByStatus(DT)
        Else
            Master_SheetTableAdapter.FillByStatusLeague(DT, LeagueBox.Text)
        End If

        For i As Short = 0 To DT.Rows.Count - 1
            Status(DT.Rows(i).Item("Status")) += 1
        Next
    End Sub

#Region "Load_Form - CrystalReport"
    'Private Sub Load_Form()
    'If Leagues Then
    'Dim source As String = Main.Gen.Get_Local_Path() & "Reports\PBC_Log.rpt"
    '    Try
    'Dim cryRpt As New ReportDocument
    '        cryRpt.Load(source)
    '
    '    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '    Dim crParameterFieldDefinition As ParameterFieldDefinition
    '    Dim crParameterValues As New ParameterValues
    '    Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '
    '            crParameterDiscreteValue.Value = LeagueBox.Text.ToString()
    '            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
    '            crParameterFieldDefinition = crParameterFieldDefinitions.Item("TeamName")
    '            crParameterValues = crParameterFieldDefinition.CurrentValues
    '
    '            crParameterValues.Clear()
    '            crParameterValues.Add(crParameterDiscreteValue)
    '            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    '
    '            CrystalReportViewer1.ReportSource = cryRpt
    '            CrystalReportViewer1.RefreshReport()
    '        Catch ex As Exception
    '            Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Fail)
    '        End Try
    'End If
    '    End Sub
#End Region

#Region "Load_Form - RDLC"
    Private Sub Load_Form()
        Fill_Status()

        Dim source As String = Main.Gen.Get_Local_Path() & "Reports\PBC_View.rdlc"
        ds.Clear()
        If LeagueBox.SelectedIndex = 0 Then
            Master_SheetTableAdapter.Fill(ds)
        Else
            Master_SheetTableAdapter.FillByLeague(ds, LeagueBox.Text)
        End If

        Try
            ReportViewer1.Reset()
            ReportViewer1.LocalReport.ReportPath = source

            Dim totals As String = Status(0) + Status(1) + Status(2) + Status(3) + Status(4)
            Dim actives As String = Status(General_Functions.PBC_Codes.Regular)
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

            Dim a As New ReportParameter("Active", actives)
            Dim h As New ReportParameter("No_Cost", Status(General_Functions.PBC_Codes.No_Cost))
            Dim b As New ReportParameter("Redeemed", Status(General_Functions.PBC_Codes.Redeemed))
            Dim c As New ReportParameter("Refund", Status(General_Functions.PBC_Codes.Refund))
            Dim d As New ReportParameter("Void", Status(General_Functions.PBC_Codes.Void))
            Dim e As New ReportParameter("Total", totals)
            Dim f As New ReportParameter("Dollars", total)
            Dim g As New ReportParameter("TeamName", LeagueBox.Text)
            Dim i As New ReportParameter("Cost", Prices(LeagueBox.SelectedIndex).ToString())
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {a, b, c, d, e, f, g, h, i})

            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("orderInvoice_orders", ordersTableAdapter.GetData(orderid)))
            ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("PBCDataSet_Master_Sheet", ds))
            ReportViewer1.RefreshReport()
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Suc)
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Fail)
        End Try
        'End If
    End Sub
#End Region

    Private Sub LeagueBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeagueBox.SelectedIndexChanged
        Load_Form()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub
End Class
