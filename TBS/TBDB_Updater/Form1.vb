Public Class Form1

    'Set Vars
    Public TB1 As String = My.Application.Info.DirectoryPath & "\Tourney_Builder_1.exe"
    Public TB As String = My.Application.Info.DirectoryPath & "\Tourney_Builder.exe"
    Public http_base As String = "http://www.delibeads.com/z_tbs/"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Disable Timer
        Timer1.Enabled = False

        Dim cmd As String() = Command.Split(" ")
        For i As Byte = 0 To cmd.Length - 1
            MsgBox(cmd(i))
        Next
        If cmd.Length = 2 Then
            'valid array
            Select Case cmd(0)
                Case "-u"
                    'update
                    Process_Update(cmd(1))
                    Process_SQL()
                    Copy_Files()
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Process_Update(ByVal latest_version As String)
        'download updates to latest version
        '-get latest versions from tb.ver

        'loop through file list
        'for xxx
        '-get file list from version folder on website


        '-download files from web version folder

        'next
    End Sub

    Private Sub Process_SQL()
        'download sql file from version folder on website


        'go line by line, executing sql command

    End Sub

    Private Sub Copy_Files()
        'copy files in temp to main dir, overwrite as necessary


        'Copy Tourney_Builder_1.exe to Tourney_Builder.exe
        System.IO.File.Copy(TB1, TB)

        'Delete Tourney_Builder_1.exe
        System.IO.File.Delete(TB1)

        'Delete Temp Folder
        System.IO.Directory.Delete(My.Application.Info.DirectoryPath & "\temp", True)

        'Execute Tourney_Builder.exe
        Process.Start(TB)

        'Shut Me Down
        Me.Close()
    End Sub
End Class
