Public Class User_Edit

    Private BT As New MPSDataSet.BowlersDataTable
    Private BID As Integer = Main.FUNC._BID
    Private fields As String() = {"BName", "Phone", "Street", "City", "State", "Zip", "CID"}

    Private Sub User_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.PageColor
        BID = Main.FUNC._BID
        CID.Value = 0
        For i As Byte = 0 To fields.Count - 1
            Controls(fields(i)).Text = ""
        Next
        Main.FUNC.dmsg("BID: " & BID & Chr(13) & _
               "Max: " & Main.DB.BOWLA.NumRows())
        CID.Maximum = Main.DB.BOWLA.NumRows()
        CID.Value = BID
        check_CID()
        get_fills()
        Me.Text = "Edit User - (" & BName.Text & ")"
        Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_Load_OK)
    End Sub

    Private Sub get_fills()
        Main.DB.BOWLA.Fill(BT)
        For i As Integer = 0 To BT.Rows.Count - 1
            BName.AutoCompleteCustomSource.Add(Get_Data1(0, "BName"))
            Street.AutoCompleteCustomSource.Add(Get_Data1(0, "Street"))
            City.AutoCompleteCustomSource.Add(Get_Data1(0, "City"))
        Next
    End Sub

    Private Sub check_CID()
        'Check for any "Special" ID's
        If CID.Value = 1 Then
            'Programmer
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).BackColor = Main.FUNC.gold
            Next
        ElseIf CID.Value > 1 And CID.Value <= 4 Then
            'Pro Shop Men 2010
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).BackColor = Main.FUNC.silver
            Next
        Else
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).BackColor = Main.FUNC.genback
            Next
        End If
        If CID.Value <= 0 Then
            'New User
            Updater.Text = "Add User"
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).Text = ""
            Next
        Else
            Updater.Text = "Update"
        End If
        If CID.Value >= 1 And CID.Value <= 4 Then
            BName.Enabled = False
        Else
            BName.Enabled = True
        End If
    End Sub

    Private Function Get_Data1(ByVal row As Integer, ByVal item As String) As String
        Return BT.Rows(row).Item(item)
    End Function

    Private Sub Items_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles BName.Leave, Street.Leave, Zip.Leave
        BName.Text = Main.FUNC.Uppercase_Words(BName.Text)
        Street.Text = Main.FUNC.Uppercase_Words(Street.Text)
        City.Text = Main.FUNC.Uppercase_Words(City.Text)
    End Sub

    Private Sub Phone_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles Phone.Leave
        If Phone.Text.Length = 11 Then
            Dim lex As String = Phone.Text.Substring(1, 3)
            Dim subx As String = Phone.Text.Substring(6, 3)
            Dim ext As String = Phone.Text.Substring(10, 1)
            Phone.Text = My.Settings.AreaCode & lex & subx & ext
            'Process_Form() 'Diabled Autoload until user presses Search
        ElseIf Phone.Text.Length < 11 Or Not Phone.Text.Length = 14 Then
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_INV_Num)
        End If
    End Sub

    Private Sub CID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CID.ValueChanged
        'Load User
        Main.FUNC.dmsg("CIDVN: " & CID.Value)
        If CID.Value > 0 Then
            BT.Rows.Clear()
            Main.DB.BOWLA.FillBy_BID(BT, CID.Value)
            Main.FUNC.dmsg("BTRs: " & BT.Rows.Count)
            BName.Text = Get_Data1(0, "BName")
            Phone.Text = Get_Data1(0, "Phone")
            Street.Text = Get_Data1(0, "Street")
            City.Text = Get_Data1(0, "City")
            State.Text = Get_Data1(0, "State")
            Zip.Text = Get_Data1(0, "Zip")
        End If
        check_CID()
    End Sub

    Private Sub Updater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Updater.Click
        If Not BName.Text = "" Then
            If Not Check_User_Exists() Then
                'User Does Not Exist
                Main.FUNC.dmsg("User Not Exist")
                Try
                    Main.FUNC.dmsg("CIDV: " & CID.Value)
                    If CID.Value = 0 Or CID.Value.ToString.Length = 0 Then
                        'New Bowler
                        Main.DB.BOWLA.Insert(BName.Text, City.Text, Phone.Text, State.Text, Street.Text, Zip.Text)
                        CID.Maximum = CID.Maximum + 1
                        Main.FUNC.dmsg("CIDm: " & CID.Maximum)
                        CID.Value = CID.Maximum
                        Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_Save_OK)
                    Else
                        Main.FUNC.dmsg("Updating ID: " & CID.Value)
                        'Update Older One
                        Main.DB.BOWLA.UpdateQuery(BName.Text, City.Text, Phone.Text, State.Text, Street.Text, Zip.Text, CID.Value)
                        Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_Save_OK)
                    End If
                Catch ex As Exception
                    Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_Save_ERR)
                End Try
            Else
                Main.FUNC.dmsg("Same User Exists")
                'User Exists
                Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_Exist_WRN)
            End If
        Else
            Main.ERS.Get_Error(Errors.Err_Codes.Edit_User_BName_WRN)
        End If
    End Sub

    Private Function Check_User_Exists() As Boolean
        BT.Rows.Clear()
        Main.DB.BOWLA.Exists(BT, BName.Text, Phone.Text, Street.Text, City.Text, State.Text, Zip.Text)
        If BT.Rows.Count > 0 Then
            'User Exists
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class