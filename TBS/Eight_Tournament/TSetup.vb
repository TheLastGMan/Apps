Public Class TSetup
    Implements TBDB.ITournament

    Public Shared TopCount As Integer = 8
    Public Shared Lineup As Short() = {1, 8, 3, 6, 4, 5, 2, 7}

    Public Function Tournament_Lineup() As Short() Implements TBDB.ITournament.Tournament_Lineup
        Return Lineup
    End Function

    Public Function Top_Count() As Integer Implements TBDB.ITournament.Top_Count
        Return TopCount
    End Function

    Public Function Tournament_Control() As System.Windows.Forms.UserControl Implements TBDB.ITournament.Tournament_Control
        Return New Edit_Tournament
    End Function

    Public Function Tournament_Report_Control() As System.Windows.Forms.UserControl Implements TBDB.ITournament.Tournament_Report_Control
        Return New TReport
    End Function

End Class
