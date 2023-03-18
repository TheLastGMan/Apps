@ModelType Web.HomeModel
@Code
    Layout = Nothing
End Code

<span class="MissedEntry">
    I'm Sorry, you have missed the @(Model.RegistrationDate.ToLongDateString) at @(model.RegistrationDate.ToShortTimeString) Registration Date.<br />
    Please Try Again Next Year.
</span>