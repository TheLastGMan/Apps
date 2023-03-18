@Code
    ViewData("Title") = "NewYear"
End Code
<h2>New Year Setup</h2>
<div>
    @Using Html.BeginForm("NewYear", "Elevated")
        @<span>
            @Html.TextBox("reg", Now.ToString, New With {.type="date"})<br />
            <input type="submit" class="button" value="Start" />
         </span>
    End Using
</div>
