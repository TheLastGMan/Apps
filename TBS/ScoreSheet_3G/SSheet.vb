Imports TBDB
Public Class SSheet

    Private Scores_Data As New TGS.ThreeGameDataTable

    Private Sub SSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeHeaderText("3 Game ScoreSheet")
        Load_Proc()
    End Sub

    Private Sub Load_Proc()
        'list of loading procedure
        Load_Data()
        Load_Report()
    End Sub

    Private Sub Load_Data()
        Dim data As List(Of TBDB.DB_Structure.Scores_Get_List) = TBDB.DBLnkr.DB_Program.Scores_Get_List(GetWeekId())
        If data.Count = 0 Then
            'no data
            WriteLog("W", "SSheet.Load_Data", "No Scores for week")
        ElseIf data(0)._ERRMsg = Nothing Then
            'data
            Dim i As Integer = 1
            For Each DBS In data
                Dim BN As String = String.Empty
                Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(DBS.Bowler_ID)
                If ret(0) = "-1" Then
                    'error
                    WriteLog("E", "SSheet.Load_Data", "Error Getting Bowler Name: " & ret(1))
                Else
                    'filter out low scores, only show top scores specified for the week
                    WriteLog("S", "SSheet.Load_Data", "Retreived bowler name")
                    If DBS.SUM3 >= GetMinimumScore() Then
                        WriteLog("S", "SSheet.Load_Data", "Score >= " & GetMinimumScore() & " < Inserting")
                        BN = ret(1) & " " & ret(2)
                        Dim ave As String = Math.Round(DBS.SUM3 / GetGamesPerWeek(), 2).ToString
                        'ave = String.Format("xxx.00", ave)
                        Dim games As String() = DBS.Scores.Split(",")
                        Scores_Data.AddThreeGameRow(i.ToString, BN, DBS.SUM3, ave, games(0), games(1), games(2))
                    Else
                        WriteLog("S", "SSheet.Load_Data", "Score < " & GetMinimumScore() & " < Can Not Insert")
                    End If
                End If
                i += 1
            Next
            WriteLog("W", "SSheet.Load_Data", "Loaded data for week id " & GetWeekId())
        Else
            'Error
            WriteLog("E", "SSheet.Load_Data", "Error loading scores for week: " & data(0)._ERRMsg)
        End If
    End Sub

    Private Sub Load_Report()
        'load report
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Reports.ScoreSheet_3G.ScoreSheet3G.rdlc"
        ReportViewer1.LocalReport.DisplayName = "ScoreSheet3G-" & GetWeekName().Replace("/", "_").Replace("\", "_")
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Week", GetLeagueName() & " - " & GetWeekName()))
        Dim DT As DataTable = Scores_Data.Copy
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("WK_SCORES", DT))
        ReportViewer1.RefreshReport()
    End Sub

End Class
