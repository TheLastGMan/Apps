Imports TBDB
Public Class BHistory
    ReadOnly BHist_DT As New BowlHist.HistoryDataTable

    ''' <summary>
    ''' Loads main form, adds list of bowler names to dropdown list
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WriteLog("D", "BHistory.BHistory_Load")
        ChangeHeaderText("Bowler History")
        Load_Bowlers()
    End Sub

    ''' <summary>
    ''' List of bowlers
    ''' </summary>
    ''' <remarks></remarks>
    Private bowler_list As List(Of TBDB.DB_Structure.Bowlers_Get_List)

    ''' <summary>
    ''' Structure for the Score_List complex array
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure Score_List
        ''' <summary>
        ''' List of games to be sorted into groups
        ''' </summary>
        ''' <remarks></remarks>
        Shared games_3_sort As String
        ''' <summary>
        ''' Contains the score array specified in scores_list
        ''' </summary>
        ''' <remarks></remarks>
        Shared scores_list(17) As Integer
        ''' <summary>
        ''' Enum of where the scores are in the scores_list
        ''' </summary>
        ''' <remarks></remarks>
        Enum Scores As Integer
            l100g = 0
            g100g = 1
            g150g = 2
            g175g = 3
            g200g = 4
            g225g = 5
            g250g = 6
            g275g = 7
            l450s = 8
            g450s = 9
            g500s = 10
            g550s = 11
            g600s = 12
            g650s = 13
            g700s = 14
            g750s = 15
            g800s = 16
        End Enum
        ''' <summary>
        ''' sets the specified score in the scores_list(pos)
        ''' </summary>
        ''' <param name="pos">position to store the score</param>
        ''' <param name="score">value to be inserted</param>
        ''' <returns>True</returns>
        ''' <remarks></remarks>
        Shared Function set_score(ByRef pos As Scores, ByRef score As Integer) As Boolean
            scores_list(pos) = score
            Return True
        End Function
        ''' <summary>
        ''' gets the score specified by the pos in scores_list(pos)
        ''' </summary>
        ''' <param name="pos">position in list</param>
        ''' <returns>score in scores_list</returns>
        ''' <remarks></remarks>
        Shared Function get_score(ByRef pos As Scores) As Integer
            Return scores_list(pos)
        End Function
    End Structure

    ''' <summary>
    ''' Parameters for the report
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure Report_Parameters
        ''' <summary>
        ''' Bowler Name
        ''' </summary>
        ''' <remarks></remarks>
        Shared Name As String = String.Empty
        ''' <summary>
        ''' USBC ID
        ''' </summary>
        ''' <remarks></remarks>
        Shared USBC As String = String.Empty
        ''' <summary>
        ''' Total number of Games Bowled
        ''' </summary>
        ''' <remarks></remarks>
        Shared Games As Integer = 0
        ''' <summary>
        ''' Bowler Average
        ''' </summary>
        ''' <remarks></remarks>
        Shared Average As String = String.Empty
        ''' <summary>
        ''' Total Series
        ''' </summary>
        ''' <remarks></remarks>
        Shared Series As Integer = 0
        ''' <summary>
        ''' List of scores in string comma delimeted array
        ''' </summary>
        ''' <remarks></remarks>
        Shared Scores As String = String.Empty
        ''' <summary>
        ''' The Game Header Line, G 1, G 2...
        ''' </summary>
        ''' <remarks></remarks>
        Shared GameStr As String = String.Empty
    End Structure

    ''' <summary>
    ''' Loads bowlers into global variable and bowler_name dropdown
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Load_Bowlers()
        WriteLog("I", "BHistory.Load_Bowlers")
        'clear dropdown list just in case
        Bowler_Name.AutoCompleteCustomSource.Clear()
        'load bowlers into list
        bowler_list = TBDB.DBLnkr.DB_Program.Bowlers_Get_List()
        'sort list into dropdown list
        If bowler_list.Count = 0 Then
            'no data
            WriteLog("W", "BHistory.Load_Bowlers", "No Bowlers Exist")
        ElseIf Not bowler_list(0)._ERRMsg Is Nothing Then
            'error
            WriteLog("E", "BHistory.Load_Bowlers", "Error Loading Bowlers: " & bowler_list(0)._ERRMsg)
        Else
            'data
            WriteLog("S", "BHistory.Load_Bowlers", "Loading Bowlers")
            For Each itm In bowler_list
                Bowler_Name.AutoCompleteCustomSource.Add(itm.FName & " " & itm.LName)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Sorts through the data, fills the datatable and fills the Report_Parameters structure
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Sort_Scores()
        WriteLog("D", "BHistory.Sort_Scores")
        'get bowler id
        Dim bid As New Integer
        Dim name As String() = Bowler_Name.Text.Split(" ")
        Try
            Dim blst As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_ID_by_Name(name(0), name(1))
            If blst.Count = 0 Then
                'no data
                WriteLog("W", "BHistory.Sort_Scores", "Bowler (" & Bowler_Name.Text & ") Not Found")
            ElseIf blst(0).ToString.Length > 16 Then
                'error
                WriteLog("E", "BHistory.Sort_Scores", "Error Finding bowler: " & blst(0))
            Else
                'data - load scores
                WriteLog("S", "BHistory.Sort_Scores", "Loading Scores for Bowler ID: " & bid)
                Dim max_games As Byte = 0
                Dim scores_list As List(Of TBDB.DB_Structure.Scores_By_BID) = TBDB.DBLnkr.DB_Program.Scores_By_BID(blst(0))
                For Each score In scores_list
                    Dim games As String() = score.Scores.TrimEnd(",").Split(",")
                    max_games = IIf(games.Length > max_games, games.Length, max_games)
                    Dim cnt As Byte = 0
                    For Each bscore As Integer In games
                        cnt += 1
                        If cnt <= 3 Then
                            Sort_Game(bscore)
                        End If
                        Score_List.games_3_sort &= "," & bscore
                    Next
                    BHist_DT.AddHistoryRow(Get_Week_Name(score.Week_ID), Set_Scores_String(games), score.AVE, score.SUM4)
                    Report_Parameters.Games += games.Count
                    Report_Parameters.Series += score.SUM3
                    Sort_Series(score.SUM3)
                Next
                'get usbc
                Dim usbca As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(blst(0))
                Report_Parameters.USBC = usbca(3)
                Report_Parameters.Name = Bowler_Name.Text
                Report_Parameters.Average = String.Format(Math.Round(Report_Parameters.Series / Report_Parameters.Games, 2), "XX0.00")
                Report_Parameters.GameStr = Set_Game_Title_String(max_games)
                Report_Parameters.Scores = Compress_Stats()
                'grab scores array
            End If
        Catch ex As Exception
            WriteLog("E", "BHistory.Sort_Scores", ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the weeks name by the id, using the Week_list located in TB.exe (Weeks._WkLst)
    ''' </summary>
    ''' <param name="wk_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_Week_Name(ByRef wk_id As Integer) As String
        Dim week As String = String.Empty
        Dim wkList = GetWeekList()
        For i As Byte = 1 To wkList.Count - 1 Step 2
            If wkList(i) = wk_id Then
                week = wkList(i + 1)
            End If
        Next
        Return week
    End Function

    ''' <summary>
    ''' Sets the scores to be shown under each game
    ''' </summary>
    ''' <param name="scores">array of the scores bowled for the week</param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Private Function Set_Scores_String(ByRef scores() As String) As String
        Dim scs As String = ""
        For Each sc In scores
            scs &= sc.PadLeft(3, " ") & vbTab
        Next
        Return scs.Trim(vbTab)
    End Function

    ''' <summary>
    ''' Formats the title string for the games
    ''' </summary>
    ''' <param name="max_games">maximum number of games bowler played</param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Private Function Set_Game_Title_String(ByRef max_games As Byte) As String
        Dim gmstr As String = String.Empty
        For cnt As Byte = 1 To max_games
            gmstr &= "G" & cnt.ToString.PadLeft(2, " ") & vbTab
        Next
        Return gmstr.Trim(vbTab)
    End Function

    ''' <summary>
    ''' Places the game in the correct spot
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Sort_Game(ByRef game As String)
        Integer.Parse(game)
        If game < 100 Then
            Score_List.scores_list(Score_List.Scores.l100g) += 1
        ElseIf game < 150 Then
            Score_List.scores_list(Score_List.Scores.g100g) += 1
        ElseIf game < 175 Then
            Score_List.scores_list(Score_List.Scores.g150g) += 1
        ElseIf game < 200 Then
            Score_List.scores_list(Score_List.Scores.g175g) += 1
        ElseIf game < 225 Then
            Score_List.scores_list(Score_List.Scores.g200g) += 1
        ElseIf game < 250 Then
            Score_List.scores_list(Score_List.Scores.g225g) += 1
        ElseIf game < 275 Then
            Score_List.scores_list(Score_List.Scores.g250g) += 1
        ElseIf game <= 300 Then
            Score_List.scores_list(Score_List.Scores.g275g) += 1
        End If
    End Sub

    ''' <summary>
    ''' Places the series in the correct spot
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Sort_Series(ByRef series As String)
        Integer.Parse(series)
        If series < 450 Then
            Score_List.scores_list(Score_List.Scores.l450s) += 1
        ElseIf series < 500 Then
            Score_List.scores_list(Score_List.Scores.g450s) += 1
        ElseIf series < 550 Then
            Score_List.scores_list(Score_List.Scores.g500s) += 1
        ElseIf series < 600 Then
            Score_List.scores_list(Score_List.Scores.g550s) += 1
        ElseIf series < 650 Then
            Score_List.scores_list(Score_List.Scores.g600s) += 1
        ElseIf series < 700 Then
            Score_List.scores_list(Score_List.Scores.g650s) += 1
        ElseIf series < 750 Then
            Score_List.scores_list(Score_List.Scores.g700s) += 1
        ElseIf series < 800 Then
            Score_List.scores_list(Score_List.Scores.g750s) += 1
        Else
            Score_List.scores_list(Score_List.Scores.g800s) += 1
        End If
    End Sub

    ''' <summary>
    ''' Loads the report
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Load_Report()
        WriteLog("D", "BHistory.Load_Report")
        'set up and copy over data set for averages
        Dim x As New DataTable("BHist") 'name of table
        With x.Columns
            .Add("Week")
            .Add("Scores")
            .Add("Average")
            .Add("Series")
        End With
        BHist_DT.CopyToDataTable(x, LoadOption.OverwriteChanges)

        'set up report viewer
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Bowler_History.Bowler_History.rdlc"
        Dim rpta As New Microsoft.Reporting.WinForms.ReportParameterCollection
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("Name", GetLeagueName() & " - Stats for " & Report_Parameters.Name)) 'League Name
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("USBC", Report_Parameters.USBC)) 'usbc id
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("Series", Report_Parameters.Series)) 'total series
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("Average", Report_Parameters.Average)) 'average
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("Games", Report_Parameters.Games)) 'total num of games
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("Scores", Report_Parameters.Scores)) 'for 3 game stats
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("GameStr", Report_Parameters.GameStr)) 'text above scores
        ReportViewer1.LocalReport.SetParameters(rpta)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("BHist", x)) 'name of dataset
        ReportViewer1.LocalReport.DisplayName = GetLeagueName() & "_Bowler_Report_" & Report_Parameters.Name.Replace(" ", "_")
        ReportViewer1.RefreshReport()
    End Sub

    ''' <summary>
    ''' Returns the compressed output of the statistics
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Compress_Stats() As String
        Dim out As String = String.Empty
        For Each sc In Score_List.scores_list
            out &= sc & ","
        Next
        Return out.Substring(0, out.Length - 1)
    End Function

    ''' <summary>
    ''' When index is changed, load report
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Bowler_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bowler_Name.SelectedIndexChanged, Bowler_Name.Leave
        Sort_Scores()
        Load_Report()
    End Sub

End Class
