Namespace Web
    Public Class ElevatedController
        Inherits System.Web.Mvc.Controller

        Private SSF As New Core.SSFunctions
        Private SR As New Core.Repository.Settings

        <ChildActionOnly>
        Function AdminLinks() As ViewResult
            Return View()
        End Function

        <ChildActionOnly>
        Function DecisionerLinks() As ViewResult
            Return View()
        End Function

        <Authorize(Roles:="Decision")>
        Function Decision() As ActionResult
            Return View(New BooleanModel With {.Bool = SR.Get("Setting.DrawingEnabled").Value})
        End Function

        <HttpPost>
        <Authorize(Roles:="Decision")>
        Function Decision(ByVal made_decision As Boolean) As ActionResult
            Dim res As Boolean = SSF.AssignUsers()
            SR.Set("Setting.DrawingEnabled", res)
            Return View(New BooleanModel With {.Bool = res})
        End Function

        <Authorize(Roles:="Admin")>
        Function NewYear() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <Authorize(Roles:="Admin")>
        Function NewYear(ByVal reg As Date) As ActionResult
            SSF.NewYear(reg, reg.Year)
            Return RedirectToAction("Admin")
        End Function

        <Authorize(Roles:="Admin")>
        Function History() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="Admin")>
        Function SecretList() As ActionResult
            Return View("SecretList", SSF.GetSecretSantas(SR.Get("Setting.Year").Value))
        End Function

        <Authorize(Roles:="Admin")>
        Function EnteredUsers() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="Admin")>
        Function UserRoles() As ActionResult
            Return View()
        End Function

    End Class
End Namespace
