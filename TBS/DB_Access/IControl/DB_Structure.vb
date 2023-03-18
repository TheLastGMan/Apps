Public Class DB_Structure

    Public Structure Boolean_Response
        Public ERR As Boolean
        Public ERRMsg As String
    End Structure

    Public Structure DB_Requriements
        Public Reqs_Met As Boolean
        Public Reqs_Msg As String
    End Structure

    Public Structure Lanes_Get
        Public _ERRMsg As String
        Public Lane As String
    End Structure

    'Bowlers.FName, Bowlers.LName, Bowlers.USBC_Sanc AS USanc, SUM(Weeks.NGames) AS GGames, SUM(Scores.SUM4) AS GSeries
    Public Structure Weeks_Final_Averages
        Public _ERRMsg As String
        Public _ERR As Boolean
        Public FName As String
        Public LName As String
        Public Name As String
        Public USBC As String
        Public SUMG As Integer
        Public SUM4 As Integer
    End Structure

    'AVE, BAlias, Bowler_ID, ID, Lane_ID, SUM3, SUM4, Scores, Week_ID
    Public Structure Scores_Get_By_Week_Lane
        Public _ERRMsg As String
        Public AVE As String
        Public BAlias As String
        Public Bowler_ID As Integer
        Public ID As Integer
        Public Lane_ID As Integer
        Public SUM3 As Integer
        Public SUM4 As Integer
        Public Scores As String
        Public Week_ID As Integer
    End Structure

    'ID, FName, LName, USBC_Sanc, Sex
    Public Structure Bowlers_Get_List
        Public _ERRMsg As String
        Public ID As Integer
        Public FName As String
        Public LName As String
        Public USBC_Sanc As String
        Public Sex As String
    End Structure

    ' ID, Week_ID, Lane_ID, Bowler_ID, Scores, SUM4, SUM3, AVE, BAlias
    Public Structure Scores_Get_List
        Public _ERRMsg As String
        Public ID As Integer
        Public Week_ID As Integer
        Public Lane_ID As Integer
        Public Bowler_ID As Integer
        Public Scores As String
        Public SUM4 As Integer
        Public SUM3 As Integer
        Public AVE As String
        Public BAlias As String
    End Structure

    ' ID, Week_ID, Lane_ID, Bowler_ID, Scores, SUM4, SUM3, AVE, BAlias
    Public Structure Scores_By_BID
        Public _ERRMsg As String
        Public ID As Integer
        Public Week_ID As Integer
        Public Lane_ID As Integer
        Public Bowler_ID As Integer
        Public Scores As String
        Public SUM4 As Integer
        Public SUM3 As Integer
        Public AVE As String
        Public BAlias As String
    End Structure

    'Lane_ID
    Public Structure Scores_Lane_By_WKID_BID
        Public _ERRMsg As String
        Public Lane_ID As Integer
    End Structure

    Public Structure Scores_Check_Bowler_Exists_BID
        Public _ERRMsg As String
        Public Exists As Boolean
    End Structure

    'Scores, FName, LName
    Public Structure Scores_By_Sex_Week
        Public _ERRMsg As String
        Public Name As String
        Public Scores As String
    End Structure

    Public Structure Lineup_Get_Setting_By_ID
        Public _ERRMsg As String
        Public Setting As String
    End Structure

    Public Structure Tournament_Get_Data
        Public _ERRMsg As String
        Public TornData As String
    End Structure

    Public Structure Tournament_Exists
        Public _ERRMsg As String
        Public exists As Boolean
    End Structure

End Class
