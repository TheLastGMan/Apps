Public Class Scores

    Private WkID As Integer = Weeks._WkID
    'Private SCORES As New TBDataSet.ScoresDataTable
    'Private HSM As New TBDataSet.ScoresDataTable
    'Private HSF As New TBDataSet.ScoresDataTable
    Private GAMES As Byte = Weeks._GmsWk
    Private HS As String() = {"No Data", "-", 0, "No Data", "-", 0}

    Private Sub Scores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Functions.Log_Write("I", "Scores.Scores_Load")
        Main.FUNC.Change_Header("Scores For (" & Weeks._WkNM & ")")
        'Load Scores
        Load_Scores()
        'Load High Games
        Load_High_Games()
        'Adjust Placement
        Load_Placements()
        Functions.Log_Write("I", "Scores.Scores_Load", "Scores loaded")
    End Sub

    Private Sub Load_High_Games()
        Functions.Log_Write("I", "Scores.Load_High_Games")
        'Scores, FName, LName
        'Format => Name - G2 (Score)
        Load_High_Scores("M")
        HS_Men.Text = HS_Format.Bowler & " - G" & HS_Format.Game & " (" & HS_Format.Score & ")"
        Load_High_Scores("F")
        HS_Women.Text = HS_Format.Bowler & " - G" & HS_Format.Game & " (" & HS_Format.Score & ")"
    End Sub

    Structure HS_Format
        Public Shared Bowler As String
        Public Shared Score As Short
        Public Shared Game As Short
    End Structure

    Public Sub Load_High_Scores(ByRef sex As String)
        HS_Format.Bowler = "No Data"
        HS_Format.Game = 0
        HS_Format.Score = 0
        Dim HSM As List(Of TBDB.DB_Structure.Scores_By_Sex_Week) = TBDB.DBLnkr.DB_Program.Scores_By_Sex_Week(sex, WkID)
        If HSM.Count = 0 Then
            'no data
            Functions.Log_Write("W", "Scores.Load_High_Games", "no data for (" & sex & ") high scores")
        ElseIf HSM.Count = 1 Then
            'error
            HS_Format.Bowler = "N/A"
            Functions.Log_Write("E", "Scores.Load_High_Games", "error loading (" & sex & ") high scores")
        Else
            'no error
            Functions.Log_Write("S", "Scores.Load_High_Games", "loaded data for (" & sex & ") high scores")
            For Each i In HSM
                Dim sc As String() = i.Scores.Split(",")
                For j As Byte = 1 To Weeks._GmsWk
                    If sc(j - 1) > HS_Format.Score Then
                        HS_Format.Bowler = i.Name
                        HS_Format.Score = sc(j - 1)
                        HS_Format.Game = j
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub Load_Scores()
        'Load Scores From DB
        '--Bowler_ID, Scores, SUM4, AVE, SUM3
        BS.Columns(3).HeaderText = "Series 3G/" & GAMES & "G"

        For i As Byte = 1 To GAMES
            BS.Columns.Add("G" & i, "G" & i)
            BS.Columns(BS.Columns.Count - 1).Width = 75
        Next

        'Main.DB.SCORA.Get_Scores_Week(SCORES, WkID)
        'Insert Into Table
        'If SCORES.Rows.Count > 0 Then
        Fill_Scores()
        'Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Score_Load_OK)
        'Else
        'Add Row - No Data
        'Dim ins As String = "X,No Data,-,-,-,"
        'For i As Byte = 1 To GAMES
        'ins &= "-,"
        'Next
        'BS.Rows.Add(ins.Split(","))
        'THROW ERROR - No Data
        'Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Score_NODATA_WRN)
        'End If
    End Sub

    Private Function Get_Bowler_Name(ByVal id As Integer)
        Dim name As String = ""
        Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(id)
        If ret.Count = 0 Then
            'no data
            Functions.Log_Write("W", "Scores.Get_Bowler_Name", "bowler data does not exists or id (" & id & ")")
        ElseIf ret(0).ToString.Length < 16 Then
            'bowler found
            name = ret(1) & " " & ret(2)
            Functions.Log_Write("S", "Edit_Tournament.Get_Bowler_Name", "Retreived bowler name (" & name & ")")
        Else
            Functions.Log_Write("E", "Edit_Tournament.Get_Bowler_Name", "could not load bowler name: " & ret(0))
        End If
        Return name
    End Function

    Private Sub Fill_Scores()
        'get scores
        BS.Rows.Clear()
        Dim Score_tmp As List(Of TBDB.DB_Structure.Scores_Get_List) = TBDB.DBLnkr.DB_Program.Scores_Get_List(Weeks._WkID)
        If Score_tmp.Count = 0 Then
            'No Data
            Functions.Log_Write("W", "Scores.Fill_Scores", "No Scores Found")
        ElseIf Score_tmp(0)._ERRMsg = Nothing Then
            'Data
            Dim cnt As Integer = 1
            For Each DBS In Score_tmp
                Dim lst As String = String.Empty
                lst = cnt & ","
                lst &= Get_Bowler_Name(DBS.Bowler_ID) & ","
                lst &= "0,"
                lst &= DBS.SUM3 & " / " & DBS.SUM4 & ","
                lst &= DBS.AVE & ","
                lst &= DBS.Scores
                BS.Rows.Add(lst.Split(","))
                cnt += 1
            Next
        Else
            'Error
            Functions.Log_Write("E", "Scores.Fill_Scores", "error grabbing scores: " & Score_tmp(0)._ERRMsg)
        End If
    End Sub

    Private Sub Load_Placements()
        Functions.Log_Write("I", "Scores.Load_Placements")
        'load +/- in grid
        Dim top As Short = Settings._ITournament.Top_Count
        'top count position
        top = IIf(BS.Rows.Count < top, BS.Rows.Count, top)

        'set top placement series value
        If BS.Rows.Count > 0 Then
            Dim series As String = BS.Rows(top - 1).Cells("Series4").Value.ToString
            Dim seriex As String() = series.Split(" / ")
            Dim tops As Integer = seriex(2)

            For i As Byte = 1 To BS.Rows.Count
                Try
                    Dim sc As String = BS.Rows(i - 1).Cells("Series4").Value
                    Dim scx As String() = sc.Split(" / ")
                    Dim val As Integer = scx(2)
                    BS.Rows(i - 1).Cells("AboveBelow").Value = Integer.Parse(val - tops)
                    Dim pref As String = String.Empty
                    If Integer.Parse(BS.Rows(i - 1).Cells("AboveBelow").Value) > 0 Then
                        pref = "+"
                    End If
                    BS.Rows(i - 1).Cells("AboveBelow").Value = pref & BS.Rows(i - 1).Cells("AboveBelow").Value
                    Functions.Log_Write("S", "Scores.Load_Placements", "Adjusted +/- for row id(" & i - 1 & ")")
                Catch ex As Exception
                    Functions.Log_Write("E", "Scores.Load_Placements", "Integer Parse Error or row id (" & i - 1 & "): " & ex.Message)
                End Try
            Next
        End If
    End Sub

End Class
