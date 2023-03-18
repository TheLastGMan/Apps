Imports TBDB
Public Class Weeks

				Public Shared _WkLst As New ArrayList
				Public Shared _WkID As Integer = -1
				Public Shared _WkNM As String = String.Empty
				Public Shared _GmsWk As Short = 4
				Public Shared _ScoMin As Short = 600
				'ID, Description, Tournament Namespace, Lineup Namespace

				Private Sub Weeks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
								Functions.Log_Write("I", "Weeks.Weeks_Load")
								Main.FUNC.Change_Header(Me.Name)
								DateTimePicker1.Value = Now()
								Load_weeks()
								load_tournament()
								Set_Week_ID()
								If _WkNM.Length > 0 Then
												Weeks_DEL.Text = _WkNM
								Else
												Weeks_DEL.SelectedIndex = Weeks_DEL.Items.Count - 1
								End If
								Set_Week_Stats()
								Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Load_OK)
				End Sub

				Public Shared Sub GetWeekList(ByRef lst As ArrayList)
								_WkLst = DBLnkr.DB_Program.Weeks_Get_List()
								lst = _WkLst
				End Sub

				Public Shared Sub GetWeekId(ByRef id As Integer)
								id = _WkID
				End Sub

				Public Shared Sub GetWeekName(ByRef weekName As String)
								weekName = _WkNM
				End Sub

				Public Shared Sub GetGamesPerWeek(ByRef gpw As Short)
								gpw = _GmsWk
				End Sub

				Public Shared Sub GetMinimumScore(ByRef gms As Short)
								gms = _ScoMin
				End Sub

				Private Sub load_tournament()
								Functions.Log_Write("I", "Weeks.load_tournament")
								TStyle.ResetText()
								TStyle.Items.Clear()
								Settings._TrnLst = load_tournaments_handler("T")
								If Settings._TrnLst.Count > 1 Then
												For i As Byte = 1 To Settings._TrnLst.Count Step 2
																TStyle.Items.Add(Settings._TrnLst(i - 1))
												Next
												TStyle.SelectedIndex = IIf(TStyle.Items.Count > 0, 0, -1)
												Functions.Log_Write("S", "Weeks.load_tournament", "loaded tournaments")
								ElseIf Settings._TrnLst.Count = 0 Then
												'no data
												Functions.Log_Write("W", "Weeks.load_tournament", "no tournaments found")
								Else
												'error
												Functions.Log_Write("E", "Weeks.load_tournament", "error: " & Settings._TrnLst(0))
								End If
				End Sub

				Private Function load_tournaments_handler(ByRef type As String) As ArrayList
								Functions.Log_Write("I", "Weeks.load_tournament_handler")
								Dim arytmp As New ArrayList()
								Dim DBF As New TBDB.FileOps(My.Application.Info.DirectoryPath & "\DB\DBClassList.txt")
								Dim DBFX As ArrayList = DBF.Search_File(type)
								'format to older array style
								For Each DBI As TBDB.FileOps.DBClassList In DBFX
												arytmp.Add(DBI.Desc)
												arytmp.Add(DBI.CRef)
								Next
								Return arytmp
				End Function

				Private Sub Load_weeks()
								Functions.Log_Write("I", "Weeks.load_weeks")
								Weeks_DEL.ResetText()
								Weeks_DEL.Items.Clear()
								_WkLst = DBLnkr.DB_Program.Weeks_Get_List()
								If Not _WkLst.Count = 1 Then
												For i As Byte = 2 To _WkLst.Count - 1 Step 2
																Weeks_DEL.Items.Add(_WkLst(i))
												Next
												Functions.Log_Write("S", "Weeks.Load_weeks", "Added Weeks to Weeks_DEL")
								ElseIf _WkLst(0) = "8" Then
												Functions.Log_Write("I", "Weeks.Load_weeks", "No Weeks Found")
								Else
												'error
												Functions.Log_Write("E", "Weeks.Load_weeks", _WkLst(0))
								End If
								'Weeks_DEL.SelectedIndex = IIf(Weeks_DEL.Items.Count > 0, Weeks_DEL.Items.Count - 1, Weeks_DEL.SelectedIndex)
								Set_Week_ID()
				End Sub

				''' <summary>
				''' Checks weather there is a week specified
				''' </summary>
				''' <returns>True if there is and False if there is not</returns>
				''' <remarks></remarks>
				Public Shared Function Validates() As Boolean
								If _WkNM.Length > 0 Then
												Return True
								Else
												Return False
								End If
				End Function

				Private Sub Week_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Week_Add.Click
								Functions.Log_Write("I", "Weeks.Week_Add_Click")
								'check if tournament exists in week
								If TStyle.Items.Count > 0 Then
												'exists
												'check if week exists
												Dim exists As Boolean = False
												For i As Byte = 1 To Weeks_DEL.Items.Count
																If Weeks_DEL.Items(i - 1).ToString = DateTimePicker1.Value.ToShortDateString Then
																				exists = True
																				Exit For
																End If
												Next
												't/f
												If Not exists Then
																'Add Week
																Dim add_success As String = DBLnkr.DB_Program.Weeks_Add(DateTimePicker1.Value.ToShortDateString, GAMES_Week.Value, SCORE_Mins.Value, TStyle.Text)
																If add_success = "1" Then
																				'success
																				Functions.Log_Write("S", "Weeks.Week_Add_Click", "Added Week " & DateTimePicker1.Value.ToShortDateString)
																				Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Added_SUC)
																				Load_weeks()
																Else
																				'failure
																				Functions.Log_Write("E", "Weeks.Week_Add_Click", add_success)
																End If
																'set stats for week
																Functions.Log_Write("I", "Weeks.Week_Add_Click", "Setting Week Information")
																Set_Global_Values()
																Weeks_DEL.SelectedIndex = Weeks_DEL.Items.Count - 1
												Else
																Functions.Log_Write("W", "Weeks.Week_Add_Click", "Weeks Already Exists")
																Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Exists_WRN)
												End If
								Else
												'does not exists
												Functions.Log_Write("W", "Weeks.Week_Add_Click", "Tournament Does Not Exist, Download One")
								End If
				End Sub

				Private Sub Week_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Week_Remove.Click
								Functions.Log_Write("I", "Weeks.Week_Remove_Click")
								If Weeks_DEL.Items.Count > 0 Then
												Functions.Log_Write("I", "Weeks.Week_Remove_Click", "Allowed to delete weeks, Confirming")
												If MsgBox("Are You Sure You Want To Delete This Week" & Chr(13) & "All Scores Will Be Lost For This Week", MsgBoxStyle.YesNo, "Are You Sure?") = MsgBoxResult.Yes Then
																Functions.Log_Write("I", "Weeks.Week_Remove_Click", "Confirmed deletion of week")
																Dim wk_id As Integer = _WkID
																Dim wk_nm As String = _WkNM
																'_WkID = -1

																Dim DEL_Torn As String = DBLnkr.DB_Program.Tournament_Delete_By_Week_ID(wk_id)
																Dim DEL_Score As DB_Structure.Boolean_Response = DBLnkr.DB_Program.Scores_Delete_By_Week_ID(wk_id)
																Dim DEL_Week As String = DBLnkr.DB_Program.Weeks_Delete(wk_id)

																Dim eres As String = ""
																If DEL_Torn.Length = 1 Then
																				Functions.Log_Write("S", "Weeks.Week_Remove_Click", "Removed Tournament for Week [" & wk_nm & "]")
																Else
																				Functions.Log_Write("E", "Weeks.Week_Remove_Click", "Error Removing Tournamet for Week [" & wk_nm & "] : " & DEL_Torn)
																				eres += "Tournament - "
																End If
																If DEL_Score.ERR Then
																				Functions.Log_Write("E", "Weeks.Week_Remove_Click", "Error Removing Scores for Week [" & wk_nm & "] : " & DEL_Score.ERRMsg)
																				eres += "Scores - "
																Else
																				Functions.Log_Write("S", "Weeks.Week_Remove_Click", "Removed Scores for Week [" & wk_nm & "]")
																End If
																If DEL_Week.Length = 1 Then
																				Functions.Log_Write("S", "Weeks.Week_Remove_Click", "Removed Week [" & wk_nm & "]")
																Else
																				Functions.Log_Write("E", "Weeks.Week_Remove_Click", "Error Removing Week [" & wk_nm & "]")
																				eres += "Week - "
																End If

																If eres.Length > 0 Then
																				'error
																				Functions.Log_Write("E", "Weeks.Week_Remove_Click", "Error Removing " & eres.Substring(0, eres.Length - 3))
																				Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Deleted_ERR)
																Else
																				'no errors
																				Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Deleted_SUC)
																				Load_weeks()
																End If
												End If
								Else
												Main.ERS.Get_Error(Errors.Err_Codes.Weeks_Deleted_WRN)
								End If
				End Sub

				Private Sub Weeks_DEL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Weeks_DEL.SelectedIndexChanged
								Functions.Log_Write("I", "Weeks.Weeks_DEL_SelectedIndexChanged")
								Set_Week_ID()
								Set_Week_Stats()
								Set_Colors()
				End Sub

				Private Sub Set_Week_ID()
								Functions.Log_Write("I", "Weeks.Set_Week_ID")
								If _WkLst.Count = 0 Then
												Functions.Log_Write("W", "Weeks.Set_Week_ID", "No weeks found")
												_WkID = -1
												Weeks_DEL.SelectedIndex = -1
								Else
												Functions.Log_Write("S", "Weeks.Set_Week_ID", "weeks found, adding")
												For i As Byte = 1 To _WkLst.Count - 1 Step 2
																If _WkLst(i + 1) = Weeks_DEL.Text Then
																				_WkID = _WkLst(i) 'ID
																				_WkNM = _WkLst(i + 1) 'Week
																				Functions.Log_Write("S", "Weeks.Set_Week_ID", "Changed week to " & _WkLst(i))
																				Weeks_DEL.Text = _WkNM
																End If
												Next
								End If
				End Sub

				Private Sub Set_Week_Stats()
								Functions.Log_Write("I", "Weeks.Set_Week_Stats")
								Dim Stats As ArrayList = DBLnkr.DB_Program.Weeks_By_ID(_WkID)
								If Stats(0).ToString.Length > 0 Then
												'ID, Weeks, Lineup, Position, Position, SSeries, STLane, NGames
												_ScoMin = Stats(5)
												SCORE_Mins.Value = _ScoMin
												_GmsWk = Stats(7)
												GAMES_Week.Value = _GmsWk
												Try
																TStyle.Text = Stats(2)
																Dim typet As String = Settings.Get_TrnLstClass(TStyle.Text)
																Settings._ITournament = Activator.CreateInstance(Type.GetType(typet))
																Functions.Log_Write("S", "Weeks.Set_Week_Stats", "Loaded Week Stats")
												Catch ex As Exception
																Functions.Log_Write("E", "Weeks.Set_Week_Stats", "Could Not Create Tournament Interface: " & ex.Message)
																MsgBox("Error", MsgBoxStyle.OkOnly, "Could Not Find Tournament Control" & Chr(13) & "Adverse Effects may be seen when loading tournament")
																Weeks_DEL.Text = String.Empty
												End Try
								Else
												Functions.Log_Write("W", "Weeks.Set_Week_Stats", "No Tournaments Loaded")
								End If
				End Sub

				Private Sub WChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WChange.Click
								Functions.Log_Write("I", "Weeks.WChange_Click")
								Dim update As String = DBLnkr.DB_Program.Weeks_Update_Settings(GAMES_Week.Value, SCORE_Mins.Value, TStyle.Text, _WkID)
								If update = "1" Then
												'success
												Set_Global_Values()
												Functions.Log_Write("S", "Weeks.WChange_Click", "updated settings")
								Else
												'error
												Functions.Log_Write("E", "Weeks.WChange_Click", "error updating week: " & update)
								End If
				End Sub

				Private Sub Set_Global_Values()
								Functions.Log_Write("I", "Weeks.Set_Global_Values", "Setting Global Values for week")
								_GmsWk = GAMES_Week.Value
								_ScoMin = SCORE_Mins.Value
								Settings._TrnNme = TStyle.Text
								Functions.Log_Write("D", "Weeks.Set_Global_Values", "Setting background colors for changeable items")
								Set_Colors()
				End Sub

				Private Sub Set_Colors()
								Functions.Log_Write("D", "Weeks.Set_Colors", "Setting Background Colors")
								GAMES_Week.BackColor = Color.White
								SCORE_Mins.BackColor = Color.White
								TStyle.BackColor = Color.WhiteSmoke
				End Sub

				Private Sub GAMES_Week_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GAMES_Week.ValueChanged
								Functions.Log_Write("D", "Weeks.GAMES_Week_ValueChanged", "Setting background color for GAMES_Week")
								If Not GAMES_Week.Value = _GmsWk Then
												GAMES_Week.BackColor = Color.Goldenrod
								Else
												GAMES_Week.BackColor = Color.White
								End If
				End Sub

				Private Sub SCORE_Mins_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCORE_Mins.ValueChanged
								Functions.Log_Write("D", "Weeks.SCORE_Mins_ValueChanged", "Setting background color for SCORE_Mins")
								If Not SCORE_Mins.Value = _ScoMin Then
												SCORE_Mins.BackColor = Color.Goldenrod
								Else
												SCORE_Mins.BackColor = Color.White
								End If
				End Sub

				Private Sub TStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TStyle.SelectedIndexChanged
								Functions.Log_Write("D", "Weeks.TStyle_SelectedIndexChanged", "Setting background color for TStyle")
								If Not TStyle.Text = Settings._TrnNme Then
												TStyle.BackColor = Color.Goldenrod
								Else
												TStyle.BackColor = Color.WhiteSmoke
								End If
				End Sub
End Class
