Imports System.Reflection

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Function LoadFile(ByRef filename As String) As List(Of String)
        Dim lines As New List(Of String)

        Dim SR As New IO.StreamReader(filename)
        While Not SR.EndOfStream
            lines.Add(SR.ReadLine())
        End While
        SR.Close()

        Return lines
    End Function

    Private Sub Parse_AFD_Click(sender As System.Object, e As System.EventArgs) Handles Parse_AFD.Click
        'Dim search As String() = {"FIX", "COM", "AWOS", "NAV", "APT", "TWR"}

        Dim files As List(Of String) = IO.Directory.GetFiles(BrowseBox.Text, "*.txt", IO.SearchOption.TopDirectoryOnly).ToList
        Dim toparse As New List(Of Type)

        For Each assembly In Reflection.Assembly.GetExecutingAssembly.GetTypes
            If Not assembly.IsInterface AndAlso GetType(IFAALoader).IsAssignableFrom(assembly) Then
                toparse.Add(assembly)
            End If
        Next

        ProgressBar1.Maximum = toparse.Count
        ProgressBar1.Value = 0

        For Each faaloader In toparse
            Dim resource As IFAALoader = DirectCast(Activator.CreateInstance(faaloader), IFAALoader)
            Dim parsefile As String = files.Where(Function(f) f.EndsWith(resource.FileType & ".txt")).FirstOrDefault

            ProgressBar1.Value += 1
            ProgressLbl.Text = "Loading: " & resource.FileType
            Me.Refresh()

            If Not String.IsNullOrEmpty(parsefile) Then
                Dim lines As List(Of String) = LoadFile(parsefile)
                If lines.Count > 0 Then
                    ProgressLbl.Text = "Parseing: " & resource.FileType & " (" & ProgressBar1.Value & " / " & toparse.Count & ")"
                    Me.Refresh()
                    AddHandler resource.NextLine, AddressOf NextLine
                    AddHandler resource.SetCount, AddressOf SetCount
                    resource.ParseFile(lines)
                End If
            End If

        Next

    End Sub


    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BrowseBox.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private localmax As Integer
    Private localsection As String
    Private starttime As DateTime

    Private Sub SetCount(ByRef count As Integer, ByRef section As String)
        localmax = count
        localsection = section
        starttime = Now

        ProgressBar2.Value = 0
        ProgressBar2.Maximum = count
        FileProgressLbl.Text = section & " : 0 / " & localmax
        Me.Refresh()
    End Sub

    Private Sub NextLine()
        ProgressBar2.Value += 1
        Dim percent As Decimal = Math.Round((ProgressBar2.Value / localmax) * 100, 1)
        FileProgressLbl.Text = localsection & " : " & ProgressBar2.Value & " / " & localmax & " (" & Format(percent, "0.0") & "%)"

        Dim tsdiff As New TimeSpan(Now.Subtract(starttime).Ticks)
        Dim ts As New TimeSpan(0, 0, (Math.Round(100 / IIf(percent = 0, 100, percent), 4) * tsdiff.TotalSeconds) - tsdiff.TotalSeconds)
        Dim esttime As String = Math.Floor(ts.TotalMinutes) & ":" & ts.Seconds.ToString.PadLeft(2, "0")

        FileProgressLbl.Text &= " | est. " & esttime
        Me.Refresh()
    End Sub

End Class
