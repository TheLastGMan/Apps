Namespace Entity

    <Schema.Table("FAA_NAV2")>
    Public Class NAV2 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(20)>
        Public Property type As String

        <Schema.Column("remarks")>
        <MaxLength(600)>
        Private Property _remarks As String
        <Schema.NotMapped>
        Public WriteOnly Property Remarks As String
            Set(value As String)
                _remarks = _remarks
            End Set
        End Property
        <Schema.NotMapped>
        Public ReadOnly Property Remarks_List As List(Of String)
            Get
                Return _remarks.Split(";").ToList()
            End Get
        End Property
    End Class

End Namespace
