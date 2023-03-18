Imports TBDB
Public Class TReport

    Private Sub TReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ChangeHeaderText("Tournament Report")
        Load_Report()
    End Sub

    Private Sub Load_Report()
        WriteLog("D", "TReport.Load_Report")
        If Check_Installed() Then
            WriteLog("D", "TReport.Load_Report", "Report Viewer 2010 Installed = Yes")
            'report viewer installed
            Data_Load()
            Data_Sort()
            Data_Fill()
            Report_Load()
        Else
            'Report Viewer Not Installed
            WriteLog("D", "TReport.Load_Report", "Report Viewer 2010 Installed = No")
            MsgBox("Please install Microsoft Report Viewer 2010 (ReportViewer.exe)" & vbCrLf & "http://www.microsoft.com/download/en/details.aspx?id=6442" & " or Direct" & vbCrLf & "http://download.microsoft.com/download/E/A/1/EA1BF9E8-D164-4354-8959-F96843DD8F46/ReportViewer.exe", MsgBoxStyle.OkOnly, "Error")
        End If
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

    Private SC As New Hashtable
    Private CB As New Hashtable
    Private BN As New Hashtable
    Private Sub Data_Load()
        'load data from db
        Dim tn_exist As String = TBDB.DBLnkr.DB_Program.Tournament_Exists(GetWeekId())
        If tn_exist = "1" Then
            'tournament exists, grab data
            Dim tn_data As String = TBDB.DBLnkr.DB_Program.Tournament_Get_Data(GetWeekId())
            If tn_data.StartsWith("-") Then
                'error
                WriteLog("E", "TReport.Data_Load", "Error getting tournament data for week: " & GetWeekId() & " - " & tn_data)
            ElseIf tn_data.Length > 1 Then
                'data exists
                Dim tn_dat As String() = tn_data.Split(",")
                For i As Integer = 0 To tn_dat.Length - 1 Step 2
                    If tn_dat(i).StartsWith("SC") Then
                        SC.Add(tn_dat(i), tn_dat(i + 1))
                    ElseIf tn_dat(i).StartsWith("CB") Then
                        CB.Add(tn_dat(i), tn_dat(i + 1))
                    ElseIf tn_dat(i).StartsWith("BN") Then
                        BN.Add(tn_dat(i), tn_dat(i + 1))
                    End If
                Next
            Else
                'data does not exists
                Data_Not_Exists()
            End If
        ElseIf tn_exist = "0" Then
            Data_Not_Exists()
        Else
            'error
            WriteLog("E", "TReport.Data_Load", "Error checking if tournament exists for week: " & GetWeekName() & " - " & tn_exist)
        End If
    End Sub

    Private Sub Data_Not_Exists()
        'does not exist
        'SC,CB have 14, BN has 15
        For i As Byte = 1 To 14
            SC.Add(i.ToString, "0")
            CB.Add(i.ToString, "0")
            BN.Add(i.ToString, "N/A")
        Next
        BN.Add("15", "N/A")
    End Sub

    Dim BNA As New ArrayList
    Dim SCA As New ArrayList
    Dim CBA As New ArrayList
    Private Sub Data_Sort()
        'parse tournemnt data into 
        'data is stored in any order BN_xx, CB_xx, SC_xx - sort ASC to DSC
        'SORT SC
        For Each k As String In SC.Keys
            SCA.Add(k)
        Next
        SCA.Sort()
        'SORT CB
        For Each k As String In CB.Keys
            CBA.Add(k)
        Next
        CBA.Sort()
        'SORT BN
        For Each k As String In BN.Keys
            BNA.Add(k)
        Next
        BNA.Sort()
    End Sub

    Private BN_Dat As String = String.Empty
    Private BN_Col As String = String.Empty
    Private Sub Data_Fill()
        'go through scores and format of [Score] [CB checked True as X] - [Bowler Name] comma [,]
        'ex 300 X - Ryan Gau or 300 - Ryan Gau
        For i As Integer = 0 To BNA.Count - 2
            BN_Dat &= SC(SCA(i)).ToString.PadLeft(3, " ") & " " & IIf(CB(CBA(i)), "X ", "") & "- " & BN(BNA(i)) & ","
        Next
        BN_Dat &= BN(BNA(BNA.Count - 1))
        'set the background color for the scores
        'loop through and compare
        For i As Integer = 0 To BNA.Count - 2 Step 2
            Dim S1 As Integer = Integer.Parse(SC(SCA(i)))
            Dim S2 As Integer = Integer.Parse(SC(SCA(i + 1)))
            If S1 > S2 Then
                'Score 1 Higher
                BN_Col &= "LimeGreen,IndianRed,"
            ElseIf S1 < S2 Then
                'Score 2 Higher
                BN_Col &= "IndianRed,LimeGreen,"
            ElseIf S1 = 0 And S2 = 0 Then
                'no data
                BN_Col &= "White,White,"
            Else
                'Tie
                BN_Col &= " Cyan,Cyan,"
            End If
        Next
        BN_Col &= "GoldenRod"
    End Sub

    Private Sub Report_Load()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Tournaments.Eight_PPL.Torn_Report.rdlc"
        Dim rpta As New Microsoft.Reporting.WinForms.ReportParameterCollection From {
            New Microsoft.Reporting.WinForms.ReportParameter("League_Name", GetLeagueName()),
            New Microsoft.Reporting.WinForms.ReportParameter("Bowl_Date", GetWeekName()),
            New Microsoft.Reporting.WinForms.ReportParameter("BN_Data", BN_Dat),
            New Microsoft.Reporting.WinForms.ReportParameter("Back_Colors", BN_Col)
        }
        ReportViewer1.LocalReport.SetParameters(rpta)
        ReportViewer1.LocalReport.DisplayName = "TReport_" & GetWeekName().Replace("/", "-")
        ReportViewer1.RefreshReport()
        ReportViewer1.ZoomPercent = 75
    End Sub

End Class
