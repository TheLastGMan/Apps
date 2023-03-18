Namespace Models.Wishlist

    Public Class WishListModel

        Public Property Items As IEnumerable(Of KeyValuePair(Of Guid, String))
        Public Property IsEditMode As Boolean

        Public Property NewWishItem As String

    End Class

End Namespace
