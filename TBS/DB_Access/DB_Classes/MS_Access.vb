Public Class MS_Access
    Implements IDB_Template

#Region "DataBase File Options"

    Private app_path As String = My.Application.Info.DirectoryPath & "\DB\Access\"

    Public Function DB_Load(ByRef file As String) As DB_Structure.Boolean_Response Implements IDB_Template.DB_Load
        Dim ret As New DB_Structure.Boolean_Response
        Try
            'IO.File.Copy(app_path & file & ".TBS", app_path & "TB.TBS", True)
            IO.File.Copy(file, app_path & "TB.TBS", True)
            ret.ERR = False
        Catch ex As Exception
            ret.ERR = True
            ret.ERRMsg = "File Could Not Be Restored: " & ex.Message
        End Try
        Return ret
    End Function

    Public Function DB_New() As DB_Structure.Boolean_Response Implements IDB_Template.DB_New
        Dim ret As New DB_Structure.Boolean_Response
        Try
            IO.File.Copy(app_path & "TB.clean", app_path & "TB.TBS", True)
            ret.ERR = False
        Catch ex As Exception
            ret.ERR = True
            ret.ERRMsg = ex.Message
        End Try
        Return ret
    End Function

    Public Function DB_Save(ByRef year As Integer, ByRef month As Byte, ByRef day As Byte, Optional ByRef save_location As String = "[Default]") As DB_Structure.Boolean_Response Implements IDB_Template.DB_Save
        Dim ret As New DB_Structure.Boolean_Response
        Try
            If save_location = "[Default]" Then
                'default location
                Dim datex As String = year & "-" & month & "-" & day & DB_Default_Extension()
                IO.File.Copy(DB_Default_Location() & "TB" & DB_Default_Extension(), app_path & "TBS_" & datex, True)
            Else
                'non default locatio
                IO.File.Copy(DB_Default_Location() & "TB" & DB_Default_Extension(), save_location)
            End If
            ret.ERR = False
        Catch ex As Exception
            ret.ERR = True
            ret.ERRMsg = "Could Not Save DataBase: " & ex.Message
        End Try
        Return ret
    End Function

    Public Function DB_Default_Extension() As String Implements IDB_Template.DB_Default_Extension
        Return ".TBS"
    End Function

    Public Function DB_Default_Location() As String Implements IDB_Template.DB_Default_Location
        Return app_path
    End Function

    Public Function DB_Search() As List(Of String) Implements IDB_Template.DB_Search
        Dim ret As New List(Of String)
        Dim ary As String() = IO.Directory.GetFiles(app_path, "TBS_*" & DB_Default_Extension(), IO.SearchOption.TopDirectoryOnly)
        For Each fle In ary
            ret.Add(fle)
        Next
        Return ret
    End Function

    Function DB_Requirements() As DB_Structure.DB_Requriements Implements IDB_Template.DB_Requirements
        'search Registry to see if Access Database Engine 2010 has been installed
        '?? <Microsoft.ACE.OLEDB.12.0\CLSID>
        Dim ret As New DB_Structure.DB_Requriements
        If Reg_Exists("Microsoft.Office.List.OLEDB.1.0\CLSID") And Reg_Exists("Microsoft.Office.List.OLEDB.2.0\CLSID") And Reg_Exists("Microsoft.Office.List.OLEDB.3.0\CLSID") And Reg_Exists("LISTNET.Listnet.14\CLSID") Then
            ret.Reqs_Met = True
        Else
            ret.Reqs_Met = False
            If MsgBox("Access DataBase Engine not installed, would you like to download and install now?", MsgBoxStyle.YesNo, "Error") = MsgBoxResult.Yes Then
                My.Computer.Network.DownloadFile("http://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe", app_path & "ADE.exe")
                Shell(app_path & "ADE.exe", AppWinStyle.NormalFocus, True, 15000)
                ret.Reqs_Met = True
                Return ret
            Else
                ret.Reqs_Msg = "Please install Microsoft Access DataBase Engine 2010 (AccessDatabaseEngine.exe)" & vbCrLf & "http://www.microsoft.com/download/en/details.aspx?id=13255" & " Or Direct" & vbCrLf & "http://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe" & vbCrLf & "and retry"
            End If
            'ret.Reqs_Msg = "Please install Microsoft Access DataBase Engine 2010 (AccessDatabaseEngine.exe)" & vbCrLf & "http://www.microsoft.com/download/en/details.aspx?id=13255" & " Or Direct" & vbCrLf & "http://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe" & vbCrLf & "and retry"
        End If
        Return ret
    End Function

    Private Function Reg_Exists(ByRef regval As String) As Boolean
        'Dim Reg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regval)
        Try
            Dim reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey(regval, False)
            Dim str As String = reg.GetValue("", 0)
            Return IIf(reg.GetValue("", 0).ToString.Length > 0, True, False)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DB_Setup() As Boolean Implements IDB_Template.DB_Setup
        'Check if we can connect to DB by filling Lineup/Version Table
        Dim VTB As New TBDS.LineupDataTable
        Dim VTA As New TBDSTableAdapters.LineupTableAdapter
        Try
            VTA.Fill(VTB)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
    End Function

    Public Function DB_Update(ByVal sql_cmds As String()) As String Implements IDB_Template.DB_Update
        Try
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Implemented() As Boolean Implements IDB_Template.Implemented
        Return True
    End Function

