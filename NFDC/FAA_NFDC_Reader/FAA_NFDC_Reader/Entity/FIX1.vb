Namespace Entity

    <Schema.Table("FAA_FIX1")>
    Public Class FIX1 : Inherits rowguid

        <Key>
        <MaxLength(30)>
        Public Property fix_id As String
        <MaxLength(30)>
        Public Property fix_state As String
        <MaxLength(2)>
        Public Property icao_region As String
        <MaxLength(15)>
        Public Property latitude As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(3)>
        Public Property type As String
        <MaxLength(22)>
        Public Property info1 As String
        <MaxLength(22)>
        Public Property info2 As String
        <MaxLength(33)>
        Public Property previous_name As String
        <MaxLength(38)>
        Public Property chart_info As String
        <MaxLength(1)>
        Public Property to_be_published As String
        <MaxLength(15)>
        Public Property fix_use As String
        <MaxLength(5)>
        Public Property nas_ident As String
        <MaxLength(4)>
        Public Property artcc_high As String
        <MaxLength(4)>
        Public Property artcc_low As String
        <MaxLength(30)>
        Public Property fix_use_icao As String
        <MaxLength(1)>
        Public Property pitch As String
        <MaxLength(1)>
        Public Property [catch] As String
        <MaxLength(1)>
        Public Property sua_atcaa As String

    End Class

End Namespace
