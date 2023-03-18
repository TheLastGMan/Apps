@ModelType Web.HomeModel

@Html.Partial("_Rules", New Web.RulesModel() with {.RegistrationDate = Model.RegistrationDate, .WorkLocations = Model.WorkLocations})
<hr />
@If User.Identity.IsAuthenticated Then
    @Html.Partial("_" & Model.ViewMode, Model)
    @<hr />
    @Html.Action("RegisteredUsers", "Home")
Else
    @<span class="NotLoggedIn">
        Please Log In To Continue
     </span>
End If
