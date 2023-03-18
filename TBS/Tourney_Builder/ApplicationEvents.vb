Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub App_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'MsgBox("startup")

            Try
                Shell(My.Application.Info.DirectoryPath & "\z_final.bat")
                'Shell(My.Application.Info.DirectoryPath & "\TBDB_Updater.exe -u " & Functions.version, AppWinStyle.MinimizedFocus, True)
            Catch ex As Exception
                'don't care if this fails, debugging
            End Try

            'Set DLL Directory
            'Dim DLLDIR As New AppDomainSetup
            'DLLDIR.PrivateBinPathProbe = IO.Path.Combine(Application.Info.DirectoryPath, "DLL")
            'DLLDIR.PrivateBinPath = IO.Path.Combine(Application.Info.DirectoryPath, "DLL")

            'My.Computer.FileSystem.RenameFile

            '====================
            '== made app a published application, app will check for updates, no need to code =='
            '====================

            'Check File Dependency
            '            Dim file_ary As String() = {"TBDB.dll", "DB\DBClass.txt", "DB\DBClassList.txt"}
            '            Dim cnt As Byte = 0
            '            Dim file_mis As New ArrayList
            '            Dim errors As String = String.Empty

            'FileDependency:
            '            file_mis.Clear()
            '            errors = String.Empty

            '            For i As Byte = 0 To file_ary.Length - 1
            '                If Not File.Exists(Application.Info.DirectoryPath & "\" & file_ary(i)) Then
            '                    errors &= file_ary(i) & ", "
            '                    file_mis.Add(file_ary(i))
            '                End If
            '            Next

            'FileDependencyErrors:
            '            Dim http_base As String = "http://www.delibeads.com/z_tbs/"
            '            If errors.Length > 0 Then
            '                If cnt <= 2 Then
            '                    IO.File.ReadAllBytes("x")
            '                    cnt += 1
            '                    'try downloading file
            '                    For j As Byte = 0 To file_mis.Count - 1
            '                        Updates.Download_Network_File(http_base, file_mis(j), Functions.version, My.Application.Info.DirectoryPath & "\" & file_mis(j))
            '                    Next
            '                    GoTo FileDependency
            '                Else
            '                    MsgBox("File Dependency (" & errors.Substring(0, errors.Length - 2) & ") Not Found" & ChrW(13) & "Program Can Not Load")
            '                End If
            '                e.Cancel = True
            '            End If

            'CheckUpdate:
            '            Try
            '                Dim wr As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(http_base & "versions.txt")
            '                Dim wrp As System.Net.HttpWebResponse = wr.GetResponse()
            '                If wrp.StatusCode = Net.HttpStatusCode.OK Then
            '                    Dim rs As IO.StreamReader = New IO.StreamReader(wrp.GetResponseStream())
            '                    Dim data As String = rs.ReadToEnd()
            '                    Dim vers As String() = data.Split(ChrW(13))
            '                    'file is sorted newest on top - oldest on bottom
            '                    If Not vers(0) = Functions.version Then
            '                        'update exists
            '                        Try
            '                            'My.Computer.Network.DownloadFile(http_base & "TBDB_Updater.exe.web", My.Application.Info.DirectoryPath & "\TBDB_Updater.exe", "", "", True, 30, True)
            '                            If MsgBox("A New Version (" & vers(0) & ") as found, you have version (" & Functions.version & ")" & Chr(13) & "Do you wish to update?", MsgBoxStyle.YesNo, "Update") = MsgBoxResult.Yes Then
            '                                Shell(My.Application.Info.DirectoryPath & "\TBDB_Updater.exe -u " & Functions.version)
            '                                e.Cancel = True
            '                            End If
            '                        Catch ex As Exception
            '                            MsgBox(ex.Message)
            '                            'download of updater.exe failed
            '                        End Try
            '                    Else
            '                        'Delete TBDB_updater if found and tb.ver just in case
            '                        File.Delete(My.Application.Info.DirectoryPath & "\tb.ver")
            '                        File.Delete(My.Application.Info.DirectoryPath & "\TBDB_Updater.exe")
            '                    End If
            '                Else
            '                    MsgBox("web request failed")
            '                End If
            '            Catch ex As Exception
            '                'MsgBox(ex.Message)
            '                'MsgBox("Update Info", MsgBoxStyle.OkOnly, "Error checking for update, might be a problem with a network connection")
            '            End Try
        End Sub

        Private Sub App_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Functions.Log_Write("EM", "Tourney_Builder Shutting Down")
            Functions.Log_Purge()
        End Sub

        Private Sub App_Unhandled(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Functions.Log_Write("I", "UE: " & e.Exception.Message)
            Functions.Log_Purge()
            Dim nl As String = ChrW(13) & "----------------------------------" & ChrW(13)
            If MsgBox("Unhandled Exception [Do You Wish To Continue?]: " & nl & e.Exception.Source & nl & e.Exception.Message & nl & e.Exception.StackTrace, MsgBoxStyle.YesNo, "CRITICAL ERROR") = MsgBoxResult.Yes Then
                e.ExitApplication = False
            Else
                e.ExitApplication = True
            End If
        End Sub

        Private Sub App_NextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

        End Sub

    End Class


End Namespace

