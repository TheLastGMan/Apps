Imports LiteDB

Public Class LiteDB
				Implements IDB_Template

#Region "DataBase File Options"

				Private ReadOnly app_path As String = My.Application.Info.DirectoryPath & "\DB\LiteDB\"
				Private ReadOnly app_DefaultDBFile As String = DB_Default_Location() & "TB" & DB_Default_Extension()

				Public Sub DBAccess(ByRef entity As Action(Of DBTables))
								Using db As New LiteRepository(app_DefaultDBFile) ' LiteDatabase(app_DefaultDBFile)
												'Check if we can connect to DB by filling Lineup/Version Table
												BsonMapper.Global.Entity(Of DBModels.Tournament)().Id(Function(f As DBModels.Tournament) f.Id).DbRef(Function(f) f.Week)
												BsonMapper.Global.Entity(Of DBModels.Score)().Id(Function(f) f.Id).DbRef(Function(f) f.Bowler).DbRef(Function(f) f.Week)
												BsonMapper.Global.Entity(Of DBModels.Bowler)().Id(Function(f) f.Id)
												BsonMapper.Global.Entity(Of DBModels.Week)().Id(Function(f) f.Id)
												BsonMapper.Global.Entity(Of DBModels.Lineup)().Id(Function(f) f.Id)
												BsonMapper.Global.UseCamelCase()
												BsonMapper.Global.SerializeNullValues = True

												Dim dbTables As New DBTables() With {
																.Bowlers = db.Database.GetCollection(Of DBModels.Bowler)(),
																.Weeks = db.Database.GetCollection(Of DBModels.Week)(),
																.Tournaments = db.Database.GetCollection(Of DBModels.Tournament)().Include(Function(f) f.Week),
																.Lineups = db.Database.GetCollection(Of DBModels.Lineup)(),
																.Scores = db.Database.GetCollection(Of DBModels.Score)().Include(Function(f) f.Week).Include(Function(f) f.Bowler)
												}
												dbTables.Bowlers.EnsureIndex(Function(f) f.Id, True)
												dbTables.Bowlers.EnsureIndex(Function(f) f.USBCSanctionNumber, True)
												dbTables.Weeks.EnsureIndex(Function(f) f.Id, True)
												dbTables.Tournaments.EnsureIndex(Function(f) f.Id, True)
												dbTables.Lineups.EnsureIndex(Function(f) f.Id, True)
												dbTables.Scores.EnsureIndex(Function(f) f.Id, True)

												entity.Invoke(dbTables)
								End Using
				End Sub

				Private ReadOnly DefaultLineups As String() = {"Vector", "192.168.137.200", "1433", "VECTORPLUS", "VectorPlus", "tbld,tbld", "0", "3.1.2.4", "Default", "0", "0", "24", "-1"}
				Private IsInit As Boolean = False
				Public Function DB_Setup() As Boolean Implements IDB_Template.DB_Setup
								'sanity check
								If (IsInit) Then
												Return True
								End If

								Try
												DBAccess(Sub(entity)
																									If (entity.Lineups.Count() = 0) Then
																													For Each v In DefaultLineups
																																	entity.Lineups.Insert(New DBModels.Lineup() With {
																																					.Place = v
																																	})
																													Next
																									End If
																					End Sub)
												IsInit = True
												Return True
								Catch ex As Exception
												Throw New Exception(ex.Message)
								End Try
				End Function

				Public Function DB_Load(ByRef file As String) As DB_Structure.Boolean_Response Implements IDB_Template.DB_Load
								Dim ret As New DB_Structure.Boolean_Response
								Try
												IO.File.Copy(file, app_DefaultDBFile, True)
												ret.ERR = False
								Catch ex As Exception
												ret.ERR = True
												ret.ERRMsg = "File Could Not Be Restored: " & ex.Message
								End Try
								Return ret
				End Function

				Public Function DB_New() As DB_Structure.Boolean_Response Implements IDB_Template.DB_New
								Dim ret As New DB_Structure.Boolean_Response
								Try
												IO.File.Delete(app_DefaultDBFile)
												ret.ERR = False
								Catch ex As Exception
												ret.ERR = True
												ret.ERRMsg = ex.Message
								End Try
								Return ret
				End Function

				Public Function DB_Save(ByRef year As Integer, ByRef month As Byte, ByRef day As Byte, Optional ByRef save_location As String = "[Default]") As DB_Structure.Boolean_Response Implements IDB_Template.DB_Save
								Dim ret As New DB_Structure.Boolean_Response
								Try
												If save_location = "[Default]" Then
																'default location
																Dim datex As String = year & "-" & month & "-" & day & DB_Default_Extension()
																IO.File.Copy(app_DefaultDBFile, DB_Default_Location() & "TBS_" & datex, True)
												Else
																'non default location
																IO.File.Copy(app_DefaultDBFile, save_location)
												End If
												ret.ERR = False
								Catch ex As Exception
												ret.ERR = True
												ret.ERRMsg = "Could Not Save DataBase: " & ex.Message
								End Try
								Return ret
				End Function

				Public Function DB_Default_Extension() As String Implements IDB_Template.DB_Default_Extension
								Return ".ltdb"
				End Function

				Public Function DB_Default_Location() As String Implements IDB_Template.DB_Default_Location
								Return app_path
				End Function

				Public Function DB_Search() As List(Of String) Implements IDB_Template.DB_Search
								Dim ret As New List(Of String)
								Dim ary As String() = IO.Directory.GetFiles(DB_Default_Location(), "TBS_*" & DB_Default_Extension(), IO.SearchOption.TopDirectoryOnly)
								Return ary.ToList()
				End Function

				Function DB_Requirements() As DB_Structure.DB_Requriements Implements IDB_Template.DB_Requirements
								'Text file, reqs already met
								Dim ret As New DB_Structure.DB_Requriements With {
												.Reqs_Met = True,
												.Reqs_Msg = String.Empty
								}
								Return ret
				End Function

				Public Function DB_Update(sql_cmds As String()) As String Implements IDB_Template.DB_Update
								Try
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Implemented() As Boolean Implements IDB_Template.Implemented
								Return True
				End Function

