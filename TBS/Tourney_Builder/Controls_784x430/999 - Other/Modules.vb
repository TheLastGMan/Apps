Public Class Modules

    Private Sub Modules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Functions.Log_Write("D", "Modules.Load")
        Main.FUNC.Change_Header("Modules")
        Insert_Row_Into_Gird("Loading Modules", "", False, "", "", "", "", "")
        Thread_Start()
    End Sub

    ''' <summary>
    ''' Changes the background color for the row of the data table
    ''' </summary>
    ''' <param name="row">datatable row</param>
    ''' <param name="color">background color</param>
    ''' <remarks></remarks>
    Private Sub change_row_background_color(ByRef row As DataGridViewRow, ByRef color As Color)
        For Each cell As DataGridViewCell In row.Cells
            cell.Style.BackColor = color
        Next
    End Sub


    ''' <summary>
    ''' Main Thread Entry
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Thread_Start()
        Dim t As New Thread(AddressOf Thread_Load)
        t.Start()
    End Sub

    ''' <summary>
    ''' generages new thread to load module status
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Thread_Load()
        Process_Modules(Load_Modules_From_Web())
        Check_Downloaded()
    End Sub

    ''' <summary>
    ''' DELEGATE - Check if modules is already installed
    ''' </summary>
    ''' <remarks></remarks>
    Private Delegate Sub Check_Downloaded_DELG()

    ''' <summary>
    ''' Check if modules is already installed
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Check_Downloaded()
        'if module is installed, change download button text to uninstall
        'change background color to green
        If Me.InvokeRequired Then
            Me.Invoke(New Check_Downloaded_DELG(AddressOf Check_Downloaded))
        Else
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim DBI As New TBDB.FileOps.DBClassList
                Dim AX As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
                DBI.Type = row.Cells("typeh").Value
                DBI.Desc = row.Cells("ModName").Value
                DBI.CRef = AX.Create_Reference_String(row.Cells("FileReference").Value, row.Cells("AssemblyName").Value)
                If AX.Exists_Reference(DBI) Then
                    'installed
                    row.Cells("IsInstalled").Value = "Yes"
                    row.Cells("DownUninstall").Value = "UnInstall"
                    change_row_background_color(row, Color.LawnGreen)
                Else
                    'no installed
                    row.Cells("IsInstalled").Value = "No"
                End If
            Next
        End If
    End Sub

    Private Delegate Sub Process_modules_DELEG(ByRef modules As List(Of ModuleService.Modulex))
    Private Sub Process_Modules(ByRef modules As List(Of ModuleService.Modulex))
        If Me.InvokeRequired Then
            Me.Invoke(New Process_modules_DELEG(AddressOf Process_Modules), modules)
        Else
            DataGridView1.Rows.Clear()
            For Each modx In modules
                Dim ins_str As String = String.Empty
                Dim ft As String = ""
                Dim fc As Char = ""
                Try
                    Dim MS As New ModuleService.VersionsSoapClient
                    '===================================================================================
                    ft = MS.Get_Type_Name(modx.type) 'string desc of file type
                    '===================================================================================
                Catch ex As Exception
                    ft = modx.type 'string desc of file type
                End Try
                Try
                    Dim MS As New ModuleService.VersionsSoapClient
                    fc = MS.Get_Single_Char_Identifer(MS.Get_Type_Name(modx.type)) 'one char file type
                Catch ex As Exception
                    fc = "U"
                End Try
                ins_str &= modx.type 'one char file type
                Insert_Row_Into_Gird(modx.display_name, ft, False, "Install", modx.file_assembly, modx.namespce, fc, modx.file)
            Next
        End If
    End Sub

    Private Sub Insert_Row_Into_Gird(ByRef ModuleName As String, ByRef type As String, ByRef installed As Boolean, ByRef btntxt As String, ByRef fileref As String, ByRef assnm As String, ByRef typeh As Char, ByRef filednld As String)
        Dim str As String = ModuleName & "|" & type & "|" & IIf(installed, "True", "False") & "|" & btntxt & "|" & fileref & "|" & assnm & "|" & typeh & "|" & filednld
        DataGridView1.Rows.Add(str.Split("|"))
    End Sub

    ''' <summary>
    ''' Loads the list of modules of the website
    ''' </summary>
    ''' <returns>[web_reference].Modulex</returns>
    ''' <remarks></remarks>
    Private Function Load_Modules_From_Web() As List(Of ModuleService.Modulex)
        Functions.Log_Write("I", "Modules.Load_Modules_From_Web", "Contacting Web Server")
        Dim ret = New List(Of ModuleService.Modulex)
        Try
            Dim ms As New ModuleService.VersionsSoapClient
            ret = ms.Get_Modules()
            Functions.Log_Write("S", "Modules.Load_Modules_From_Web", "Loaded " & ret.Count & " Modules from web")
        Catch ex As Exception
            Functions.Log_Write("E", "Modules.Load_Modules_From_Web", "Module List could not be found: " & ex.Message)
        End Try
        Return ret
    End Function

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex > -1 Then
            If DataGridView1.Columns(e.ColumnIndex).Name = "DownUninstall" Then
                If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Install" Then
                    'install
                    '>download file
                    Try
                        Dim filex As String = DataGridView1.Rows(e.RowIndex).Cells("fileurl").Value
                        get_file_portion(filex)
                        My.Computer.Network.DownloadFile(DataGridView1.Rows(e.RowIndex).Cells("fileurl").Value, My.Application.Info.DirectoryPath & "\" & filex)
                        '>add reference
                        Dim AX As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
                        Dim DBI As New TBDB.FileOps.DBClassList
                        DBI.Type = DataGridView1.Rows(e.RowIndex).Cells("typeh").Value
                        DBI.Desc = DataGridView1.Rows(e.RowIndex).Cells("ModName").Value
                        DBI.CRef = AX.Create_Reference_String(DataGridView1.Rows(e.RowIndex).Cells("FileReference").Value, DataGridView1.Rows(e.RowIndex).Cells("AssemblyName").Value)
                        If AX.Write_Reference(DBI) Then
                            AX.Flush()
                            'created reference
                            Check_Downloaded()
                        Else
                            'could not create reference
                            Functions.Log_Write("E", "Modules.InstallUninstall_click", "Could Not Create File Reference")
                        End If
                        Main.Load_Menu_Reports()
                        Thread_Start()
                    Catch ex As Exception
                        Functions.Log_Write("E", "Modules.InstallUninstall_click", "Error Downloading File: " & ex.Message)
                    End Try
                Else
                    'uninstall
                    '>delete reference
                    If MsgBox("Are You Sure", MsgBoxStyle.YesNo, "Delete Module") = MsgBoxResult.Yes Then
                        Dim AX As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
                        If AX.Delete_Reference(AX.Create_Reference_String(DataGridView1.Rows(e.RowIndex).Cells("FileReference").Value, DataGridView1.Rows(e.RowIndex).Cells("AssemblyName").Value)) Then
                            'deleted
                            Functions.Log_Write("S", "Modules.InstallUninstall_Coick", "Reference Deleted")
                        Else
                            'could not delete
                            Functions.Log_Write("E", "Modules.InstallUninstall_Coick", "Reference Could Not Be Deleted")
                        End If
                        '>delete file
                        Try
                            Dim filex As String = DataGridView1.Rows(e.RowIndex).Cells("fileurl").Value
                            get_file_portion(filex)
                            File.Delete(My.Application.Info.DirectoryPath & "\" & filex)
                            Functions.Log_Write("S", "Modules.InstallUninstall_Coick", "Deleted File")
                        Catch ex As Exception
                            'error
                            Functions.Log_Write("E", "Modules.InstallUninstall_Coick", "Could Not Delete File")
                        End Try
                        Main.Load_Menu_Reports()
                        Thread_Start()
                    End If
                End If
            End If
        End If
    End Sub

    Private Function get_file_portion(ByRef file As String) As Boolean
        Dim index As Integer = file.LastIndexOf("/")
        If index > 0 Then
            file = file.Substring(index + 1, file.Length - index - 1)
            Return True
        Else
            Return False
        End If
    End Function

End Class
