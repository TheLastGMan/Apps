Public Class Settings

    Public Shared _ITournament As TBDB.ITournament
    Public Shared _TrnLst As New ArrayList
    Public Shared _TrnNme As String

    Public Shared Function Get_TrnLstClass(ByVal desc As String) As String
        Dim tclass As String = ""
        For i As Integer = 1 To _TrnLst.Count
            If _TrnLst(i - 1) = desc Then
                tclass = _TrnLst(i)
                Exit For
            End If
        Next
        Return tclass
    End Function

    Public Shared Sub GetLeagueName(ByRef lgName As String)
        lgName = Get_League_Name()
    End Sub

    Public Shared Function Get_League_Name() As String
        Functions.Log_Write("I", "Settings.load_league_name", "")
        Dim league As TBDB.DB_Structure.Lineup_Get_Setting_By_ID = TBDB.DBLnkr.DB_Program.Lineup_Get_Setting_By_ID(VDB.DB_Settings_Rows.LeagueName)
        If league._ERRMsg = Nothing Then
            'success
            Functions.Log_Write("S", "Settings.load_league_name", "loaded league name")
            Return league.Setting
        Else
            'error
            Functions.Log_Write("E", "Settings.load_league_name", "could not connect to db: " & league._ERRMsg)
            Return "-1"
        End If
    End Function

    '-------------------------------------

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Functions.Log_Write("I", "Settings.Settings_Load", "")
        load_league_name()
        FR.Items.Clear()
        load_external_references_tournaments()
        load_external_references_reports()
    End Sub

    Private Sub load_league_name()
        Functions.Log_Write("I", "Settings.load_league_name", "")
        Dim league As TBDB.DB_Structure.Lineup_Get_Setting_By_ID = TBDB.DBLnkr.DB_Program.Lineup_Get_Setting_By_ID(VDB.DB_Settings_Rows.LeagueName)
        If league._ERRMsg = Nothing Then
            'success
            LeagueName.Text = league.Setting
            Functions.Log_Write("S", "Settings.load_league_name", "loaded league name")
        Else
            'error
            Functions.Log_Write("E", "Settings.load_league_name", "could not connect to db: " & league._ERRMsg)
        End If
    End Sub

    Private Sub load_external_references_tournaments()
        Functions.Log_Write("I", "Settings.load_external_references_tournaments", "")
        Dim TBF As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
        Dim refs As ArrayList = TBF.Search_File("T")
        If refs.Count > 0 Then
            'data
            For Each DBI As TBDB.FileOps.DBClassList In refs
                FR.Items.Add(DBI.Desc)
            Next
            Functions.Log_Write("S", "Settings.load_external_references_tournaments", "loaded tournaments into FR")
        ElseIf refs.Count = 1 Then
            Functions.Log_Write("W", "Settings.load_external_references_tournaments", "no data found")
        Else
            'no data
            Dim DBI As TBDB.FileOps.DBClassList = TBF.Search_File("T")(0)
            Functions.Log_Write("E", "Settings.load_external_references_tournaments", "error grabbing references: " & DBI.CRef)
        End If
    End Sub

    Private Sub load_external_references_reports()
        Functions.Log_Write("I", "Settings.load_external_references_reports", "")
        Dim TBF As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
        Dim refs As ArrayList = TBF.Search_File("R")
        If refs.Count > 0 Then
            'data
            For Each DBI As TBDB.FileOps.DBClassList In refs
                FR.Items.Add(DBI.Desc)
            Next
            Functions.Log_Write("S", "Settings.load_external_references_reports", "loaded reports into FR")
        ElseIf refs.Count = 0 Then
            Functions.Log_Write("W", "Settings.load_external_references_reports", "no data found")
        Else
            'no data
            Dim DBI As TBDB.FileOps.DBClassList = TBF.Search_File("T")(0)
            Functions.Log_Write("E", "Settings.load_external_references_reports", "error grabbing references: " & DBI.CRef)
        End If
    End Sub

    Private Sub AER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AER.Click
        Functions.Log_Write("I", "Settings.AER_Click")
        'add external reference
        Dim type As Char = TOF.Text.Substring(0, 1)
        Dim AX As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
        Dim BDI As New TBDB.FileOps.DBClassList
        BDI.Type = type
        BDI.Desc = DisplayName.Text
        BDI.CRef = AX.Create_Reference_String(AssName.Text, RootNS.Text)
        If Not AX.Exists_Reference(BDI) Then
            'file do not exists, try to add reference
            If AX.Write_Reference(BDI) Then
                'successfully added
                Functions.Log_Write("S", "Settings.AER_Click", "File Reference " & DisplayName.Text & " Added to file")
                DisplayName.ResetText()
                AssName.ResetText()
                NmSpace.ResetText()
                FR.Items.Clear()
                load_external_references_tournaments()
                load_external_references_reports()
            Else
                'failed being added
                Functions.Log_Write("E", "Settings.AER_Click", "File Reference " & DisplayName.Text & " Could not be Added to file")
            End If
        Else
            'reference already exists
            Functions.Log_Write("W", "Settings.AER_Click", "File Reference " & DisplayName.Text & " Already Exists")
        End If
    End Sub

    Private Sub DER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DER.Click
        Functions.Log_Write("I", "Settings.DER_Click")
        'remove external reference
        Dim AX As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
        If AX.Delete_Reference(FR.Text) Then
            'deleted successfully
            Functions.Log_Write("S", "Settings.DER_Click", "Deleted Reference " & FR.Text & " Successfully")
            FR.Items.Clear()
            load_external_references_tournaments()
            load_external_references_reports()
        Else
            'could not be deleted
            Functions.Log_Write("E", "Settings.DER_Click", "Could Not Delete Reference " & FR.Text)
        End If
    End Sub

    Private Sub LeagueName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeagueName.Leave
        Functions.Log_Write("D", "Settings.LeagueName_TextChanged")
        'update league name
        Dim upd As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Lineup_Update_By_ID(VDB.DB_Settings_Rows.LeagueName, LeagueName.Text)
        If Not upd.ERR Then
            'successful
            Functions.Log_Write("S", "Settings.LeagueName_TextChanged", "Updated ID:" & VDB.DB_Settings_Rows.LeagueName & " with value: " & LeagueName.Text)
        Else
            'failure
            Functions.Log_Write("E", "Settings.LeagueName_TextChanged", "Could not update ID: " & VDB.DB_Settings_Rows.LeagueName & " with value " & LeagueName.Text & " := " & upd.ERRMsg)
        End If
    End Sub

End Class
