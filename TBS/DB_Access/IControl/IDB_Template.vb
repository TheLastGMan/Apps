Public Interface IDB_Template

    'Is this implemented yet?
    Function Implemented() As Boolean

#Region "LOG"

    'Initialize Log
    Sub Log_Init()

    'Write Log
    Sub Log_Write(ByRef msg As String)

    'Read Log
    Function Log_Read() As ArrayList

#End Region

#Region "DB File Save/Load"

    ''' <summary>
    ''' Init test setup and connect to DB, True if success, False if not
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function DB_Setup() As Boolean

    ''' <summary>
    ''' Update SQL commands in string format
    ''' </summary>
    ''' <param name="sql_cmds">Array of sql commands</param>
    ''' <returns>True if successful, False if Not</returns>
    ''' <remarks></remarks>
    Function DB_Update(ByVal sql_cmds() As String) As String

    ''' <summary>
    ''' Initializes a new clean database, true if successful, false if not (check ERR_Msg for details)
    ''' </summary>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function DB_New() As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Searches DB files for the list of restorable DBs
    ''' </summary>
    ''' <returns>ArrayList of files found</returns>
    ''' <remarks></remarks>
    Function DB_Search() As List(Of String)

    ''' <summary>
    ''' Returns True if requirements are met, if False, check Reqs_Msg
    ''' </summary>
    ''' <returns>DB_Structure.DB_Requirements</returns>
    ''' <remarks></remarks>
    Function DB_Requirements() As DB_Structure.DB_Requriements

    ''' <summary>
    ''' Backup function for database, yyyy/mm/dd for tracking purposes
    ''' </summary>
    ''' <param name="year">Year</param>
    ''' <param name="month">Month 01-12</param>
    ''' <param name="day">Day 01-31</param>
    ''' <param name="save_location">if different from [Default], will save to specified location, else will save to default local location</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function DB_Save(ByRef year As Integer, ByRef month As Byte, ByRef day As Byte, Optional ByRef save_location As String = "[Default]") As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Default Location of the save files
    ''' </summary>
    ''' <returns>string of location</returns>
    ''' <remarks></remarks>
    Function DB_Default_Location() As String

    ''' <summary>
    ''' Extension of save file
    ''' </summary>
    ''' <returns>extension, should be in format ereg(".*+")</returns>
    ''' <remarks></remarks>
    Function DB_Default_Extension() As String

    ''' <summary>
    ''' Inits load request on the selected file
    ''' </summary>
    ''' <param name="file">filename of file to process</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function DB_Load(ByRef file As String) As DB_Structure.Boolean_Response

#End Region

