Imports System.Data.Entity
Namespace Data

    Public Class Context : Inherits DbContext

        Public Property Users As DbSet(Of Entity.User)
        Public Property SSInfo As DbSet(Of Entity.SSInfo)
        Public Property Logs As DbSet(Of Entity.Logs)
        Public Property Settings As DbSet(Of Entity.Settings)
        Public Property Wishlist As DbSet(Of Entity.Wishlist)

    End Class

End Namespace
