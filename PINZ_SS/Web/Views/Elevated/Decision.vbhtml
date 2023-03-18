@modeltype Web.BooleanModel

<h1>Decision Making</h1>
<div>
    @If Model.Bool Then
        'drawing has already been selected
        @<span>Secret Santa Process has already been run</span>
    Else
        @<span>Do you wish to run the Secret Santa Process?<br /><br /></span>
        Using Html.BeginForm("Decision", "Elevated")
            @Html.Hidden("made_decision", True)
            @<input type="submit" class="button" value="Yes" />
        End Using
    End If
</div>