#Region "Bowlers"

    ''' <summary>
    ''' Gets list of all the bowlers
    ''' </summary>
    ''' <returns>DB_Structure.Bowlers_Get_List</returns>
    ''' <remarks></remarks>
    Function Bowlers_Get_List() As List(Of DB_Structure.Bowlers_Get_List)

    'Get list sorted by LName
    Function Bowler_Get_By_LName() As ArrayList

    'Update bowler by ID
    Function Bowler_Update_By_ID(ByVal id As Integer, ByVal FName As String, ByVal LName As String, ByVal USBC_ID As String, ByVal Sex As String) As ArrayList

    'Get bowler by ID
    Function Bowler_Get_By_ID(ByVal id As Integer) As ArrayList

    'Get Bowler ID by FName, LName
    Function Bowler_Get_ID_by_Name(ByVal FName As String, ByVal LName As String) As ArrayList

    'insert bowler
    Function Bowler_Insert(ByVal FName As String, ByVal LName As String, ByVal USBC As String, ByVal SEX As String)

#End Region

#Region "Weeks"

    'Get a list of the weeks
    Function Weeks_Get_List() As ArrayList

    'Delete a Week
    Function Weeks_Delete(ByVal week_id As Integer) As String

    'Add Week
    Function Weeks_Add(ByVal week As String, ByVal games_this_week As Integer, ByVal series_minimum As Integer, ByVal tounament_style As String) As String

    'Get Week by ID
    Function Weeks_By_ID(ByVal id As Integer) As ArrayList

    'Update Settings by ID
    Function Weeks_Update_Settings(ByVal games As Integer, ByVal series As Integer, ByVal tournament_desc As String, ByVal week_id As Integer) As String

    'Get Final Average List
    Function Weeks_Final_Averages() As List(Of DB_Structure.Weeks_Final_Averages)

#End Region

#Region "Scores"
    ''' <summary>
    ''' Gets list of scores for the current active Week ID as an array of DB_Structure.Scores_Get_List
    ''' </summary>
    ''' <param name="WID">Week ID</param>
    ''' <returns>array of DB_Structure.Scores_Get_List</returns>
    ''' <remarks></remarks>
    Function Scores_Get_List(ByVal WID As Integer) As List(Of DB_Structure.Scores_Get_List)

    ''' <summary>
    ''' Delete Scores By Week_ID, if ERR is true, check ERRMsg for message
    ''' </summary>
    ''' <param name="week_id">Week ID</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Scores_Delete_By_Week_ID(ByVal week_id As Integer) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Update Lane Number by BID and WKID, check ERR for status
    ''' </summary>
    ''' <param name="BID">Bowler ID</param>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="lane">Lane Number</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Scores_Lane_Update_By_BID_WKID(ByVal BID As Integer, ByVal WKID As Integer, ByVal lane As Integer) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Insert Scores, see ERR for status
    ''' </summary>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="Lane">Lane Number</param>
    ''' <param name="BID">Bowler ID</param>
    ''' <param name="Scores">Scores as comma string (game1,game2,...)</param>
    ''' <param name="Sum3">3 Game Series</param>
    ''' <param name="SumX">Total Series</param>
    ''' <param name="Average">Average, 2 Decimal Places</param>
    ''' <param name="Vect_Alias">Bowler Alias</param>
    ''' <returns>ERR = False if successful, check ERRMsg if not</returns>
    ''' <remarks></remarks>
    Function Scores_Insert(ByVal WKID As Integer, ByVal Lane As Integer, ByVal BID As Integer, ByVal Scores As String, ByVal Sum3 As Short, ByVal SumX As Short, ByVal Average As String, Optional ByVal Vect_Alias As String = "") As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Get Scores By Week
    ''' </summary>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="LID">Lane ID</param>
    ''' <returns>List(Of DB_Structure.Scores_Get_By_Week_Lane)</returns>
    ''' <remarks></remarks>
    Function Scores_Get_By_Week_Lane(ByVal WKID As Integer, ByVal LID As Short) As List(Of DB_Structure.Scores_Get_By_Week_Lane)

    ''' <summary>
    ''' Update Scores for week by Bowler ID, Lane Number, Week ID
    ''' </summary>
    ''' <param name="BID">Bowler ID</param>
    ''' <param name="LID">Lane ID</param>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="Scores">Scores as comma string (game1,game2,xxx)</param>
    ''' <param name="Ser3">3 Game Series</param>
    ''' <param name="SerX">Total Series</param>
    ''' <param name="Ave">Average to 2 decimal places</param>
    ''' <param name="BAlias">Bowler Alias</param>
    ''' <returns>DBStructure.Boolean_Response, ERR = false if successful, check ERRMsg if not</returns>
    ''' <remarks></remarks>
    Function Scores_Update_By_BID_LID_WKID(ByVal BID As Integer, ByVal LID As Integer, ByVal WKID As Integer, ByVal Scores As String, ByVal Ser3 As Integer, ByVal SerX As Integer, ByVal Ave As String, ByVal BAlias As String) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Check if bowler exists for week, check ERR for status
    ''' </summary>
    ''' <param name="BID">Bowler ID</param>
    ''' <returns>DB_Strucutre.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Scores_Check_Bowler_Exists_BID(ByVal BID As Integer) As DB_Structure.Scores_Check_Bowler_Exists_BID

    ''' <summary>
    ''' Get Lane by Week and Bowler ID, check ERR for status
    ''' </summary>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="BID">Bowler ID</param>
    ''' <returns>DB_Structure.Scores_Lane_By_WKID_BID</returns>
    ''' <remarks></remarks>
    Function Scores_Lane_By_WKID_BID(ByVal WKID As Integer, ByVal BID As Integer) As DB_Structure.Scores_Lane_By_WKID_BID

    ''' <summary>
    ''' Delete Scores by Week_ID and Bowler_ID, see ERR for status
    ''' </summary>
    ''' <param name="WKID">Week ID</param>
    ''' <param name="BID">Bowler ID</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Scores_Delete_By_WKID_BID(ByVal WKID As Integer, ByVal BID As Integer) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Get Scores Sex and Week
    ''' </summary>
    ''' <param name="Sex">Sex Type (M,F,B,G)</param>
    ''' <param name="Week">Week ID</param>
    ''' <returns>DB_Structure.Scores_By_Sex_Week</returns>
    ''' <remarks></remarks>
    Function Scores_By_Sex_Week(ByVal Sex As String, ByVal Week As Integer) As List(Of DB_Structure.Scores_By_Sex_Week)

    ''' <summary>
    ''' Gets Scores by Bowler ID
    ''' </summary>
    ''' <param name="bid">Bowler ID</param>
    ''' <returns>list of DB_Structure.Scores_By_BID</returns>
    ''' <remarks></remarks>
    Function Scores_By_BID(ByVal bid As Integer) As List(Of DB_Structure.Scores_By_BID)

