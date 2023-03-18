Public Class SSFunctions

    Private UR As New Repository.User
    Private SSR As New Repository.SSInfo
    Private SR As New Repository.Settings

    Public Function GetUsersInfo(ByRef fbid As Long, ByRef AccessToken As String) As Model.FBInfo
        Dim ui As Entity.User = UR.GetUser_by_Id(fbid)
        Dim fbi As New Model.FBInfo
        With fbi
            fbi.fbid = ui.FB_Id
            fbi.name = ui.Name
            fbi.username = ui.UserName
            fbi.assigned_to = SSR.IsAssignedTo(fbid)
            fbi.seen_ss = SSR.HasSeenSS(fbid)
            fbi.works_at_location = New Core.FB.FBRepository().WorksAtLocation(fbi.fbid, SR.WorkLocation, AccessToken)
        End With
        Return fbi
    End Function

    Public Function RegisteredUsers(ByVal year As Integer) As List(Of Entity.User)
        Dim result As List(Of Entity.User) = (From u In UR.users Join s In SSR.SSInfo On u.FB_Id Equals s.FBId Where s.year = year Order By u.Name Select u).ToList
        Return result
    End Function

    Public Function GetSecretSantas(ByVal year As Integer) As List(Of SecretSantas)
        Dim result As List(Of SecretSantas) = (From u In SSR.SSInfo Join s In UR.users On u.FBId Equals s.FB_Id Where u.year = year Select New SecretSantas() With {.Giver = UR.GetUser_by_Id(u.FBId), .Receiver = If(u.AssignedTo_FBId Is Nothing, Nothing, UR.GetUser_by_Id(u.AssignedTo_FBId))}).ToList
        Return result
    End Function

    Public Function NewYear(ByVal regdate As Date, ByVal year As Integer) As Boolean
        SR.RegistrationDate = regdate
        SR.Set("Setting.DrawingEnabled", "false")
        SR.Set("Setting.Year", year.ToString)
        Return True
    End Function

    Public Function AssignUsers() As Boolean
        'get list of users
        Dim users As List(Of Long) = (From s In SSR.SSInfo Join u In UR.users On s.FBId Equals u.FB_Id Where s.year = SR.Get("Setting.Year").Value Select s.FBId).ToList
        Dim users2 As List(Of Long) = (From s In SSR.SSInfo Join u In UR.users On s.FBId Equals u.FB_Id Where s.year = SR.Get("Setting.Year").Value Select s.FBId).ToList

        Dim RND As New Random(31415)
        For Each usr As Long In users
            For j As Integer = 1 To RND.Next(250)
                RND.Next(0, users2.Count - 1)
            Next

            Dim tmplst As List(Of Long) = users2.Where(Function(f) Not f = usr).ToList

            Dim index As Integer = RND.Next(0, tmplst.Count)
            Dim assusr As Long = tmplst(index)

            SSR.Update(usr, assusr)

            users2.Remove(assusr)
        Next

        'update validated setting
        SR.Set("Setting.DrawingEnabled", "true")

        Return True
    End Function

End Class
