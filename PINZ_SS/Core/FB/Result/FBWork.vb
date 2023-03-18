Namespace FB.Result

    Public Class FBWork

        Public Property employer As FBidname
        Public Property location As FBidname
        Public Property position As FBidname
        Public Property description As String
        Public Property start_date As String
        Public Property end_date As String

        Public ReadOnly Property StartDate As Date
            Get
                Dim sd As String() = start_date.Split("-")
                Return New Date(Integer.Parse(sd(0)), Integer.Parse(sd(1)), 1)
            End Get
        End Property

        Public ReadOnly Property EndDate As Date
            Get
                Dim ed As String() = end_date.Split("-")
                Return New Date(Integer.Parse(ed(0)), Integer.Parse(ed(1)), 1)
            End Get
        End Property

    End Class

End Namespace