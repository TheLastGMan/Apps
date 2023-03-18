Namespace Models.Wishlist

    Public Class WishListItem

        Public Sub New(ByRef wishitem As String, Optional ByVal IsEdit As Boolean = False)
            Me.WishForItem = wishitem
            Me.IsEditMode = IsEdit
        End Sub

        Public Property id As Guid?
        Public Property WishForItem As String
        Public Property IsEditMode As Boolean = False
        Public Property AJAXUpdateID As String = "wishlistgrid"
        Property inline As Boolean = False

    End Class

End Namespace
