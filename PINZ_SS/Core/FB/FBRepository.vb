Namespace FB

    Public Class FBRepository

        Public Function GetEmpInfo(ByRef AccessToken As String)
            Return FBRequest(Of Result.FBResponse)("me", AccessToken)
        End Function

        Public Function GetEmpInfo(ByVal fbid As Long, ByRef AccessToken As String) As Result.FBResponse
            Return FBRequest(Of Result.FBResponse)(fbid.ToString, AccessToken)
        End Function

        Public Function WorksAtLocation(ByRef fbid As Long, ByVal employer_id As List(Of Long), ByRef AccessToken As String) As Boolean
            Dim res As Result.FBResponse = GetEmpInfo(fbid, AccessToken)
            If res.work IsNot Nothing Then
                Dim workplace As FB.Result.FBWork = res.work.Where(Function(f) employer_id.Contains(f.employer.id)).FirstOrDefault
                If workplace IsNot Nothing AndAlso workplace.end_date Is Nothing Then
                    'it doesn't exists, they work there
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function

        Private Function FBRequest(Of T)(ByRef graph_query As String, Optional ByRef AccessToken As String = "") As T
            Dim url As New Uri(FBUrl & graph_query & IIf(AccessToken IsNot Nothing AndAlso AccessToken.Length > 0, "?access_token=" & AccessToken, ""))
            Using WC As New Net.WebClient()
                Dim res As String = WC.DownloadString(url)
                Return Json.JsonConvert.DeserializeObject(Of T)(res)
            End Using
        End Function

        Private ReadOnly Property FBUrl As String
            Get
                Return "https://graph.facebook.com/"
            End Get
        End Property

    End Class

End Namespace
