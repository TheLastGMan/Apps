@modeltype web.SecretListModel
@Code
    ViewData("Title") = "SecretList"
End Code

<table id="ss_users">
    <thead>
        <tr>
            <td colspan="2">Secret Santa List</td>
        </tr>
    </thead>
    <tbody>
        <tr style="font-size:1.2em; font-weight:bold; font-family:Desigers;">
            <td>Giver</td>
            <td>Receiver</td>
        </tr>
        @For Each usr In Model.SecretSantas
            @<tr>
                <td>
                    @(usr.Giver.Name)
                </td>
                <td>
                    @(usr.Receiver.Name)
                </td>
             </tr>
        Next
    </tbody>
</table>