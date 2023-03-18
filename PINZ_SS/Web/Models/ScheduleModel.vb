Public Class ScheduleModel

    Public Property Departments As New List(Of SelectListItem)
    Public Property department As Integer
    Public Property ShowInTime As Boolean = True
    Public Property ShowOutTime As Boolean = False
    Public Property ShowFirstNames As Boolean = True
    Public Property ShowLastNames As Boolean = True
    Public Property Unscheduled As Boolean = False
    Public Property Jobs As Boolean = True
    Public Property Availability As Boolean = True
    Public Property Telephone As Boolean = False
    Public Property StartDate As Date = Now.AddDays(-1 * Now.DayOfWeek)
    Public Property EndDate As Date = Now.AddDays(7 - Now.DayOfWeek)

    Public ReadOnly Property timestamp As Long
        Get
            Return Now.Ticks
        End Get
    End Property

    Public Property YesNoCB As New List(Of SelectListItem)

End Class
