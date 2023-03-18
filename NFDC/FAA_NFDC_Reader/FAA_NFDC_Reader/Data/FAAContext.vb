Imports System.Data.Entity
Public Class FAAContext : Inherits DbContext

    Public Property COM As DbSet(Of Entity.COM)

    Public Property AWOS1 As DbSet(Of Entity.AWOS1)
    Public Property AWOS2 As DbSet(Of Entity.AWOS2)

    Public Property FIX1 As DbSet(Of Entity.FIX1)

    Public Property APT1 As DbSet(Of Entity.APT)

    Public Property TWR1 As DbSet(Of Entity.TWR1)
    Public Property TWR2 As DbSet(Of Entity.TWR2)
    Public Property TWR3 As DbSet(Of Entity.TWR3)
    Public Property TWR4 As DbSet(Of Entity.TWR4)
    Public Property TWR7 As DbSet(Of Entity.TWR7)
    Public Property TWR8 As DbSet(Of Entity.TWR8)
    Public Property TWR9 As DbSet(Of Entity.TWR9)

    Public Property NAV1 As DbSet(Of Entity.NAV1)
    Public Property NAV2 As DbSet(Of Entity.NAV2)

    Public Property NATFIX As DbSet(Of Entity.NATFIX)

End Class
