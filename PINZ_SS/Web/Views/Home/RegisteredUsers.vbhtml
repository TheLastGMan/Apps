@ModelType Web.RegisteredUserModel
@code
    Layout = nothing
End Code

<table id="ss_users" border="0" cellpadding="1" cellspacing="0">
    <thead>
        <tr>
            <td class="HeaderText">
                Entered Employees
            </td>
        </tr>
    </thead>
    <tbody>
        @For Each p As Core.Entity.User In Model.Users
            @<tr>
                <td>
                    @(p.Name)
                </td>
             </tr>
        Next
        @If Model.Users.Count = 0 Then
            @<tr>
                <td>None Registered</td>
             </tr>
        End If
    </tbody>
</table>
<br />