Imports System.Threading
Imports TBDB

Public Class Edit_Tournament

				Private ReadOnly WIN As Color = Color.LimeGreen
				Private ReadOnly TIE As Color = Color.Turquoise
				Private ReadOnly LOSE As Color = Color.Crimson
				Private Loaded As Boolean = False
				Private CONTENT As String()
				Private SCWinDir As New Hashtable
				Private SCWinCmp As New Hashtable

				Private Sub Edit_Tournament_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
								WriteLog("I", "Edit_Tournament.Edit_Tournament_Load")
								ChangeHeaderText("Tournament Layout")
								Fill_Hash()
								Load_Lanes()
								Load_Tournament()
				End Sub

				Private Sub Fill_Hash()
								WriteLog("I", "Edit_Tournament.Fill_Hash")
								With SCWinDir
												.Add("SC11", "SC21")
												.Add("SC12", "SC21")
												.Add("SC13", "SC22")
												.Add("SC14", "SC22")
												.Add("SC15", "SC23")
												.Add("SC16", "SC23")
												.Add("SC17", "SC24")
												.Add("SC18", "SC24")
												.Add("SC21", "SC31")
												.Add("SC22", "SC31")
												.Add("SC23", "SC32")
												.Add("SC24", "SC32")
												.Add("SC31", "SC41")
												.Add("SC32", "SC41")
								End With
								With SCWinCmp
												.Add("SC11", "SC12")
												.Add("SC13", "SC14")
												.Add("SC15", "SC16")
												.Add("SC17", "SC18")
												.Add("SC21", "SC22")
												.Add("SC23", "SC24")
												.Add("SC31", "SC32")
								End With
				End Sub

				Private Sub Load_Lanes()
								WriteLog("I", "Edit_Tournament.Load_Lanes")
								Dim SLane As Byte = 1
								L1.Text = "#" & SLane
								L2.Text = "#" & SLane + 1
								L3.Text = "#" & SLane + 2
								L4.Text = "#" & SLane + 3
								L5.Text = "#" & SLane + 4
								L6.Text = "#" & SLane + 5
								L7.Text = "#" & SLane + 6
								L8.Text = "#" & SLane + 7
								L9.Text = "#" & SLane + 4
								L10.Text = "#" & SLane + 5
								L11.Text = "#" & SLane + 2
								L12.Text = "#" & SLane + 3
								L13.Text = "#" & SLane + 6
								L14.Text = "#" & SLane + 7
				End Sub

				Private Sub Reset_Tournament(ByVal tf As Boolean)
								WriteLog("I", "Edit_Tournament.Reset_Tournament")
								Loaded = False
								Dim SC1 As String = "SC11|SC12|SC13|SC14|SC15|SC16|SC17|SC18|SC21|SC22|SC23|SC24|SC31|SC32"
								Dim SC As String() = SC1.Split("|")
								Dim BN1 As String = "BN11|BN12|BN13|BN14|BN15|BN16|BN17|BN18|BN21|BN22|BN23|BN24|BN31|BN32"
								Dim BN As String() = BN1.Split("|")
								Enable_Page(tf, "SC11|SC12|SC13|SC14|SC15|SC16|SC17|SC18|SC21|SC22|SC23|SC24|SC31|SC32")
								CB11.Checked = tf
								CB12.Checked = tf
								CB13.Checked = tf
								CB14.Checked = tf
								CB15.Checked = tf
								CB16.Checked = tf
								CB17.Checked = tf
								CB18.Checked = tf
								CB21.Checked = tf
								CB22.Checked = tf
								CB23.Checked = tf
								CB24.Checked = tf
								CB31.Checked = tf
								CB32.Checked = tf
								For i As Byte = 1 To 14
												Controls(SC(i - 1)).Text = 0
												Controls(BN(i - 1)).Text = ""
												Controls(BN(i - 1)).BackColor = Color.White
								Next
								BN41.Text = ""
				End Sub

				Private Sub Tournament_Save()
								Dim TH As New System.Threading.Thread(AddressOf Tournament_Save_Thread)
								TH.Start()
								'Tournament_Save_Thread()
				End Sub

				Private Sub Tournament_Save_Thread()
								WriteLog("I", "Edit_Tournament.Tournament_Save")
								'Loop through all tournaments fields and save
								Dim str As String = String.Empty
								'Names
								WriteLog("I", "Edit_Tournament.Tournament_Save", "Names to DataBase input")
								For i As Integer = 1 To Controls.Count
												If Controls(i - 1).Name.StartsWith("BN") Then
																WriteLog("D", "Edit_Tournament.Tournament_Save", "adding (" & Controls(i - 1).Text & ")")
																str &= Controls(i - 1).Name & "," & Controls(i - 1).Text & ","
												End If
												'Scores
												If Controls(i - 1).Name.StartsWith("SC") Then
																Dim SC As NumericUpDown = Controls(i - 1)
																WriteLog("D", "Edit_Tournament.Tournament_Save", "adding (" & SC.Value & ")")
																str &= SC.Name & "," & SC.Value & ","
												End If
												'Check Boxes
												If Controls(i - 1).Name.StartsWith("CB") Then
																Dim CB As CheckBox = Controls(i - 1)
																WriteLog("D", "Edit_Tournament.Tournament_Save", "adding (" & CB.Checked & ")")
																str &= CB.Name & "," & CB.Checked.ToString & ","
												End If
								Next
								str = str.Substring(0, str.Length - 1)
								'Save tournament
								WriteLog("I", "Edit_Tournament.Tournament_Save", "Commencing Save Procedure")
								Dim save As String = TBDB.DBLnkr.DB_Program.Tournament_Update_Data_By_WkID(GetWeekId(), str)
								If save = "1" Then
												'success
												WriteLog("S", "Edit_Tournament.Tournament_Save", "Tournament Updated")
								Else
												'failure
												WriteLog("E", "Edit_Tournament.Tournament_Save", "Tournament Update Failed: " & save)
								End If
				End Sub

				Private Sub Load_Tournament()
								WriteLog("I", "Edit_Tournament.Load_Tournament")
								'Check if week is available
								Dim exists As String = TBDB.DBLnkr.DB_Program.Tournament_Exists(GetWeekId())
								If exists = "1" Then
												'Week Available data got, fill tournament
												WriteLog("E", "Edit_Tournament.Load_Tournament", "tournament exists for week id (" & GetWeekId() & ") - loading data")
												Dim data As String = TBDB.DBLnkr.DB_Program.Tournament_Get_Data(GetWeekId())
												Dim conts As String() = data.Split(",")
												'Bowler Names
												For i As Integer = 0 To conts.Length - 2 Step 2
																WriteLog("D", "Edit_Tournament.Load_Tournament", "loading control (" & conts(i) & ") with data (" & conts(i + 1) & ")")
																If conts(i).StartsWith("BN") Then
																				Controls(conts(i)).Text = conts(i + 1)
																End If
												Next
												'Bowler Scores
												For i As Integer = 0 To conts.Length - 2 Step 2
																If conts(i).StartsWith("SC") Then
																				Dim sc As NumericUpDown = TryCast(Controls(conts(i)), NumericUpDown)
																				sc.Value = conts(i + 1)
																				'Controls.RemoveByKey(conts(i))
																				'Controls.Add(sc)
																End If
												Next
												'Bowler checkboxes
												For i As Integer = 0 To conts.Length - 2 Step 2
																If conts(i).StartsWith("CB") Then
																				Dim cb As CheckBox = TryCast(Controls(conts(i)), CheckBox)
																				cb.Checked = conts(i + 1)
																				'Controls.RemoveByKey(conts(i))
																				'Controls.Add(cb)
																End If
												Next
												WriteLog("D", "Edit_Tournament.Load_Tournament", "finished loading tournament")
								ElseIf exists = "0" Then
												'No data, check if there are top 8 scores and fill tournament to insert data
												WriteLog("E", "Edit_Tournament.Load_Tournament", "tournament does not exist for week id (" & GetWeekId() & ") - inserting data")
												Dim data As List(Of TBDB.DB_Structure.Scores_Get_List) = TBDB.DBLnkr.DB_Program.Scores_Get_List(GetWeekId())
												'if data not long enough, reset = false, else reset = true
												'scores 1 to 9
												If data.Count >= 8 Then
																'8 bowlers in sheet, insert
																Dim cnt As Byte = 10
																Dim lop As Byte = 1

																While lop <= 8
																				Dim DBS = data(TSetup.Lineup(lop - 1) - 1)
																				WriteLog("D", "Edit_Tournament.Load_Tournament", "loading bowler name for id (" & DBS.Bowler_ID & ")")
																				Dim BName As String = Get_Bowler_Name(DBS.Bowler_ID)
																				Dim ctrl As Integer = cnt + lop
																				Controls("BN" & ctrl.ToString).Text = BName
																				lop += 1
																End While

																'Insert into Tournament Table
																TBDB.DBLnkr.DB_Program.Tournament_Insert(GetWeekId(), "")
																'Save Data
																Tournament_Save()
												Else
																'not enough bowlers
																Enable_Page(False, "CB11|CB12|CB13|CB14|CB15|CB16|CB17|CB18|CB21|CB22|CB23|CB24|CB31|CB32")
																Enable_Page(False, "SC11|SC12|SC13|SC14|SC15|SC16|SC17|SC18|SC21|SC22|SC23|SC24|SC31|SC32")
																Enable_Page(False, "BN11|BN12|BN13|BN14|BN15|BN16|BN17|BN18|BN21|BN22|BN23|BN24|BN31|BN32")
																WriteLog("W", "Edit_Tournament.Load_Tournament", "Not enough bowlers in week (" & data.Count & " out of 8)")
												End If
								Else
												'error
												WriteLog("E", "Edit_Tournament.Load_Tournament", "Error checking if tournament exists for week id (" & GetWeekId() & "): " & exists)
												Reset_Tournament(False)
								End If

				End Sub

				Private Function Get_Bowler_Name(ByVal id As Integer)
								WriteLog("I", "Edit_Tournament.Get_Bowler_Name")
								Dim name As String = ""
								Dim ret As ArrayList = TBDB.DBLnkr.DB_Program.Bowler_Get_By_ID(id)
								If ret.Count = 0 Then
												'no data
												WriteLog("W", "Edit_Tournament.Get_Bowler_Name", "no data for bowler id (" & id & ")")
								ElseIf ret(0).ToString.Length < 16 Then
												'error
												name = ret(1) & " " & ret(2)
												WriteLog("S", "Edit_Tournament.Get_Bowler_Name", "Retreived bowler name: " & name)
								Else
												WriteLog("E", "Edit_Tournament.Get_Bowler_Name", "could not load bowler name: " & ret(0))
								End If
								Return name
				End Function

				Private Sub Enable_Page(ByVal tf As Boolean, ByVal conts As String)
								WriteLog("I", "Edit_Tournament.Enable_Page", "Enabling Page = " & tf.ToString & ", for controls (" & conts & ")")
								Dim con As String() = conts.Split("|")
								For i As Byte = 0 To con.Length - 1
												WriteLog("D", "Edit_Tournament.Enable_Page", "Setting control (" & con(i) & ") to value (" & tf & ")")
												Controls(con(i)).Enabled = tf
								Next
								conts = conts.Replace("SC", "CB")
								con = conts.Split("|")
								For i As Byte = 0 To con.Length - 1
												WriteLog("D", "Edit_Tournament.Enable_Page", "Setting control (" & con(i) & ") to value (" & tf & ")")
												Controls(con(i)).Enabled = tf
								Next
				End Sub

				Private Sub Del_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Del.Click
								If MsgBox("Are You Sure You Want To Delete This Tournament?", MsgBoxStyle.YesNo, "Are You Sure?") = MsgBoxResult.Yes Then
												Dim del As String = DBLnkr.DB_Program.Tournament_Delete_By_Week_ID(GetWeekId())
												If del = "1" Then
																'success
																WriteLog("S", "Edit_Tournament.Del_Click", "deleted tournament for week: " & GetWeekId())
																Reset_Tournament(False)
																Load_Tournament()
												Else
																'failure
																WriteLog("E", "Edit_Tournament.Del_Click", "could not delete tournament for week: " & GetWeekId())
												End If
								End If
				End Sub

				Private Sub CBX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB11.CheckedChanged, CB12.CheckedChanged, CB13.CheckedChanged, CB14.CheckedChanged, CB15.CheckedChanged, CB16.CheckedChanged, CB17.CheckedChanged, CB18.CheckedChanged, CB21.CheckedChanged, CB22.CheckedChanged, CB23.CheckedChanged, CB24.CheckedChanged, CB31.CheckedChanged, CB32.CheckedChanged
								WriteLog("I", "Edit_Tournament.CBX_CheckChanged")
								Dim CB As CheckBox = sender
								If CB.Checked Then
												WriteLog("I", "Edit_Tournament.CBX_CheckChanged", "Is Checked, Override Scores")
												Dim nb_scnme As String = Get_WinCtrl(CB.Name.Replace("CB", "SC"))
												SetText(nb_scnme.Replace("SC", "BN"), Controls(CB.Name.Replace("CB", "BN")).Text)
												Change_Color(CB.Name.Replace("CB", "BN"), Get_Comp(CB.Name.Replace("CB", "SC")), Equation.sc1_eq_sc2)
								Else
												WriteLog("I", "Edit_Tournament.CBX_CheckChanged", "Not Checked, Resetting Scores")
												Dim SC As NumericUpDown = Controls(CB.Name.Replace("CB", "SC"))
												SC.Value += 1
												SC.Value -= 1
								End If
								Tournament_Save()
				End Sub

				Private Sub BNX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BN11.TextChanged, BN12.TextChanged, BN13.TextChanged, BN14.TextChanged, BN15.TextChanged, BN16.TextChanged, BN17.TextChanged, BN18.TextChanged, BN21.TextChanged, BN22.TextChanged, BN23.TextChanged, BN24.TextChanged, BN31.TextChanged, BN32.TextChanged
								WriteLog("I", "Edit_Tournament.BNX_TextChanged", "Set Score to zero")
								Dim TB As TextBox = sender
								Dim SC As NumericUpDown = Controls(TB.Name.Replace("BN", "SC"))
								SC.Value = 0
				End Sub

				Private Sub SCX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC11.ValueChanged, SC12.ValueChanged, SC13.ValueChanged, SC14.ValueChanged, SC15.ValueChanged, SC16.ValueChanged, SC17.ValueChanged, SC18.ValueChanged, SC21.ValueChanged, SC22.ValueChanged, SC23.ValueChanged, SC24.ValueChanged, SC31.ValueChanged, SC32.ValueChanged
								WriteLog("I", "Edit_Tournament.SCX_ValueChanged")
								Dim SC As NumericUpDown = sender
								WriteLog("I", "Edit_Tournament.SCX_ValueChanged", "Control (" & SC.Name & ") value changed")
								Dim comp As NumericUpDown = Controls(Get_Comp(SC.Name))
								'Determin which score is better
								Dim CBSC As CheckBox = Controls(SC.Name.Replace("SC", "CB"))
								Dim CBCM As CheckBox = Controls(Get_Comp(SC.Name).Replace("SC", "CB"))
								If CBSC.Checked Or CBCM.Checked Then
												WriteLog("W", "Edit_Tournament.SCX_ValueChanged", "Override is checked, upholding checked law | M: " & CBSC.Checked & " - C: " & CBCM.Checked)
								Else
												If SC.Value > comp.Value Then
																'Greater
																WriteLog("I", "Edit_Tournament.SCX_ValueChanged", SC.Name & " > " & comp.Name)
																Dim nctrl As String = Get_WinCtrl(SC.Name)
																SetText(nctrl.Replace("SC", "BN"), Controls(SC.Name.Replace("SC", "BN")).Text)
																Change_Color(SC.Name, comp.Name, Equation.sc1_gt_sc2)
												ElseIf SC.Value < comp.Value Then
																'Less than
																WriteLog("I", "Edit_Tournament.SCX_ValueChanged", SC.Name & " < " & comp.Name)
																Dim nctrl As String = Get_WinCtrl(comp.Name)
																SetText(nctrl.Replace("SC", "BN"), Controls(comp.Name.Replace("SC", "BN")).Text)
																Change_Color(SC.Name, comp.Name, Equation.sc1_lt_sc2)
												Else
																'Tie
																WriteLog("I", "Edit_Tournament.SCX_ValueChanged", SC.Name & " = " & comp.Name)
																If SC.Value = 0 And comp.Value = 0 Then
																				'both invalid, set to white
																				Dim nctrl As String = Get_WinCtrl(SC.Name)
																				SetText(nctrl.Replace("SC", "BN"), "")
																				Change_Color(SC.Name, comp.Name, Equation.white)
																Else
																				Change_Color(SC.Name, comp.Name, Equation.sc1_eq_sc2)
																End If
												End If
								End If
								Tournament_Save()
				End Sub

				Private Enum Equation As Byte
								sc1_gt_sc2 = 1
								sc1_lt_sc2 = 2
								sc1_eq_sc2 = 3
								white = 4
				End Enum

				Private Sub Change_Color(ByVal sc1 As String, ByVal sc2 As String, ByVal equ As Equation)
								WriteLog("I", "Edit_Tournament.Change_Color")
								Select Case equ
												Case Equation.sc1_gt_sc2
																'SC1 - green, SC2 - red
																WriteLog("I", "Edit_Tournament.Change_Color", sc1 & " - Win | Lose - " & sc2)
																Set_Color(sc1.Replace("SC", "BN"), WIN)
																Set_Color(sc2.Replace("SC", "BN"), LOSE)
												Case Equation.sc1_lt_sc2
																'SC1 - red, SC2 - green
																WriteLog("I", "Edit_Tournament.Change_Color", sc2 & " - Win | Lose - " & sc1)
																Set_Color(sc1.Replace("SC", "BN"), LOSE)
																Set_Color(sc2.Replace("SC", "BN"), WIN)
												Case Equation.sc1_eq_sc2
																'SC1 & SC2 - blue
																WriteLog("I", "Edit_Tournament.Change_Color", sc1 & " - Tie - " & sc2)
																Set_Color(sc1.Replace("SC", "BN"), TIE)
																Set_Color(sc2.Replace("SC", "BN"), TIE)
												Case Equation.white
																WriteLog("I", "Edit_Tournament.Change_Color", sc1 & " - White - " & sc2)
																Set_Color(sc1.Replace("SC", "BN"), Color.White)
																Set_Color(sc2.Replace("SC", "BN"), Color.White)
								End Select
				End Sub

				Private Sub Set_Color(ByVal ctrl As String, ByVal color As Color)
								WriteLog("I", "Edit_Tournament.Set_Color", "Setting control (" & ctrl & ") - background color (" & color.ToKnownColor & ")")
								Controls(ctrl).BackColor = color
				End Sub

				Private Sub SetText(ByVal ctrl As String, ByVal text As String)
								WriteLog("I", "Edit_Tournament.Set_Color", "Setting control (" & ctrl & ") - text (" & text & ")")
								Controls(ctrl).Text = text
				End Sub

				Private Function Get_Comp(ByVal init As String) As String
								Dim ret As String = ""
								For Each DIC As DictionaryEntry In SCWinCmp
												If DIC.Key = init Then
																ret = DIC.Value
												ElseIf DIC.Value = init Then
																ret = DIC.Key
												End If
								Next
								Return ret
				End Function

				Private Function Get_WinCtrl(ByVal init As String) As String
								Dim ret As String = ""
								For Each DIC As DictionaryEntry In SCWinDir
												If DIC.Key = init Then
																ret = DIC.Value
												End If
								Next
								Return ret
				End Function

End Class