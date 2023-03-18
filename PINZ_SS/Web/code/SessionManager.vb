Public Class SessionManager

    Private _AccessToken As String = "FBAccessToken"
    Public Property AccessToken As String
        Get
            Dim res As String = HttpContext.Current.Session(_AccessToken)
            If res IsNot Nothing Then
                Return res
            Else
                Return HttpContext.Current.Response.Cookies(_AccessToken).Value
            End If
        End Get
        Set(value As String)
            HttpContext.Current.Response.SetCookie(New HttpCookie(_AccessToken, value))
            HttpContext.Current.Session(_AccessToken) = value
        End Set
    End Property

End Class
