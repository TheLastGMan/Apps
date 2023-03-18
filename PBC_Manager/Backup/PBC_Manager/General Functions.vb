Public Class General_Functions

    Public cont As Control
    Public TextName As String
    Public AdminRW As Boolean 'Admin can Change
    Public AdminName As String 'Admin Name
    Public CERR As Color = Color.IndianRed
    Public CSUC As Color = Color.LightGreen
    Public CWRN As Color = Color.Orange

    Public Sub Check_Controls(ByVal cont As Control)
        If Not Main.PANEL1.Controls(0).Name = cont.Name Or Main.PANEL1.Controls(0).Name = "Home" Then
            Main.PANEL1.Controls(0).Dispose()
            Main.PANEL1.Controls.Clear()
            Main.PANEL1.Controls.Add(cont)
        End If
    End Sub

    Public Function Get_Local_Path()
        Return My.Application.Info.DirectoryPath & "\"
    End Function

    Public Sub Change_Header(ByVal str As String)
        Main.HEADER.Text = "PBC - " & str.Replace("_", " ")
    End Sub

    Public Enum PBC_Codes As SByte
        Regular = 0
        No_Cost = 1
        Refund = 2
        Void = 3
        Redeemed = 4
    End Enum

    Public Function Get_PBC_Int(ByVal str As String)
        'MsgBox(str)
        Select Case str
            Case "Regular"
                Return PBC_Codes.Regular
            Case "No Cost"
                Return PBC_Codes.No_Cost
            Case "Refund"
                Return PBC_Codes.Refund
            Case "Void"
                Return PBC_Codes.Void
            Case Else
                Return PBC_Codes.Redeemed
        End Select
    End Function

    Public Enum Error_Codes As Short
        clean = 0
        DB_Con_Err = 200

        Login_Success = 400

        League_Add_Suc = 410
        League_Rem_Suc = 411

        Team_Add_Suc = 420
        Team_Load_Suc = 421
        Team_Rem_Suc = 422

        Admin_Add_Suc = 430
        Admin_Get_Suc = 431
        Admin_Rem_Suc = 432

        Setting_Load_Suc = 440
        Setting_Save_Suc = 441

        Report_Load_Suc = 450

        PBC_Add_Suc = 460
        PBC_RED_Suc = 461
        '--------------------------------------------------
        No_League = 510
        No_League_Exist = 511
        League_Exists = 512

        No_Team = 520
        No_Team_Exist = 521
        Team_Exists = 522

        No_Admin = 530
        No_Admins = 531
        Admin_Exist = 532
        Admin_Rem_Fail = 534

        Setting_Load_Fail = 540
        Setting_Save_Fail = 541

        Report_Load_Fail = 550

        PBC_TL_ERROR = 560
        PBC_Format = 561

        No_KeyB = 590
        No_Rows = 591
        No_BC = 592
    End Enum

    Public Sub get_err_msg(ByVal err As Short)
        Dim msg As String = String.Empty
        Dim color As Color = Control.DefaultBackColor
        Select Case err
            Case Error_Codes.clean
                msg = "Welcome"
            Case Error_Codes.DB_Con_Err
                msg = "Could Not Connect To DataBase"
                color = CERR
            Case Error_Codes.No_Admin
                msg = "Invalid Admin ID"
                color = CWRN
            Case Error_Codes.No_KeyB
                msg = "No Valid Input Field"
                color = CWRN
            Case Error_Codes.No_BC
                msg = "Invalid Barcode"
                color = CWRN
            Case Error_Codes.No_League
                msg = "Invalid League Format"
                color = CWRN
            Case Error_Codes.No_League_Exist
                msg = "No Leagues Exists"
                color = CWRN
            Case Error_Codes.No_Team
                msg = "Invalid Team Format"
                color = CWRN
            Case Error_Codes.No_Team_Exist
                msg = "No Teams Exist"
                color = CWRN
            Case Error_Codes.No_Admins
                msg = "Please Check Name and Passwords"
                color = CWRN
            Case Error_Codes.No_Rows
                msg = "No Rows Exists"
                color = CWRN
            Case Error_Codes.League_Add_Suc
                msg = "League Added Successfully"
                color = CSUC
            Case Error_Codes.Team_Add_Suc
                msg = "Team Added Successfully"
                color = CSUC
            Case Error_Codes.Admin_Add_Suc
                msg = "Admin Added Successfully"
                color = CSUC
            Case Error_Codes.Login_Success
                msg = "Login Successful"
                color = CSUC
            Case Error_Codes.League_Rem_Suc
                msg = "League Remove Successfully"
                color = CSUC
            Case Error_Codes.Team_Exists
                msg = "Team Already Exists"
                color = CWRN
            Case Error_Codes.League_Exists
                msg = "League Already Exists"
                color = CWRN
            Case Error_Codes.Setting_Load_Fail
                msg = "Setting Load Failed"
                color = CWRN
            Case Error_Codes.Setting_Load_Suc
                msg = "Settings Loaded Successfully"
                color = CSUC
            Case Error_Codes.Setting_Save_Fail
                msg = "Settings Save Failed"
                color = CWRN
            Case Error_Codes.Setting_Save_Suc
                msg = "Settings Saved Successfully"
                color = CSUC
            Case Error_Codes.Team_Load_Suc
                msg = "Teams Loaded Successfully"
                color = CSUC
            Case Error_Codes.Team_Rem_Suc
                msg = "Team Removed Successfully"
                color = CSUC
            Case Error_Codes.Admin_Get_Suc
                msg = "Admins Retrieved Successfully"
                color = CSUC
            Case Error_Codes.Admin_Exist
                msg = "Admin Exists"
                color = CWRN
            Case Error_Codes.Admin_Rem_Suc
                msg = "Admin Removed Successfully"
                color = CSUC
            Case Error_Codes.Admin_Rem_Fail
                msg = "Cannot Remove Self"
                color = CWRN
            Case Error_Codes.Report_Load_Suc
                msg = "Report Loaded Successfully"
                color = CSUC
            Case Error_Codes.Report_Load_Fail
                msg = "Could Not Load Report - Try Reinstaling"
                color = CERR
            Case Error_Codes.PBC_TL_ERROR
                msg = "No League and/or Teams Exist"
                color = CWRN
            Case Error_Codes.PBC_Format
                msg = "Invalid Format of Name/PBC ID"
                color = CWRN
            Case Error_Codes.PBC_Add_Suc
                msg = "PBC Added Successfully"
                color = CSUC
            Case Error_Codes.PBC_RED_Suc
                msg = "PBC Redeemed Successfully"
                color = CSUC
            Case Else
                msg = "Unknown Error"
        End Select
        Main.Status.Text = msg & " - " & err.ToString()
        set_status_color(color)
    End Sub

    Public Sub set_status_color(ByVal color As Color)
        Main.Status.BackColor = color
    End Sub

    Public Function adjust_pass(ByVal pass As String)
        Return pass.ToUpper()
    End Function

    Public Sub Save_DB()
        Dim filex As String = InputBox("Save DB As : ", "Save DB")
        Dim filetmp As String()
        Dim locpth As String = Get_Local_Path() & "DataBase\"
        If filex.Length > 0 And Not filex = "aORG" Then
            Try
                filetmp = filex.Split(".")
                File.Copy(locpth & "PBC.accdb", locpth & filetmp(0) & ".accdb", True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub Delete_DB(ByVal db As String)
        If MsgBox("Do you wish to Save the Current DB?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Save_DB()
        End If
        If MsgBox("Are You Sure you Want To Delete (" & db & ")?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                File.Delete(Get_Local_Path() & "DataBase\" & db & ".accdb")
            Catch ex As Exception

            End Try
        End If
        Delete.Close()
        Open.Show()
    End Sub

    Public Sub Open_DB(ByVal db As String)
        If MsgBox("Do you wish to Save the Current DB?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Save_DB()
        End If
        Try
            File.Copy(Get_Local_Path() & "DataBase\" & db & ".accdb", Get_Local_Path() & "DataBase\PBC.accdb", True)
        Catch ex As Exception

        End Try
        Open.Close()
        Load_Main()
        Main.Focus()
    End Sub

    Public Sub New_DB()
        Dim newdb As String = InputBox("New DB", "New DB")
        If newdb.Length > 0 And Not newdb = "PBC" Then
            Try
                File.Create(Get_Local_Path() & "DataBase\" & newdb & ".accdb", 1024, FileOptions.Asynchronous)
                If MsgBox("Do you Wish to Load you new DB (" & newdb & ")?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    File.Copy(Get_Local_Path() & "DataBase\" & newdb & ".accdb", Get_Local_Path() & "DataBase\PBC.accdb", True)
                End If
            Catch ex As Exception

            End Try
        End If
        Load_Main()
    End Sub

    Private Sub Load_Main()
        cont = New Home
        Check_Controls(cont)
    End Sub

End Class
