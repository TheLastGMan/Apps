Namespace Web
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        Private SSI As New Core.Repository.SSInfo
        Private SM As New SessionManager
        Private SR As New Core.Repository.Settings

        '
        ' GET: /Home

        Function Index() As ActionResult
            Dim model As New HomeModel() With {.RegistrationDate = SR.RegistrationDate, .WorkLocations = SR.WorkLocation}

            If User.Identity.IsAuthenticated Then
                Try
                    With model
                        .Profile = New Core.SSFunctions().GetUsersInfo(User.Identity.Name, SM.AccessToken)
                        .IsEntered = New Core.Repository.SSInfo().Exists(User.Identity.Name)
                        .AfterRegistrationDate = IIf(Now > SR.RegistrationDate, True, False)
                        .DrawingEnabled = Boolean.Parse(SR.Get("Setting.DrawingEnabled").Value)
                    End With
                Catch ex As Exception
                    Return RedirectToAction("LogOut", "Account")
                End Try
            End If

            Dim ShowView As String = "Index"
            If model.Profile IsNot Nothing AndAlso (model.Profile.works_at_location Or model.IsEntered) Then
                'work at PINZ or (manually entered), check status
                If model.IsEntered And model.AfterRegistrationDate Then
                    'entered and after registration date - show secret santa
                    If model.Profile.seen_ss Then
                        'show their secret santa
                        ShowView = "ShowSecretSanta"
                    Else
                        'have not seen santa, determine option
                        If model.DrawingEnabled Then
                            ShowView = "GetSecretSanta"
                        Else
                            ShowView = "GetSecretSantaHold"
                        End If
                    End If
                ElseIf model.IsEntered And Not model.AfterRegistrationDate Then
                    'entered and not after registration date, show wait screen
                    ShowView = "WaitScreen"
                ElseIf Not model.IsEntered And Not model.AfterRegistrationDate Then
                    'allow registration
                    ShowView = "Registration"
                Else
                    'missed the entry period
                    ShowView = "MissedEntry"
                End If
            Else
                'show work location check failed, check session
                If New SessionManager().AccessToken Is Nothing Then
                    ShowView = "SessionTimeout"
                Else
                    ShowView = "AddWorkLocation"
                End If
            End If
            model.ViewMode = ShowView

            Return View(model)
        End Function

        <Authorize>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GetSecretSanta() As ActionResult
            SSI.SetSeen(User.Identity.Name, True)
            Return RedirectToAction("", "Home")
        End Function

        <Authorize>
        <HttpPost>
        Function EnterSecretSanta() As ActionResult
            SSI.Add(New Core.Entity.SSInfo() With {.FBId = User.Identity.Name})
            Return RedirectToAction("", "Home")
        End Function

        <Authorize>
        <HttpPost>
        Function ChickenOut() As ActionResult
            SSI.Remove(User.Identity.Name)
            Return RedirectToAction("", "Home")
        End Function

        <ChildActionOnly>
        Function RegisteredUsers() As ViewResult
            Dim model As New RegisteredUserModel
            model.Users = New Core.SSFunctions().RegisteredUsers(SR.Get("Setting.Year").Value)
            Return View(model)
        End Function

    End Class
End Namespace
