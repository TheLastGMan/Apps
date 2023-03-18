Namespace Entity

    <Table("PINZSS_SecretSantaInfo")>
    Public Class SSInfo

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property FBId As Long
        Public Property AssignedTo_FBId As Long?
        <Required>
        Public Property year As Integer = Now.Year
        Public Property seen_ss As Boolean = False
        Private Property _progressstatus As Byte

        'Public Property ProgressStatus As ProgressStatus
        '    Get
        '        Return DirectCast(_progressstatus, ProgressStatus)
        '    End Get
        '    Set(value As ProgressStatus)
        '        _progressstatus = Byte.Parse(value)
        '    End Set
        'End Property

        <NotMapped>
        Public ReadOnly Property AssignedToProfile As Entity.User
            Get
                If AssignedTo_FBId Is Nothing Then
                    Return Nothing
                End If
                Return New Repository.User().GetUser_by_Id(AssignedTo_FBId)
            End Get
        End Property

    End Class

    Public Enum ProgressStatus As Byte
        PreRegistration = 0 'user logged in with facebook
        WorkValidated = 1 'passes work location validation

    End Enum

End Namespace
