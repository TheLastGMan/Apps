Public Class Form1

    Private ControlPosition As New Point(12, 12)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearErr()
        SetDefault()
    End Sub

    Private Sub HandleErr(ByRef msg As String)
        ErrMsg.Text = msg
        ErrMsg.Visible = True
    End Sub

    Private Sub ClearErr()
        ErrMsg.Text = ""
        ErrMsg.Visible = False
    End Sub

    Private Sub SetButtons(ByVal EnterNames As Boolean, ByVal MatchUp As Boolean, ByVal Print As Boolean)
        EnterBtn.Visible = EnterNames
        MatchBtn.Visible = MatchUp
        PrintBtn.Visible = Print
    End Sub

    Private Sub SetMainControl(ByRef lctrl As IBaseUC)
        Dim ctrl As Control = DirectCast(lctrl, Control)
        ctrl.Name = "MCTRL"
        ctrl.Location = ControlPosition
        For i As Integer = 0 To Controls.Count - 1
            If Controls(i).Name = "MCTRL" Then
                Controls.RemoveAt(i)
                Exit For
            End If
        Next
        Controls.Add(ctrl)
        AddHandler lctrl.RaiseErr, AddressOf HandleErr
        AddHandler lctrl.ClearErr, AddressOf ClearErr
    End Sub

    Private Sub SetDefault()
        SetMainControl(_EN)
        SetButtons(False, True, False)
        ShouldRematch = True
    End Sub

#Region "Enter Names"

    Private ShouldRematch As Boolean = False
    Private _EN As New EnterNameControl
    Private Sub EnterBtn_Click(sender As Object, e As EventArgs) Handles EnterBtn.Click
        SetDefault()
    End Sub

    Private Function EnterNamesIsValid() As Boolean
        If Not _EN.IsValid Then
            HandleErr("Name List Is Invalid")
            Return False
        End If
        Return True
    End Function

    Private Function EnterNamesList() As List(Of String)
        Return _EN.Names()
    End Function

#End Region

#Region "Match Up"

    Private _MU As New MatcherControl
    Private Sub MatchBtn_Click(sender As Object, e As EventArgs) Handles MatchBtn.Click
        If EnterNamesIsValid() Then
            SetButtons(True, False, True)
            SetMainControl(_MU)
        End If
        If ShouldRematch AndAlso EnterNamesIsValid() Then
            _MU.PairUp(EnterNamesList)
            ShouldRematch = False
        End If
    End Sub

    Private Function MatchedPairs() As List(Of MatchPair)
        Return _MU.MatchedPairs
    End Function

#End Region

    Private _PF As New PrintControl
    Private Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        SetButtons(True, True, False)
        SetMainControl(_PF)
        _PF.SetData(MatchedPairs)
    End Sub

End Class
