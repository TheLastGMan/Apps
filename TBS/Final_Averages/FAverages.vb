Imports TBDB
Public Class FAverages

    Dim Bowlers As New ArrayList

    Private Sub FAverages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WriteLog("I", "FAverage.FAverage_Load")
        ChangeHeaderText("Final Averages")
        Dim ins As String = "Unknown"
        If Check_Installed() Then
            'Report Viewer 2010 Installed
            Load_DataBase()
            Load_Report()
            ins = "Yes"
        Else
            'not installed
            ins = "No"
        End If
        WriteLog("D", "FAverage.FAverage_Load", "Report Viewer 2010 Installed = " & ins)
    End Sub

    ''' <summary>
    ''' Checks weather Report Viewer 2010 is installed or not
    ''' </summary>
    ''' <returns>True if Installed, False otherwise</returns>
    ''' <remarks></remarks>
    Private Function Check_Installed() As Boolean
        Dim systype As String = IIf(Environment.Is64BitOperatingSystem, "Wow6432Node\", "")
        Try
            Dim reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\" & systype & "Microsoft\ReportViewer\v10.0", False)
            Dim str As String = reg.GetValue("Install", 0)
            Return str
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Load_DataBase()
        Dim rep As List(Of TBDB.DB_Structure.Weeks_Final_Averages) = TBDB.DBLnkr.DB_Program.Weeks_Final_Averages()
        If rep.Count = 0 Then
            'no data
            WriteLog("E", "FAverages.Load_DataBase", "No Data")
        ElseIf rep(0)._ERR Then
            'error
            WriteLog("E", "FAverages.Load_DataBase", "Error Loading Averages: " & rep(0)._ERRMsg)
        Else
            'no error
            WriteLog("W", "FAverages.Load_DataBase", "Loading Final Averages")
            For Each itm In rep
                FARY.AddFAveragesRow(itm.Name, itm.SUM4, itm.SUMG, itm.USBC, Format_Average(itm.SUMG, itm.SUM4))
            Next
        End If
    End Sub
    Private FARY As New DBFAverages.FAveragesDataTable

    ''' <summary>
    ''' Rounds and formats average to 2 decimal places
    ''' </summary>
    ''' <param name="series">Total Series</param>
    ''' <param name="games">Number of games bowled</param>
    ''' <returns>Formated average rounded to 2 decimal places</returns>
    ''' <remarks>basic remark</remarks>
    Private Function Format_Average(ByRef games As Integer, ByRef series As Integer) As String
        Return Math.Round(series / games, 2).ToString("##0.00")
    End Function

    Private Sub Load_Report()
        'set up and copy over data set for averages
        Dim x As New DataTable("FAverages") 'name of table
        With x.Columns
            .Add("BName")
            .Add("Series")
            .Add("Games")
            .Add("USBC_Sanc")
            .Add("Average")
        End With
        FARY.CopyToDataTable(x, LoadOption.OverwriteChanges)

        'set up report viewer
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Final_Averages.Fin_Aves.rdlc"
        Dim rpta As New Microsoft.Reporting.WinForms.ReportParameterCollection
        rpta.Add(New Microsoft.Reporting.WinForms.ReportParameter("League_Name", GetLeagueName()))
        ReportViewer1.LocalReport.SetParameters(rpta)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("FAVEset", x)) 'name of dataset
        ReportViewer1.LocalReport.DisplayName = GetLeagueName() & "_Final_Averages"
        ReportViewer1.RefreshReport()
    End Sub

End Class