#End Region

#Region "Lanes"

    Public Function Lanes_Get() As List(Of DB_Structure.Lanes_Get) Implements IDB_Template.Lanes_Get
        Dim LNS As New List(Of DB_Structure.Lanes_Get)
        Try
            Dim LDA As New TBDSTableAdapters.LanesTableAdapter
            Dim LDT As New TBDS.LanesDataTable
            LDA.Fill(LDT)
            For i As Integer = 1 To LDT.Rows.Count
                Dim INS As New DB_Structure.Lanes_Get
                INS.Lane = LDT.Rows(i - 1).Item(1)
                LNS.Add(INS)
            Next
        Catch ex As Exception
            Dim INS As New DB_Structure.Lanes_Get
            INS._ERRMsg = ex.Message
            LNS.Add(INS)
        End Try
        Return LNS
    End Function

#End Region

#Region "Logs"

    Public Sub Log_Init() Implements IDB_Template.Log_Init

    End Sub

    Public Sub Log_Write(ByRef msg As String) Implements IDB_Template.Log_Write

    End Sub

    Public Function Log_Read() As ArrayList Implements IDB_Template.Log_Read
        Return New ArrayList
    End Function

#End Region

#Region "Bowlers"

    Public Function Bowlers_Get_List() As List(Of DB_Structure.Bowlers_Get_List) Implements IDB_Template.Bowlers_Get_List
        Dim BLST As New List(Of DB_Structure.Bowlers_Get_List)

        Try
            Dim BDA As New TBDSTableAdapters.BowlersTableAdapter
            Dim BDT As New TBDS.BowlersDataTable
            BDA.All_Bowlers(BDT)
            '0 to 4
            'ID, FName, LName, USBC, Sex
            For Each row As DataRow In BDT.Rows
                Dim db As New DB_Structure.Bowlers_Get_List
                db.ID = row.Item("ID")
                db.FName = row.Item("FName")
                db.LName = row.Item("LName")
                db.USBC_Sanc = row.Item("USBC_Sanc")
                db.Sex = row.Item("Sex")
                BLST.Add(db)
            Next
        Catch ex As Exception
            Dim db As New DB_Structure.Bowlers_Get_List
            db._ERRMsg = ex.Message
            BLST.Add(db)
        End Try

        Return BLST
    End Function

    Public Function Bowler_Get_By_LName() As ArrayList Implements IDB_Template.Bowler_Get_By_LName
        Dim BLST As New ArrayList

        Try
            Dim BDA As New TBDSTableAdapters.BowlersTableAdapter
            Dim BDT As New TBDS.BowlersDataTable
            BDA.Sort_LName(BDT)
            For i As Integer = 1 To BDT.Rows.Count
                '0-4
                For j As Byte = 0 To 4
                    BLST.Add(BDT.Rows(i - 1).Item(j))
                Next
            Next
        Catch ex As Exception
            BLST.Add("-1")
            BLST.Add(ex.Message)
        End Try

        Return BLST
    End Function

    Public Function Bowler_Update_By_ID(ByVal id As Integer, ByVal FName As String, ByVal LName As String, ByVal USBC_ID As String, ByVal Sex As String) As ArrayList Implements IDB_Template.Bowler_Update_By_ID
        Dim BLST As New ArrayList

        Try
            Dim BDA As New TBDSTableAdapters.BowlersTableAdapter
            BDA.Update_By_ID(FName, LName, USBC_ID, Sex, id)
            BLST.Add("1")
        Catch ex As Exception
            BLST.Add(ex.Message)
        End Try

        Return BLST
    End Function

    Public Function Bowler_Get_By_ID(ByVal id As Integer) As ArrayList Implements IDB_Template.Bowler_Get_By_ID
        Dim BLST As New ArrayList

        Try
            Dim BDA As New TBDSTableAdapters.BowlersTableAdapter
            Dim BDT As New TBDS.BowlersDataTable
            BDA.Get_All_By_ID(BDT, id)
            For i As Integer = 1 To BDT.Rows.Count
                For j As Byte = 0 To 4
                    BLST.Add(BDT.Rows(i - 1).Item(j))
                Next
            Next
        Catch ex As Exception
            BLST.Add("-1")
            BLST.Add(ex.Message)
        End Try

        Return BLST
    End Function

    Public Function Bowler_Insert(ByVal FName As String, ByVal LName As String, ByVal USBC As String, ByVal SEX As String) As Object Implements IDB_Template.Bowler_Insert
        Try
            Dim BDS As New TBDSTableAdapters.BowlersTableAdapter
            BDS.Insert(FName, LName, USBC, SEX)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Bowler_Get_ID_by_Name(ByVal FName As String, ByVal LName As String) As ArrayList Implements IDB_Template.Bowler_Get_ID_by_Name
        Dim BLST As New ArrayList
        Try
            Dim BDS As New TBDSTableAdapters.BowlersTableAdapter
            BLST.Add(BDS.Get_ID_By_Name(FName, LName))
        Catch ex As Exception
            BLST.Add(ex.Message)
        End Try
        Return BLST
    End Function

