Imports System.Web
Namespace Repository

    Public Class RSS

        Private SSI As New SSInfo()
        Private SSF As New SSFunctions()
        Private SR As New Settings()

        Public Function RegisteredUsers() As String
            'setup
            Dim RSS As New RSSGenerator.Template.Channel("PINZ Secret Santa", SR.Get("BaseUrl").Value, "Secret Santa Has Arrived")
            RSS.pubDate = Now
            RSS.lastBuildDate = RSS.pubDate
            RSS.copyright = Now.Year
            RSS.ttl = 15

            Dim lst As List(Of Entity.User) = SSF.RegisteredUsers(SR.Get("Setting.Year").Value)
            For Each usr In lst
                Dim SB As New Text.StringBuilder
                SB.AppendLine("<div style=""font-size:16px;"">ID : " & usr.FB_Id & "</div>")
                SB.AppendLine("<div style=""font-size:16px;"">Name : " & usr.Name & "</div>")
                SB.AppendLine("<div style=""font-size:16px;"">UsrName : " & usr.UserName & "</div>")

                Dim item As New RSSGenerator.Template.ChannelItem(usr.Name, "http://www.facebook.com/" & usr.FB_Id, HttpUtility.HtmlEncode(SB.ToString))
                item.guid = New RSSGenerator.Template.guid(Guid.NewGuid.ToString)
                item.pubDate = RSS.pubDate
                RSS.Items.Add(item)
            Next

            Return RSS.Make.RSSFeed
        End Function

        Public Function AssignedUsers() As String
            'setup
            Dim RSS As New RSSGenerator.Template.Channel("PINZ Secret Santa", SR.Get("BaseUrl").Value, "Secret Santa Has Arrived")
            RSS.pubDate = Now
            RSS.lastBuildDate = RSS.pubDate
            RSS.copyright = Now.Year
            RSS.ttl = 15

            Dim lst As List(Of SecretSantas) = SSF.GetSecretSantas(SR.Get("Setting.Year").Value)
            Dim alst As New List(Of Long)

            Dim usr As Core.SecretSantas = lst(0)
            For i As Integer = 1 To lst.Count
                usr = lst(i - 1)

                Dim SB As New Text.StringBuilder
                SB.AppendLine("<div style=""font-size:16px;"">G-ID : " & usr.Giver.FB_Id & "</div>")
                SB.AppendLine("<div style=""font-size:16px;"">G-Name : " & usr.Giver.Name & "</div>")
                If usr.Receiver IsNot Nothing Then
                    SB.AppendLine("<div style=""font-size:16px;"">R-ID : " & usr.Receiver.FB_Id & "</div>")
                    SB.AppendLine("<div style=""font-size:16px;"">R-Name : " & usr.Receiver.Name & "</div>")
                Else
                    SB.AppendLine("<div style=""font-size:16px;"">Receiver Unknown At This Time</div>")
                End If

                Dim item As New RSSGenerator.Template.ChannelItem(usr.Giver.Name, "http://www.facebook.com/" & usr.Giver.FB_Id, HttpUtility.HtmlEncode(SB.ToString))
                item.guid = New RSSGenerator.Template.guid(Guid.NewGuid.ToString)
                item.pubDate = RSS.pubDate.AddSeconds(-1 * i)
                RSS.Items.Add(item)

                alst.Add(usr.Giver.FB_Id)

                'If Not alst.Contains(usr.Receiver.FB_Id) Then
                '    'continue with grouping
                '    usr = lst.Where(Function(f) f.Giver.FB_Id = usr.Receiver.FB_Id).Single
                'Else
                '    'unknown 
                'End If
            Next

            Return RSS.Make.RSSFeed
        End Function

    End Class

End Namespace
