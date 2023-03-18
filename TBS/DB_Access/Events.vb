Public Module Events

				Public Event WriteLogEvent(ByRef errCode As String, ByRef subFunction As String, ByRef message As String)
				Public Event ChangeHeaderEvent(ByRef message As String)
				Public Event GetWeekIdEvent(ByRef weekId As Integer)
				Public Event GetWeekNameEvent(ByRef weekName As String)
				Public Event GetLeagueNameEvent(ByRef leagueName As String)
				Public Event GetWeekListEvent(ByRef wkList As ArrayList)
				Public Event GetScoreMinEvent(ByRef minScore As Short)
				Public Event GetGamesPerWeekEvent(ByRef gmsPerWeek As Short)

				Public Sub WriteLog(ByRef errCode As String, ByRef subFunction As String, Optional ByRef msg As String = "")
								RaiseEvent WriteLogEvent(errCode, subFunction, msg)
				End Sub

				Public Sub ChangeHeaderText(ByVal message As String)
								RaiseEvent ChangeHeaderEvent(message)
				End Sub

				Public Function GetWeekName() As String
								Dim weekName As String = String.Empty
								RaiseEvent GetWeekNameEvent(weekName)
								Return weekName
				End Function

				Public Function GetLeagueName() As String
								Dim leagueName As String = String.Empty
								RaiseEvent GetLeagueNameEvent(leagueName)
								Return leagueName
				End Function

				Public Function GetWeekId() As Integer
								Dim id As Integer = 0
								RaiseEvent GetWeekIdEvent(id)
								Return id
				End Function

				Public Function GetWeekList() As ArrayList
								Dim lst As New ArrayList
								RaiseEvent GetWeekListEvent(lst)
								Return lst
				End Function

				Public Function GetMinimumScore() As Short
								Dim score As Integer
								RaiseEvent GetScoreMinEvent(score)
								Return score
				End Function

				Public Function GetGamesPerWeek() As Short
								Dim gpw As Integer
								RaiseEvent GetGamesPerWeekEvent(gpw)
								Return gpw
				End Function

End Module