#End Region

#Region "Weeks"

    Public Function Weeks_Get_List() As ArrayList Implements IDB_Template.Weeks_Get_List
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Dim WKD As New TBDS.WeeksDataTable
        Dim wklst As New ArrayList()
        Try
            WKA.Get_All_Weeks(WKD)
            wklst.Add(WKD.Columns.Count())
            For i As Integer = 0 To WKD.Rows.Count - 1
                For j As Byte = 0 To 1
                    wklst.Add(WKD.Rows(i).Item(j)) 'ID, Week
                Next
            Next
        Catch ex As Exception
            wklst.Add(-1)
            wklst.Add(ex.Message)
        End Try

        Return wklst
    End Function

    Public Function Weeks_Delete(ByVal week_id As Integer) As String Implements IDB_Template.Weeks_Delete
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Try
            WKA.Delete_Week_By_ID(week_id)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Weeks_Add(ByVal week As String, ByVal games_this_week As Integer, ByVal series_minimum As Integer, ByVal tournament_style As String) As String Implements IDB_Template.Weeks_Add
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Try
            WKA.Add_Week(week, tournament_style, series_minimum, games_this_week)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Weeks_By_ID(ByVal id As Integer) As ArrayList Implements IDB_Template.Weeks_By_ID
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Dim WKD As New TBDS.WeeksDataTable
        Dim WKLst As New ArrayList
        Try
            WKA.Get_Week_By_ID(WKD, id)
            If WKD.Rows.Count > 0 Then
                For i As Byte = 0 To WKD.Columns.Count - 1
                    WKLst.Add(WKD.Rows(0).Item(i))
                Next
            Else
                WKLst.Add("")
            End If
        Catch ex As Exception
            WKLst.Add(ex.Message)
        End Try
        Return WKLst
    End Function

    Public Function Weeks_Update_Settings(ByVal games As Integer, ByVal series As Integer, ByVal tournament_desc As String, ByVal week_id As Integer) As String Implements IDB_Template.Weeks_Update_Settings
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Dim WKD As New TBDS.WeeksDataTable
        Dim WKret As String = ""
        Try
            WKA.Update_Settings_By_ID(series, games, tournament_desc, week_id)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Weeks_Final_Averages() As List(Of DB_Structure.Weeks_Final_Averages) Implements IDB_Template.Weeks_Final_Averages
        Dim WKA As New TBDSTableAdapters.WeeksTableAdapter
        Dim WKD As New TBDS.WeeksDataTable
        Dim WKret As New List(Of DB_Structure.Weeks_Final_Averages)
        Try
            WKA.Get_Final_Averages(WKD)
            For Each row As DataRow In WKD.Rows
                Dim WKDat As New DB_Structure.Weeks_Final_Averages
                With WKDat
                    .Name = row.Item("FName") & " " & row.Item("LName")
                    .USBC = row.Item("USanc")
                    .SUMG = row.Item("GGames")
                    .SUM4 = row.Item("GSeries")
                    ._ERR = False
                End With
                WKret.Add(WKDat)
            Next
        Catch ex As Exception
            Dim WKDat As New DB_Structure.Weeks_Final_Averages
            WKDat._ERR = True
            WKDat._ERRMsg = ex.Message
            WKret.Add(WKDat)
        End Try
        Return WKret
    End Function

