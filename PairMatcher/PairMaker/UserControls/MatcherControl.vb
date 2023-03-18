Public Class MatcherControl : Implements IBaseUC

    Public Event ClearErr() Implements IBaseUC.ClearErr
    Public Event RaiseErr(ByRef msg As String) Implements IBaseUC.RaiseErr

    Private PS As Matching.IPair

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PS = DirectCast(New Matching.Pair, Matching.IPair)
    End Sub

    Private _MatchedPairs As New List(Of MatchPair)
    Public ReadOnly Property MatchedPairs As List(Of MatchPair)
        Get
            Return _MatchedPairs
        End Get
    End Property

    Private Sub MatcherControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub PairUp(ByRef names As List(Of String))
        _MatchedPairs = PS.PairUp(names)
        NameGrid.Rows.Clear()
        For Each itm As MatchPair In _MatchedPairs
            NameGrid.Rows.Add(itm.Name1, itm.Name2)
        Next
    End Sub

End Class
