@modeltype Web.RulesModel
@code
    Layout = nothing
End Code

<h1>Rules</h1>
<div style="width:60%; margin:auto; text-align:left; font-size:1.2em;">
    <ul>
        <li>Secret Santa is applicable to active PINZ employees (<a href="http://www.facebook.com/@(model.WorkLocations(0))" target="_blank">PINZ</a> or <a href="http://www.facebook.com/@(model.WorkLocations(1))" target="_blank">PINZ 1</a>)<br /><i>&nbsp;&nbsp;(as indicated on your facebook profile)</i></li>
        <li>Registration will be open until @(Model.RegistrationDate.ToLongDateString) at @(Model.RegistrationDate.ToShortTimeString)</li>
        <li>$20.00 limit recommended</li>
        <li>Recipient can be drawn 3 hours after registration end</li>
        <li>Drop off gift(s) by end of day 12/24/@(now.Year) to the employee break room</li>
        <li><i><b>Do Not</b> put your name on the gift, it has to be secret</i></li>
    </ul>
</div>