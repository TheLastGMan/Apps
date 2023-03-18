Imports TBDB.DBLnkr

Imports System.Management

Public Class Main
    Public ERS As New Errors
    Public VDB As New VDB
    Public FUNC As New Functions
    Private ReadOnly app_path = Application.StartupPath & "\DB\"
    Private ReadOnly Info_stat As String = "By: Ryan Gau  " & Chr(169) & "(2009 - " & Now.Year & ") |  Version - " & Functions.version
    Public Shared ClassList As New ArrayList

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load 'NO LOGGING
        Dim x As New SplashMenu
        'SplashMenu.SetInfo() = "Checking For Updates"
        Check_For_Update() 'NO LOGGING
        'SplashMenu.SetInfo() = "Connecting To DB"
        DB_Extern_Connect() 'NO LOGGING
        'SplashMenu.SetInfo() = "Checking Requirements"
        DB_Reqs()
        'SplashMenu.SetInfo() = "Setting Up DB"
        DB_Extern_Setup()
        'SplashMenu.SetInfo() = "Setting Up Logging"
        DB_Logging_Init()
        'SplashMenu.SetInfo() = "Loading Main Menu"
        'Check_Version()
        Map_Events()
        Set_Title()
        Load_Program()
    End Sub

#Region "EVENTS"

    Public Sub Map_Events()
        AddHandler TBDB.Events.ChangeHeaderEvent, AddressOf FUNC.Change_Header
        AddHandler TBDB.Events.WriteLogEvent, AddressOf Functions.Log_Write
        AddHandler TBDB.Events.GetWeekIdEvent, AddressOf Weeks.GetWeekId
        AddHandler TBDB.Events.GetWeekNameEvent, AddressOf Weeks.GetWeekName
        AddHandler TBDB.Events.GetWeekListEvent, AddressOf Weeks.GetWeekList
        AddHandler TBDB.Events.GetScoreMinEvent, AddressOf Weeks.GetMinimumScore
        AddHandler TBDB.Events.GetGamesPerWeekEvent, AddressOf Weeks.GetGamesPerWeek
        AddHandler TBDB.Events.GetLeagueNameEvent, AddressOf Settings.GetLeagueName
    End Sub

