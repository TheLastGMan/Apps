<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1.0,width=device-width" />
    <title>PINZ Secret Santa</title>
    <link rel="icon" type="image/png" href="@Url.Content("~/Content/favicon.png")" />
    <link rel="Shortcut Icon" type="image/vnd.microsoft.icon" href="@Url.Content("~/Content/favicon.ico")" />
    <link rel="stylesheet" href="@Url.Content("~/content/mobile/jquery.mobile-1.3.2.min.css")">
    <link href="@Url.Content("~/content/site.min.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/scripts/jquery-1.7.1.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>
    <!--<script src="@Url.Content("~/scripts/jquery.mobile-1.3.2.min.js")" type="text/javascript"></script>-->
    <script src="@Url.Content("~/scripts/modernizr-2.5.3.js")" type="text/javascript"></script>
</head>

<body>
    <div id="main_container">
        <div id="header">
            @Html.Partial("_header")
        </div>
        @If User.IsInRole("Admin") Then
            @<div id="AdminLinks">
                @Html.Action("AdminLinks", "Elevated")
             </div>
        End If
        @If User.IsInRole("Decisioner") Then
            @<div id="DecisionerLinks">
                @Html.Action("DecisionerLinks", "Elevated")
             </div>
        End If
        <div id="login">
            @Html.Action("Auth", "Account")
        </div>
        <div id="main_content">
            @RenderBody()
        </div>
        <div id="footer">
            @Html.Partial("_footer")
        </div>
    </div>
</body>
</html>
