Imports System.Data.SqlClient
Public Class DB

    'Private Shared SQLstr As String = "Data Source=.\SQLEXPRESS;Initial Catalog=FAA_NFDC;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;Connect Timeout=120"
    Private Shared SQLstr As String = "Data Source=rpgcor08.db.8515393.hostedresource.com; Initial Catalog=rpgcor08; User ID=rpgcor08; Password=RPG_Rustydog08;MultipleActiveResultSets=True;Connect Timeout=120"
    Private Shared SQLcon As New SqlConnection(SQLstr)

    Public Shared Function EXECsql(ByRef sql As String) As Data.DataTable
        Dim DT As New Data.DataTable("RESULTS")

        Try
            If SQLcon.State = ConnectionState.Closed Then
                SQLcon.Open()
            End If
            Dim SQLDA As New SqlDataAdapter(sql, SQLcon)
            SQLDA.Fill(DT)
        Catch ex As Exception

        Finally
            SQLcon.Close()
        End Try

        Return DT
    End Function

    Public Shared Function EXECbulkcopy(ByRef data_table_name As String, ByRef dtx As Data.DataTable) As Boolean
        Dim BC As New SqlBulkCopy(SQLcon)
        Try
            EXECsql("DELETE FROM " & data_table_name)
            If SQLcon.State = ConnectionState.Closed Then
                SQLcon.Open()
            End If
            BC.BulkCopyTimeout = 10000
            BC.DestinationTableName = data_table_name
            BC.WriteToServer(dtx)
            Return True
        Catch ex As Exception
            Return False
        Finally
            BC.Close()
            SQLcon.Close()
        End Try
    End Function

End Class
