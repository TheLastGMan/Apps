Public Class rowguidkey

    <Schema.DatabaseGenerated(Schema.DatabaseGeneratedOption.Identity)>
    <Key>
    <DefaultValue("newid()")>
    Public Property rowkey As Guid

End Class
