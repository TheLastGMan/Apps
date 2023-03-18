Public Class printpage

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        For i As Byte = 0 To Controls.Count - 1
            AddHandler Controls(i).KeyDown, AddressOf ESC_Key
        Next
        load_report()
    End Sub

    Private Sub ESC_Key(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            closeme()
        End If
    End Sub

    Private Sub Printed(ByVal sender As Object, ByVal e As EventArgs) Handles ReportViewer1.Print, ReportViewer1.ReportExport
        Main.FUNC._PRINTED = True
    End Sub

    Private Sub closeme()
        If Main.FUNC._PRINTED Then
            chkcloseme()
        Else
            If MsgBox("Close Without Printing?", MsgBoxStyle.YesNo, "Close") = MsgBoxResult.Yes Then
                chkcloseme()
            End If
        End If
    End Sub

    Private Sub chkcloseme()
        Main.FUNC._PRINTED = False
        If My.Settings.PrintWindows Then
            ParentForm.Close()
        Else
            Main.FUNC.load_default()
        End If
    End Sub

    Private Sub load_report()
        Dim DT As New MPSDataSet.Drill_SheetDataTable
        Main.DB.DRILLA.FillBy_ID(DT, Main.FUNC._PRINTFID)
    End Sub

End Class
