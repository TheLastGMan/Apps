@ModelType Web.Models.Wishlist.WishListItem
@Code
    Layout = Nothing
End Code

<tbody id="@(Model.id.ToString)">
    <tr>
        @Using Ajax.BeginForm("DeleteWishListItem", New AjaxOptions With {
                                .HttpMethod = "POST",
                                .InsertionMode = InsertionMode.Replace,
                                .UpdateTargetId = Model.id.ToString,
                                .Url = Url.Action("DeleteWishListItem")})
            @Html.AntiForgeryToken()
            @<td>
                @Html.HiddenFor(Function(f) f.id)
                @Model.WishForItem
            </td>
            If Model.IsEditMode Then
                @<td>
                        <input type="submit" value="Delete" />
                    </td>
            End If
        End Using
    </tr>
</tbody>