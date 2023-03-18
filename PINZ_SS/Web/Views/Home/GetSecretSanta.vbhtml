@ModelType Web.HomeModel
@Code
    Layout = Nothing
End Code

<span class="ChooseSecretSanta">
    Draw for your Recipient<br />
    @Using Html.BeginForm("GetSecretSanta", "Home")
        @<input type="submit" value="Draw Name" class="button" /> 
        @Html.AntiForgeryToken()
    End Using
</span>