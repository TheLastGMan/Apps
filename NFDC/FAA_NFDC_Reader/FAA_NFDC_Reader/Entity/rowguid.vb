Public MustInherit Class rowguid

    <Schema.DatabaseGenerated(Schema.DatabaseGeneratedOption.Identity)>
    <DefaultValue("newid()")>
    Public Property rowguid As Guid

End Class
