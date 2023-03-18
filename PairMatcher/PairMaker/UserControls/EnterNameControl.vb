Public Class EnterNameControl : Implements IBaseUC

    Public Event ClearErr() Implements IBaseUC.ClearErr
    Public Event RaiseErr(ByRef msg As String) Implements IBaseUC.RaiseErr

    Private NS As INameService

    Private Sub EnterNameControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NS = DirectCast(New Matching.NameService, INameService)
        LoadNames()
        NameBox.Focus()
    End Sub

    Private Sub LoadNames()
        Dim namelst As List(Of String) = NS.LoadNames
        NameBox.AutoCompleteCustomSource.Clear()
        NameBox.AutoCompleteCustomSource.AddRange(namelst.ToArray)
    End Sub

    Public Function IsValid() As Boolean
        Return IIf(NameGrid.Rows.Count > 1 AndAlso NameGrid.Rows.Count Mod 2 = 0, True, False)
    End Function

    Public Function Names() As List(Of String)
        Dim lst As New List(Of String)
        For Each row As DataGridViewRow In NameGrid.Rows
            lst.Add(row.Cells(1).Value.ToString)
        Next
        Return lst
    End Function

    Private Sub NameBox_KeyPress(sender As Object, e As KeyEventArgs) Handles NameBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            AddName()
        End If
    End Sub

    Private Sub AddName()
        'check name
        Dim err As Boolean = False
        For Each row As DataGridViewRow In NameGrid.Rows
            If row.Cells(1).Value.ToString = NameBox.Text Then
                RaiseEvent RaiseErr("Name Already Exists")
                err = True
                Exit For
            End If
        Next
        If Not err AndAlso NameBox.Text.Length > 0 Then
            RaiseEvent ClearErr()
            NameGrid.Rows.Add(NameGrid.Rows.Count + 1, NameBox.Text)
            NameBox.AutoCompleteCustomSource.Add(NameBox.Text)
            SaveNames()
        End If
        NameBox.Text = ""
        NameBox.Focus()
    End Sub

    Private Sub AddNameBtn_Click(sender As Object, e As EventArgs) Handles AddNameBtn.Click
        AddName()
    End Sub

    Private Sub SaveNames()
        Dim lst As New List(Of String)
        For Each itm In NameBox.AutoCompleteCustomSource
            lst.Add(itm.ToString)
        Next
        NS.SaveNames(lst)
    End Sub

End Class
