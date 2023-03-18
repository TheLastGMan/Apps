Namespace Web
    Public Class AccountController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Account

        Private SM As New SessionManager

        <ChildActionOnly>
        Function Auth() As ActionResult
            Dim model As New FBModel
            model.FBAppId = FBAppId

            If User.Identity.IsAuthenticated Then
                model.Profile = New Core.SSFunctions().GetUsersInfo(User.Identity.Name, SM.AccessToken)
            End If

            Return View("FBAuth", model)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function AuthPost(ByVal AccessToken As String) As ActionResult
            'get fb info
            LogIn(AccessToken)
            Return RedirectToAction("", "Home")
        End Function
        'Function AuthPost(ByVal FB_ID As String, ByVal AccessToken As String) As ActionResult

        <NonAction>
        Private Sub LogIn(ByRef authtoken As String)
            'Dim info As Core.FB.Result.FBResponse = New Core.FB.FBRepository().GetEmpInfo(FB_ID, AccessToken)
            Try
                Dim info As Core.FB.Result.FBResponse = New Core.FB.FBRepository().GetEmpInfo(authtoken)
                'register user
                Dim reg As Boolean = New Core.Repository.User().AddUser(info.id, info.name, info.username)

                If reg Then
                    FormsAuthentication.SetAuthCookie(info.id, False)
                    SM.AccessToken = authtoken
                End If
            Catch ex As Exception
                'invalid access token
                'Throw New Exception("AccessToken Validation Error : for (" & authtoken & ")")
                LogOut()
            End Try
        End Sub

        <HttpPost>
        Function FacebookManual() As ViewResult
            Response.Redirect(FBAuthUrl)
            Return Nothing
        End Function

        Function FacebookReturn(ByVal code As String, Optional ByVal expires_in As String = "60") As ActionResult
            'successful request
            Dim req = Request
            If Not String.IsNullOrEmpty(code) AndAlso code.Length > 0 Then
                LogIn(code)
            End If
            Return RedirectToAction("", "Home")
        End Function

        Function LogOut() As ActionResult
            FormsAuthentication.SignOut()
            SM.AccessToken = Nothing
            Return RedirectToAction("", "Home")
        End Function

        Private ReadOnly Property FBAuthUrl As String
            Get
                Dim baseurl As String = New Core.Repository.Settings().Get("BaseUrl").Value
                Dim SB As New StringBuilder
                SB.Append("https://www.facebook.com/dialog/oauth")
                SB.Append("?client_id=" & FBAppId)
                SB.Append("&redirect_uri=" & baseurl & "/FacebookReturn")
                SB.Append("&scope=user_work_history")
                SB.Append("&response_type=token")
                Return SB.ToString
            End Get
        End Property

        Private ReadOnly Property FBAppId As String
            Get
                Return ConfigurationManager.AppSettings("FB_App_Id")
            End Get
        End Property

    End Class
End Namespace
