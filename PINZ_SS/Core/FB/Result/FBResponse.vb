Namespace FB.Result

    Public Class FBResponse

        Public Property id As Long
        Public Property name As String
        Public Property first_name As String
        Public Property last_name As String
        Public Property username As String
        Public Property locale As String
        Public Property gender As String

        Public ReadOnly Property FBProfileLink As String
            Get
                Return "http://www.facebook.com/" & id.ToString
            End Get
        End Property

        Public Property work As List(Of FBWork)
        Public Property verified As Boolean
        Public Property timezone As SByte
        Public Property updated_time As DateTime

    End Class

End Namespace
