Public Class Updater

    'SQL Params for Version Updates
    'Private SqlCon As New OleDb.OleDbConnection(My.Settings.TBConnectionString)
    'Private SqlCmd As OleDbCommand
    'Public Sub Check_Version()
    '    'Checks and Updates DB when necessary
    '    Dim Cver As String = ""
    '    Dim Cvers As String() = {""}

    '    Try
    '        'Check to See If We Can Get Version
    '        'ALWAYS Last Row In Table
    '        Dim TDB As New TBDataSet.LineupDataTable
    '        Main.DB.LINKA.Fill(TDB)
    '        Cver = Main.VDB.DB_Settings_Get(TDB.Rows.Count)
    '        Cvers = Cver.Split(".")
    '    Catch ex As Exception
    '        '-No Version Found, Update DataBase, old ver only has 2 rows
    '        Dim ip As String = Main.VDB.IPAddr(0) & "." & Main.VDB.IPAddr(1) & "." & Main.VDB.IPAddr(2) & "." & Main.VDB.IPAddr(3)
    '        Main.VDB.DB_Settings_Update(Main.VDB.SMV, 1)
    '        Main.VDB.DB_Settings_Update(ip, 2)
    '        Main.VDB.DB_Settings_Insert(Main.VDB.IPPort)
    '        Main.VDB.DB_Settings_Insert(Main.VDB.DBUsrPsw(0))
    '        Main.VDB.DB_Settings_Insert(Main.VDB.DBUsrPsw(1) & "," & Main.VDB.DBUsrPsw(2))
    '        Main.VDB.DB_Settings_Insert("0")
    '        Main.VDB.DB_Settings_Insert("3.1.1.0")
    '        Cver = "3.1.1.0"
    '        Cvers = Cver.Split(".")
    '    End Try

    '    'Have Version Check it for possible updates

    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "1" And Cvers(3) < "5" Then
    '        'Move to Version 3.1.1.5
    '        Try
    '            'Add (Series, Start_Lane) to Weeks
    '            '-Prepare for SMon Support
    '            SqlCon.Open()
    '            SQL_Exec("ALTER TABLE Weeks ADD COLUMN SSeries Number[Integer];")
    '            SQL_Exec("ALTER TABLE Weeks ADD COLUMN STLane Number[Integer];")
    '            SQL_Exec("ALTER TABLE Scores ADD COLUMN BAlias TEXT[64];")
    '            SQL_Exec("UPDATE Weeks SET SSeries=600, STLane=17;")
    '            SqlCon.Close()

    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.1.5", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.1.5 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.1.5 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "1" And Cvers(3) < "7" Then
    '        '3.1.1.6 [NO DB Changes]
    '        '-Added (Bowler History) => 3 Game Statistics
    '        '3.1.1.7
    '        Try
    '            'Update VDB to include [I]nternal DB Name
    '            Main.VDB.DB_Settings_Insert("0")
    '            '4->5|5->6|6->7|7->8
    '            Main.VDB.DB_Settings_Update(Main.VDB.DB_Settings_Get(7), 8)
    '            Main.VDB.DB_Settings_Update(Main.VDB.DB_Settings_Get(6), 7)
    '            Main.VDB.DB_Settings_Update(Main.VDB.DB_Settings_Get(5), 6)
    '            Main.VDB.DB_Settings_Update(Main.VDB.DB_Settings_Get(4), 5)
    '            Main.VDB.DB_Settings_Update(Main.VDB.IPName, VDB.DB_Settings_Rows.IDBName)
    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.1.7", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.1.7 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.1.6 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "1" And Cvers(3) < "8" Then
    '        '3.1.1.8
    '        '=Fixed PageBreak under "Weekly Scoresheet"
    '        Try
    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.1.8", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.1.8 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.1.8 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) < "2" Then
    '        '3.1.2.0
    '        'Added Ability to Change number of games
    '        Try
    '            '-Mod DB for Num of Games For Week
    '            SqlCon.Open()
    '            SQL_Exec("ALTER TABLE Scores ALTER COLUMN Scores Text(128);")
    '            SQL_Exec("ALTER TABLE Weeks ADD COLUMN NGames Number[Byte];")
    '            SQL_Exec("UPDATE Weeks SET NGames=4;")
    '            SqlCon.Close()

    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.2.0", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.2.0 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.2.0 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "2" And Cvers(3) < "1" Then
    '        '3.1.2.1
    '        '=Fixed weekly scoresheet display with more than 4 games
    '        '=Fixed Yearly average to include all games bowled instead of 4 every week (TODO)
    '        Try
    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.2.1", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.2.1 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.2.1 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "2" And Cvers(3) < "2" Then
    '        '3.1.2.2
    '        '=Fixed Removeing Bowler From Lane
    '        '=Updated Transfering Bowler To Different Lane
    '        Try
    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.2.2", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.2.2 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.2.2 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    If Cvers(0) <= "3" And Cvers(1) <= "1" And Cvers(2) <= "2" And Cvers(3) < "3" Then
    '        '3.1.2.3
    '        '=Minor Code Update
    '        Try
    '            'Update DB Version
    '            Main.VDB.DB_Settings_Update("3.1.2.3", VDB.DB_Settings_Rows.Version)
    '            Main.Error_Status.Text = "DB Updated to Version 3.1.2.3 [" & Errors.Err_Codes.DB_Update_OK & "]"
    '            Main.Error_Status.BackColor = Main.ERS.OK
    '        Catch ex As Exception
    '            Main.Error_Status.Text = "Error Updating DB to Version 3.1.2.3 [[[" & Errors.Err_Codes.DB_Update_ERR & "]]]"
    '            Main.Error_Status.BackColor = Main.ERS.ERR
    '            MsgBox("Error Updateing DB, Program Errors May Occur" & Chr(13) & "Contact Programmer For Help Solving Problem", MsgBoxStyle.OkOnly, "PROGRAM ERROR")
    '        End Try
    '    End If
    '    Main.VDB.DB_Settings_Load(False)
    'End Sub

    'Public Sub SQL_Exec(ByVal query As String)
    '    SqlCmd = New OleDbCommand(query, SqlCon)
    '    SqlCmd.ExecuteNonQuery()
    'End Sub



End Class