#End Region

#Region "Lanes"

    ''' <summary>
    ''' Get a list of the lanes as DB_Structure.Lanes_Get
    ''' </summary>
    ''' <returns>Array list of DB_Structure.Lanes_Get</returns>
    ''' <remarks></remarks>
    Function Lanes_Get() As List(Of DB_Structure.Lanes_Get)

#End Region

#Region "Tournament"

    'Load Tournament
    Function Tournament_Load() As ArrayList

    'Delete Tournament by Week ID
    Function Tournament_Delete_By_Week_ID(ByVal week_id As Integer) As String

    'Check if Tournament Exists
    Function Tournament_Exists(ByVal week_id As Integer) As String

    'Get Tournament Data
    Function Tournament_Get_Data(ByVal week_id As Integer) As String

    'Update Tournament by WeekID
    Function Tournament_Update_Data_By_WkID(ByVal week_id As Integer, ByVal tdata As String) As String

    'Insert Tournament
    Function Tournament_Insert(ByVal WKID As Integer, ByVal Data As String) As String

#End Region

#Region "Lineup (Settings)"

    ''' <summary>
    ''' Get Setting By ID
    ''' </summary>
    ''' <param name="SID">Setting ID</param>
    ''' <returns>Setting Value</returns>
    ''' <remarks></remarks>
    Function Lineup_Get_Setting_By_ID(ByVal SID As Integer) As DB_Structure.Lineup_Get_Setting_By_ID

    ''' <summary>
    ''' Delete Setting By ID, may cause adverse results, typically only for updateing purposes
    ''' </summary>
    ''' <param name="SID">Setting ID</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Lineup_Delete_Setting_By_ID(ByVal SID As Integer) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Update Setting By ID
    ''' </summary>
    ''' <param name="SID">Setting ID</param>
    ''' <param name="value">New Setting</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Lineup_Update_By_ID(ByVal SID As Integer, ByVal value As String) As DB_Structure.Boolean_Response

    ''' <summary>
    ''' Insert Setting, typically used for updateing purposes
    ''' </summary>
    ''' <param name="value">Value of Setting</param>
    ''' <returns>DB_Structure.Boolean_Response</returns>
    ''' <remarks></remarks>
    Function Lineup_Insert(ByVal value As String) As DB_Structure.Boolean_Response

#End Region

End Interface
