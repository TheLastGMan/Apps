Public Class Add_Bowler

				Private BIDs As Integer
				Private Series As Short
				Private loaded As Boolean = False

				'Cells (Bowler_Name, G1, G2, G3, G4, 3Sum, 4Sum, Ave, [Alias], ([ID])

				Private Sub Add_Bowler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
								Functions.Log_Write("I", "Add_Bowler.Add_Bowler_Load")
								Main.FUNC.Change_Header("Add Bowler")
								Check_Games()
								Load_Page()
								For i As Short = 1 To Me.Controls.Count()
												AddHandler Me.Controls(i - 1).KeyDown, AddressOf KeyPressDown
								Next
								Check_SMon() 'Score Monitor Option
								Load_Lanes_Week()
								Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Bowler_Load_OK)
								loaded = True
				End Sub

				Public Sub Load_Page()
								Functions.Log_Write("I", "Add_Bowler.Load_Page")
								Edit_Scores.Rows.Clear()
								Load_Lanes()
								Load_bowlers()
								Bowler_Name.Focus()
				End Sub

				Private Sub Check_Games()
								Functions.Log_Write("I", "Add_Bowler.Check_Games", "Add Columns For Game Count of (" & Weeks._GmsWk & ")")
								'Check how many games this week
								'Add Columns
								For i As Byte = 1 To Weeks._GmsWk
												Edit_Scores.Columns.Add("G" & i, "G" & i)
								Next
				End Sub

				Private Sub Enable_Page(Optional ByRef tf As Boolean = False)
								Functions.Log_Write("I", "Add_Bowler.Enable_page")
								Lane_Pick.Enabled = tf
								Bowler_Name.Enabled = tf
								Sex.Enabled = tf
								USBC_ID.Enabled = tf
								Button1.Enabled = tf
								Edit_Scores.Enabled = tf
				End Sub

				Private Sub Check_SMon()
								Functions.Log_Write("I", "Add_Bowler.Check_SMon")
								Dim sizevt As Integer() = {1, 150, 150, 85, 85, 95, 90} 'SMon Sizes
								Dim sizev As Integer() = {1, 150, 1, 85, 85, 95, 52} 'Reg Sizes
								If Main.VDB.ChkSMon Then
												'Show SMon
												SMonImport.Visible = True 'TODO: SMon Support
												Edit_Scores.Columns("Aliasx").Visible = True
												For i As Byte = 0 To 5
																Edit_Scores.Columns(i).Width = sizevt(i)
												Next
												For i As Byte = 6 To Edit_Scores.Columns.Count - 1
																Edit_Scores.Columns(i).Width = sizevt(6)
												Next
								Else
												'Hide SMon
												SMonImport.Visible = False
												Edit_Scores.Columns("Aliasx").Visible = False
												For i As Byte = 0 To 5
																Edit_Scores.Columns(i).Width = sizev(i)
												Next
												For i As Byte = 6 To Edit_Scores.Columns.Count - 1
																Edit_Scores.Columns(i).Width = sizev(6)
												Next
								End If
				End Sub

				Private Sub KeyPressDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs)
								If e.KeyCode = Keys.Home Then
												'Lane Index Up (PREV0)
												If Not Lane_Pick.SelectedIndex = 0 Then
																Lane_Pick.SelectedIndex = Lane_Pick.SelectedIndex - 1
												End If
								ElseIf e.KeyCode = Keys.End Then
												'Lane Index Down (NEXT)
												If Not Lane_Pick.SelectedIndex = Lane_Pick.Items.Count - 1 Then
																Lane_Pick.SelectedIndex = Lane_Pick.SelectedIndex + 1
												End If
								End If
				End Sub

				Private Sub Load_bowlers()
								Functions.Log_Write("I", "Add_Bowler.Load_bowlers", "loading bowlers into Bowler_Name")
								Bowler_Name.AutoCompleteCustomSource.Clear()
								Dim ret As List(Of TBDB.DB_Structure.Bowlers_Get_List) = TBDB.DBLnkr.DB_Program.Bowlers_Get_List()
								If ret.Count = 0 Then
												'no data
												Functions.Log_Write("W", "Change_Lane.Get_Bowler_Name", "no data for bowler")
								ElseIf ret(0)._ERRMsg Is Nothing Then
												'data
												Functions.Log_Write("S", "Change_Lane.Get_Bowler_Name", "retreived bowlers")
												For Each itm In ret
																Add_Bowler_Dropdown(itm.FName & " " & itm.LName & " (" & itm.USBC_Sanc & ")")
												Next
								Else
												'error
												Functions.Log_Write("E", "Change_Lane.Get_Bowler_Name", "error loading bowler name: " & ret(0)._ERRMsg)
								End If
				End Sub

				Private LoadLanes As Boolean = True
				Private Function Load_Lanes() As Boolean
								Functions.Log_Write("I", "Add_Bowler.Load_Lanes")
								If LoadLanes Then
												Lane_Pick.Items.Clear()
												Dim lanes As List(Of TBDB.DB_Structure.Lanes_Get) = TBDB.DBLnkr.DB_Program.Lanes_Get()
												If lanes(0)._ERRMsg = Nothing Then
																'no error
																For Each i As TBDB.DB_Structure.Lanes_Get In lanes
																				Lane_Pick.Items.Add(i.Lane)
																Next
																Lane_Pick.SelectedIndex = 0
																Lane_Pick.Text = Lane_Pick.Items(0)
																Functions.Log_Write("I", "Add_Bowler.Load_Lanes", "Loaded lanes")
																LoadLanes = True
																Return True
												Else
																'error
																Functions.Log_Write("I", "Add_Bowler.Load_Lanes", "Error Loading Lanes: " & lanes(0)._ERRMsg)
																Return False
												End If
								End If
								Return True
				End Function

				Private Function Get_Bowler_ID(ByRef FName As String, ByRef LName As String) As Integer
								Functions.Log_Write("I", "Add_Bowler.Get_Bowler_ID")
								Dim bid As Integer = -1
								Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_ID_by_Name(FName, LName)
								If ret(0) Is Nothing Then
												'no data
								ElseIf (ret(0).ToString.Length < 16) Then
												'success
												Functions.Log_Write("S", "Add_Bowler.Get_Bowler_ID", "Retreived bowler id")
												bid = Integer.Parse(ret(0))
								Else
												Functions.Log_Write("E", "Add_Bowler.Get_Bowler_ID", "error getting bowler id: " & ret(0))
								End If
								Return bid
				End Function

				Private Sub Lane_Pick_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lane_Pick.SelectedIndexChanged
								Functions.Log_Write("I", "Add_Bowler.Lane_Pick_SelectedIndexChanged")
								'Load Lane Info
								Load_Lanes_Week()
				End Sub

				Private Sub Load_Lanes_Week()
								Functions.Log_Write("I", "Add_Bowler.Load_Lanes_Week")
								'First Clear DataTable
								Edit_Scores.Rows.Clear()
								'Loop Through Scores to Find Lane ID
								'"Bowler_ID", "Bowler_ID", "BAlias", "SUM3", "SUM4", "AVE" | "Scores" |
								Dim scores As List(Of TBDB.DB_Structure.Scores_Get_By_Week_Lane) = TBDB.DBLnkr.DB_Program.Scores_Get_By_Week_Lane(Weeks._WkID, Lane_Pick.Text)
								If scores.Count = 0 Then
												'no data
												Functions.Log_Write("W", "Add_Bowler.Load_Lanes_Week", "No Data For Week ID (" & Weeks._WkID & ") on Lane (" & Lane_Pick.Text & ")")
								ElseIf Not scores(0)._ERRMsg = Nothing Then
												'error
												Functions.Log_Write("E", "Add_Bowler.Load_Lanes_Week", "Error Week (" & Weeks._WkID & ") on Lane (" & Lane_Pick.Text & ") - " & scores(0)._ERRMsg)
								Else
												'success
												'0 to 8 s 9
												Functions.Log_Write("S", "Add_Bowler.Load_Lanes_Week", "Grabed Data For Week (" & Weeks._WkID & ") on Lane (" & Lane_Pick.Text & ")")
												For Each i In scores
																Dim baname As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(i.Bowler_ID)
																If baname.Count > 1 Then
																				'Data
																				'1 - FN, 2 - LN
																				Functions.Log_Write("S", "Add_Bowler.Load_Lanes_Week", "Bowler Name Got From ID (" & i.Bowler_ID & ")")
																				Dim ins As String = String.Empty
																				'ins &= scores(i) & "," 'Score ID
																				ins &= i.Bowler_ID & "," 'Bowler ID
																				ins &= baname(1) & " " & baname(2) & "," 'Bowler Name
																				ins &= i.BAlias & "," 'Bowler Alias
																				ins &= i.SUM3 & "," 'Sum 3
																				ins &= i.SUM4 & "," 'Sum [NGames]
																				ins &= i.AVE & "," 'average
																				ins &= Get_Game_Str(i.Scores)
																				Edit_Scores.Rows.Add(ins.Split(","))
																				'4 - scores
																				Functions.Log_Write("I", "Add_Bowler.Load_Lanes_Week", "Added Bowler (" & baname(1) & " " & baname(2) & ") to Week")
																ElseIf baname.Count = 0 Then
																				'no data
																				Functions.Log_Write("W", "Add_Bowler.Load_Lanes_Week", "Bowler Name Does Not Exists For ID (" & i.Bowler_ID & ")")
																Else
																				'error
																				Functions.Log_Write("E", "Add_Bowler.Load_Lanes_Week", "Bowler Name Error for ID (" & i.Bowler_ID & ") - " & baname(0))
																End If
												Next
								End If
				End Sub

				Private Function Get_Game_Str(ByRef gamestr As String) As String
								Dim gt As String = IIf(gamestr.Substring(gamestr.Length - 1, 1) = ",", gamestr.Substring(0, gamestr.Length - 1), gamestr)
								Dim gs As String() = gt.Split(",")
								For i As Byte = gs.Length To Weeks._GmsWk - 1
												gt &= ",0"
								Next
								Return gt
				End Function

				'--------------------------------------------------------
				'-- Main Section For Loading bowler, etc...
				'--------------------------------------------------------

				Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
								Functions.Log_Write("I", "Add_Bowler.Button1_Click")
								Add_New_Bowler_Week()
								Bowler_Name.Focus()
				End Sub

				Private Sub Add_New_Bowler_Week()
								Functions.Log_Write("I", "Add_Bowler.Add_New_Bowler_Week")
								'Check Info
								If Check_Info() Then
												Main.ERS.Get_Error(Errors.Err_Codes.Tourn_Bowler_INFO_WRN)
								Else
												'Insert Bowler
												'MsgBox("Insert Bowler OVERIDE")
												If Insert_Bowler() Then
																Add_Bowler_Dropdown(Bowler_Name.Text)
																Bowler_Name.Text = String.Empty
												End If
								End If
				End Sub

				Private Sub Add_Bowler_Dropdown(ByVal name As String)
								'add bowler to drop down list
								Functions.Log_Write("I", "Add_Bowler.Add_Bowler_Dropdown")
								Bowler_Name.AutoCompleteCustomSource.Add(name)
				End Sub

				Private Function Insert_Bowler() As Boolean
								Functions.Log_Write("I", "Add_Bowler.Insert_Bowler")
								Dim name As String() = Bowler_Name.Text.Split(" ")
								Dim ret As String = TBDB.DBLnkr.DB_Program.Bowler_Insert(name(0), name(1), USBC_ID.Text.Trim(), Sex.Text)
								If ret = "1" Then
												Functions.Log_Write("S", "Add_Bowler.Insert_Bowler", "added bowler successfully")
												Insert_Scores(name(0), name(1))
								Else
												Functions.Log_Write("E", "Add_Bowler.Insert_Bowler", "could not insert bowler: " & ret)
												Return False
								End If
								Sex.SelectedIndex = -1
								USBC_ID.Text = ""
								Return True
				End Function

				Private Sub Insert_Scores(ByRef FName As String, ByRef LName As String)
								Functions.Log_Write("I", "Add_Bowler.Insert_Scores")
								Dim gamesx As String = String.Empty
								For i As Byte = 1 To Weeks._GmsWk
												gamesx &= "0,"
								Next
								Dim INSX As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Scores_Insert(Weeks._WkID, Lane_Pick.Text, Get_Bowler_ID(FName, LName), gamesx, 0, 0, "0.00")
								If Not INSX.ERR Then
												'success
												Functions.Log_Write("S", "Add_Bowler.Insert_Scores", "adding scores into db for: " & FName & " " & LName)
												Dim ins As String = Get_Bowler_ID(FName, LName) & "|" & Bowler_Name.Text & "||0|0|0.00|" & gamesx.Replace(",", "|")
												Insert_Bowler_Into_Grid(ins)
								Else
												'failure
												Functions.Log_Write("E", "Add_Bowler.Insert_Scores", "error inserting scores: " & INSX.ERRMsg)
								End If
				End Sub

				Private Sub Insert_Bowler_Into_Grid(ByVal ins_str As String)
								Functions.Log_Write("I", "Add_Bowler.Insert_Bowler_Into_Grid")
								Edit_Scores.Rows.Add(ins_str.Split("|"))
								Load_bowlers()
				End Sub

				Private Function Check_Info() As Boolean
								Functions.Log_Write("I", "Add_Bowler.Check_Info")
								If Sex.SelectedIndex = -1 Or Bowler_Name.Text.Length = 0 Or Not Bowler_Name.Text.Contains(" ") Or Bowler_Name.Text.Length < 3 Then
												Return True
								Else
												Return False
								End If
				End Function

				Private Sub Bowler_Name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bowler_Name.Leave
								Functions.Log_Write("I", "Add_Bowler.Bowler_Name_Leave")
								Dim nme As String = ""
								If Check_Name(Bowler_Name.Text) Then
												Dim Name As String() = Bowler_Name.Text.Split(" ")
												nme = Name(0).Substring(0, 1)
												nme = nme.ToUpper
												Name(0) = nme & Name(0).Substring(1, Name(0).Length - 1)
												nme = Name(1).Substring(0, 1)
												nme = nme.ToUpper
												Name(1) = nme & Name(1).Substring(1, Name(1).Length - 1)
												Bowler_Name.Text = Name(0) & " " & Name(1)
												'If Bowler Exists
												'Get Bowler ID
												Dim baname As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_ID_by_Name(Name(0), Name(1))
												If baname(0) = Nothing Then
																'no data
																Functions.Log_Write("W", "Add_Bowler.Bowler_Name_Leave", "No Data Exists for (" & Name(0) & " " & Name(1) & ")")
																Sex.Enabled = True
																USBC_ID.Enabled = True
																Button1.Enabled = True
																Sex.Focus()
												ElseIf baname(0).ToString.Length < 16 Then
																'no error - bowler name exists
																Functions.Log_Write("S", "Add_Bowler.Bowler_Name_Leave", "Data Grabbed for (" & Name(0) & " " & Name(1) & ")")
																'Check if bowler exists for Week
																Dim bwk As TBDB.DB_Structure.Scores_Check_Bowler_Exists_BID = TBDB.DBLnkr.DB_Program.Scores_Check_Bowler_Exists_BID(baname(0))
																If Not bwk._ERRMsg = Nothing Then
																				'error
																				Functions.Log_Write("E", "Add_Bowler.Bowler_Name_Leave", "Error check if bowler (" & baname(0) & ") exists in week (" & Weeks._WkNM & "): " & bwk._ERRMsg)
																ElseIf bwk.Exists Then
																				'bowler exists in week, grab lane
																				Functions.Log_Write("I", "Add_Bowler.Bowler_Name_Leave", "Bowler Exists In Week, grabbing current lane")
																				Dim biwk As TBDB.DB_Structure.Scores_Lane_By_WKID_BID = TBDB.DBLnkr.DB_Program.Scores_Lane_By_WKID_BID(Weeks._WkID, Integer.Parse(baname(0)))
																				If biwk._ERRMsg = Nothing And biwk.Lane_ID = 0 Then
																								'bowler does not exists in week, add to lane
																								Functions.Log_Write("I", "Add_Bowler.Bowler_Name_Leave", "Bowler Does Not Exists in week, adding to lane")
																								Insert_Scores(Name(0), Name(1))
																								Sex.SelectedIndex = -1
																								USBC_ID.ResetText()
																								Button1.Enabled = False
																								Bowler_Name.ResetText()
																				ElseIf Not biwk.Lane_ID = Nothing Then
																								'lane found
																								Functions.Log_Write("W", "Add_Bowler.Bowler_Name_Leave", "Bowler exists on lane ID: " & biwk.Lane_ID)
																								Sex.Enabled = False
																								USBC_ID.Enabled = False
																								Button1.Enabled = False
																				Else
																								'error
																								Functions.Log_Write("E", "Add_Bowler.Bowler_Name_Leave", "Error checking for bowler (" & baname(0) & ") for week (" & Weeks._WkNM & ") : " & biwk._ERRMsg)
																				End If
																Else
																				'bowler does not exists in week, add to lane
																				Functions.Log_Write("I", "Add_Bowler.Bowler_Name_Leave", "Bowler Does Not Exists in week, adding to lane")
																				Insert_Scores(Name(0), Name(1))
																				Sex.SelectedIndex = -1
																				USBC_ID.ResetText()
																				Button1.Enabled = False
																				Bowler_Name.ResetText()
																End If
												Else
																'error
																Functions.Log_Write("E", "Add_Bowler.Bowler_Name_Leave", "Error for (" & Name(0) & " " & Name(1) & ") - " & baname(0))
												End If
								End If
				End Sub

				Private Function Check_Name(ByVal name As String) As Boolean
								Functions.Log_Write("I", "Add_Bowler.Check_Name")
								If Bowler_Name.Text.Length = 0 Or Not Bowler_Name.Text.Contains(" ") Or Bowler_Name.Text.Length < 3 Then
												'Not Correct
												Return False
								Else
												Dim Names As String() = Bowler_Name.Text.Split(" ")
												If Names(0).Length < 1 Or Names(1).Length < 1 Then
																Return False
												End If
												'Correct
												Return True
								End If
				End Function

				Private Sub Edit_Scores_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Edit_Scores.CellEndEdit
								Functions.Log_Write("I", "Add_Bowler.Edit_Scores_CellValueChanged")
								'MsgBox("Rows: " & Edit_Scores.Rows.Count)
								If Edit_Scores.Rows.Count > 0 Then
												Dim Row As Integer = e.RowIndex
												Update_Scores(Row)
												Update_Average(Row)
												Dim Scores As String = ""
												For i As Byte = 6 To 5 + Weeks._GmsWk
																Scores &= Edit_Scores.Rows(Row).Cells(i).Value & ","
												Next
												Scores = Scores.Substring(0, Scores.Length - 1)
												'Dim Scores As String = Edit_Scores.Rows(Row).Cells(1).Value & "," & Edit_Scores.Rows(Row).Cells(2).Value & "," & Edit_Scores.Rows(Row).Cells(3).Value & "," & Edit_Scores.Rows(Row).Cells(4).Value
												Dim SID As Integer = Edit_Scores.Rows(Row).Cells("ID").Value
												Dim Ser3 As Integer = Edit_Scores.Rows(Row).Cells("Series3").Value
												Dim SerX As Integer = Edit_Scores.Rows(Row).Cells("series4").Value
												Dim Ave As String = Edit_Scores.Rows(Row).Cells("Average").Value.ToString
												Dim BAlias As String = Edit_Scores.Rows(Row).Cells(2).Value
												'MsgBox("Row - " & Row & " - Name: " & Name(0) & " " & Name(1) & " - Scores: " & Scores & " - Ave: " & Ave)
												Dim upd As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Scores_Update_By_BID_LID_WKID(SID, Lane_Pick.Text, Weeks._WkID, Scores, Ser3, SerX, Ave, BAlias)
												If Not upd.ERR Then
																'success
																Functions.Log_Write("S", "Add_Bowler.Edit_Scores_CellValueChanged", "Scores Updated for SID (" & SID & ")")
												Else
																'failure
																Functions.Log_Write("E", "Add_Bowler.Edit_Scores_CellValueChanged", "Error Updating Scores for SID ( " & SID & ")")
												End If
												'MsgBox("Updated Scores")
								End If
				End Sub

				Private Function Format_Ave(ByRef average As Decimal) As String
								Functions.Log_Write("I", "Add_Bowler.Format_Ave")
								'Dim ave As String = Edit_Scores.Rows(row).Cells(7).Value
								Dim ave As String = average.ToString
								'MsgBox(ave)
								Dim Avs As String() = ave.Split(".")
								If Avs.Count = 1 Then
												'Has no decimal
												ave = ave & ".00"
								Else
												'Has decimal
												If Avs(1).Length = 1 Then
																'Has 1 Decimal
																ave = ave & "0"
												End If
								End If
								Return ave
				End Function

				Private Sub Update_Scores(ByRef row As SByte)
								Functions.Log_Write("I", "Add_Bowler.Update_Scores")
								Dim Scores As Short() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
								Dim value As Short = 0

								For i As SByte = 6 To 5 + Weeks._GmsWk
												Try
																value = Short.Parse(Edit_Scores.Rows(row).Cells(i).Value)
																If value > 300 Then
																				value = 300
																ElseIf value < 0 Then
																				value = 0
																End If
																Scores(i - 6) = value
																Edit_Scores.Rows(row).Cells(i).Value = value
												Catch ex As Exception
																'Value is Not Integer
																Edit_Scores.Rows(row).Cells(i).Value = 0
												End Try
								Next
								Dim s3 As Integer = Scores(0) + Scores(1) + Scores(2)
								Dim s4 As Integer = 0
								For i As Byte = 0 To Scores.Length - 1
												s4 += Scores(i)
								Next
								Edit_Scores.Rows(row).Cells("Series3").Value = s3
								Edit_Scores.Rows(row).Cells("series4").Value = s4
								Edit_Scores.Refresh()
				End Sub

				Private Sub Update_Average(ByRef row As SByte)
								Functions.Log_Write("I", "Add_Bowler.Update_Average")
								Dim games As SByte = 0
								For i As SByte = 6 To 5 + Weeks._GmsWk
												If Edit_Scores.Rows(row).Cells(i).Value > 0 Then
																games += 1
												End If
								Next
								'MsgBox("UA - Games: " & games & " | Row: " & row)
								If games > 0 Then
												Dim ave As Decimal = 0.0
												'MsgBox(Edit_Scores.Rows(row).Cells(4).Value)
												ave = Math.Round(Edit_Scores.Rows(row).Cells(4).Value / games, 2)
												Edit_Scores.Rows(row).Cells(5).Value = Format_Ave(ave)
								Else
												Edit_Scores.Rows(row).Cells(5).Value = "0.00"
								End If
				End Sub

				Private Sub Sex_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Sex.KeyDown, USBC_ID.KeyDown
								Functions.Log_Write("I", "Add_Bowler.Sex_SelectedIndexChanged")
								If e.KeyCode = Keys.Enter Then
												Add_New_Bowler_Week()
												Bowler_Name.Focus()
								End If
				End Sub

				Private Sub Grid_Row_Click(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles Edit_Scores.CellMouseClick
								Functions.Log_Write("I", "Add_Bowler.Grid_Row_Click")
								If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex >= 0 Then
												ContextMenuStrip1.Items.Clear()
												Dim name As String() = Edit_Scores.Rows(e.RowIndex).Cells(1).Value.ToString.Split(" ")
												Dim bid As Integer = Edit_Scores.Rows(e.RowIndex).Cells(0).Value
												ContextMenuStrip1.Items.Add(bid & "-" & e.RowIndex & " - Edit Bowlers")
												ContextMenuStrip1.Items.Add(bid & "-" & e.RowIndex & " - Remove From Week")
												ContextMenuStrip1.Items.Add(bid & "-" & e.RowIndex & " - Change Lane")
												ContextMenuStrip1.Show(New Point(MousePosition.X, MousePosition.Y))
								End If
				End Sub

				Private Sub ContextMenu_click(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
								Functions.Log_Write("I", "Add_Bowler.ContextMenu_click")
								Dim text As String = e.ClickedItem.Text

								Dim cont As String() = text.Split("-")
								Dim bid As Integer = Integer.Parse(cont(0))
								Dim row As Integer = Integer.Parse(cont(1))

								If text.Contains("Edit") Then
												'Edit Bowler
												Bowler_Info._BID = bid
												Main.FUNC.Cont = New Bowler_Info
												Main.FUNC.Change_Cont()
								ElseIf text.Contains("Remove") Then
												'Remove Bowler From Week
												If MsgBox("Remove Bowler From Week?" & Chr(13) & "All Scores For This Week Will Be Lost", MsgBoxStyle.YesNo, "Are You Sure") = MsgBoxResult.Yes Then
																Dim del As TBDB.DB_Structure.Boolean_Response = TBDB.DBLnkr.DB_Program.Scores_Delete_By_WKID_BID(Weeks._WkID, bid)
																If Not del.ERR Then
																				'success
																				Functions.Log_Write("S", "Add_Bowler.ContextMenu_click", "deleted scores for week: " & Weeks._WkID & " - bid: " & bid)
																				Load_Page()
																				Load_Lanes_Week()
																Else
																				'failure
																				Functions.Log_Write("E", "Add_Bowler.ContextMenu_click", "error trying to delete scores for week: " & Weeks._WkID & " - bid: " & bid)
																End If
												End If
								ElseIf text.Contains("Change") Then
												'coming Soon
												Bowler_Info._BID = bid
												If Change_Lane.ShowDialog = DialogResult.OK Then
																'Continue After Move Successful
																Load_Lanes_Week()
												End If
								End If
				End Sub

				Private Sub SMonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMonImport.Click
								Functions.Log_Write("I", "Add_Bowler.SMonImport_Click")
								MsgBox("In Development")
								Dim scores As String() = {""}
								Dim gseries As Integer() = {0}

								'Temp Table
								Dim dat As String() = {"ID", "BN", "SA", "3GS", "4GS", "AVE", "G1", "G2", "G3", "G4"}

								'Main.DB.SCORA.Get_Scores_Week(SDB, Weeks._WkID)
								'Load_Lanes_Week()
				End Sub

				'Private Sub NGames_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
				'    Functions.Log_Write("I", "Add_Bowler.Ngames_ValueChanged")
				'    'Setup the Table
				'    Main.DB.WIKSA.Update_NGames(NGames.Value, Weeks._WkID)
				'    Main.FUNC._GAMES = NGames.Value
				'    Dim tlen As Byte = Edit_Scores.Columns.Count - 6 '# of game colums already there
				'    If NGames.Value < tlen Then
				'        'Remove Columns
				'        For i As Byte = 1 To (tlen - NGames.Value)
				'            Edit_Scores.Columns.Remove("G" & NGames.Value + i)
				'        Next
				'    Else
				'        'Add Columns
				'        For i As Byte = 1 To (NGames.Value - tlen)
				'            Edit_Scores.Columns.Add("G" & tlen + i, "G" & tlen + i)
				'        Next
				'    End If
				'    Edit_Scores.Columns(4).HeaderText = NGames.Value & "G Series"
				'    If Edit_Scores.Rows.Count > 1 Then
				'        For i As Byte = 0 To Edit_Scores.Rows.Count - 1
				'            Update_Scores(i)
				'            Update_Average(i)
				'        Next
				'    End If
				'    If loaded Then
				'        Check_SMon()
				'        Load_Lanes_Week()
				'    End If
				'End Sub

End Class