#End Region

    ReadOnly check_file_url As String = "http://www.rpgcor.com/apps/TBS/prod/Installer.msi"
    ReadOnly filex As String = "Installer.msi"

    Private Sub Check_For_Update()
        'check for backup files
        If File.Exists(My.Application.Info.DirectoryPath & "\DB\DBClass.txt.bak") Then
            'copy over
            File.Copy(My.Application.Info.DirectoryPath & "\DB\DBClass.txt.bak", My.Application.Info.DirectoryPath & "\DB\DBClass.txt", True)
            File.Delete(My.Application.Info.DirectoryPath & "\DB\DBClass.txt.bak")
        End If
        If File.Exists(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt.bak") Then
            File.Copy(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt.bak", My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
            File.Delete(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt.bak")
        End If
        Update_Check()
    End Sub

    Private Sub Update_Check()
        'checks for update
        '>add 30 days as a default update interval to the last check date
        Dim checkdate As Date = My.Settings.LastCheckDate.AddDays(30)
        If Now() > checkdate Then
            'download file
            Try
                My.Computer.Network.DownloadFile(check_file_url, filex)
            Catch ex As Exception
                Exit Sub
            End Try
            If File.Exists(filex) Then
                'check if valid
                SplashMenu.Close()
                If New FileInfo(filex).Length > 1000000 Then
                    'valid
                    If MsgBox("New Update Found" & vbCrLf & "Do You Wish To Update Now?", MsgBoxStyle.YesNo, "Update Found") = MsgBoxResult.Yes Then
                        'exec
                        My.Settings.LastCheckDate = Now()
                        My.Settings.LastFileDate = New FileInfo(filex).CreationTime
                        'copy primary files
                        Shell("copy '" & My.Application.Info.DirectoryPath & "\DB\DBClass.txt' '" & My.Application.Info.DirectoryPath & "\DB\DBClass.txt.bak'")
                        Shell("copy '" & My.Application.Info.DirectoryPath & "\DB\DBClassList.txt' '" & My.Application.Info.DirectoryPath & "\DB\DBClassList.txt.bak'")
                        Shell(filex)
                        Me.Close()
                    Else
                        'check for postpone
                        If MsgBox("Do You Wish To Postpone The Update For 30 Days?", MsgBoxStyle.YesNo, "Postpone") = MsgBoxResult.Yes Then
                            My.Settings.LastCheckDate = Now()
                        Else
                            Exit Sub
                        End If
                    End If
                Else
                    'invalid
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub DB_Reqs()
        Dim reqs As TBDB.DB_Structure.DB_Requriements = TBDB.DBLnkr.DB_Program.DB_Requirements()
        If Not reqs.Reqs_Met Then
            SplashMenu.Close()
            Functions.Log_Write("E", "Main.DB_Reqs", "Database Requirements Not")
            If MsgBox(reqs.Reqs_Msg, MsgBoxStyle.RetryCancel, "Requirements Not Met") = MsgBoxResult.Retry Then
                Functions.Log_Write("D", "Main.DB_Reqs", "Retrying DB Requirements")
                DB_Reqs()
            Else
                Functions.Log_Write("D", "Main.DB_Reqs", "User Canceled DB Requirements Check")
                Me.Close()
            End If
        End If
    End Sub

    Public Reps As New ArrayList 'Type, Desc, Report Class
    Friend Sub Load_Menu_Reports()
        Functions.Log_Write("I", "Main.Load_Menu_Reports")
        Dim TBF As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
        Reps = TBF.Search_File("R")
        Dim RN As ToolStripMenuItem = ReportsToolStripMenuItem
        RN.DropDownItems.Clear()
        Dim itmx As New ToolStripMenuItem
        itmx.Text = "&Tournament Report"
        AddHandler itmx.Click, AddressOf TournamentReportToolStripMenuItem_Click
        RN.DropDownItems.Add(itmx)
        For Each DBI As TBDB.FileOps.DBClassList In Reps
            Dim Itm As New ToolStripMenuItem()
            Itm.Text = DBI.Desc
            Itm.Name = DBI.CRef
            AddHandler Itm.Click, AddressOf Menu_Click
            RN.DropDownItems.Add(Itm)
            Functions.Log_Write("D", "Main.Load_Menu_Reports", "Added Report (" & DBI.Desc & ")")
        Next
    End Sub

    Private Sub Menu_Click(ByVal obj As Object, ByVal e As EventArgs)
        Functions.Log_Write("I", "Main.Menu_Click")
        If Weeks.Validates() Then
            Functions.Log_Write("D", "Main.Menu_Click", "Valid Week, Loading Report")
            Try
                Dim Itm As ToolStripMenuItem = obj
                Dim UC As String = Itm.Name
                Dim TA As UserControl = Activator.CreateInstance(Type.GetType(UC))
                Dim UCS As UserControl = TA
                Functions.Log_Write("S", "Main.Menu_Click", "created interface: " & UC)
                FUNC.Cont = TA
                FUNC.Change_Cont()
            Catch ex As Exception
                Functions.Log_Write("E", "Main.Menu_Click", "Could Not Create Instance: " & ex.Message)
                MsgBox("Could Not Create Interface: " & DirectCast(obj, ToolStripMenuItem).Name & ": " & ex.Message)
            End Try
        Else
            Functions.Log_Write("D", "Main.Menu_Click", "InValid Week, Can Not Load Report")
        End If
    End Sub

    Private Sub DB_Logging_Init()
        If DB_Logging_Enab Then
            DB_Program.Log_Init()
        End If
    End Sub

    Private Sub DB_Extern_Connect()
        Select Case DB_External_Setup()
            Case DB_Extern_Result.Failed_Both
                SplashMenu.Close()
                MsgBox("Access To The Program And Logging Database Could Not Be Established" & ChrW(13) & "Can Not Continue", MsgBoxStyle.OkOnly, "MAJOR ERROR")
                Me.Close()
            Case DB_Extern_Result.Failed_DBLnk2
                SplashMenu.Close()
                MsgBox("Access To The Logging Database Could Not Be Established" & ChrW(13) & "Logging Will Not Be Enabled", MsgBoxStyle.OkOnly, "Logging Failure")
                DB_Logging_Enab = False
                'Load_Program()
            Case DB_Extern_Result.Failed_DBLnk1
                SplashMenu.Close()
                Functions.Log_Write("W", "Main.DB_Extern_Connect: Can Not Connect To Program Database")
                MsgBox("Access To The Program Database Could Not Be Established" & ChrW(13) & "Can Not Continue", MsgBoxStyle.OkOnly, "Primary Failure")
                Me.Close()
            Case DB_Extern_Result.Success
                Functions.Log_Write("S", "Main.DB_Extern_Connect: Connected to Program & Logging Database")
                'Load_Program()
        End Select
    End Sub

    Private Sub DB_Extern_Setup()
        If Not DB_Program.DB_Setup Then
            'setup unsessfull
            SplashMenu.Close()
            MsgBox("Could Not Connect To Program DataBase" & ChrW(13) & "Please Check DataBase Or Try Restoring A Previous Version")
            Me.Close()
        End If
    End Sub

    Private Sub DB_Extern_Check_Update(ByRef cmds() As String)
        Functions.Log_Write("I", "Main.DB_Extern_Check_Update")
        Dim message As String = DB_Program.DB_Update(cmds)
        If Not message = "1" Then
            'error
        End If
    End Sub

    Private Sub Set_Title()
        Dim htext As TBDB.DB_Structure.Lineup_Get_Setting_By_ID = TBDB.DBLnkr.DB_Program.Lineup_Get_Setting_By_ID(VDB.DB_Settings_Rows.LeagueName)
        If htext._ERRMsg = Nothing Then
            'success
            Me.Text &= " : " & htext.Setting
        End If
    End Sub

    Private Sub Load_Program()
        Functions.Log_Write("I", "Main.Load_Program")
        VDB.DB_Setup() 'Setup Vector Database
        Dim dates As String = Now.Month.ToString & "/" & Now.Day.ToString & "/" & Now.Year.ToString
        Progress_Status.Value = 0
        Info_Status.TextAlign = ContentAlignment.MiddleCenter
        Info_Status.Text = Info_stat
        For i As Integer = 0 To Controls.Count - 1
            AddHandler Controls(i).KeyDown, AddressOf Form1_KeyDown
        Next
        ERS.Get_Error(Errors.Err_Codes.Main_Load_OK)
        SMon_Init()
        Load_Menu_Reports()
        Reset_Week_ID()
        If Weeks._WkNM = dates Then
            'Add Bowlers to Tournament Screen
            Add_Bowlers()
        Else
            'Add Week Screen
            Weeks_Page()
        End If
    End Sub

    Private Sub Reset_Week_ID()
        'reset active week id to 0
        Dim upd As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Lineup_Update_By_ID(VDB.DB_Settings_Rows.Week_ID, "0")
        If Not upd.ERR Then
            'success
            Functions.Log_Write("D", "Main.Reset_Week_ID", "reset active week id to 0")
        Else
            'error
            Functions.Log_Write("D", "Main.Reset_Week_ID", "could not reset active week id to 0: " & upd.ERRMsg)
        End If
    End Sub

    Private Sub SMon_Init()
        Functions.Log_Write("I", "Main.SMon_Init")
        'Check Version
        Try
            'FUNC.Check_Version()
        Catch ex As Exception
            MsgBox("DataBase Is Corrupt!" & Chr(13) & "Please restore a previous version")
        End Try
        Load_Saves()
    End Sub

    Private vtrue As Boolean = False
    Private kdebugt As Boolean() = {False, False, False, False}
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'does not seem to work
        If e.KeyCode = Keys.D And My.Computer.Keyboard.ShiftKeyDown Then
            kdebugt(0) = True
        ElseIf e.KeyCode = Keys.E And kdebugt(0) Then
            kdebugt(1) = True
        ElseIf e.KeyCode = Keys.B And kdebugt(1) Then
            kdebugt(2) = True
        ElseIf e.KeyCode = Keys.U And kdebugt(2) Then
            kdebugt(3) = True
        ElseIf e.KeyCode = Keys.G And kdebugt(3) Then
            'execute
            MenuStrip.Items("DebugToolStripMenuItem").Visible = Not MenuStrip.Items("DebugToolStripMenuItem").Visible
        Else
            kdebugt(0) = False
            kdebugt(1) = False
            kdebugt(2) = False
            kdebugt(3) = False
        End If
        If e.KeyCode = Keys.V Then
            vtrue = True
        ElseIf e.KeyCode = Keys.T And vtrue Then
            MenuStrip.Items("VectorToolStripMenuItem").Visible = Not MenuStrip.Items("VectorToolStripMenuItem").Visible
        Else
            vtrue = False
        End If
    End Sub

    Private Sub Load_Saves()
        Functions.Log_Write("I", "Main.Load_Saves")
        'Displays the saved files ending in .accdb under DB folder
        Dim files As List(Of String) = TBDB.DBLnkr.DB_Program.DB_Search()
        Dim ftmp As String() = {String.Empty}
        Dim exist As Boolean = False
        Dim index As SByte = 0
        Dim res As ToolStripMenuItem = RestoreToolStripMenuItem
        Dim tmp As New ToolStripMenuItem
        Dim loccr As Short = 0
        Dim loccx As Short = 0
        Dim file As String
        res.DropDownItems.Clear()
        For Each itm In files
            'Gets File Name
            loccr = itm.LastIndexOf("\") + 1
            loccx = itm.LastIndexOf(".")
            file = itm.Substring(loccr, loccx - loccr)
            'Split file into yyyy && mm
            ftmp = file.Split("_")
            ftmp = ftmp(1).Split("-")
            ftmp(2) = FUNC.Get_Month(ftmp(1)) & " - " & ftmp(0)
            If res.DropDownItems.Count > 0 Then
                For j As Short = 0 To res.DropDownItems.Count - 1
                    If res.DropDownItems(j).Name = ftmp(2) Then
                        exist = True
                        index = j
                        Exit For
                    End If
                Next
            End If
            If exist Then
                exist = False
                'Insert File
                tmp = res.DropDownItems(index)
                tmp.DropDownItems.Add(file, Nothing, AddressOf Restore_Saves).Name = file
            Else
                'Does Not Exist - Add
                res.DropDownItems.Add(ftmp(2)).Name = ftmp(2)
                'Insert File
                tmp = res.DropDownItems(res.DropDownItems.Count - 1)
                tmp.DropDownItems.Add(file, Nothing, AddressOf Restore_Saves).Name = file
            End If
            'res.DropDownItems.Add(file)
            'tmp = res.DropDownItems(i)
            'tmp.DropDownItems.Add("TMP")
        Next
        'TB_yyyy-m-d
    End Sub

    Private Sub Restore_Saves(ByVal sender As Object, ByVal e As System.EventArgs)
        'Restores the selected save from the Restore MenuItem
        Functions.Log_Write("I", "Main.Restore_Saves")
        Dim filex As String = sender.ToString 'item text
        Restore_File(filex, True)
    End Sub

    Private Sub Restore_File(ByRef filex As String, Optional ByRef use_default_location As Boolean = True)
        If use_default_location Then
            'modify for default database location
            filex = TBDB.DBLnkr.DB_Program.DB_Default_Location & filex & TBDB.DBLnkr.DB_Program.DB_Default_Extension
        End If
        If MsgBox("Are You Sure You Wish To Restore " & Chr(13) & "(" & filex & ")" & Chr(13) & "Any Unsaved Data Will Be Lost", MsgBoxStyle.YesNo, "Are You Sure") = MsgBoxResult.Yes Then
            Dim restore As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.DB_Load(filex)
            If Not restore.ERR Then
                'success
                Functions.Log_Write("S", "Main.Restore_Saves", "[" & Errors.Err_Codes.File_Restore_OK & "] - DB Restored Successfully")
                Weeks._WkNM = String.Empty
                Weeks_Page()
                SMon_Init()
            Else
                'failure
                Functions.Log_Write("E", "Main.Restore_Saves", "[" & Errors.Err_Codes.File_Restore_ERR & "] " & restore.ERRMsg)
            End If
        End If
    End Sub

    Private Sub Add_Bowlers()
        FUNC.Cont = New Add_Bowler
        FUNC.Change_Cont()
    End Sub

    Private Sub Weeks_Page()
        FUNC.Cont = New Weeks
        FUNC.Change_Cont()
    End Sub

    Private Function check_values() As Boolean
        Functions.Log_Write("I", "Main.check_value")
        Dim ret As Boolean = True
        If Weeks._WkID = -1 Then
            ret = False
            Functions.Log_Write("W", "Main.check_value", "Week Invalid")
        Else
            Functions.Log_Write("S", "Main.check_value", "Week Valid")
        End If
        If Settings._ITournament Is Nothing Then
            ret = False
            Functions.Log_Write("W", "Main.check_value", "Tournament Invalid")
        Else
            Functions.Log_Write("S", "Main.check_value", "Tournament Valid")
        End If
        Return ret
    End Function

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddBowlersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBowlersToolStripMenuItem.Click, Button1.Click
        Functions.Log_Write("I", "Main.AddBowlersToolStripMenuItem")
        'Add Bowlers to Tournament
        If check_values() Then
            Functions.Log_Write("S", "Main.AddBowlersToolStripMenuItem", "Validation Passes")
            'check passes
            Progress_Status.Value = 33
            Add_Bowlers()
        Else
            'check fails
            Functions.Log_Write("W", "Main.AddBowlersToolStripMenuItem", "Validation Failed")
        End If
    End Sub

    Private Sub ScoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTToolStripMenuItem.Click, Button2.Click
        'Show Scores
        Functions.Log_Write("W", "Main.ScoresBowlersToolStripMenuItem")
        If check_values() Then
            'check passes
            Functions.Log_Write("S", "Main.ScoresToolStripMenuItem", "Validation Passes")
            Progress_Status.Value = 66
            FUNC.Cont = New Scores
            FUNC.Change_Cont()
        Else
            'check fails
            Functions.Log_Write("W", "Main.ScoresToolStripMenuItem", "Validation Failed")
        End If
    End Sub

    Private Sub EditTournamentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTournamentToolStripMenuItem.Click, Button3.Click
        'Edit Tournament
        Functions.Log_Write("I", "Main.EditTournamentToolStripMenuItem_Click")
        Progress_Status.Value = 99
        If check_values() Then
            Functions.Log_Write("S", "Main.EditTournamentToolStripMenuItem_Click", "Validation Passes")
            Try
                Dim TC As TBDB.ITournament = Settings._ITournament
                FUNC.Cont = TC.Tournament_Control
                Functions.Log_Write("S", "Main.EditTournamentToolStripMenuItem_Click", "set tournament control")
                FUNC.Change_Cont()
            Catch ex As Exception
                Functions.Log_Write("E", "Main.EditTournamentToolStripMenuItem_Click", "could not create tournament report: " & ex.Message)
                MsgBox(ex.Message & Chr(13) & ex.Source & Chr(13) & ex.StackTrace)
            End Try
        Else
            Functions.Log_Write("W", "Main.EditTournamentToolStripMenuItem_Click", "Validation Failed")
        End If

    End Sub

    Private Sub WeeksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeeksToolStripMenuItem.Click
        Functions.Log_Write("I", "Main.WeeksToolStripMenuItem_Click")
        Weeks_Page()
    End Sub

    Private Sub PrintWeekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Functions.Log_Write("I", "Main.PrintWeekToolStripMenuItem_Click")

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        'Save Dialog Box
        Dim save As New TBDB.DB_Structure.Boolean_Response

        Dim datex As String = Now.Year & "-" & Now.Month & "-" & Now.Day
        SaveFileDialog1.DefaultExt = "*" & TBDB.DBLnkr.DB_Program.DB_Default_Extension
        SaveFileDialog1.FileName = datex
        SaveFileDialog1.Filter = "Tourney Builder|" & SaveFileDialog1.DefaultExt
        If MsgBox("Do you wish to specify a location to save to?", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
            If SaveFileDialog1.ShowDialog > 0 Then
                Functions.Log_Write("D", "Main.SaveToolStripMenuItem_Click", "Saving to a specified location")
                save = TBDB.DBLnkr.DB_Program.DB_Save(0, 0, 0, SaveFileDialog1.FileName)
            End If
        Else
            Functions.Log_Write("D", "Main.SaveToolStripMenuItem_Click", "Saving to default location")
            save = TBDB.DBLnkr.DB_Program.DB_Save(Now.Year, Now.Month, Now.Day)
        End If
        'check save response
        If save.ERR = False Then
            'success
            Error_Status.BackColor = ERS.OK
            Functions.Log_Write("S", "Main.SaveToolStripMenuItem_Click", "File Saved As Successfully - [" & Errors.Err_Codes.File_Save_OK & "]")
        Else
            'error
            Error_Status.BackColor = ERS.ERR
            Functions.Log_Write("E", "Main.SaveToolStripMenuItem_Click", save.ERRMsg)
        End If
        Load_Saves()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        'load a non default location file
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Restore_File(OpenFileDialog1.FileName, False)
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If MsgBox("Do you wish to start a new season, Previous Data will be lost", MsgBoxStyle.YesNo, "NEW") = MsgBoxResult.Yes Then
            Dim status As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.DB_New()
            If status.ERR Then
                'error
                Functions.Log_Write("E", "Main.NewToolStripMenuItem_Click", "Error Creating New Season: " & status.ERRMsg)
            Else
                'no error
                Functions.Log_Write("S", "Main.NewToolStripMenuItem_Click", "Created A New Season")
                Weeks_Page()
                SMon_Init()
            End If
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem.Click
        Functions.Log_Write("I", "Main.HomeToolStripMenuItem_Click")
        Weeks_Page()
    End Sub

    Private Sub InformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformationToolStripMenuItem.Click
        Functions.Log_Write("I", "Main.InformationToolStripMenuItem_Click", "Bolwer Info Clicked")
        FUNC.Cont = New Bowler_Info
        FUNC.Change_Cont()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        FUNC.Cont = New Vector_Settings
        FUNC.Change_Cont()
    End Sub

    Private Sub ErrorsAllComingSoonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorsAllComingSoonToolStripMenuItem.Click
        'FUNC.Cont = New Vector_Errors_All
        'FUNC.Change_Cont()
    End Sub

    Private Sub Main_Dispose(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Disposed
        Functions.Log_Write("I", "Main.Main_Dispose")
        VDB.DB_Close()
    End Sub

    Private Sub FindLastScoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindLastScoresToolStripMenuItem.Click
        FUNC.Cont = New VectorFBowler
        FUNC.Change_Cont()
    End Sub

    Private Sub TournamentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TournamentReportToolStripMenuItem.Click
        Functions.Log_Write("I", "Main.TournamentReportToolStripMenuItem_Click")
        Progress_Status.Value = 99
        Try
            Dim TC As TBDB.ITournament = Settings._ITournament
            FUNC.Cont = TC.Tournament_Report_Control
            Functions.Log_Write("S", "Main.TournamentReportToolStripMenuItem_Click", "set tournament report control")
            FUNC.Change_Cont()
        Catch ex As Exception
            Functions.Log_Write("E", "Main.TournamentReportToolStripMenuItem_Click", "could not create tournament report: " & ex.Message)
        End Try
    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem1.Click
        Functions.Log_Write("I", "Main.SettingsToolStripMenuItem1", "Settings Pressed")
        FUNC.Cont = New Settings
        FUNC.Change_Cont()
    End Sub

    Private Sub ModulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModulesToolStripMenuItem.Click
        'downloadable modules
        Functions.Log_Write("I", "Main.ModulesToolStripMenuItem_Click")
        FUNC.Cont = New Modules
        FUNC.Change_Cont()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Update_Check()
    End Sub

End Class
