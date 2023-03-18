@modeltype Web.Models.Wishlist.WishListModel
@Code
    Layout = nothing
End Code

<table id="wishlistgrid">
    <thead>
        <tr>
            <th>Wishing List</th>
            @If Model.IsEditMode Then
                @<th style="width:20%;">&nbsp;</th>
            End If
        </tr>
    </thead>
        @For Each itm As KeyValuePair(Of Guid, String) In Model.Items
                    @Html.Partial("_WishListItem", New Web.Models.Wishlist.WishListItem(itm.Value, Model.IsEditMode) with {.id = itm.Key, .AJAXUpdateID=itm.Key.ToString})
        Next
    @If Model.IsEditMode Then
        @<tfoot>
            @Using Ajax.BeginForm("AddWishListItem", New AjaxOptions With {
                                    .HttpMethod = "POST",
                                    .InsertionMode = InsertionMode.InsertAfter,
                                    .UpdateTargetId = "wishlistgrid",
                                    .Url = Url.Action("AddWishListItem")})
                @Html.AntiForgeryToken()
                @<tr>
                        <td>
                            New Wish List Item : @Html.TextBoxFor(Function(f) f.NewWishItem)
                        </td>
                        <td>
                            <input type="submit" value="Add" onclick="document.getElementById('@Html.FieldIdFor(function(f) f.NewWishItem)').value='';"/>
                        </td>
                    </tr>
            End Using
        </tfoot>
    End If
</table>
