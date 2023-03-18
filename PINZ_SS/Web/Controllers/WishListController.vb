Namespace Web
    Public Class WishListController
        Inherits System.Web.Mvc.Controller

        Private Shared ReadOnly WSLR As New Core.Repository.Wishlist
        Private Shared ReadOnly SSI As New Core.Repository.Settings

        <ChildActionOnly>
        Function Grid(fbid As Long, isedit As Boolean) As PartialViewResult
            Dim model As New Models.Wishlist.WishListModel With {
                .IsEditMode = isedit,
                .Items = WSLR.UserWishlist(fbid, SSI.CurrentYear)
            }
            Return PartialView("WishList", model)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function AddWishListItem(NewWishItem As String) As ActionResult
            Dim WL As New Core.Entity.Wishlist
            Dim id As String = User.Identity.Name

            WSLR.AddItem(id, SSI.CurrentYear, NewWishItem, WL)

            If Request.IsAjaxRequest Then
                Return PartialView("_WishListItem", New Models.Wishlist.WishListItem(NewWishItem, True) With {.id = WL.Id, .inline = True})
            End If

            Return RedirectToAction("Index", "Home")
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function DeleteWishListItem(id As Guid, WishForItem As String) As ActionResult
            WSLR.Delete(id)
            Dim idu As String = User.Identity.Name

            If Request.IsAjaxRequest Then
                Return PartialView("_Blank")
            End If

            Return RedirectToAction("Index", "Home")
        End Function

    End Class
End Namespace
