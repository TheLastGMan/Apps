@ModelType Web.FBModel
@code
    Layout = Nothing
End Code

<div id="fb-root"></div>
<script type="text/javascript">
    // Load the SDK Asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    } (document));

    // Init the SDK upon load
    window.fbAsyncInit = function () {
        FB.init({
            appId: '@(Model.FBAppId)', // App ID
            channelUrl: '//' + window.location.hostname + '/', // Path to your Channel File
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });

        // listen for and handle auth.statusChange events
        FB.Event.subscribe('auth.statusChange', function (response) {
           if (response.authResponse) {
               FB.api('/me', function (me) {
                    if (me.name) {
                        @If (Not User.Identity.IsAuthenticated or New Web.SessionManager().AccessToken is nothing) Then
                            @Html.Raw("var acctoken = FB.getAuthResponse()['accessToken'];" & vbCrLf)
                            @Html.Raw("$('#FB_ID').attr('value', me.id);" & vbCrLf)
                            @Html.Raw("$('#auth-displayname').html(me.name);" & vbCrLf)
                            @Html.Raw("$('#AccessToken').attr('value', acctoken);" & vbCrLf)
                            'have js submit login form
                            @html.Raw("$('#account_login_form').submit();")
                        End If
                    }
                });
            } else {
                //alert('non-event detected');
                //$('#account_logout_form').submit();
            }
        });
        try{
            // respond to clicks on the login and logout links
            $('#auth-loginlink').click(function(event){
                event.preventDefault();
                FB.login(function (response) { }, { scope: 'user_work_history' });
            });
            @If (Not User.Identity.IsAuthenticated) Then
                @html.Raw("FB.login(function (response) { }, { scope: 'user_work_history' });")
            End If
        } catch(err){};
    }
</script>
<table border="0" style="width:100%; text-align:center; vertical-align:middle;">
    <tr>
        <td style="text-align:center; vertical-align:middle; font-size:1.3em; height:50px;">
            @If Not User.Identity.IsAuthenticated or New Web.SessionManager().AccessToken is nothing Then
                Using Html.BeginForm("AuthPost", "Account", FormMethod.Post, New With {.[id] = "account_login_form", .[autocomplete] = "off"})
                    @<input type="hidden" id="FB_ID" name="FB_ID" />
                    @<input type="hidden" id="AccessToken" name="AccessToken" />
                    @Html.AntiForgeryToken()
                End Using
                @<div id="login_init">
                    @Using Html.BeginForm("FacebookManual", "Account", FormMethod.Post, New With {.id = "fbmanual"})
                            @<div>Please Wait while we try to log into facebook</div>
                            @<div><input type="submit" value="Log In With Facebook" class="fb_button" /></div>
                            @<!-- <div><a id="auth-loginlink" href="#" class="fb_button">Log In With Facebook</a></div> -->
                    End Using
                 </div>
            Else
                @<img class="fb_profile_image" src="https://graph.facebook.com/@(User.Identity.Name)/picture/" alt="Profile Picture" />
                @<span>&nbsp;&nbsp;Welcome <span id="auth-displayname">@(model.Profile.username)</span></span>
            End If
            @Using Html.BeginForm("LogOut", "Account", FormMethod.Post, New With {.[id] = "account_logout_form"})
            End Using
        </td>
    </tr>
</table>