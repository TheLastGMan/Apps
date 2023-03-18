Imports Tourney_Builder
Public Class SSheet

    Private Sub SSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FUNC As New Functions
        FUNC.Change_Header("ScoreSheet")
        Load_Proc()
    End Sub

    Private Scores_Data As New SSheet_Data.SScoresDataTable

    Private Sub Load_Proc()
        'list of loading procedure
        'load data and store in scores_structure
        Dim ins As String = "Unknown"
        If Check_Installed() Then
            ins = "Yes"
            Load_Data()
            Load_Report()
        Else
            ins = "No"
        End If
        Functions.Log_Write("D", "SSheet.Load_Proc", "Report Viewer 2010 Installed = No")
    End Sub

    ''' <summary>
    ''' Checks weather Report Viewer 2010 is installed or not
    ''' </summary>
    ''' <returns>True if Installed, False otherwise</returns>
    ''' <remarks></remarks>
    Private Function Check_Installed() As Boolean
        Dim systype As String = IIf(Environment.Is64BitOperatingSystem, "Wow6432Node\", "")
        Try
            Dim reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\" & systype & "Microsoft\ReportViewer\v10.0", False)
            Dim str As String = reg.GetValue("Install", 0)
            Return str
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Format_Scores(ByRef score As String) As String
        Dim games As String() = score.Split(",")
        score = ""
        For Each gme As String In games
            score &= gme.PadLeft(3, " ") & vbTab
        Next
        Return score.TrimEnd(vbTab)
    End Function

    Private Function Format_Header() As String
        Dim ret As String = ""
        For i As Short = 1 To Weeks._GmsWk
            ret &= "G" & i.ToString.PadLeft(2, " ") & vbTab
        Next
        Return ret.TrimEnd(vbTab)
    End Function

    Private Sub Load_Data()
        Dim data As List(Of TBDB.DB_Structure.Scores_Get_List) = TBDB.DBLnkr.DB_Program.Scores_Get_List(Weeks._WkID)
        If data.Count = 0 Then
            'no data
            Functions.Log_Write("W", "SSheet.Load_Data", "No Scores for week")
        ElseIf data(0)._ERRMsg = Nothing Then
            'data
            Dim i As Integer = 1
            For Each DBS In data
                Dim BN As String = String.Empty
                Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(DBS.Bowler_ID)
                If ret(0) = "-1" Then
                    'error
                    Functions.Log_Write("E", "SSheet.Load_Data", "Error Getting Bowler Name: " & ret(1))
                Else
                    Functions.Log_Write("S", "SSheet.Load_Data", "Retreived bowler name")
                    BN = ret(1) & " " & ret(2)
                    Scores_Data.AddSScoresRow(i, BN, DBS.Scores, DBS.SUM4, DBS.AVE, 0, ret(4))
                End If
                i += 1
            Next
            'loop through and calc +/-
            Dim TopC As Integer = 0
            Try
                TopC = IIf(Scores_Data.Rows.Count < Settings._ITournament.Top_Count, Scores_Data.Rows.Count, Settings._ITournament.Top_Count)
            Catch ex As Exception
                TopC = 1
            End Try
            For i = 1 To Scores_Data.Rows.Count
                Scores_Data.Rows(i - 1).Item("PM") = Scores_Data.Rows(i - 1).Item("SUM_Max") - Scores_Data.Rows(TopC - 1).Item("SUM_Max")
            Next
            Functions.Log_Write("W", "SSheet.Load_Data", "Loaded data for week id " & Weeks._WkID)
        Else
            'Error
            Functions.Log_Write("E", "SSheet.Load_Data", "Error loading scores for week: " & data(0)._ERRMsg)
        End If
    End Sub

    Public Sub Correct_Scores()
        For Each row As DataRow In Scores_Data.Rows
            row.Item("Scores") = Format_Scores(row.Item("Scores"))
        Next
    End Sub

    Private Structure HS_Template
        Public Name As String
        Public Game As Short
        Public Score As Short
    End Structure

    Private Function Get_High_Score(ByRef sex As Char) As String
        Dim RET As New HS_Template
        RET.Name = "N/A"
        RET.Game = 0
        RET.Score = 0
        For Each row As DataRow In Scores_Data.Rows
            If row.Item("Sex") = sex Then
                'take into account
                Dim scores As String() = row.Item("Scores").ToString.TrimEnd(",").Split(",")
                For i As Integer = 1 To scores.Length
                    If Short.Parse(scores(i - 1)) > RET.Score Then
                        'higher score
                        RET.Score = Short.Parse(scores(i - 1))
                        RET.Game = i
                        RET.Name = row.Item("BowlerName")
                    End If
                Next
            End If
        Next
        Return RET.Name & " (G" & RET.Game.ToString.PadLeft(2, "0") & ") = " & RET.Score
    End Function

    Private Sub Load_Report()
        'load report
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Tourney_Builder.ScoreSheet.rdlc"
        ReportViewer1.LocalReport.DisplayName = "ScoreSheet-" & Weeks._WkNM.Replace("/", "_").Replace("\", "_")
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Field_Header", Format_Header()))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Week", Settings.Get_League_Name() & " - " & Weeks._WkNM))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("HS_M", Get_High_Score("M")))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("HS_F", Get_High_Score("F")))
        '>got high scores, now correct them
        'correct scores before output
        Correct_Scores()
        '>---------------<
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("TopC", Settings._ITournament.Top_Count))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Data", Format_Header()))
        Dim DT As DataTable = Scores_Data.Copy
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", DT))
        ReportViewer1.RefreshReport()
    End Sub

End Class
