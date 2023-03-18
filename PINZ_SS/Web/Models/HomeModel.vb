Public Class HomeModel

    Public Property Profile As Core.Model.FBInfo
    Public Property IsEntered As Boolean
    Public Property AfterRegistrationDate As Boolean
    Public Property RegistrationDate As Date
    Public Property DrawingEnabled As Boolean

    Public Property ViewMode As String

    Public Property WorkLocations As New List(Of Long)

End Class
