Namespace Entity

    <Table("PINZSS_Settings")>
    Public Class Settings

        <Key>
        <MaxLength(256)>
        Public Property Key As String
        <Required>
        <MaxLength(512)>
        Public Property Value As String

    End Class

End Namespace
