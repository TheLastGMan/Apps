Imports System.Net.Mail
Imports System.Net.Mime
Public Class Form1

    Private insMail As New MailMessage()
    Private smtp As New SmtpClient()
    Private recips As String()
    Private SETS As New Settings

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SETS.load_settings()
        'For i = 0 To IPa.GetUpperBound(0)
        'MsgBox("IP Addr " & i & " : " & IPa(i).ToString)
        'Next
    End Sub

    Private Sub Send1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Send1.Click
        insMail.IsBodyHtml = True
        insMail.BodyEncoding = System.Text.Encoding.UTF8
        insMail.Subject = Subject1.Text
        insMail.Body = Message1.Text
        'insMail.ReplyTo = New MailAddress("pepse25@msn.com")
        'insMail.Headers.Add("X-SID-PRA:", "6514083385@VTEXT.COM")
        If get_sender() And get_recips() Then
            Dim smtp As New SmtpClient
            Dim creds As New System.Net.NetworkCredential(SETS.Username, SETS.Password)
            With smtp
                .Host = SETS.Server
                .Port = SETS.Port
                .DeliveryMethod = SmtpDeliveryMethod.Network
                .Credentials = creds
            End With
            Try
                smtp.Send(insMail)
                MsgBox("Message Sent")
                Message1.Text = ""
                Subject1.Text = ""
                To1.Text = ""
                To1.Focus()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Sytax Error in Email Addresses")
        End If
    End Sub

    Private Function get_sender() As Boolean
        Dim sender As String() = From1.Text.Split(";")
        With sender(0)
            If .Contains("@") And .Contains(".") And .Substring(.IndexOf("@"), .Length - .IndexOf("@")).Contains(".") Then
                insMail.From = New MailAddress(sender(0))
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function get_recips() As Boolean
        Dim ret As Boolean = False
        insMail.To.Clear()
        Dim recips As String() = To1.Text.Split(";")
        For i = 0 To recips.GetUpperBound(0)
            insMail.To.Add(New MailAddress(recips(i)))
            ret = True
        Next
        Return ret
    End Function

    Private Sub Message1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Message1.KeyUp
        'TxtCnt.Value = Message1.MaxLength - Message1.Text.Length
    End Sub
    Private Sub Message1_TextChage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Message1.TextChanged
        TxtCnt.Value = Message1.MaxLength - Message1.Text.Length
    End Sub
End Class
