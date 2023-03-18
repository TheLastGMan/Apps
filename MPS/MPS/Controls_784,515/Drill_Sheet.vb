Public Class Drill_Sheet

    Private users As String() = {"BName", "Phone", "Street", "City", "State", "Zip"}
    Private fields As String() = {"Comments", "DateD", "Drill_Type", "Layout_Type", _
                                  "Special_Txt", "BColor", "BWeight", "BInitials", "BNum", "FB_Pitch", "LR_Pitch", _
                                  "TPitch", "TSidePitch", "Hand", "MTSpan", "RTSpan", "MRSpan", "MPitch", "RPitch", _
                                  "MSize", "RSize", "TSize", "Fingered"}
    Private BDT As New MPSDataSet.Drill_SheetDataTable
    Private BT As New MPSDataSet.BowlersDataTable
    Private BID As Integer = 0
    Private BNT As String = ""
    Private SaveForm As Boolean = False
    Private uchg As Boolean = False
    Private exitx As Boolean = False
    Private fidact As Boolean = True
    Private cidact As Boolean = True

    Private Sub Drill_Sheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inits()
        Get_Maxs()
        Get_Info()
        Get_Colors()
        Get_Weights()
        Handler_KeyDown()
        Enable_Fields(False)
        NForm.Enabled = False
        AutoLoad()
        'Erase_Fields()
        BName.Focus()
        Main.ERS.Get_Error(Errors.Err_Codes.Drill_Load_OK)
    End Sub

    Private Sub AutoLoad()
        '==TBD=='
        If Not Main.FUNC._SID = 0 Then
            'Load User
            '--Load_User(Main.FUNC._BID) 'Taken care of with Load_Bowler_2()
            'Set FID
            FID.Value = Main.FUNC._SID
            'Load Drill Page
            BDT.Rows.Clear()
            'Fill Table
            Main.DB.DRILLA.FillBy_ID(BDT, Main.FUNC._SID)
            'Fill Fields
            Load_Bowler_2()
            Enable_Fields(True)
            'Turn off Auto Load
            Main.FUNC._SID = 0
            Choices.Enabled = True
            NForm.Enabled = True
        ElseIf Not Main.FUNC._BID = 0 Then
            CID.Value = Main.FUNC._BID
            Main.FUNC._BID = 0
            AddRm_TxtChg(False)
            Erase_Fields()
            AddRm_TxtChg(True)
            Choices.Enabled = True
        Else
            AddRm_UTxtChg(True)
        End If
    End Sub

    Private Sub Get_Maxs()
        FID.Maximum = Main.DB.DRILLA.NumRows()
        CID.Maximum = Main.DB.BOWLA.NumRows()
        Main.FUNC.dmsg("CID-M: " & CID.Maximum & " | FID-M: " & FID.Maximum)
    End Sub

    Private Sub Inits()
        Dim MPS As New MPSDataSet
        MPS.EnforceConstraints = False
        Me.BackColor = My.Settings.PageColor
        Logo.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory & My.Settings.Logo
        Pic_Location.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory & My.Settings.Logo1
        txt_phone.Text = My.Settings.Phone
        BID = 0
        BNT = ""
    End Sub

    Private Sub Get_Info()
        Main.DB.BOWLA.Fill(BT)
        Dim Rows As Integer = BT.Rows.Count
        BName.AutoCompleteCustomSource.Clear()
        City.AutoCompleteCustomSource.Clear()
        Street.AutoCompleteCustomSource.Clear()
        For i As Integer = 0 To Rows - 1
            'Customer
            BName.AutoCompleteCustomSource.Add(Get_Data1(i, "BName"))
            'Street
            Street.AutoCompleteCustomSource.Add(Get_Data1(i, "Street"))
            'City
            City.AutoCompleteCustomSource.Add(Get_Data1(i, "City"))
        Next
    End Sub

    Private Sub Handler_KeyDown()
        For i As Integer = 0 To Controls.Count - 1
            AddHandler Controls(i).KeyDown, AddressOf Key_Down
        Next
        RemoveHandler Comments.KeyDown, AddressOf Key_Down
    End Sub

    Private Sub AddRm_TxtChg(ByVal add As Boolean)
        If add Then
            For i As Integer = 0 To fields.Count - 1
                AddHandler Controls(fields(i)).TextChanged, AddressOf TextChange
            Next
        Else
            For i As Integer = 0 To fields.Count - 1
                RemoveHandler Controls(fields(i)).TextChanged, AddressOf TextChange
            Next
        End If
    End Sub

    Private Sub AddRm_UTxtChg(ByVal add As Boolean)
        If add Then
            For i As Integer = 0 To users.Count - 1
                AddHandler Controls(users(i)).TextChanged, AddressOf UTextChange
            Next
        Else
            RemoveHandler BName.TextChanged, AddressOf UTextChange
            RemoveHandler Phone.TextChanged, AddressOf UTextChange
            RemoveHandler Street.TextChanged, AddressOf UTextChange
            RemoveHandler City.TextChanged, AddressOf UTextChange
            RemoveHandler State.TextChanged, AddressOf UTextChange
            RemoveHandler Zip.TextChanged, AddressOf UTextChange
        End If
    End Sub

    Private Sub TextChange(ByVal sender As Object, ByVal e As EventArgs)
        SaveForm = True
    End Sub

    Private Sub UTextChange(ByVal sender As Object, ByVal e As EventArgs)
        uchg = True
        If User_FilledOut() Then
            'All Info Filled Out, enable bottom
            Save_Sheet(0)
            Erase_Fields()
            uchg = False
        End If
    End Sub

    Private Function User_FilledOut() As Boolean
        If BName.Text.Length > 0 And Phone.Text.Length = 14 And Street.Text.Length > 0 And City.Text.Length > 0 And State.Text.Length = 2 And Zip.Text.Length = 5 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Enable_User(ByVal enab As Boolean)
        For i As Integer = 0 To users.Count - 1
            Controls(users(i)).Enabled = enab
        Next
    End Sub

    Private Sub Get_Colors()
        'Gets the entered brand names of the bowling balls
        BColor.AutoCompleteCustomSource.Clear()
        Main.DB.DRILLA.FillBy_Color(BDT)
        For i As Integer = 0 To BDT.Rows.Count - 1
            BColor.AutoCompleteCustomSource.Add(BDT.Rows(i).Item(0))
        Next
    End Sub

    Private Sub Get_Weights()
        'Add Weights 6.0 to 16.0 every 0.25lbs
        BWeight.AutoCompleteCustomSource.Clear()
        For i As Decimal = 6.0 To 16 Step 0.25
            BWeight.AutoCompleteCustomSource.Add(i.ToString)
        Next
    End Sub

    Private Sub Drill_Sheet_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Leave, MyBase.Disposed
        'Save The Info
        Save_Sheet(1)
    End Sub

    Private Sub Enable_Fields(ByVal tf As Boolean)
        For i As Integer = 0 To fields.Count() - 1
            If Not fields(i) = "" Then
                Controls(fields(i)).Enabled = tf
            End If
        Next
    End Sub

    Private Sub Key_Down(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Erase_Fields()
        'Store Name into Temp Field
        BNT = BName.Text
        Choices.Enabled = False
        Enable_Fields(True)
        AddRm_TxtChg(False)
        'Bowler Does Not Exist, Clear All Fields
        'Mod: Phone.Text = ""
        For i As Integer = 0 To fields.Count - 1
            If Not fields(i) = "" Then
                Controls(fields(i)).Text = "0"
            End If
        Next
        BColor.Text = ""
        BWeight.Text = ""
        BInitials.Text = ""
        BNum.Text = ""
        Special_Txt.Text = ""
        DateD.Text = IIf(Now.Month < 10, "0" & Now.Month, Now.Month) & IIf(Now.Day < 10, "0" & Now.Day, Now.Day) & Now.Year
        Drill_Type.SelectedIndex = 0
        Layout_Type.SelectedIndex = 0
        FB_Pitch.SelectedIndex = 0
        LR_Pitch.SelectedIndex = 0
        Fingered.SelectedIndex = 0
        Grips.Checked = False
        Hand.SelectedIndex = 1
        Slug.Checked = False
        Main.FUNC.dmsg("Erase: USer Exists: " & Check_User_Exists())
        If Not Check_User_Exists() Then
            CID.Maximum = CID.Maximum + 1
            CID.Value = CID.Maximum
        Else
            CID.Value = Main.DB.Get_BID(BName.Text)
        End If
        'FID.Maximum = FID.Maximum + 1
        'FID.Value = FID.Maximum
        Choices.Enabled = True
        Enable_User(False)
        AddRm_TxtChg(True)
        NForm.Enabled = True
    End Sub

    Private Function Check_User_Exists() As Boolean
        BT.Rows.Clear()
        Main.DB.BOWLA.Exists(BT, BName.Text, Phone.Text, Street.Text, City.Text, State.Text, Zip.Text)
        Main.FUNC.dmsg("BRows: " & BT.Rows.Count)
        If BT.Rows.Count > 0 Then
            'User Exists
            Return True
        Else
            Return False
        End If
    End Function

    Private Function Check_Name_Exists(ByVal name As String) As Boolean
        Dim tf As Boolean = False
        For i As Integer = 0 To BName.AutoCompleteCustomSource.Count - 1
            If BName.AutoCompleteCustomSource.Item(i) = name Then
                'Bowler Exists
                tf = True
            End If
        Next
        Return tf
    End Function

    '---------- SAVE SHEET ----------'
    Private Sub Save_Sheet(ByVal opt As Byte, Optional ByVal sys_close As Boolean = False)
        'opt | 0 = Bowler, 1 = Form, 2 = Bowler/Form
        Main.FUNC.dmsg("Save: " & opt)
        Select Case opt
            Case 0
                Save_User()
            Case 1
                Save_Form()
            Case 2
                Save_User()
                Save_Form()
        End Select
    End Sub

    Private Sub Save_User()
        Main.FUNC.dmsg("Save User: " & uchg)
        If User_FilledOut() And uchg Then
            'Save Data - Insert to keep a copy of the Bowler History
            'if new bowler, add to custom source & DB
            If Not Check_User_Exists() Then
                Main.FUNC.dmsg("Save User Not Found: Adding")
                'Bowler Does Not Exist, Insert
                Try
                    Main.DB.BOWLA.Insert(BName.Text, City.Text, Phone.Text, State.Text, Street.Text, Zip.Text)
                    CID.Maximum = CID.Maximum + 1
                    cidact = False
                    CID.Value = CID.Maximum
                    cidact = True
                    'Add To Sources
                    BName.AutoCompleteCustomSource.Add(BName.Text)
                    Street.AutoCompleteCustomSource.Add(Street.Text)
                    City.AutoCompleteCustomSource.Add(City.Text)
                Catch ex As Exception
                    Main.ERS.Get_Error(Errors.Err_Codes.Drill_Bowler_Add_ERR)
                End Try
            End If
            uchg = False
        End If
    End Sub

    Private Sub Save_Form(Optional ByVal sys_close As Boolean = False)
        Main.FUNC.dmsg("Save Form: " & SaveForm)
        If SaveForm Then
            Try
                BID = Main.DB.Get_BID(BName.Text)
                Main.DB.DRILLA.Insert(BID, Comments.Text, DateD.Text, Hand.SelectedIndex, Grips.Checked, MPitch.Text, RPitch.Text, MRSpan.Text, MTSpan.Text, RTSpan.Text, TPitch.Text, FB_Pitch.SelectedIndex, TSidePitch.Text, LR_Pitch.SelectedIndex, MSize.Text, RSize.Text, TSize.Text, Fingered.SelectedIndex, Slug.Checked, Layout_Type.SelectedIndex, Drill_Type.SelectedIndex, Special_Txt.Text, BColor.Text, BWeight.Text, BInitials.Text, BNum.Text)
                FID.Maximum = FID.Maximum + 1
                fidact = False
                FID.Value = FID.Maximum
                fidact = True
                SaveForm = False
            Catch ex As Exception
                Main.FUNC.dmsg("ERR: Save Form Failed")
            End Try
        End If
    End Sub

    '---------- Bowler Name Field ----------'
    Private Sub BName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BName.Leave
        If BName.Text.Length > 0 Then
            'Change the first letter of every word to uppercase
            BName.Text = Main.FUNC.Uppercase_Words(BName.Text)
            BName.Text = BName.Text.Replace(",", "-")
            'Focus to Phone and Do Not Load Info Until Phone is filled out
            Phone.Focus()
            '==Moved to Process_Form()
            'Process_Form() 'Removed Process until user presses Search
        Else
            Enable_Fields(False)
            'Phone.ReadOnly = True
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_REQ_Name)
        End If
    End Sub

    '---------- Phone Field ----------'
    Private Sub Phone_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Phone.Leave
        'If exitx Then
        'Exit Sub
        'End If
        If Phone.Text.Length = 11 Then
            Dim lex As String = Phone.Text.Substring(1, 3)
            Dim subx As String = Phone.Text.Substring(6, 3)
            Dim ext As String = Phone.Text.Substring(10, 1)
            Phone.Text = My.Settings.AreaCode & lex & subx & ext
            'Process_Form() 'Diabled Autoload until user presses Search
        ElseIf Phone.Text.Length < 11 Or Not Phone.Text.Length = 14 Then
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_INV_Num)
        End If
        Street.Focus()
    End Sub

    Private Sub Street_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Street.Leave
        If Not Street.Text = "" Then
            Street.Text = Main.FUNC.Uppercase_Words(Street.Text)
        Else
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_REQ_Street)
        End If
    End Sub

    Private Sub City_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles City.Leave
        City.Text = Main.FUNC.Uppercase_Words(City.Text)
    End Sub

    Private Sub BColor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BColor.Leave
        BColor.Text = Main.FUNC.Uppercase_Words(BColor.Text)
    End Sub

    Private Sub State_Leave(ByVal sender As System.Object, ByVal e As EventArgs) Handles State.Leave
        If State.Text.Length < 2 Then
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_INV_State)
        End If
    End Sub

    Private Sub Zip_Leave(ByVal sender As System.Object, ByVal e As EventArgs) Handles Zip.Leave
        If Zip.Text.Length < 5 Then
            Main.ERS.Get_Error(Errors.Err_Codes.Drill_INV_Zip)
        End If
    End Sub

    Private Function Get_Data(ByVal item As String, Optional ByVal row As Integer = 0) As String
        Return BDT.Rows(row).Item(item)
    End Function

    Private Function Get_Data1(ByVal row As Integer, ByVal item As String) As String
        Return BT.Rows(row).Item(item)
    End Function

    Private Function format_date(ByVal dated As String) As String
        Dim parts As String() = dated.Split("/")
        Dim datex As Short() = {Short.Parse(parts(0)), Short.Parse(parts(1)), Short.Parse(parts(2))}
        Return IIf(datex(0) < 10, "0" & datex(0), datex(0)) & "/" & IIf(datex(1) < 10, "0" & datex(1), datex(1)) & "/" & datex(2)
    End Function

    'Load Bowler Info
    Private Sub Load_Bowler_2()
        AddRm_TxtChg(False)
        'Customer Info
        CID.Text = Get_Data("BID")
        Comments.Text = Get_Data("Comments")
        DateD.Text = format_date(Get_Data("DateD"))
        'Type of Drilling
        Drill_Type.SelectedIndex = Get_Data("Drilling_Conventional")
        'Layout
        Layout_Type.SelectedIndex = Get_Data("Layout")
        'Drilling Comments
        Special_Txt.Text = Get_Data("Drilling_Notes")
        'Ball Info
        BColor.Text = Get_Data("Ball_Color")
        BWeight.Text = Get_Data("Ball_Weight")
        BInitials.Text = Get_Data("Ball_Initials")
        BNum.Text = Get_Data("Ball_No")
        'Spans
        MRSpan.Text = Get_Data("MRSpan")
        MTSpan.Text = Get_Data("MTSpan")
        RTSpan.Text = Get_Data("RTSpan")
        'Pitch
        MPitch.Text = Get_Data("MPitch")
        RPitch.Text = Get_Data("RPitch")
        TPitch.Text = Get_Data("TPitch")
        'Sizes
        MSize.Text = Get_Data("MSize")
        RSize.Text = Get_Data("RSize")
        TSize.Text = Get_Data("TSize")
        'L/R Hand
        Hand.SelectedIndex = IIf(Get_Data("Hand"), 1, 0)
        'Grips
        Grips.Checked = Get_Data("Grips")
        'Fin/UnFin
        Fingered.SelectedIndex = IIf(Get_Data("FinUnFin"), 1, 0)
        'Slug
        Slug.Checked = Get_Data("Slug")
        'Pitch Dir
        FB_Pitch.SelectedIndex = IIf(Get_Data("TFB"), 1, 0)
        LR_Pitch.SelectedIndex = IIf(Get_Data("TSLR"), 1, 0)
        'Enabe
        AddRm_TxtChg(True)
        SaveForm = False
    End Sub

    Private Sub FID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FID.ValueChanged
        'SAVE INFO BEFORE MOVING ON
        Main.FUNC.dmsg("FID: " & FID.Value & Chr(13) & _
               "SAVE: " & SaveForm & Chr(13) & _
               "FIDAct: " & fidact)
        Main.FUNC._PRINTFID = FID.Value
        If FID.Value > 0 Then
            'check if we should continue
            If fidact Then
                'Save
                Save_Sheet(1)
                '---Grab Info and Set All Info Over To Retreived Data
                'Load Drill Page
                BDT.Rows.Clear()
                'Fill Table
                Main.DB.DRILLA.FillBy_ID(BDT, FID.Value)
                'Load_User(Integer.Parse(BDT.Rows(0).Item("BID")))
                'Fill Fields
                Load_Bowler_2()
                'Disable User Info
                Enable_User(False)
                'Enable New User Button
                Choices.Enabled = True
                Enable_Fields(True)
                'Set FID for Print
                Main.FUNC._PRINTFID = FID.Value
            End If
        Else
            'erase field
            Erase_Fields()
        End If
    End Sub

    Private Sub Logo_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logo.MouseHover
        ToolTip1.SetToolTip(Logo, My.Settings.LogoName)
    End Sub

    Private Sub Load_User(ByVal id As Integer)
        AddRm_UTxtChg(False)
        For i As Byte = 0 To users.Count - 1
            Controls(users(i)).Text = ""
        Next
        BT.Rows.Clear()
        Main.DB.BOWLA.FillBy_BID(BT, id)
        uchg = False
        BName.Text = Get_Data1(0, "BName")
        Phone.Text = Get_Data1(0, "Phone")
        Street.Text = Get_Data1(0, "Street")
        City.Text = Get_Data1(0, "City")
        State.Text = Get_Data1(0, "State")
        Zip.Text = Get_Data1(0, "Zip")
        AddRm_UTxtChg(True)
        uchg = False
    End Sub

    Private Sub CID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CID.ValueChanged

        Main.FUNC.dmsg("CIDVal: " & CID.Value & Chr(13) & _
               "CIDAct: " & cidact)

        If CID.Value > 0 Then
            'check if we chould continue
            If cidact Then
                Save_Sheet(0)
                Load_User(CID.Value)
                Enable_User(False)
                Enable_Fields(True)
            End If
        Else
            For i As Byte = 0 To users.Count - 1
                Controls(users(i)).BackColor = Main.FUNC.genback
            Next
            Enable_User(True)
            Erase_User()
            AddRm_UTxtChg(True)
            Enable_Fields(False)
        End If
        If CID.Value = 1 Then
            For i As Byte = 0 To users.Count - 1
                Controls(users(i)).BackColor = Main.FUNC.gold
            Next
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).BackColor = Main.FUNC.gold
            Next
            Main.Error_Status.BackColor = Main.FUNC.gold
            Main.Error_Status.Text = "Meet Your Programmer - Ryan Gau 2010"
        ElseIf CID.Value > 1 And CID.Value < 5 Then
            For i As Byte = 0 To users.Count - 1
                Controls(users(i)).BackColor = Main.FUNC.silver
            Next
            For i As Byte = 0 To fields.Count - 1
                Controls(fields(i)).BackColor = Main.FUNC.silver
            Next
            Main.Error_Status.BackColor = Main.FUNC.silver
            Main.Error_Status.Text = "Meet Your Pro Shop Man - " & BName.Text & " 2010"
        End If
    End Sub

    Private Sub Erase_User()
        For i As Byte = 0 To users.Count - 1
            Controls(users(i)).Text = ""
        Next
    End Sub

    Private Sub Choices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Choices.Click
        'Save Form
        Save_Sheet(1)
        'Disable Form and Enable Users
        Enable_Fields(False)
        Enable_User(True)
        'Erase User Fields
        For i As Integer = 0 To users.Count - 1
            Controls(users(i)).Text = ""
        Next
        CID.Value = 0
        NForm.Enabled = False
        BName.Focus()
    End Sub

    Private Sub NForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NForm.Click
        Save_Sheet(1)
        FID.Value = 0
        'Erase_Fields()
    End Sub

End Class
