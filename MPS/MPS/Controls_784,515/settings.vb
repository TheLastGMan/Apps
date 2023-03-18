Public Class settings

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Phone.Text = My.Settings.Phone
        AreaCode.Value = My.Settings.AreaCode
        Logo.Text = My.Settings.LogoName.ToString()
        PrintWindow.SelectedIndex = My.Settings.PrintWindows
        DefPage.SelectedIndex = My.Settings.DefaultPage
        Me.BackColor = My.Settings.PageColor
        BGColor.Text = My.Settings.PageColor.Name
        ColorDialog1.Color = My.Settings.PageColor
        set_auto_save()
    End Sub

    Private Sub set_auto_save()
        For i As Byte = 0 To Controls.Count - 1
            AddHandler Controls(i).Leave, AddressOf settings_save
        Next
        AddHandler PrintWindow.SelectedIndexChanged, AddressOf settings_save
        AddHandler DefPage.TextChanged, AddressOf settings_save
    End Sub

    Private Sub settings_save()
        Main.FUNC.dmsg("Settings Saved")
        My.Settings.Phone = Phone.Text
        My.Settings.AreaCode = AreaCode.Value
        My.Settings.LogoName = Logo.Text
        My.Settings.PageColor = ColorDialog1.Color
        My.Settings.PrintWindows = PrintWindow.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub BGColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGColor.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            BGColor.Text = ColorDialog1.Color.ToString
            Me.BackColor = ColorDialog1.Color
        End If
    End Sub


End Class
