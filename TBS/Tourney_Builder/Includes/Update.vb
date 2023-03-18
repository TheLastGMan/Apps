Public Class Updates

    Public Shared Versions As New ArrayList
    Public Shared WebSite As String = "http://www.delibeads.com/z_tbs/"

    Public Shared Function Check_For_Update() As String
        'Try
        Dim update_available As Boolean = False
        Get_Versions()
        'Store Version into Array
        Dim FUNC As New Functions
        'First line is the latest version
        'If Not Get_Hash(Versions(0).ToString) = Get_Hash(Functions.version) Then
        If Not Versions(0).ToString = Functions.version Then
            'update available
            update_available = True
        End If
        Return update_available.ToString
        'Catch ex As Exception
        'Return ex.Message
        'End Try
    End Function

    Private Shared Sub Get_Versions()
        'Download Update File
        My.Computer.Network.DownloadFile(WebSite & "versions.txt", My.Application.Info.DirectoryPath & "\tb.ver", "", "", True, 30, True)
        Dim UPFile As New IO.StreamReader(My.Application.Info.DirectoryPath & "\tb.ver", True)
        'add versions to list as long as it is not the same version
        While UPFile.Peek <> -1
            Dim fver As String = UPFile.ReadLine()
            If Not Functions.version = fver Then
                Versions.Add(UPFile.ReadLine())
            Else
                Versions.Add(UPFile.ReadLine())
                Exit While
            End If
        End While
        UPFile.Close()
    End Sub

    Public Shared Function Process_Update() As Boolean
        Dim update_success As Boolean = False

        'Versions are stored in order Newest to Oldest

        Return update_success
    End Function

    Public Shared Function Download_File(ByVal file_src As String, ByVal file_dest As String) As Boolean
        Dim download_success As Boolean = False

        Dim dir As String = My.Application.Info.DirectoryPath & "\"
        My.Computer.Network.DownloadFile(WebSite & file_src, dir & file_dest, "", "", True, 30, True)

        Return download_success
    End Function

    Private Shared Function Get_Hash(ByVal str As String) As String
        Dim HASH As New System.Security.Cryptography.SHA1Managed
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(str)
        Return Encoding.UTF8.GetString(HASH.ComputeHash(bytes))
    End Function

    Public Shared Function Download_Network_File(ByVal url As String, ByVal file As String, ByVal version As String, ByVal dest As String) As Boolean
        Try
            My.Computer.Network.DownloadFile(url & "\" & version & "\" & file, dest, "", "", True, 5, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Copy_File(ByVal source As String, ByVal dest As String) As Boolean
        Try
            IO.File.Copy(source, dest, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Create_Folder(ByVal path As String) As Boolean
        Try
            IO.Directory.CreateDirectory(path)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