#End Region

#Region "Scores"

    Public Function Scores_Delete_By_WKID_BID(ByVal WKID As Integer, ByVal BID As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Delete_By_WKID_BID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim STA As New TBDSTableAdapters.ScoresTableAdapter
            STA.Delete_by_WKID_BID(WKID, BID)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_Delete_By_Week_ID(ByVal week_id As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Delete_By_Week_ID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim STA As New TBDSTableAdapters.ScoresTableAdapter
            STA.Delete_By_Week_ID(week_id)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_Get_List(ByVal WID As Integer) As List(Of DB_Structure.Scores_Get_List) Implements IDB_Template.Scores_Get_List
        Dim SLT As New List(Of DB_Structure.Scores_Get_List)
        Try
            Dim STA As New TBDSTableAdapters.ScoresTableAdapter
            Dim STD As New TBDS.ScoresDataTable
            STA.Fill(STD, WID)
            For i As Integer = 1 To STD.Rows.Count
                Dim DBS As New DB_Structure.Scores_Get_List
                With DBS
                    .ID = STD.Rows(i - 1).Item("ID")
                    .Week_ID = STD.Rows(i - 1).Item("Week_ID")
                    .Lane_ID = STD.Rows(i - 1).Item("Lane_ID")
                    .Bowler_ID = STD.Rows(i - 1).Item("Bowler_ID")
                    .Scores = STD.Rows(i - 1).Item("Scores")
                    .SUM4 = STD.Rows(i - 1).Item("SUM4")
                    .SUM3 = STD.Rows(i - 1).Item("SUM3")
                    .AVE = STD.Rows(i - 1).Item("AVE")
                    .BAlias = STD.Rows(i - 1).Item("BAlias")
                End With
                SLT.Add(DBS)
            Next
        Catch ex As Exception
            Dim DBS As New DB_Structure.Scores_Get_List
            DBS._ERRMsg = ex.Message
            SLT.Add(DBS)
        End Try
        Return SLT
    End Function

    Public Function Scores_Lane_Update_By_BID_WKID(ByVal BID As Integer, ByVal WKID As Integer, ByVal lane As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Lane_Update_By_BID_WKID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            SCA.Update_Lane_By_BID_WKID(lane, BID, WKID)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_Insert(ByVal WKID As Integer, ByVal Lane As Integer, ByVal BID As Integer, ByVal Scores As String, ByVal Sum3 As Short, ByVal SumX As Short, ByVal Average As String, Optional ByVal Vect_Alias As String = "") As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Insert
        Dim RET As New DB_Structure.Boolean_Response
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            SCA.Insert(WKID, Lane, BID, Scores, SumX, Sum3, Average, Vect_Alias)
            RET.ERR = False
        Catch ex As Exception
            RET.ERR = True
            RET.ERRMsg = ex.Message
        End Try
        Return RET
    End Function

    Public Function Scores_Get_By_Week_Lane(ByVal WKID As Integer, ByVal LID As Short) As List(Of DB_Structure.Scores_Get_By_Week_Lane) Implements IDB_Template.Scores_Get_By_Week_Lane
        Dim RET As New List(Of DB_Structure.Scores_Get_By_Week_Lane)
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            Dim SCT As New TBDS.ScoresDataTable
            SCA.Scores_By_Week_Lane(SCT, WKID, LID)
            For i As Integer = 1 To SCT.Rows.Count
                Dim DBS As New DB_Structure.Scores_Get_By_Week_Lane
                With DBS
                    .ID = SCT.Rows(i - 1).Item("ID")
                    .Lane_ID = SCT.Rows(i - 1).Item("Lane_ID")
                    .Week_ID = SCT.Rows(i - 1).Item("Week_ID")
                    .Bowler_ID = SCT.Rows(i - 1).Item("Bowler_ID")
                    .BAlias = SCT.Rows(i - 1).Item("BAlias")
                    .AVE = SCT.Rows(i - 1).Item("AVE")
                    .SUM3 = SCT.Rows(i - 1).Item("SUM3")
                    .SUM4 = SCT.Rows(i - 1).Item("SUM4")
                    .Scores = SCT.Rows(i - 1).Item("Scores")
                End With
                RET.Add(DBS)
            Next
        Catch ex As Exception
            Dim DBS As New DB_Structure.Scores_Get_By_Week_Lane
            DBS._ERRMsg = ex.Message
            RET.Add(DBS)
        End Try
        Return RET
    End Function

    Public Function Scores_Update_By_BID_LID_WKID(ByVal BID As Integer, ByVal LID As Integer, ByVal WKID As Integer, ByVal Scores As String, ByVal Ser3 As Integer, ByVal SerX As Integer, ByVal Ave As String, ByVal BAlias As String) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Update_By_BID_LID_WKID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            SCA.Update_Scores_By_SID(Scores, SerX, Ser3, Ave, BAlias, WKID, BID)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_Check_Bowler_Exists_BID(ByVal BID As Integer) As DB_Structure.Scores_Check_Bowler_Exists_BID Implements IDB_Template.Scores_Check_Bowler_Exists_BID
        Dim DBS As New DB_Structure.Scores_Check_Bowler_Exists_BID
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            DBS.Exists = SCA.Bowler_Exists(BID)
        Catch ex As Exception
            DBS._ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_Lane_By_WKID_BID(ByVal WKID As Integer, ByVal BID As Integer) As DB_Structure.Scores_Lane_By_WKID_BID Implements IDB_Template.Scores_Lane_By_WKID_BID
        Dim DBS As New DB_Structure.Scores_Lane_By_WKID_BID
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            DBS.Lane_ID = SCA.Lane_By_WKID_BID(WKID, BID)
        Catch ex As Exception
            DBS._ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Scores_By_Sex_Week(ByVal Sex As String, ByVal Week As Integer) As List(Of DB_Structure.Scores_By_Sex_Week) Implements IDB_Template.Scores_By_Sex_Week
        '9    , 10   , 4
        'FName, LName, Scores
        Dim ret As New List(Of DB_Structure.Scores_By_Sex_Week)
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            Dim SCT As New TBDS.ScoresDataTable
            SCA.Scores_by_sex_week(SCT, Week, Sex)
            For i As Integer = 1 To SCT.Rows.Count
                Dim DBS As New DB_Structure.Scores_By_Sex_Week
                DBS.Name = SCT.Rows(i - 1).Item("FName") & " " & SCT.Rows(i - 1).Item("LName")
                DBS.Scores = SCT.Rows(i - 1).Item("Scores")
                ret.Add(DBS)
            Next
        Catch ex As Exception
            Dim DBS As New DB_Structure.Scores_By_Sex_Week
            DBS._ERRMsg = ex.Message
            ret.Add(DBS)
        End Try
        Return ret
    End Function

    Public Function Scores_By_BID(ByVal bid As Integer) As List(Of DB_Structure.Scores_By_BID) Implements IDB_Template.Scores_By_BID
        Dim ret As New List(Of DB_Structure.Scores_By_BID)
        Try
            Dim SCA As New TBDSTableAdapters.ScoresTableAdapter
            Dim SCT As New TBDS.ScoresDataTable
            SCA.Scores_By_BID(SCT, bid)
            For i As Integer = 1 To SCT.Rows.Count
                Dim DBS As New DB_Structure.Scores_By_BID
                DBS.ID = SCT.Rows(i - 1).Item("ID")
                DBS.Week_ID = SCT.Rows(i - 1).Item("Week_ID")
                DBS.Lane_ID = SCT.Rows(i - 1).Item("Lane_ID")
                DBS.Bowler_ID = SCT.Rows(i - 1).Item("Bowler_ID")
                DBS.Scores = SCT.Rows(i - 1).Item("Scores")
                DBS.SUM4 = SCT.Rows(i - 1).Item("SUM4")
                DBS.SUM3 = SCT.Rows(i - 1).Item("SUM3")
                DBS.AVE = SCT.Rows(i - 1).Item("AVE")
                DBS.BAlias = SCT.Rows(i - 1).Item("BAlias")
                ret.Add(DBS)
            Next
        Catch ex As Exception
            Dim DBS As New DB_Structure.Scores_By_BID
            DBS._ERRMsg = ex.Message
        End Try
        Return ret
    End Function

#End Region

#Region "Tournament"

    Public Function Tournament_Load() As ArrayList Implements IDB_Template.Tournament_Load
        Return New ArrayList
    End Function

    Public Function Tournament_Delete_By_Week_ID(ByVal week_id As Integer) As String Implements IDB_Template.Tournament_Delete_By_Week_ID
        Dim TTA As New TBDSTableAdapters.TournamentTableAdapter
        Try
            TTA.Delete_By_Week_ID(week_id)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Tournament_Exists(ByVal week_id As Integer) As String Implements IDB_Template.Tournament_Exists
        Try
            Dim TTA As New TBDSTableAdapters.TournamentTableAdapter
            Return TTA.Exists(week_id).ToString
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Tournament_Get_Data(ByVal week_id As Integer) As String Implements IDB_Template.Tournament_Get_Data
        Try
            Dim TTA As New TBDSTableAdapters.TournamentTableAdapter
            Dim TTD As New TBDS.TournamentDataTable
            Return TTA.Get_Data_By_WKID(week_id)
        Catch ex As Exception
            Return "-" & ex.Message
        End Try
    End Function

    Public Function Tournament_Update_Data_By_WkID(ByVal week_id As Integer, ByVal tdata As String) As String Implements IDB_Template.Tournament_Update_Data_By_WkID
        Try
            Dim TTA As New TBDSTableAdapters.TournamentTableAdapter
            TTA.Update_Data_By_WkID(tdata, week_id)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Tournament_Insert(ByVal WKID As Integer, ByVal Data As String) As String Implements IDB_Template.Tournament_Insert
        Try
            Dim TTA As New TBDSTableAdapters.TournamentTableAdapter
            TTA.Insert(WKID, Data)
            Return "1"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#End Region

#Region "Lineup (Settings)"

    Public Function Lineup_Delete_Setting_By_ID(ByVal SID As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Delete_Setting_By_ID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim LTA As New TBDSTableAdapters.LineupTableAdapter
            LTA.Delete_Value(SID)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = False
        End Try
        Return DBS
    End Function

    Public Function Lineup_Get_Setting_By_ID(ByVal SID As Integer) As DB_Structure.Lineup_Get_Setting_By_ID Implements IDB_Template.Lineup_Get_Setting_By_ID
        Dim DBS As New DB_Structure.Lineup_Get_Setting_By_ID
        Try
            Dim LTA As New TBDSTableAdapters.LineupTableAdapter
            DBS.Setting = LTA.Get_Value(SID)
        Catch ex As Exception
            DBS._ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Lineup_Update_By_ID(ByVal SID As Integer, ByVal value As String) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Update_By_ID
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim LTA As New TBDSTableAdapters.LineupTableAdapter
            LTA.Update_Value_By_ID(value, SID)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

    Public Function Lineup_Insert(ByVal value As String) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Insert
        Dim DBS As New DB_Structure.Boolean_Response
        Try
            Dim LTA As New TBDSTableAdapters.LineupTableAdapter
            LTA.Insert(value)
            DBS.ERR = False
        Catch ex As Exception
            DBS.ERR = True
            DBS.ERRMsg = ex.Message
        End Try
        Return DBS
    End Function

#End Region

End Class
