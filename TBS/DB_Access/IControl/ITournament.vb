Public Interface ITournament

    ''' <summary>
    ''' How many bowlers will move on to the Tournament
    ''' </summary>
    ''' <returns>Number of bowlers to move on</returns>
    ''' <remarks>Scoresheet: used to show how far ahead the bowlers are above/below [top_count]</remarks>
    Function Top_Count() As Integer

    ''' <summary>
    ''' Lineup for the tournament bracket for who plays against each other
    ''' </summary>
    ''' <returns>array list positions</returns>
    ''' <remarks></remarks>
    Function Tournament_Lineup() As Short()

    ''' <summary>
    ''' Main Tournament Control Control
    ''' </summary>
    ''' <returns>User Control</returns>
    ''' <remarks></remarks>
    Function Tournament_Control() As System.Windows.Forms.UserControl

    ''' <summary>
    ''' Tournament Report Control
    ''' </summary>
    ''' <returns>User Control</returns>
    ''' <remarks></remarks>
    Function Tournament_Report_Control() As System.Windows.Forms.UserControl

End Interface
