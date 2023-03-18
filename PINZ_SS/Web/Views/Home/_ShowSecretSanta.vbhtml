@ModelType Web.HomeModel
@Code
    Layout = Nothing
End Code

<span class="SecretSanta">
    Your Secret Recipient Is:<br />
    <a href="http://facebook.com/@(Model.Profile.assigned_to.FB_Id)" target="_blank">@(Model.Profile.assigned_to.Name)</a>
    <br />
    @Html.Action("Grid", "WishList", New With {.fbid = Model.Profile.assigned_to.FB_Id, .isedit = False})
</span>