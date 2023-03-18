Namespace Repository

    Public Class Wishlist

        Private ReadOnly DBC As New Data.Context

        Public Function Entities() As IQueryable(Of Entity.Wishlist)
            Return DBC.Wishlist.AsQueryable
        End Function

        Public Function UserWishlist(fbid As Long, year As Integer) As IEnumerable(Of KeyValuePair(Of Guid, String))
            Return Entities.Where(Function(f) f.FBId.Equals(fbid) And f.Year.Equals(year)).ToDictionary(Function(f) f.Id, Function(f) f.WantedItem).AsEnumerable
        End Function

        Public Function AddItem(fbid As Long, year As Integer, ByRef item As String, ByRef WL As Entity.Wishlist) As Boolean
            WL = New Entity.Wishlist With {.FBId = fbid, .Year = year, .WantedItem = item}
            DBC.Wishlist.Add(WL)
            Return DBC.SaveChanges()
        End Function

        Public Function Read(id As Guid) As Entity.Wishlist
            Return Entities.Where(Function(f) f.Id.Equals(id)).FirstOrDefault
        End Function

        Public Function Delete(ByRef id As Guid) As Boolean
            DBC.Wishlist.Remove(Read(id))
            Return DBC.SaveChanges()
        End Function

    End Class

End Namespace
