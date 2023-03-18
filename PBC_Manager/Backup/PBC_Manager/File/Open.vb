Public Class Open

    Private DBpath As String = Main.Gen.Get_Local_Path() & "DataBase"
    Private FileTmp As String()

    Private Sub Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenFiles(DBpath)
    End Sub

    Private Sub OpenFiles(ByVal dir_name As String)
        'Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)
        Dim file_name As String
        Dim files As Collection
        Dim i As Integer

        ' Get a list of files it contains.
        files = New Collection
        file_name = Dir$(dir_name & "\*.accdb", vbReadOnly + vbHidden + vbSystem + vbDirectory)
        Do While Len(file_name) > 0
            If (file_name <> "..") And (file_name <> ".") Then
                files.Add(dir_name & "\" & file_name)
            End If
            file_name = Dir$()
        Loop

        ' Delete the files.
        For i = 1 To files.Count
            file_name = files(i)
            FileTmp = file_name.Split("\DataBase\")
            FileTmp = FileTmp(FileTmp.Count() - 1).Split(".")
            If Not FileTmp(0) = "PBC" Then
                DBBox.Items.Add(FileTmp(0))
            End If
            ' See if it is a directory.
            'If GetAttr(file_name) And vbDirectory Then
            ' It is a directory. Delete it.
            'RmDir(file_name)
            'Else
            ' It's a file. Delete it.
            'MsgBox(file_name)
            'SetAttr(file_name, vbNormal)
            'Kill(file_name)
            'End If
        Next i
        ' The directory is now empty. Delete it.
        'RmDir(dir_name)
    End Sub

    Private Sub Open_DB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Open_DB.Click
        If DBBox.Text.Length > 0 Then
            Main.Gen.Open_DB(DBBox.Text)
        Else
            DBBox.Focus()
        End If
    End Sub
End Class