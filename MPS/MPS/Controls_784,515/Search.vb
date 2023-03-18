Public Class Search

    Private BAT As New MPSDataSet.BowlersDataTable
    Private BDT As New MPSDataSet.Drill_SheetDataTable
    Private BT As String = ""
    Private BID As Integer = 0
    Private CMD As String = "SELECT ID, BName, Phone, Street, City, State, Zip FROM Bowlers WHERE "
    Private CMDQ As String = ""
    Private data As Boolean = False
    Private SQLCON As New OleDb.OleDbConnection(My.Settings.MPSConnectionString)

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.PageColor
        Get_Info()
        Get_Maxs()
        BName.Text = Main.FUNC._SBNT
        NPhone.Text = Main.FUNC._SPHONE
        Cust_Sort.SelectedIndex = 0
        BName.Focus()
        'DataGridView1.Rows.Add("1,1,1,1,1,1,1".Split(","))
    End Sub

    Private Function Get_Data(ByVal row As Integer, ByVal data As String) As String
        Return BDT.Rows(row).Item(data)
    End Function

    Private Function Get_Data1(ByVal row As Integer, ByVal data As String) As String
        Return BAT.Rows(row).Item(data)
    End Function

    Private Sub Get_Maxs()
        CID.Maximum = Main.DB.BOWLA.NumRows()
    End Sub

    Private Sub Get_Info()
        Main.DB.BOWLA.Fill(BAT)
        Dim Rows As Integer = BAT.Rows.Count
        BName.AutoCompleteCustomSource.Clear()
        City1.AutoCompleteCustomSource.Clear()
        Street.AutoCompleteCustomSource.Clear()
        'Main.FUNC.dmsg(Rows)
        Dim stor As String() = {}
        For i As Integer = 0 To Rows - 1
            'Customer
            Try
                stor = Get_Data1(i, "BName").Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)
                Main.FUNC.dmsg("CNT: " & stor.Count & " 0: " & stor(0) & " 1: " & stor(1))
                BName.AutoCompleteCustomSource.Add(Get_Data1(i, "BName"))
                BName.AutoCompleteCustomSource.Add(stor(1) & ", " & stor(0))
            Catch ex As Exception
                BName.AutoCompleteCustomSource.Add(Get_Data1(i, "BName"))
            End Try
            'Street
            Street.AutoCompleteCustomSource.Add(Get_Data1(i, "Street"))
            'City
            City1.AutoCompleteCustomSource.Add(Get_Data1(i, "City"))
        Next
    End Sub

    Private Sub Insert_Null_Row()
        DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Add("N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A".Split(","))
    End Sub

    Private Sub NPhone_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NPhone.Leave
        'Formatting The Text Fields
        BName.Text = Main.FUNC.Uppercase_Words(BName.Text)
        If NPhone.Text.Length = 11 Then
            Dim lex As String = NPhone.Text.Substring(1, 3)
            Dim subx As String = NPhone.Text.Substring(6, 3)
            Dim ext As String = NPhone.Text.Substring(10, 1)
            NPhone.Text = My.Settings.AreaCode & lex & subx & ext
        End If
        Preload_Rows()
    End Sub

    Private Sub generate_cmd()
        data = False
        CMDQ = ""
        If Not BName.Text.Length = 0 Then
            If Cust_Sort.SelectedIndex = 0 Then
                CMDQ &= Get_and() & "BName LIKE '% " & BName.Text & "%' "
            ElseIf Cust_Sort.SelectedIndex = 2 Then
                CMDQ &= Get_and() & "BName LIKE '%" & BName.Text & "%' "
            Else
                CMDQ &= Get_and() & "BName LIKE '" & BName.Text & "%' "
            End If
            data = True
        End If
        If NPhone.Text.Length = 14 Then
            CMDQ &= Get_and() & "Phone = '" & NPhone.Text & "' "
            data = True
        End If
        If Not Street.Text.Length = 0 Then
            CMDQ &= Get_and() & "Street = '" & Street.Text & "' "
            data = True
        End If
        If Not City1.Text.Length = 0 Then
            CMDQ &= Get_and() & "City = '" & City1.Text & "' "
            data = True
        End If
        If Not State1.Text.Length = 0 Then
            CMDQ &= Get_and() & "State = '" & State1.Text & "' "
            data = True
        End If
        If Not Zip1.Text.Length = 0 Then
            CMDQ &= Get_and() & "Zip = '" & Zip1.Text & "' "
            data = True
        End If
        If Not CID.Value = 0 Then
            CMDQ &= Get_and() & "ID = '" & CID.Value & "' "
            data = True
        End If
    End Sub

    Private Function Get_and() As String
        If data Then
            Return " AND "
        Else
            Return ""
        End If
    End Function

    Private Sub BName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BName.TextChanged
        BName.Text = Main.FUNC.Uppercase_Words(BName.Text)
        Preload_Rows()
        For i As Byte = 0 To BName.Text.Length
            SendKeys.Send("{RIGHT}")
        Next
    End Sub

    Private Sub BName_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles BName.Enter
        For i As Byte = 0 To BName.Text.Length
            SendKeys.Send("{RIGHT}")
        Next
    End Sub

    Private Sub Items_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles Street.Leave, City1.Leave, State1.Leave, Zip1.Leave, CID.Leave
        Preload_Rows()
    End Sub

    Private Sub Preload_Rows()
        generate_cmd()
        Dim query As String = CMD & CMDQ
        If Not CMDQ.Length > 0 Then
            DataGridView1.Rows.Clear()
            Exit Sub
        End If
        Dim COM As New OleDb.OleDbCommand(query, SQLCON)
        'Main.FUNC.dmsg(query)
        BT = ""
        If Not SQLCON.State = ConnectionState.Open Then
            SQLCON.Open()
        End If
        Dim DR As OleDb.OleDbDataReader = COM.ExecuteReader()
        While DR.Read
            BT &= DR(0) & "," & DR(1) & "," & DR(2) & "," & DR(3) & "," & DR(4) & "," & DR(5) & "," & DR(6) & "|"
        End While
        DR.Close()
        SQLCON.Close()
        Dim rows As String() = BT.Split("|")
        If rows.Count > 1 Then
            DataGridView1.Rows.Clear()
            For i As Integer = 1 To rows.Count - 1
                DataGridView1.Rows.Add(rows(i - 1).Split(","))
            Next
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DataGridView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            new_user()
        End If
    End Sub

    '=====================================
    Private Sub DataGridView1_CellRightClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim img As System.Drawing.Image = New Bitmap(1, 1)
        If e.RowIndex >= 0 Then
            Dim ID As Integer = Integer.Parse(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Set_Context(ID, DataGridView1.Rows(e.RowIndex).Cells(1).Value)
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                new_user()
            End If
            SetMenuLocation()
        End If
    End Sub

    Private Sub new_user()
        ContextMenuStrip1.Items.Clear()
        ContextMenuStrip1.Items.Add("New User")
        SetMenuLocation()
    End Sub

    Private Sub SetMenuLocation()
        ContextMenuStrip1.Show(New Point(MousePosition.X + 8, MousePosition.Y + 8))
    End Sub

    Private Sub Set_Context(ByVal id As Integer, ByVal user As String)
        BDT.Rows.Clear()
        Main.DB.DRILLA.Get_Date(BDT, id)
        ContextMenuStrip1.Items.Clear()
        ContextMenuStrip1.Items.Add("#" & id & " - Edit User [" & user & "]")
        ContextMenuStrip1.Items.Add("#" & id & " - New Drilling")
        If BDT.Rows.Count > 0 Then
            For i As Integer = 0 To BDT.Rows.Count - 1
                ContextMenuStrip1.Items.Add("#" & BDT.Rows(i).Item("ID") & " - Drilling [" & BDT.Rows(i).Item("DateD") & "]")
            Next
        End If
    End Sub

    Private Sub ItemClick(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        '--------------ERRORS------------'
        Main.FUNC.dmsg("Click Name: " & e.ClickedItem.Text.ToString)
        Dim num1 As String() = e.ClickedItem.Text.Split("-")
        Try
            num1(0) = num1(0).Remove(0, 1)
            Main.FUNC.dmsg("Item Click: " & Chr(13) & _
            "num1(0): " & num1(0) & Chr(13) & _
            "num1(0): " & num1(1))
        Catch ex As Exception
            'new bowler
        End Try
        If e.ClickedItem.Text.Contains("Edit User") Then
            Main.FUNC._BID = Integer.Parse(num1(0))
            Main.FUNC.dmsg("BID: " & Main.FUNC._BID)
            edit_user()
            Exit Sub
        ElseIf e.ClickedItem.Text.Contains("New User") Then
            'New User
            Main.FUNC.dmsg("New User")
            Main.FUNC._BID = 0
            edit_user()
        ElseIf e.ClickedItem.Text.Contains("New Drilling") Then
            'New Sheet
            Main.FUNC._BID = Integer.Parse(num1(0))
            Main.Drill_Sheet()
        ElseIf e.ClickedItem.Text.Contains("Drilling") Then
            Main.FUNC.dmsg("Load Drilling")
            '--Set Vars and Load Drill Sheet
            If BDT.Rows.Count > 0 Then
                Dim FID As Integer = Integer.Parse(num1(0))
                'Set FID to use
                Main.FUNC._SID = FID
                Main.FUNC._BID = BID
                'Load Form
                Main.Drill_Sheet()
            End If
        End If
    End Sub

    Private Sub edit_user()
        If Not User_Edit.ShowDialog = DialogResult.Retry Then
            'get info for autofill
            Get_Info()
            'preload rows after change
            Preload_Rows()
        End If
    End Sub

End Class
