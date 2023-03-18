Namespace Entity

    <Table("PINZSS_Wishlist")>
    Public Class Wishlist

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property Id As Guid
        <Required>
        Public Property FBId As Long
        <Required>
        Public Property Year As Integer
        <Required>
        <MaxLength(64)>
        Public Property WantedItem As String

    End Class

End Namespace