Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ip As String = "10.14.15.1"
        Dim port As Integer = 23
        Dim timeout As Integer = 10
        Dim session As New ScriptingTelnet(ip, port, timeout)
        Dim connected As Boolean = session.Connect()

        If connected Then
            Try
                session.WaitFor("Username:")
                session.SendAndWait("pepse25", "Password:")
                session.SendAndWait("rustydog08", "#")
                session.SendAndWait("sib", "#")
                MsgBox("Success")
            Catch ex As Exception
                MsgBox("error")
            End Try
        Else
            MsgBox("Error - Connect")
        End If
    End Sub
End Class
