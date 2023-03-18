Public Class VDB
    'Score Monitor DB Settings
    Public SMV As String = "Vector"
    Public IPAddr As Byte() = {192, 0, 0, 1}
    Public IPPort As Integer = 1433
    Public IPName As String = "VectorPlus"
    Public DBUsrPsw As String() = {"VectorPlus", "tbld", "tbld"}
    Public ChkSMon As Integer = 0

    Private SQLCon As New OleDb.OleDbConnection
    Private SQLQry As New OleDb.OleDbCommand
    Private query As String = ""

    Public Enum Logging_Levels As Integer
        Emergency = 0
        Alert = 1
        Critical = 2
        Errorx = 3
        Warning = 4
        Notification = 5
        Informational = 6
        Debugging = 7
    End Enum

    Public Shared Function Convert_Logging_to_ErrorCode(ByRef ERR As Logging_Levels) As String
        Dim code As String = String.Empty
        Select Case ERR
            Case Logging_Levels.Emergency
                code = "EM"
            Case Logging_Levels.Alert
                code = "A"
            Case Logging_Levels.Critical
                code = "C"
            Case Logging_Levels.Errorx
                code = "E"
            Case Logging_Levels.Warning
                code = "W"
            Case Logging_Levels.Notification
                code = "N"
            Case Logging_Levels.Informational
                code = "I"
            Case Logging_Levels.Debugging
                code = "D"
        End Select
        Return "-" & ERR.ToString & "- " & code
    End Function

    Public Enum DB_Settings_Rows As Integer
        SMon = 1
        IPAddr = 2
        IPPort = 3
        IDBName = 4
        DBName = 5
        DBUrsPwd = 6
        ShowSMon = 7
        Version = 8
        LeagueName = 9
        Week_ID = 10
        Games_Week = 11
        Number_Lanes = 12
    End Enum

    Public Function DB_Setup() As Boolean
        Functions.Log_Write("I", "VDB.DB_Setup")
        SQLQry.Connection = SQLCon
    End Function

    Public Sub DB_Set_Conn()
        Functions.Log_Write("I", "VDB.DB_Set_Conn")
        Dim ip As String = IPAddr(0) & "." & IPAddr(1) & "." & IPAddr(2) & "." & IPAddr(3)
        Dim provider As String = ""

        If SMV = "Vector" Then
            'Data Source=192.168.137.200\vectorplus;Persist Security Info=True;User ID=tbld;Password=tbld;Initial Catalog=VectorPlus;"
            provider = "Provider=SQLOLEDB;"
        Else
            'AMF
            'Not Supported
            provider = ""
        End If
        Dim con As String = provider & "Data Source=" & ip & "\" & IPName.ToUpper & ";Persist Security Info=True;Password=" & DBUsrPsw(2) & ";User ID=" & DBUsrPsw(1) & ";Initial Catalog=" & DBUsrPsw(0)
        SQLCon.ConnectionString = con
    End Sub

    Public Function DB_Open() As Boolean
        Functions.Log_Write("I", "VDB.DB_Open")
        Try
            If SQLCon.State = ConnectionState.Closed Then
                Functions.Log_Write("S", "VDB.DB_Open", "Opening DB")
                SQLCon.Open()
                Return True
            Else
                Functions.Log_Write("W", "VDB.DB_Open", "DB Already Open")
                Return False
            End If
        Catch ex As Exception
            Functions.Log_Write("E", "VDB.DB_Open", "Error Opening DB Connection: " & ex.Message)
            Return False
        End Try
    End Function

    Public Sub DB_Close()
        SQLCon.Close()
    End Sub

    Public Function DB_Settings_Update(ByRef setting As String, ByRef id As Integer) As Boolean
        Functions.Log_Write("I", "VDB.DB_Settings_Update")
        Dim upd As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Lineup_Update_By_ID(id, setting)
        If Not upd.ERR Then
            Functions.Log_Write("S", "VDB.DB_Settings_Update", "Updated setting (" & id & ")")
            Return True
        Else
            Functions.Log_Write("E", "VDB.DB_Settings_Update", "Error updateing setting (" & id & "): " & upd.ERRMsg)
            Return False
        End If
    End Function

    Public Function DB_Settings_Insert(ByRef setting As String) As Boolean
        Functions.Log_Write("I", "VDB.DB_Settings_Insert")
        Dim ins As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Lineup_Insert(setting)
        If Not ins.ERR Then
            Functions.Log_Write("S", "VDB.DB_Settings_Insert", "Inserted setting (" & setting & ")")
            Return True
        Else
            Functions.Log_Write("E", "VDB.DB_Settings_Insert", "Error inserting setting (" & setting & ")")
            Return False
        End If
    End Function

    Public Function DB_Settings_Get(ByRef row As VDB.DB_Settings_Rows) As String
        Functions.Log_Write("I", "VDB.DB_Settings_Get")
        Dim gets As TBDB.DB_Structure.Lineup_Get_Setting_By_ID = TBDB.DBLnkr.DB_Program.Lineup_Get_Setting_By_ID(row)
        If gets._ERRMsg = Nothing Then
            'no error
            Functions.Log_Write("S", "VDB.DB_Settings_Get", "Grabbed setting for: " & row)
            Return gets.Setting
        Else
            'error
            Functions.Log_Write("E", "VDB.DB_Settings_Get", "Error getting setting for: " & row & " : " & gets._ERRMsg)
            Return ""
        End If
    End Function

    Public Function DB_Settings_Load(Optional ByRef show As Boolean = True) As Boolean
        Try
            'Load Settings
            SMV = DB_Settings_Get(DB_Settings_Rows.SMon)
            Dim ipx As String() = DB_Settings_Get(DB_Settings_Rows.IPAddr).Split(".")
            IPAddr(0) = ipx(0)
            IPAddr(1) = ipx(1)
            IPAddr(2) = ipx(2)
            IPAddr(3) = ipx(3)
            IPPort = DB_Settings_Get(DB_Settings_Rows.IPPort)
            IPName = DB_Settings_Get(DB_Settings_Rows.IDBName)
            DBUsrPsw(0) = DB_Settings_Get(DB_Settings_Rows.DBName)
            Dim usrpwd As String() = DB_Settings_Get(DB_Settings_Rows.DBUrsPwd).Split(",")
            DBUsrPsw(1) = usrpwd(0)
            DBUsrPsw(2) = usrpwd(1)
            ChkSMon = DB_Settings_Get(DB_Settings_Rows.ShowSMon)
            DB_Set_Conn()
            If show Then
                Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Set_Load_OK)
            End If
            Return True
        Catch ex As Exception
            Main.ERS.Get_Error(Errors.Err_Codes.Vector_Settings_Set_Load_ERR)
            Return False
        End Try
    End Function

    Public Function DB_Settings_Save() As Boolean
        Functions.Log_Write("I", "VDB.DB_Settings_Save")
        Try
            DB_Settings_Update(SMV, DB_Settings_Rows.SMon)
            Dim ip As String = IPAddr(0) & "." & IPAddr(1) & "." & IPAddr(2) & "." & IPAddr(3)
            DB_Settings_Update(ip, DB_Settings_Rows.IPAddr)
            DB_Settings_Update(IPPort, DB_Settings_Rows.IPPort)
            DB_Settings_Update(IPName, DB_Settings_Rows.IDBName)
            DB_Settings_Update(DBUsrPsw(0), DB_Settings_Rows.DBName)
            DB_Settings_Update(DBUsrPsw(1) & "," & DBUsrPsw(2), DB_Settings_Rows.DBUrsPwd)
            DB_Settings_Update(ChkSMon, DB_Settings_Rows.ShowSMon)
            DB_Set_Conn()
            Functions.Log_Write("S", "VDB.DB_Settings_Save", "Saved Settings")
            Return True
        Catch ex As Exception
            Functions.Log_Write("E", "VDB.DB_Settings_Save", "Error saving settings: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Test_Conn() As Boolean
        Functions.Log_Write("I", "VDB.Test_Conn")
        Try
            DB_Open()
            If SMV = "Vector" Then
                SQLQry = New OleDbCommand("SELECT COUNT(*) AS Cnt FROM dbo.GameData", SQLCon)
            Else
                'AMF
                'Not Supported
            End If
            Return IIf(SQLQry.ExecuteScalar() > 0, True, False)
        Catch ex As Exception
            MsgBox("ERROR")
            Return False
        End Try
    End Function

    Public Function Find_Last_Bowler(ByRef bowler As String) As String
        Dim ret As String = ""

        If SMV = "Vector" Then
            'Brunswick
            query = "SELECT Name, Lane, SeriesGameNumber, TotalScratchScore, Strikes, Spares, Splits, SplitConversions, CompletionDate " & _
                    "FROM dbo.GameData " & _
                    "WHERE (Name = '" & bowler & "') " & _
                    "ORDER BY SessionID DESC, SeriesGameNumber"
            SQLQry = New OleDbCommand(query, SQLCon)
        Else
            'AMF
            'Not Supported
        End If
        DB_Open()

        Dim reader As OleDbDataReader = SQLQry.ExecuteReader()
        'Check for Rows
        If reader.HasRows Then
            While reader.Read()
                ret &= reader(0) & "," & reader(1) & "," & reader(2) & "," & reader(3) & "," & reader(4) & "," & reader(5) & "," & reader(6) & "," & reader(7) & "," & reader(8) & "|"
            End While
        End If
        'Close Connection
        reader.Close()

        Return ret
    End Function

    Public Function Lane_Ers_Month(ByRef lane As String, ByRef start_date As String, ByRef end_date As String) As String
        Dim ret As String = ""

        'Get Lane Error Counts
        If SMV = "Vector" Then
            'Brunswick
            query = "SELECT TOP 100 PERCENT P1 AS Lane, Title AS Error, COUNT(Title) AS Count " & _
                "FROM dbo.AppLog " & _
                "WHERE (P1 = '" & lane & "') AND (NOT (Title = 'pinsetter alive')) AND (NOT (Title = 'pinsetter unit alive')) AND (NOT (Title = 'Reboot Scoring Computer')) AND (NOT (Title = 'Scorer started')) " & _
                "AND (NOT (Title LIKE 'CDE%')) AND (NOT (Title = 'Bumper Emergency Notification')) AND (NOT (Title = 'Copying of the Backed-Up Databases')) AND " & _
                "(NOT (Title = 'Database Preparation Task')) AND (NOT (Title = '--')) AND (NOT (Title = 'GS Set last pins')) AND (NOT (Title LIKE 'Warning in %')) AND AppLogDate BETWEEN '" & start_date & " 12:00:00 AM' AND '" & end_date & " 11:59:59 PM' " & _
                "GROUP BY P1, Title " & _
                "ORDER BY P1, Title"
            SQLQry = New OleDbCommand(query, SQLCon)
        Else
            'AMF
            'Not Supported
        End If
        DB_Open()

        Dim reader As OleDbDataReader = SQLQry.ExecuteReader()
        'Check for Rows
        If reader.HasRows Then
            While reader.Read()
                ret &= reader(0) & "," & reader(1) & "," & reader(2) & "|"
            End While
        End If
        'Close Connection
        reader.Close()

        Return ret
    End Function

End Class
