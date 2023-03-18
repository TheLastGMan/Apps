Namespace Web
    Public Class RSSController
        Inherits System.Web.Mvc.Controller

        Private RSSR As New Core.Repository.RSS

        Function RegisteredUsers() As ActionResult
            Return View("StrXml", DirectCast(RSSR.RegisteredUsers, Object))
        End Function

        Function AssignedUsers() As ActionResult
            Return View("StrXml", DirectCast(RSSR.AssignedUsers, Object))
        End Function

    End Class
End Namespace
