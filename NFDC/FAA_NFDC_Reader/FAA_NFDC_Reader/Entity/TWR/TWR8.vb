Namespace Entity

    <Schema.Table("FAA_TWR8")>
    Public Class TWR8 : Inherits rowguid

        <Key>
        <MaxLength(4)>
        Public Property icao As String

        <Schema.NotMapped>
        Public Property ClassB As String
            Get
                Return IIf(_classb, "Y", "N")
            End Get
            Set(value As String)
                If value.Length > 0 Then
                    _classb = IIf(value = "Y", True, False)
                End If
            End Set
        End Property
        <Schema.Column("ClassB")>
        Private Property _classb As Boolean

        <Schema.NotMapped>
        Public Property ClassC As String
            Get
                Return IIf(_classc, "Y", "N")
            End Get
            Set(value As String)
                If value.Length > 0 Then
                    _classc = IIf(value = "Y", True, False)
                End If
            End Set
        End Property
        <Schema.Column("ClassC")>
        Private Property _classc As Boolean

        <Schema.NotMapped>
        Public Property ClassD As String
            Get
                Return IIf(_classd, "Y", "N")
            End Get
            Set(value As String)
                If value.Length > 0 Then
                    _classd = IIf(value = "Y", True, False)
                End If
            End Set
        End Property
        <Schema.Column("ClassD")>
        Private Property _classd As Boolean

        <Schema.NotMapped>
        Public Property ClassE As String
            Get
                Return IIf(_classe, "Y", "N")
            End Get
            Set(value As String)
                If value.Length > 0 Then
                    _classe = IIf(value = "Y", True, False)
                End If
            End Set
        End Property
        <Schema.Column("ClassE")>
        Private Property _classe As Boolean

        <MaxLength(300)>
        Public Property airspace_hours As String

    End Class

End Namespace
