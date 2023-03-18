Imports Microsoft.Reporting.WinForms

Public Class PrintControl : Implements IBaseUC

    Public Event ClearErr() Implements IBaseUC.ClearErr
    Public Event RaiseErr(ByRef msg As String) Implements IBaseUC.RaiseErr

    Private Sub PrintControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub SetData(ByRef people As List(Of MatchPair))
        Dim rds As New ReportDataSource("MatchedPair", people)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.RefreshReport()
    End Sub

End Class
