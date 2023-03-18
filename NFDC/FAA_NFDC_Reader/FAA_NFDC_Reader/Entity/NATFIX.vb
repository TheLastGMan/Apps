Namespace Entity

    <Schema.Table("FAA_NATFIX")>
    Public Class NATFIX : Inherits rowguid

        <Key>
        <MaxLength(5)>
        Public Property icao As String
        <MaxLength(15)>
        Public Property latitude As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(4)>
        Public Property artcc_id As String
        <MaxLength(2)>
        Public Property state_code As String
        <MaxLength(2)>
        Public Property region_code As String
        <MaxLength(7)>
        Public Property type As String

    End Class

End Namespace
