Namespace Repository

    Public Class SSInfo

        Private DBC As New Data.Context
        Private SSI As New Settings

        Public ReadOnly Property SSInfo As List(Of Entity.SSInfo)
            Get
                Return DBC.SSInfo.ToList
            End Get
        End Property

        Public ReadOnly Property Entities As IQueryable(Of Entity.SSInfo)
            Get
                Return DBC.SSInfo.AsQueryable
            End Get
        End Property

        Public Function Exists(ByVal fbid As Long) As Boolean
            Try
                If SSInfo.Where(Function(f) f.FBId = fbid And f.year = SSI.CurrentYear).Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Add(ByRef SS As Entity.SSInfo) As Boolean
            Try
                SS.year = SSI.CurrentYear
                DBC.SSInfo.Add(SS)
                DBC.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Remove(ByVal FBId As Long) As Boolean
            Try
                Dim info As Entity.SSInfo = SSInfo.Where(Function(f) f.FBId = FBId And f.year = SSI.CurrentYear).FirstOrDefault
                DBC.SSInfo.Remove(info)
                DBC.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function AssignUser(ByVal FBId As Long, ByVal Receiver_FBId As Long) As Boolean
            Try
                If Exists(FBId) Then
                    'update
                    Return Update(FBId, Receiver_FBId)
                Else
                    'create
                    Return Add(New Entity.SSInfo() With {.FBId = FBId, .AssignedTo_FBId = Receiver_FBId})
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Update(ByVal fbid As Long, ByVal receiver_fbid As Long) As Boolean
            Try
                Dim usr = SSInfo.Where(Function(f) f.FBId = fbid And f.year = SSI.CurrentYear).FirstOrDefault
                usr.AssignedTo_FBId = receiver_fbid
                DBC.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function SetSeen(ByVal fbid As Long, Optional ByVal seen As Boolean = False) As Boolean
            Try
                Dim usr = SSInfo.Where(Function(f) f.FBId = fbid And f.year = SSI.CurrentYear).FirstOrDefault
                usr.seen_ss = seen
                DBC.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function IsAssignedTo(ByVal fbid As Long) As Entity.User
            Dim usr = SSInfo.Where(Function(f) f.FBId = fbid And f.year = SSI.CurrentYear).FirstOrDefault
            If usr IsNot Nothing Then
                Return usr.AssignedToProfile
            Else
                Return Nothing
            End If
        End Function

        Public Function HasSeenSS(ByVal fbid As Long) As Boolean
            Dim usr = SSInfo.Where(Function(f) f.FBId = fbid And f.year = SSI.CurrentYear).FirstOrDefault
            If usr IsNot Nothing Then
                Return usr.seen_ss
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
