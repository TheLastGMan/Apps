@ModelType Web.HomeModel
@Code
    Layout = Nothing
End Code

<span class="ShowRegistration">
    I Wish to Participate in PINZ Secret Santa<br />
    @Using Html.BeginForm("EnterSecretSanta", "Home")
        @<input type="submit" value="Enter" class="button" />
    End Using
</span>