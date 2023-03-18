Public Class Errors

    Private OK As Color = Color.LimeGreen
    Private WRN As Color = Color.Orange
    Private ERR As Color = Color.IndianRed

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

    Public Enum Err_Codes As Short
        Main_Load_OK = 0
        '------
        Drill_Load_OK = 100
        Drill_Bowler_Add_ERR = 101
        Drill_DB_Load_ERR = 102
        Drill_DB_Load_OK = 103
        Drill_Ins_OK = 104
        Drill_Ins_ERR = 105
        '-
        Drill_REQ_Name = 110
        Drill_REQ_Street = 111
        Drill_INV_State = 112
        Drill_INV_Zip = 113
        Drill_INV_Num = 114
        '------
        Settings_Load_OK = 200
        Settings_Save_OK = 201
        Settings_Save_ERR = 202
        '------
        Edit_User_Load_OK = 300
        Edit_User_Save_OK = 301
        Edit_User_Save_ERR = 302
        Edit_User_BName_WRN = 303
        Edit_User_Exist_WRN = 304
        '------
        Print_NOFID_WRN
        '------
        Save_OK = 51
        Save_ERR = 52
        Save_Chr_WRN = 53
        '------
        Restore_OK = 61
        Restore_ERR = 62
        '------ Easter Eggs
        ZZ_Programmer = 3141
        ZZ_Pro_Shop = 3142
    End Enum

    Public Sub Get_Error(ByVal error_id As Integer)
        Dim out As String
        Dim color As Color

        Select Case error_id
            Case Err_Codes.Print_NOFID_WRN
                out = "Drilling Sheet Must Be Selected"
                color = WRN
            Case Err_Codes.Edit_User_Exist_WRN
                out = "Customer Already Exists"
                color = WRN
            Case Err_Codes.Edit_User_BName_WRN
                out = "Customer Name Must Not Be Empty"
                color = WRN
            Case Err_Codes.Edit_User_Load_OK
                out = "User Loaded"
                color = OK
            Case Err_Codes.Edit_User_Save_ERR
                out = "Error Updating User"
                color = ERR
            Case Err_Codes.Edit_User_Save_OK
                out = "User Updated"
                color = OK
            Case Err_Codes.ZZ_Pro_Shop
                out = "Meet Your Pro Shop Man 2010"
                color = Main.FUNC.silver
            Case Err_Codes.ZZ_Programmer
                out = "Meet Your Programmer - Ryan Gau 2010"
                color = Main.FUNC.gold
            Case Err_Codes.Drill_REQ_Name
                out = "Name Required"
                color = WRN
            Case Err_Codes.Drill_REQ_Street
                out = "Street Required"
                color = WRN
            Case Err_Codes.Drill_INV_Num
                out = "Invalid Number"
                color = WRN
            Case Err_Codes.Drill_INV_State
                out = "Invalid State"
                color = WRN
            Case Err_Codes.Drill_INV_Zip
                out = "Invalid Zip"
                color = WRN
            Case Err_Codes.Settings_Load_OK
                out = "Setting Loaded"
                color = OK
            Case Err_Codes.Settings_Save_ERR
                out = "Settings Saved"
                color = OK
            Case Err_Codes.Settings_Save_OK
                out = "Error Saving Settings"
                color = ERR
            Case Err_Codes.Drill_Ins_ERR
                out = "Insertion Error"
                color = ERR
            Case Err_Codes.Drill_Ins_OK
                out = "Insertion Successful"
                color = OK
            Case Err_Codes.Save_OK
                out = "DB Saved"
                color = OK
            Case Err_Codes.Save_ERR
                out = "Error Saving DB"
                color = ERR
            Case Err_Codes.Save_Chr_WRN
                out = "Invalid Characters"
                color = WRN
            Case Err_Codes.Restore_ERR
                out = "Error Restoring DB"
                color = WRN
            Case Err_Codes.Restore_OK
                out = "Restored DB"
                color = OK
            Case Err_Codes.Drill_DB_Load_OK
                out = "Sheet Loaded"
                color = OK
            Case Err_Codes.Drill_DB_Load_ERR
                out = "Error Loading Drilling Sheet"
                color = ERR
            Case Err_Codes.Drill_Bowler_Add_ERR
                out = "Error Adding Bowler"
                color = ERR
            Case Err_Codes.Drill_Load_OK
                out = "Drilling Page Loaded"
                color = OK
            Case Err_Codes.Main_Load_OK
                out = "Program Startup"
                color = OK
            Case Else
                out = "Unknown Error"
                color = ERR
                error_id = 999
        End Select

        out &= " - [" & error_id & "]"
        Main.Error_Status.Text = out

        Get_Color(color)
    End Sub

    Private Sub Get_Color(ByVal color As Color)
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
