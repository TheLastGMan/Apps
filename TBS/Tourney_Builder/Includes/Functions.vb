Imports TBDB
Public Class Functions

				Public Cont As UserControl
				Public USBC_Search As String() = {"FName", "LName", "0", "0", "Sex", "ID"}
				'Global Version
				Public Shared version As String = My.Application.Info.Version.ToString

				Public Shared Sub Log_Write(ByRef error_code As Char, ByRef sub_function As String, Optional ByRef msg As String = "")
								If DBLnkr.DB_Logging_Enab Then
												DBLnkr.DB_Logging.Log_Write(error_code & " " & sub_function & " " & msg)
								End If

								Dim color As Color
								Select Case error_code
												Case "E"
																color = Errors._ERR
												Case "S"
																color = Errors._OK
												Case "W"
																color = Errors._WRN
												Case "I"
																color = Color.Cyan
												Case Else
																color = Color.Magenta
								End Select
								Errors.Send_Message(IIf(msg.Length = 0, sub_function, msg), color)
				End Sub

				Public Shared Sub Log_Purge()

				End Sub

				Public Sub Change_Header(ByRef text As String)
								Main.Header.Text = text
				End Sub

				Public Sub Change_Cont()
								Dim found As Boolean = False
								If Not Main.Panel1.Controls.Contains(Cont) Then
												Main.Panel1.Controls.Clear()
												Main.Panel1.Controls.Add(Cont)
								End If
				End Sub

				Public Function Get_Month(ByRef mo As Byte) As String
								Dim ret As String = ""

								Select Case mo
												Case 1
																ret = "Jan"
												Case 2
																ret = "Feb"
												Case 3
																ret = "Mar"
												Case 4
																ret = "Apr"
												Case 5
																ret = "May"
												Case 6
																ret = "June"
												Case 7
																ret = "July"
												Case 8
																ret = "Aug"
												Case 9
																ret = "Sep"
												Case 10
																ret = "Oct"
												Case 11
																ret = "Nov"
												Case 12
																ret = "Dec"
								End Select

								Return ret
				End Function

End Class
