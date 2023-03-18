Public Class PBC_Print_Front

    Private ExpDays As Short = 365
    Private ExpYear As Short = 1
    Private StartNum As String

    Private Sub Print_Front_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Set_date()
        Load_Form()
    End Sub

    Private Sub Set_date()
        Dim today As System.DateTime
        Dim dates As System.DateTime
        today = Now
        dates = today.AddYears(1)
        DateTime.Text = dates.ToString()
    End Sub

    Private Sub Load_Form()
        Try
            StartNum = Get_Numbers()
            Dim a As New ReportParameter("ExpDate", DateTime.Text)
            '10 by 6-digit numbers
            Dim b As New ReportParameter("C1", format_number(StartNum))
            Dim c As New ReportParameter("C2", format_number(StartNum + 1))
            Dim d As New ReportParameter("C3", format_number(StartNum + 2))
            Dim e As New ReportParameter("C4", format_number(StartNum + 3))
            Dim f As New ReportParameter("C5", format_number(StartNum + 4))
            Dim g As New ReportParameter("C6", format_number(StartNum + 5))
            Dim h As New ReportParameter("C7", format_number(StartNum + 6))
            Dim i As New ReportParameter("C8", format_number(StartNum + 7))
            Dim j As New ReportParameter("C9", format_number(StartNum + 8))
            Dim k As New ReportParameter("C10", format_number(StartNum + 9))

            PBC_Print.LocalReport.EnableExternalImages = True
            PBC_Print.ShowParameterPrompts = False
            PBC_Print.LocalReport.ReportPath = Main.Gen.Get_Local_Path() & "Reports\PBC_Front.rdlc"
            PBC_Print.ProcessingMode = ProcessingMode.Local
            PBC_Print.LocalReport.SetParameters(New ReportParameter() {a, b, c, d, e, f, g, h, i, j, k})
            PBC_Print.RefreshReport()
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Suc)
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.Report_Load_Fail)
        End Try
    End Sub

    Public Function Get_Numbers()
        'Get the 6 digit number from the DB
        Dim DT As New PBCDataSet.PB_CardsDataTable
        Dim ret As String
        PB_CardsTableAdapter.FillByCardDesc(DT)
        ret = DT.Rows(0).Item("Card Number")
        'MsgBox("SN: " & StartNum & " - DT: " & DT.Rows(0).Item("Card Number"))
        DT.Dispose()
        Return ret
    End Function

    Private Sub Update_Number()
        'MsgBox(StartNum + 10)
        PB_CardsTableAdapter.Insert(StartNum + 10)
    End Sub

    Private Function format_number(ByVal num As String) As String
        Select num.ToString.Length
            Case 1
                num = "00000" & num
            Case 2
                num = "0000" & num
            Case 3
                num = "000" & num
            Case 4
                num = "000" & num
            Case 5
                num = "0" & num
            Case 6
                num = num
            Case Else
                num = num.Substring(num.Length - 6, 6)
                Exit Select
        End Select
        Return num
    End Function

    Private Sub DateTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTime.ValueChanged
        Load_Form()
    End Sub

    Private Sub PBC_Print_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBC_Print.Print
        PBC_Print.PrintDialog()
        PBC_Print.PrintDialog()
        Update_Number()
        Load_Form()
    End Sub
End Class
