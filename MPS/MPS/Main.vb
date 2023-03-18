Public Class Main

    Public ERS As New Errors
    Public DB As New DB
    Public FUNC As New Functions

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Info_Status.TextAlign = ContentAlignment.MiddleCenter
        Info_Status.Text = "By: Ryan Gau  " & Chr(169) & "2010  |  Version - 1.0.0.0"
        FUNC.load_default()
        ERS.Get_Error(Errors.Err_Codes.Main_Load_OK)
    End Sub

    Public Sub Drill_Sheet(Optional ByVal override As Boolean = False)
        FUNC.Cont = New Drill_Sheet
        FUNC.Change_Cont(override)
    End Sub

    Public Sub Search(Optional ByVal override As Boolean = False)
        FUNC.Cont = New Search
        FUNC.Change_Cont(override)
    End Sub

    Private Sub Main_Close(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Leave, MyBase.Disposed
        My.Settings.Save()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DrillSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrillSheetToolStripMenuItem.Click
        Drill_Sheet()
    End Sub

    Private Sub RestoreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem1.Click
        Restore.Show()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        SaveDB.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        FUNC.Cont = New settings
        FUNC.Change_Cont()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        FUNC.Cont = New Search
        FUNC.Change_Cont()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If FUNC._PRINTFID = 0 Then
            ERS.Get_Error(Errors.Err_Codes.Print_NOFID_WRN)
        Else
            If My.Settings.PrintWindows Then
                Prints.ShowDialog()
            Else
                FUNC.Cont = New printpage
                FUNC.Change_Cont()
            End If
        End If
    End Sub
End Class