#End Region

#Region "Lanes"

				Public Function Lanes_Get() As List(Of DB_Structure.Lanes_Get) Implements IDB_Template.Lanes_Get
								Dim LNS As New List(Of DB_Structure.Lanes_Get)
								Try
												Dim res = Lineup_Get_Setting_By_ID(12).Setting
												Dim cnt = Integer.Parse(res)
												For i As Integer = 1 To cnt
																LNS.Add(New DB_Structure.Lanes_Get() With {
																				.Lane = i.ToString()
																})
												Next
								Catch ex As Exception
												Dim INS As New DB_Structure.Lanes_Get
												INS._ERRMsg = ex.Message
												LNS.Add(INS)
								End Try
								Return LNS
				End Function

#End Region

#Region "Logs"

				Public Sub Log_Init() Implements IDB_Template.Log_Init

				End Sub

				Public Sub Log_Write(ByRef msg As String) Implements IDB_Template.Log_Write

				End Sub

				Public Function Log_Read() As ArrayList Implements IDB_Template.Log_Read
								Return New ArrayList
				End Function

#End Region

#Region "Bowlers"

				Public Function Bowlers_Get_List() As List(Of DB_Structure.Bowlers_Get_List) Implements IDB_Template.Bowlers_Get_List
								Dim BLST As New List(Of DB_Structure.Bowlers_Get_List)

								Try
												DBAccess(Sub(entity)
																									Dim bowlers = entity.Bowlers.Query().ToList()
																									Dim bowlerSel = bowlers.Select(Function(f) New DB_Structure.Bowlers_Get_List With {
																												.ID = f.Id,
																												.FName = f.FName,
																												.LName = f.LName,
																												.USBC_Sanc = f.USBCSanctionNumber,
																												.Sex = f.Sex
																									}).OrderBy(Function(f) f.FName).ThenBy(Function(f) f.LName).ToList()
																									BLST.AddRange(bowlerSel)
																					End Sub)
								Catch ex As Exception
												Dim db As New DB_Structure.Bowlers_Get_List
												db._ERRMsg = ex.Message
												BLST.Add(db)
								End Try

								Return BLST
				End Function

				Public Function Bowler_Get_By_LName() As ArrayList Implements IDB_Template.Bowler_Get_By_LName
								Dim BLST As New ArrayList

								'SELECT ID, FName, LName, USBC_Sanc, Sex FROM Bowlers ORDER BY LName ASC
								Try
												DBAccess(Sub(entity)
																									Dim bowlers = entity.Bowlers.Query().ToList().OrderBy(Function(f) f.LName).OrderBy(Function(F) F.FName)
																									For Each b In bowlers
																													BLST.Add(b.Id)
																													BLST.Add(b.FName)
																													BLST.Add(b.LName)
																													BLST.Add(b.USBCSanctionNumber)
																													BLST.Add(b.Sex)
																									Next
																					End Sub)
								Catch ex As Exception
												BLST.Add("-1")
												BLST.Add(ex.Message)
								End Try

								Return BLST
				End Function

				Public Function Bowler_Update_By_ID(id As Integer, FName As String, LName As String, USBC_ID As String, Sex As String) As ArrayList Implements IDB_Template.Bowler_Update_By_ID
								Dim BLST As New ArrayList
								'UPDATE `Bowlers` SET `FName` = ?, `LName` = ?, `USBC_Sanc` = ?, `Sex` = ? WHERE (`ID` = ?)
								Try
												DBAccess(Sub(entity)
																									entity.Bowlers.Upsert(id, New DBModels.Bowler() With {
																												.Id = id,
																												.FName = FName,
																												.LName = LName,
																												.USBCSanctionNumber = USBC_ID,
																												.Sex = Sex
																									})
																					End Sub)
												BLST.Add("1")
								Catch ex As Exception
												BLST.Add(ex.Message)
								End Try

								Return BLST
				End Function

				Public Function Bowler_Get_By_ID(id As Integer) As ArrayList Implements IDB_Template.Bowler_Get_By_ID
								Dim BLST As New ArrayList
								'SELECT ID, FName, LName, USBC_Sanc, Sex FROM Bowlers WHERE (ID = ?)
								Try
												DBAccess(Sub(entity)
																									Dim b = entity.Bowlers.FindById(id)
																									BLST.Add(b.Id)
																									BLST.Add(b.FName)
																									BLST.Add(b.LName)
																									BLST.Add(b.USBCSanctionNumber)
																									BLST.Add(b.Sex)
																					End Sub)
								Catch ex As Exception
												BLST.Add("-1")
												BLST.Add(ex.Message)
								End Try

								Return BLST
				End Function

				Public Function Bowler_Insert(FName As String, LName As String, USBC As String, SEX As String) As Object Implements IDB_Template.Bowler_Insert
								Try
												DBAccess(Sub(entity)
																									entity.Bowlers.Insert(New DBModels.Bowler() With {
																													.FName = FName,
																													.LName = LName,
																													.USBCSanctionNumber = USBC,
																													.Sex = SEX
																									})
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Bowler_Get_ID_by_Name(FName As String, LName As String) As ArrayList Implements IDB_Template.Bowler_Get_ID_by_Name
								Dim BLST As New ArrayList
								'SELECT ID FROM Bowlers WHERE FName = ? AND LName = ?
								Try
												DBAccess(Sub(entity)
																									Dim b = entity.Bowlers.Query().Where(Function(f) f.FName.Equals(FName) AndAlso f.LName.Equals(LName)).ToList()
																									If b.Count > 0 Then
																													BLST.Add(b.First().Id)
																									Else
																													BLST.Add(Nothing)
																									End If
																					End Sub)
								Catch ex As Exception
												BLST.Add(ex.Message)
								End Try
								Return BLST
				End Function

#End Region

#Region "Weeks"

				Public Function Weeks_Get_List() As ArrayList Implements IDB_Template.Weeks_Get_List
								Dim wklst As New ArrayList()
								'SELECT ID, Week FROM Weeks
								Try
												DBAccess(Sub(entity)
																									Dim w = entity.Weeks.Query().OrderByDescending(Function(f) f.WeekName).ToEnumerable()
																									wklst.Add(2)
																									For Each wk In w
																													wklst.Add(wk.Id)
																													wklst.Add(wk.WeekName)
																									Next
																					End Sub)
								Catch ex As Exception
												wklst.Add(-1)
												wklst.Add(ex.Message)
								End Try

								Return wklst
				End Function

				Public Function Weeks_Delete(week_id As Integer) As String Implements IDB_Template.Weeks_Delete
								'DELETE FROM `Weeks` WHERE (`ID` = ?)
								Try
												DBAccess(Sub(entity)
																									entity.Weeks.Delete(week_id)
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Weeks_Add(week As String, games_this_week As Integer, series_minimum As Integer, tournament_style As String) As String Implements IDB_Template.Weeks_Add
								'INSERT INTO `Weeks` (`Week`, `Lineups`, `Position`, `Checked`, `SSeries`, `STLane`, `NGames`) VALUES (?, ?, 8, False, ?, 17, ?)
								Try
												DBAccess(Sub(entity)
																									entity.Weeks.Insert(New DBModels.Week() With {
																													.WeekName = week,
																													.Lineups = tournament_style,
																													.Position = 8,
																													.Checked = False,
																													.SSeries = series_minimum,
																													.STLane = 17,
																													.NGames = games_this_week
																									})
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Weeks_By_ID(id As Integer) As ArrayList Implements IDB_Template.Weeks_By_ID
								'SELECT ID, Week, Lineups, [Position], Checked, SSeries, STLane, NGames FROM Weeks WHERE (`ID` = ?)
								Dim WKLst As New ArrayList
								Try
												DBAccess(Sub(entity)
																									Dim w = entity.Weeks.Query().Where(Function(f) f.Id.Equals(id)).FirstOrDefault()
																									If w Is Nothing Then
																													WKLst.Add(String.Empty)
																									Else
																													WKLst.Add(w.Id)
																													WKLst.Add(w.WeekName)
																													WKLst.Add(w.Lineups)
																													WKLst.Add(w.Position)
																													WKLst.Add(w.Checked)
																													WKLst.Add(w.SSeries)
																													WKLst.Add(w.STLane)
																													WKLst.Add(w.NGames)
																									End If
																					End Sub)
								Catch ex As Exception
												WKLst.Add(ex.Message)
								End Try
								Return WKLst
				End Function

				Public Function Weeks_Update_Settings(games As Integer, series As Integer, tournament_desc As String, week_id As Integer) As String Implements IDB_Template.Weeks_Update_Settings
								'UPDATE `Weeks` SET `SSeries` = ?, `NGames` = ?, `Lineups` = ? WHERE (`ID` = ?)
								Try
												DBAccess(Sub(entity)
																									Dim w = entity.Weeks.Find(Function(f) f.Id.Equals(week_id)).First()
																									w.SSeries = series
																									w.NGames = games
																									w.Lineups = tournament_desc
																									entity.Weeks.Update(w)
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				''' <summary>
				''' Get bowlers game totals and average across all weeks
				''' </summary>
				''' <returns></returns>
				<STAThread>
				Public Function Weeks_Final_Averages() As List(Of DB_Structure.Weeks_Final_Averages) Implements IDB_Template.Weeks_Final_Averages
								Dim WKret As New List(Of DB_Structure.Weeks_Final_Averages)
								'SELECT Bowlers.FName, Bowlers.LName, Bowlers.USBC_Sanc AS USanc, SUM(Weeks.NGames) AS GGames, SUM(Scores.SUM4) AS GSeries
								'FROM Weeks
								'INNER Join Scores ON Weeks.ID = Scores.Week_ID
								'INNER Join Bowlers ON Scores.Bowler_ID = Bowlers.ID
								'GROUP BY Bowlers.ID, Bowlers.FName, Bowlers.LName, Bowlers.USBC_Sanc
								'ORDER BY Bowlers.LName, Bowlers.FName
								Try
												DBAccess(Sub(entity)
																									Dim q = entity.Bowlers.Query().ToEnumerable()
																									For Each blr In q
																													Dim bwlr = New DB_Structure.Weeks_Final_Averages With {
																																	.FName = blr.FName,
																																	.LName = blr.LName,
																																	.Name = blr.FName & " " & blr.LName,
																																	.USBC = blr.USBCSanctionNumber,
																																	.SUMG = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(blr.Id)).ToList().Sum(Function(f) f.Week.NGames),
																																	.SUM4 = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(blr.Id)).ToList().Sum(Function(g) g.SUM4)
																													}
																													If (bwlr.SUMG > 0) Then
																																	WKret.Add(bwlr)
																													End If
																									Next
																					End Sub)
								Catch ex As Exception
												Dim WKDat As New DB_Structure.Weeks_Final_Averages
												WKDat._ERR = True
												WKDat._ERRMsg = ex.Message
												WKret.Add(WKDat)
								End Try
								Return WKret
				End Function

#End Region

#Region "Scores"

				Public Function Scores_Delete_By_WKID_BID(WKID As Integer, BID As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Delete_By_WKID_BID
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									Dim bowlers = entity.Scores.Query().Where(Function(f) f.Week.Id.Equals(WKID) AndAlso f.Bowler.Id.Equals(BID)).ToList()
																									For Each b In bowlers
																													entity.Scores.Delete(b.Id)
																									Next
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_Delete_By_Week_ID(week_id As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Delete_By_Week_ID
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									entity.Scores.DeleteMany(Function(f) f.Week.Id.Equals(week_id))
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_Get_List(WID As Integer) As List(Of DB_Structure.Scores_Get_List) Implements IDB_Template.Scores_Get_List
								Dim SLT As New List(Of DB_Structure.Scores_Get_List)
								Try
												DBAccess(Sub(entity)
																									Dim q = entity.Scores.Query().Where(Function(f) f.Week.Id.Equals(WID)).ToList()
																									Dim s = q.Select(Function(f) New DB_Structure.Scores_Get_List() With {
																													.ID = f.Id,
																													.Week_ID = f.Week.Id,
																													.Lane_ID = f.LaneNumber,
																													.Bowler_ID = f.Bowler.Id,
																													.Scores = f.Scores,
																													.SUM4 = f.SUM4,
																													.SUM3 = f.SUM3,
																													.AVE = f.AVE,
																													.BAlias = f.BAlias
																									}).OrderByDescending(Function(f) f.SUM4).ThenByDescending(Function(f) f.SUM3).ThenByDescending(Function(f) f.AVE).ToList()
																									SLT.AddRange(s)
																					End Sub)
								Catch ex As Exception
												Dim DBS As New DB_Structure.Scores_Get_List
												DBS._ERRMsg = ex.Message
												SLT.Add(DBS)
								End Try
								Return SLT
				End Function

				Public Function Scores_Lane_Update_By_BID_WKID(BID As Integer, WKID As Integer, lane As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Lane_Update_By_BID_WKID
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									Dim ss = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(BID) AndAlso f.Week.Id.Equals(WKID)).ToList()
																									For Each s In ss
																													s.LaneNumber = lane
																													entity.Scores.Update(s)
																									Next
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_Insert(WKID As Integer, Lane As Integer, BID As Integer, Scores As String, Sum3 As Short, SumX As Short, Average As String, Optional Vect_Alias As String = "") As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Insert
								Dim RET As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									Dim model = New DBModels.Score() With {
																													.Week = entity.Weeks.FindById(WKID),
																													.LaneNumber = Lane,
																													.Bowler = entity.Bowlers.FindById(BID),
																													.Scores = Scores,
																													.SUM3 = Sum3,
																													.SUM4 = SumX,
																													.AVE = Average,
																													.BAlias = Vect_Alias
																									}

																									entity.Scores.Insert(model)
																					End Sub)
												RET.ERR = False
								Catch ex As Exception
												RET.ERR = True
												RET.ERRMsg = ex.Message
								End Try
								Return RET
				End Function

				Public Function Scores_Get_By_Week_Lane(WKID As Integer, LID As Short) As List(Of DB_Structure.Scores_Get_By_Week_Lane) Implements IDB_Template.Scores_Get_By_Week_Lane
								Dim RET As New List(Of DB_Structure.Scores_Get_By_Week_Lane)
								Try
												DBAccess(Sub(entity)
																									Dim q = entity.Scores.Query()
																									Dim fltr = q.Where(Function(f) f.Week.Id = WKID AndAlso f.LaneNumber = LID).ToList()
																									For Each f In fltr
																													If (f.Bowler Is Nothing) Then
																																	entity.Scores.Delete(f.Id)
																													Else
																																	Dim sc As New DB_Structure.Scores_Get_By_Week_Lane() With {
																																					.ID = f.Id,
																																					.Lane_ID = f.LaneNumber,
																																					.Week_ID = f.Week.Id,
																																					.Bowler_ID = f.Bowler.Id,
																																					.BAlias = IIf(f.BAlias Is Nothing, String.Empty, f.BAlias),
																																					.AVE = f.AVE,
																																					.SUM3 = f.SUM3,
																																					.SUM4 = f.SUM4,
																																					.Scores = f.Scores
																																				}
																																	RET.Add(sc)
																													End If
																									Next
																					End Sub)
								Catch ex As Exception
												Dim DBS As New DB_Structure.Scores_Get_By_Week_Lane
												DBS._ERRMsg = ex.Message
												RET.Add(DBS)
								End Try
								Return RET
				End Function

				Public Function Scores_Update_By_BID_LID_WKID(BID As Integer, LID As Integer, WKID As Integer, Scores As String, Ser3 As Integer, SerX As Integer, Ave As String, BAlias As String) As DB_Structure.Boolean_Response Implements IDB_Template.Scores_Update_By_BID_LID_WKID
								'UPDATE Scores
								'SET Scores = ?, SUM4 = ?, SUM3 = ?, AVE = ?, BAlias = ?
								'WHERE(Week_ID = ?) And (Bowler_ID = ?)
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									Dim ss = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(BID) AndAlso f.Week.Id.Equals(WKID)).ToList()
																									For Each s In ss
																													s.Scores = Scores
																													s.SUM3 = Ser3
																													s.SUM4 = SerX
																													s.LaneNumber = LID
																													s.AVE = Ave
																													s.BAlias = BAlias
																													entity.Scores.Update(s)
																									Next
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_Check_Bowler_Exists_BID(BID As Integer) As DB_Structure.Scores_Check_Bowler_Exists_BID Implements IDB_Template.Scores_Check_Bowler_Exists_BID
								'SELECT COUNT(*) FROM Scores WHERE (Bowler_ID = ?)
								Dim DBS As New DB_Structure.Scores_Check_Bowler_Exists_BID
								Try
												DBAccess(Sub(entity)
																									Dim cnt = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(BID)).Count()
																									DBS.Exists = (cnt > 0)
																					End Sub)
								Catch ex As Exception
												DBS._ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_Lane_By_WKID_BID(WKID As Integer, BID As Integer) As DB_Structure.Scores_Lane_By_WKID_BID Implements IDB_Template.Scores_Lane_By_WKID_BID
								'SELECT Lane_ID
								'From Scores
								'Where (Week_ID = ?) And (Bowler_ID = ?)
								Dim DBS As New DB_Structure.Scores_Lane_By_WKID_BID
								Try
												DBAccess(Sub(entity)
																									Dim lane = entity.Scores.Query().Where(Function(f) f.Week.Id.Equals(WKID) AndAlso f.Bowler.Id.Equals(BID)).First()
																									DBS.Lane_ID = lane.LaneNumber
																					End Sub)
								Catch ex As Exception
												DBS._ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Scores_By_Sex_Week(Sex As String, Week As Integer) As List(Of DB_Structure.Scores_By_Sex_Week) Implements IDB_Template.Scores_By_Sex_Week
								'9    , 10   , 4
								'FName, LName, Scores
								Dim ret As New List(Of DB_Structure.Scores_By_Sex_Week)
								Try
												DBAccess(Sub(entity)
																									Dim q = entity.Scores.Query().Where(Function(f) f.Bowler.Sex.Equals(Sex) AndAlso f.Week.Id.Equals(Week)).ToList()
																									Dim b = q.Select(Function(f) New DB_Structure.Scores_By_Sex_Week() With {
																												.Name = f.Bowler.FName & " " & f.Bowler.LName,
																												.Scores = f.Scores
																									})
																									ret.AddRange(b)
																					End Sub)
								Catch ex As Exception
												Dim DBS As New DB_Structure.Scores_By_Sex_Week
												DBS._ERRMsg = ex.Message
												ret.Add(DBS)
								End Try
								Return ret
				End Function

				Public Function Scores_By_BID(bid As Integer) As List(Of DB_Structure.Scores_By_BID) Implements IDB_Template.Scores_By_BID
								Dim ret As New List(Of DB_Structure.Scores_By_BID)
								Try
												DBAccess(Sub(entity)
																									Dim q = entity.Scores.Query().Where(Function(f) f.Bowler.Id.Equals(bid))
																									Dim s = q.ToList().Select(Function(f) New DB_Structure.Scores_By_BID() With {
																												.ID = f.Id,
																												.Week_ID = f.Week.Id,
																												.Lane_ID = f.LaneNumber,
																												.Bowler_ID = bid,
																												.Scores = f.Scores,
																												.SUM4 = f.SUM4,
																												.SUM3 = f.SUM3,
																												.AVE = f.AVE,
																												.BAlias = f.BAlias
																								})
																									ret.AddRange(s)
																					End Sub)
								Catch ex As Exception
												Dim DBS As New DB_Structure.Scores_By_BID
												DBS._ERRMsg = ex.Message
								End Try
								Return ret
				End Function

#End Region

#Region "Tournament"

				Public Function Tournament_Load() As ArrayList Implements IDB_Template.Tournament_Load
								Return New ArrayList
				End Function

				Public Function Tournament_Delete_By_Week_ID(week_id As Integer) As String Implements IDB_Template.Tournament_Delete_By_Week_ID
								Try
												DBAccess(Sub(entity)
																									entity.Tournaments.DeleteMany(Function(f) f.Week.Id.Equals(week_id))
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Tournament_Exists(week_id As Integer) As String Implements IDB_Template.Tournament_Exists
								Try
												Dim exists = "0"
												DBAccess(Sub(entity)
																									exists = IIf(entity.Tournaments.Query().Where(Function(f) f.Week.Id.Equals(week_id)).Count() > 0, "1", "0")
																					End Sub)
												Return exists
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Tournament_Get_Data(week_id As Integer) As String Implements IDB_Template.Tournament_Get_Data
								Try
												Dim data As String = String.Empty
												DBAccess(Sub(entity)
																									Dim td = entity.Tournaments.Query().Where(Function(f) f.Week.Id.Equals(week_id)).First()
																									data = td.Data
																					End Sub)
												Return data
								Catch ex As Exception
												Return "-" & ex.Message
								End Try
				End Function

				Public Function Tournament_Update_Data_By_WkID(week_id As Integer, tdata As String) As String Implements IDB_Template.Tournament_Update_Data_By_WkID
								Try
												DBAccess(Sub(entity)
																									Dim t = entity.Tournaments.Query().Where(Function(f) f.Week.Id.Equals(week_id)).First()
																									t.Data = tdata
																									entity.Tournaments.Update(t)
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

				Public Function Tournament_Insert(WKID As Integer, Data As String) As String Implements IDB_Template.Tournament_Insert
								Try
												DBAccess(Sub(entity)
																									entity.Tournaments.Insert(New DBModels.Tournament() With {
																									.Week = entity.Weeks.FindById(WKID),
																									.Data = Data
																									})
																					End Sub)
												Return "1"
								Catch ex As Exception
												Return ex.Message
								End Try
				End Function

#End Region

#Region "Lineup (Settings)"

				Public Function Lineup_Delete_Setting_By_ID(SID As Integer) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Delete_Setting_By_ID
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									entity.Lineups.Delete(SID)
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = False
								End Try
								Return DBS
				End Function

				Public Function Lineup_Get_Setting_By_ID(SID As Integer) As DB_Structure.Lineup_Get_Setting_By_ID Implements IDB_Template.Lineup_Get_Setting_By_ID
								Dim DBS As New DB_Structure.Lineup_Get_Setting_By_ID
								Try
												DBAccess(Sub(entity)
																									Dim s = entity.Lineups.FindById(SID)
																									DBS.Setting = s.Place
																					End Sub)
								Catch ex As Exception
												DBS._ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Lineup_Update_By_ID(SID As Integer, value As String) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Update_By_ID
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									Dim s = entity.Lineups.FindById(SID)
																									s.Place = value
																									entity.Lineups.Update(s)
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

				Public Function Lineup_Insert(value As String) As DB_Structure.Boolean_Response Implements IDB_Template.Lineup_Insert
								Dim DBS As New DB_Structure.Boolean_Response
								Try
												DBAccess(Sub(entity)
																									entity.Lineups.Insert(New DBModels.Lineup() With {
																									.Place = value})
																					End Sub)
												DBS.ERR = False
								Catch ex As Exception
												DBS.ERR = True
												DBS.ERRMsg = ex.Message
								End Try
								Return DBS
				End Function

#End Region

End Class
