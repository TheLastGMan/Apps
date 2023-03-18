Public Class DBModels

				Public Class Bowler
								Public Property Id As Integer
								Public Property FName As String
								Public Property LName As String
								Public Property USBCSanctionNumber As String
								Public Property Sex As String
				End Class

				Public Class Week
								Public Property Id As Integer
								Public Property WeekName As String
								Public Property Lineups As String
								Public Property Position As Byte
								Public Property Checked As Boolean
								Public Property SSeries As Short
								Public Property STLane As Short
								Public Property NGames As Short
				End Class

				Public Class Tournament
								Public Property Id As Integer
								Public Property Week As Week
								Public Property Data As String
				End Class

				Public Class Lineup
								Public Property Id As Integer
								Public Property Place As String
				End Class

				Public Class Score
								Public Property Id As Integer
								Public Property Week As Week
								Public Property LaneNumber As Short
								Public Property Bowler As Bowler
								Public Property Scores As String
								Public Property SUM4 As Short
								Public Property SUM3 As Short
								Public Property AVE As Decimal
								Public Property BAlias As String
				End Class

End Class
