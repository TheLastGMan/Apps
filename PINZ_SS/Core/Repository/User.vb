Namespace Repository

    Public Class User

        Private DBC As New Data.Context

        Public ReadOnly Property users As List(Of Entity.User)
            Get
                Return DBC.Users.ToList
            End Get
        End Property

        Public Function GetUserId_by_Username(ByVal UserName As String) As String
            Return users.Where(Function(f) f.UserName = UserName).Select(Function(f) f.FB_Id).SingleOrDefault()
        End Function

        Public Function GetUser_by_Id(ByVal UserID As String) As Entity.User
            Try
                Return users.Where(Function(f) f.FB_Id = UserID).FirstOrDefault
            Catch ex As Exception
                Return New Entity.User
            End Try
        End Function

        Public Function AddUser(ByRef FBID As String, ByRef FBName As String, ByRef FBUserName As String) As Boolean

            If Not UserNameExists(FBUserName) Then
                'create if user does not exist
                Dim user As New Entity.User
                user.FB_Id = FBID
                user.Name = FBName
                user.UserName = FBUserName
                user.Created = Now
                Try
                    DBC.Users.Add(user)
                    DBC.SaveChanges()
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End If

            Return True
        End Function

        Public Function UserNameExists(ByVal FBUserName As String) As Boolean
            If users.Where(Function(f) f.UserName = FBUserName).Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
