@Code
    Layout = Nothing
End Code

<div class="footer_content">
    Copyright &copy; 2012 - @Now.Year <br />
    @If (User.Identity.IsAuthenticated) Then
        @<span><a href="mailto:pepse25@msn.com?Subject=PINZ%20Secret%20Santa%20(@(User.Identity.Name))">Ryan Gau</a> | <a href="http://facebook.com/pepse25" target="_blank">Facebook</a></span>
    Else
        @<span>Ryan G</span>
    End If
    &nbsp;|&nbsp;<a href="http://www.rpgcor.com" target="_blank">RPGCor</a>
    <br />
    Version 1.0.1d
</div>
