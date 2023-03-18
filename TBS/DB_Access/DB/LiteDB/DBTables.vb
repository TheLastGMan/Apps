Imports LiteDB

Public Class DBTables

				Public Property Bowlers As ILiteCollection(Of DBModels.Bowler)
				Public Property Weeks As ILiteCollection(Of DBModels.Week)
				Public Property Tournaments As ILiteCollection(Of DBModels.Tournament)
				Public Property Lineups As ILiteCollection(Of DBModels.Lineup)
				Public Property Scores As ILiteCollection(Of DBModels.Score)

End Class
