Public NotInheritable Class SplashMenu

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Public WriteOnly Property SetInfo() As String
        Set(ByVal value As String)
            InfoText.Text = value
        End Set
    End Property

    Private Sub SplashMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class
