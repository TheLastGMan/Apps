Public Class ResponseDefaults

    Public Current As Boolean
    Public Errors As Boolean
    Public Message As String

    Public Sub New()
        Errors = False
        Message = ""
        Current = AFD.IsCurrent()
    End Sub

    Public Sub SetError(ByRef msg As String)
        Errors = True
        Message = msg
    End Sub

    Public Sub ClearError()
        Errors = False
        Message = ""
    End Sub

End Class
