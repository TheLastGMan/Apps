@ModelType Web.HomeModel
@Code
    Layout = Nothing
    Dim RegDate As DateTime = Model.RegistrationDate.AddHours(3)
End Code

<span class="SecretSantaWait">
    Thank you for entering<br />
    You can draw for your recipient after @(RegDate.ToLongDateString) at @(RegDate.ToShortTimeString)
</span>
<span>
    While you wait, fill out your Wish List!
</span>
@Html.Action("Grid", "WishList", New With {.fbid = Model.Profile.fbid, .isedit = True})
<div>
    @Using Html.BeginForm("ChickenOut", "Home")
        @<input type="submit" value="Chicken Out" class="button" />            
    End Using
</div>
