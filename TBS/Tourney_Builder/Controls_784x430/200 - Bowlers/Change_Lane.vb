Imports System.Windows.Forms

Public Class Change_Lane

    Private Sub Change_Lane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Functions.Log_Write("I", "Change_Lane.Change_Lane_Load")
        Load_Lanes()
        Get_Bowler_Name()
        Lane_Pick.SelectedIndex = 0
    End Sub

    Private Sub Get_Bowler_Name()
        Functions.Log_Write("I", "Change_Lane.Get_Bowler_Name")
        Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(Bowler_Info._BID)
        If ret(0) = "-1" Then
            'error
            Functions.Log_Write("E", "Change_Lane.Get_Bowler_Name", "error loading bowler name: " & ret(1))
            BName.Text = "N/A"
        Else
            Functions.Log_Write("S", "Change_Lane.Get_Bowler_Name", "retreived bowler name")
            BName.Text = ret(1) & " " & ret(2)
        End If
    End Sub

    Private Function Load_Lanes() As Boolean
        Functions.Log_Write("I", "Change_Lane.Load_Lanes")
        Lane_Pick.Items.Clear()
        Dim lanes As List(Of TBDB.DB_Structure.Lanes_Get) = TBDB.DBLnkr.DB_Program.Lanes_Get()
        If lanes(0)._ERRMsg = Nothing Then
            'data
            For Each i As TBDB.DB_Structure.Lanes_Get In lanes
                Lane_Pick.Items.Add(i.Lane)
            Next
            Lane_Pick.SelectedIndex = IIf(Lane_Pick.Items.Count > 0, 0, -1)
            Functions.Log_Write("S", "Change_Lane.Load_Lanes", "loaded lanes")
            Return True
        Else
            Functions.Log_Write("E", "Change_Lane.Load_Lanes", "could not load lanes: " & lanes(0)._ERRMsg)
            Return False
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Functions.Log_Write("I", "Change_Lane.Button1_Click")
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Okay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Okay.Click
        Functions.Log_Write("I", "Change_Lane.Okay_Click")
        'Bowler_ID, Week_ID, Lane_Number
        Dim update As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Scores_Lane_Update_By_BID_WKID(Bowler_Info._BID, Weeks._WkID, Lane_Pick.Text)
        If Not update.ERR Then
            'success
            Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Change_Lane_OK)
            Functions.Log_Write("S", "Change_Lane.Okay_Click", "changed lanes")
        Else
            'error
            Functions.Log_Write("E", "Change_Lane.Okay_Click", "error changing lanes: " & update.ERRMsg)
            Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Change_Lane_ERR)
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class
