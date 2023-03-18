Public Class Errors

    Public OK As Color = Color.LimeGreen
    Public WRN As Color = Color.Orange
    Public ERR As Color = Color.IndianRed

    Public Shared _OK As Color = Color.LimeGreen
    Public Shared _WRN As Color = Color.Orange
    Public Shared _ERR As Color = Color.IndianRed

    Public Shared Sub Send_Message(ByRef msg As String, ByRef bg_color As Color)
        Main.Error_Status.Text = msg
        Main.Error_Status.BackColor = bg_color
        Main.Refresh()
    End Sub

    ReadOnly Property Get_Color_ERR(ByVal ERR As String)
        Get
            If ERR = "OK" Then
                Return OK
            ElseIf ERR = "WRN" Then
                Return WRN
            Else
                Return ERR
            End If
        End Get
    End Property

    Public Enum Err_Codes As Integer
        '----- File Menu (0-99)
        Main_Load_OK = 0
        File_Restore_OK = 10
        File_Restore_ERR = 11
        File_Save_OK = 12
        File_Save_ERR = 13
        File_New_OK = 14
        File_New_ERR = 15
        '------ Weeks (100-199)
        Weeks_Load_OK = 110
        Weeks_Update_SUC = 111
        Weeks_Update_ERR = 112
        Weeks_Exists_WRN = 113
        Weeks_Added_SUC = 114
        Weeks_Deleted_SUC = 115
        Weeks_Deleted_ERR = 116
        Weeks_Deleted_WRN = 117
        '----- Bowlers (200-299)
        Bowler_History_Load_OK = 210
        '-----
        Bowler_Info_Load_OK = 220
        Bowler_Info_UPD_OK = 221
        Bowler_Info_UPD_ERR = 222
        Bowler_Info_Del_OK = 223
        Bowler_Info_Del_ERR = 224
        '------ Tournament (300-399)
        Tourn_Bowler_Load_OK = 310
        Tourn_Bowler_Week_WRN = 311
        Tourn_Bowler_INFO_WRN = 312
        Tourn_Bowler_UPD_OK = 313
        Tourn_Bowler_UPD_ERR = 314
        Tourn_Bowler_EXIST_WRN = 315
        Tourn_Bowler_EXIST_WK_WRN = 316
        Tourn_Bowler_Delete_OK = 317
        Tourn_Bowler_Delete_ERR = 318
        '----- Change Err
        Tourn_Change_Lane_OK = 320
        Tourn_Change_Lane_ERR = 321
        '-----
        Tourn_Score_Load_OK = 330
        Tourn_Score_NODATA_WRN = 331
        '-----
        Bracket_Load_OK = 340
        Bracket_Update_FAIL = 341
        Bracket_Update_SUCC = 342
        '-----
        Tourn_Edit_Load_OK = 350
        Tourn_Edit_NOWEEK_WRN = 351
        Tourn_Edit_UPD_OK = 352
        Tourn_Edit_UPD_ERR = 353
        Tourn_Edit_Delete_OK = 354
        Tourn_Edit_Delete_ERR = 355
        '----- Reports (400-499)
        Reports_Final_Load_OK = 410
        Reports_Final_NODATA_WRN = 411
        Reports_Averages_Load_OK = 412
        '----- SMon (500-599)
        Vector_Settings_Load_OK = 510
        Vector_Settings_Set_Load_OK = 511
        Vector_Settings_Set_Load_ERR = 512
        Vector_Settings_Set_Save_OK = 513
        Vector_Settings_Set_Save_ERR = 514
        '----- DB_Update (5090-5099)
        DB_Update_OK = 5090
        DB_Update_ERR = 5091
        '----- Debug (5100-5199)
        Debug_Load_OK = 5100
    End Enum

    Public Sub Get_Error(ByRef error_id As Integer)
        Dim out As String
        Dim color As Color

        Select Case error_id
            Case Err_Codes.Tourn_Change_Lane_OK
                out = "Bowler Moved Successfully"
                color = OK
            Case Err_Codes.Tourn_Change_Lane_ERR
                out = "Error Moving Bowler To New Lane"
                color = ERR
            Case Err_Codes.Bowler_Info_Del_ERR
                out = "Error Deleteing Bowler"
                color = ERR
            Case Err_Codes.Bowler_Info_Del_OK
                out = "Bowler Deleted"
                color = OK
            Case Err_Codes.Debug_Load_OK
                out = "Debug Loaded"
                color = OK
            Case Err_Codes.Vector_Settings_Load_OK
                out = "Setting Monitor Loaded"
                color = OK
            Case Err_Codes.Vector_Settings_Set_Load_ERR
                out = "Error Loading Settings"
                color = ERR
            Case Err_Codes.Vector_Settings_Set_Load_OK
                out = "Settings Loaded"
                color = OK
            Case Err_Codes.Vector_Settings_Set_Save_ERR
                out = "Error Saving Settings"
                color = ERR
            Case Err_Codes.Tourn_Edit_Delete_OK
                out = "Tournament Deleted"
                color = OK
            Case Err_Codes.Tourn_Edit_Delete_ERR
                out = "Error Deleteing Tournament"
                color = ERR
            Case Err_Codes.Tourn_Bowler_Delete_OK
                out = "Deleted Bowler From Week"
                color = OK
            Case Err_Codes.Tourn_Bowler_Delete_ERR
                out = "Error Deleteing Bowler From Week"
                color = ERR
            Case Err_Codes.Bowler_Info_Load_OK
                out = "Bowler Information Loaded"
                color = OK
            Case Err_Codes.Bowler_Info_UPD_OK
                out = "Bowler Information Updated"
                color = OK
            Case Err_Codes.Bowler_Info_UPD_ERR
                out = "Error Updating Bowler Information"
                color = ERR
            Case Err_Codes.File_New_OK
                out = "New Season Started"
                color = OK
            Case Err_Codes.File_New_ERR
                out = "Clean File Does Not Exist"
                color = ERR
            Case Err_Codes.File_Save_ERR
                out = "Error Saving File"
                color = ERR
            Case Err_Codes.Tourn_Edit_UPD_OK
                out = "Tournament Updated"
                color = OK
            Case Err_Codes.Tourn_Edit_UPD_ERR
                out = "Could Not Update Tournament DB"
                color = ERR
            Case Err_Codes.Tourn_Edit_Load_OK
                out = "Tournament Loaded OK"
                color = OK
            Case Err_Codes.Tourn_Edit_NOWEEK_WRN
                out = "No Weeks Found"
                color = WRN
            Case Err_Codes.Reports_Final_Load_OK
                out = "Report (Final Averages) Loaded"
                color = OK
            Case Err_Codes.Reports_Final_NODATA_WRN
                out = "No Bowler Scores Found"
                color = WRN
            Case Err_Codes.Reports_Averages_Load_OK
                out = "Report (Averages) Loaded"
                color = OK
            Case Err_Codes.Bowler_History_Load_OK
                out = "Bowler History Loaded"
                color = OK
            Case Err_Codes.Tourn_Score_Load_OK
                out = "Scores Loaded"
                color = OK
            Case Err_Codes.Tourn_Score_NODATA_WRN
                out = "No Scores Found For Week"
                color = WRN
            Case Err_Codes.Tourn_Bowler_EXIST_WK_WRN
                out = "Bowler Exists For Current Week"
                color = WRN
            Case Err_Codes.Tourn_Bowler_EXIST_WRN
                out = "Bowler Exists"
                color = WRN
            Case Err_Codes.Tourn_Bowler_UPD_OK
                out = "Score Updated"
                color = OK
            Case Err_Codes.Tourn_Bowler_UPD_ERR
                out = "Could Not Update Scores DB"
                color = ERR
            Case Err_Codes.Tourn_Bowler_INFO_WRN
                out = "Please Fill Out Required Info"
                color = WRN
            Case Err_Codes.Tourn_Bowler_Week_WRN
                out = "Must Have Week Added"
                color = WRN
            Case Err_Codes.Tourn_Bowler_Load_OK
                out = "Add Bowler Loaded"
                color = OK
            Case Err_Codes.Weeks_Deleted_SUC
                out = "Week Deleted Successfully"
                color = OK
            Case Err_Codes.Weeks_Deleted_ERR
                out = "Could Not Delete Week From DB"
                color = ERR
            Case Err_Codes.Weeks_Exists_WRN
                out = "Week Already Exists"
                color = WRN
            Case Err_Codes.Weeks_Added_SUC
                out = "Week Added Successfully"
                color = OK
            Case Err_Codes.Weeks_Load_OK
                out = "Weeks Loaded"
                color = OK
            Case Err_Codes.Weeks_Update_SUC
                out = "Week Added"
                color = OK
            Case Err_Codes.Weeks_Deleted_WRN
                out = "Can Not Delete The Last Remaining Week"
                color = WRN
            Case Err_Codes.Weeks_Update_ERR
                out = "Could Not Update Weeks DB"
                color = ERR
            Case Err_Codes.Main_Load_OK
                out = "Program Startup"
                color = OK
            Case Err_Codes.Bracket_Load_OK
                out = "Bracket Lineup Loaded"
                color = OK
            Case Err_Codes.Bracket_Update_FAIL
                out = "Could Not Update Bracket DB"
                color = ERR
            Case Err_Codes.Bracket_Update_SUCC
                out = "Bracket Updated"
                color = OK
            Case Else
                out = "Unknown Error"
        End Select

        out &= " - [" & error_id & "]"
        Main.Error_Status.Text = out
    End Sub

    Private Sub Get_Color(ByRef color As Color)
        Select Case color
            Case OK
                Main.Error_Status.BackColor = OK
            Case WRN
                Main.Error_Status.BackColor = WRN
            Case ERR
                Main.Error_Status.BackColor = ERR
        End Select
    End Sub

End Class
