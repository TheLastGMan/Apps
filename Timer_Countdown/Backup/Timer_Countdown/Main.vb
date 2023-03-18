Public NotInheritable Class Main

    Dim Min1 As Integer = 10
    Dim Sec As Integer = Min1 * 60
    Dim Sect As Integer
    Dim Str As String


    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        'Me.Location = New Point(0, 0)
        Me.Location = New Point(0, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        TIMER.Interval = 1000
    End Sub

    Private Sub START_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles START.Click
        START.Visible = False
        QUIT.Visible = False
        QUIT.BringToFront()
        TIMER.Enabled = True
        Sec = Min1 * 60
        Timer_Text.Text = "10:00"
    End Sub

    Private Sub TIMER_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER.Tick
        Sec -= 1
        Process_Time()
        'Timer_Text.Text = Process_Time()
    End Sub

    Private Sub Process_Time()
        Dim OUT1 As String
        Dim Min As Integer
        Min = Math.Floor(Sec / 60)
        Sect = Sec - (Min * 60)
        OUT1 = IIf(Sect < 10, ":0", ":")
        'If (Sect < 10) Then
        'OUT1 = Min & ":0" & Sect
        'Else
        'OUT1 = Min & ":" & Sect
        'End If
        '2 Min Warning
        If (Min < 2 And Sec > 58) Then
            Timer_Text.BackColor = Color.Green
            'My.Computer.Audio.Play("Windows Error.wav", AudioPlayMode.Background)
            ''ElseIf (Min = 0 And Sect >= 57 And Sect <= 59) Then
            '1 Min Warning
            ''    My.Computer.Audio.Play("notify.wav", AudioPlayMode.Background)
            ''ElseIf (Min = 0 And Sect >= 26 And Sect <= 30) Then
            '30 Sec Warning
            ''    My.Computer.Audio.Play("Windows Hardware Fail.wav", AudioPlayMode.Background)
        ElseIf (Min = 0 And Sect = 0) Then
            'Done
            'Return OUT1
            Timer_Text.Text = OUT1
            'My.Computer.Audio.Play("tada.wav", AudioPlayMode.Background)
            TIMER.Enabled = False
            Threading.Thread.Sleep(2000)
            Quit_Screen()
        End If
        'Return OUT1
        Timer_Text.Text = OUT1
    End Sub

    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Text.Click
        Quit_Screen()
    End Sub

    Private Sub Quit_Screen()
        TIMER.Enabled = False
        START.Visible = True
        QUIT.Visible = True
        QUIT.BringToFront()
    End Sub

    Private Sub Quit_Prog() Handles QUIT.Click
        Me.Close()
    End Sub
End Class
