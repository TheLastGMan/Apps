Public Class BarCode
    ' Barcode must be 8 or 13 Numeric Digits
    Private Function UPCA_Bin(ByVal strEANCode As String) As String
        Dim K As Integer
        Dim strAux As String = ""
        Dim strExit As String = ""
        Dim strCode As String = ""

        strEANCode = Trim(strEANCode)
        strAux = strEANCode

        If (strAux.Length <> 13) And (strAux.Length <> 8) Then
            Err.Raise(5, "EAN2Bin", "Invalid EAN Code")
        End If

        For K = 0 To strEANCode.Length - 1
            Select Case (strAux.Chars(K).ToString)
                Case Is < "0", Is > "9"
                    Err.Raise(5, "EAN2Bin", "Invalid char on EAN Code")
            End Select
        Next

        If (strAux.Length = 13) Then
            strAux = Mid(strAux, 2)
            Select Case CInt(Left(strEANCode, 1))
                Case 0
                    strCode = "000000"
                Case 1
                    strCode = "001011"
                Case 2
                    strCode = "001101"
                Case 3
                    strCode = "001110"
                Case 4
                    strCode = "010011"
                Case 5
                    strCode = "011001"
                Case 6
                    strCode = "011100"
                Case 7
                    strCode = "010101"
                Case 8
                    strCode = "010110"
                Case 9
                    strCode = "011010"
            End Select
        Else
            strCode = "0000"
        End If

        '* The EAN BarCode starts with a "guardian" 
        strExit = "00101"

        '* First half of the code
        For K = 1 To Len(strAux) \ 2
            Select Case CInt(Mid(strAux, K, 1))
                Case 0
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0001101", "0100111")
                Case 1
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0011001", "0110011")
                Case 2
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0010011", "0011011")
                Case 3
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0111101", "0100001")
                Case 4
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0100011", "0011101")
                Case 5
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0110001", "0111001")
                Case 6
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0101111", "0000101")
                Case 7
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0111011", "0010001")
                Case 8
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0110111", "0001001")
                Case 9
                    strExit &= IIf(Mid(strCode, K, 1) = "0", "0001011", "0010111")
            End Select
        Next K

        '* Middle "guardian" separator
        strExit &= "01010"

        '* Second half of the code
        For K = Len(strAux) \ 2 + 1 To Len(strAux)
            Select Case CInt(Mid(strAux, K, 1))
                Case 0
                    strExit &= "1110010"
                Case 1
                    strExit &= "1100110"
                Case 2
                    strExit &= "1101100"
                Case 3
                    strExit &= "1000010"
                Case 4
                    strExit &= "1011100"
                Case 5
                    strExit &= "1001110"
                Case 6
                    strExit &= "1010000"
                Case 7
                    strExit &= "1000100"
                Case 8
                    strExit &= "1001000"
                Case 9
                    strExit &= "1110100"
            End Select
        Next K
        strExit &= "10100"
        Return strExit
    End Function

    Public Sub UPCA_Draw(ByVal strEANCode As String, ByVal objPicBox As PictureBox, _
                                Optional ByVal sngX1 As Single = (-1), _
                                Optional ByVal sngY1 As Single = (-1), _
                                Optional ByVal sngX2 As Single = (-1), _
                                Optional ByVal sngY2 As Single = (-1), _
                                Optional ByVal FontForText As Font = Nothing)

        Dim K As Single
        Dim sngPosX As Single
        Dim sngPosY As Single
        Dim sngScaleX As Decimal
        Dim strEANBin As String
        Dim strFormat As New StringFormat

        strEANBin = UPCA_Bin(strEANCode)

        If (FontForText Is Nothing) Then
            FontForText = New Font("Verdana", 12)
        End If

        If sngX1 = (-1) Then sngX1 = 0
        If sngY1 = (-1) Then sngY1 = 0
        If sngX2 = (-1) Then sngX2 = objPicBox.Width
        If sngY2 = (-1) Then sngY2 = objPicBox.Height

        sngScaleX = (objPicBox.Width / strEANBin.Length)

        sngPosX = sngX1
        sngPosY = sngY2 - CSng(1.5 * FontForText.Height)

        objPicBox.CreateGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.White), sngX1, sngY1, sngX2 - sngX1, sngY2 - sngY1)

        For K = 1 To Len(strEANBin)
            If Mid(strEANBin, K, 1) = "1" Then
                'objPicBox.CreateGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.Red), sngPosX, sngY1, sngScaleX, sngPosY)
                objPicBox.CreateGraphics.FillRectangle(Brushes.Black, sngPosX, sngY1, sngScaleX, sngPosY)
            End If
            sngPosX += sngScaleX
            'sngPosX += sngX1 + (K * sngScaleX)
        Next K

        strFormat.Alignment = StringAlignment.Center
        strFormat.FormatFlags = StringFormatFlags.NoWrap
        objPicBox.CreateGraphics.DrawString(strEANCode, FontForText, New System.Drawing.SolidBrush(Color.Black), CSng((sngX2 - sngX1) / 2), CSng(sngY2 - FontForText.Height), strFormat)
    End Sub

    REM ----------------------------------------------------------------------------
#Region "EAN13"

    Private EAN13_Num As String = ""

    ReadOnly Property EAN13_Code()
        Get
            Return EAN13_Num
        End Get
    End Property

    Public Function EAN13_Check_Len(ByVal dig6 As String)
        If Not dig6 <> 6 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function EAN13_Gen(ByVal dig6 As String)
        Dim ProdInfo As String = My.Settings.Prod_Cntry & My.Settings.Prod_Code
        Dim start As String = "0000000101"
        Dim cents As String = "01010"
        Dim stops As String = "1010000000"
        Dim check As String = EAN13_Ck_Code(ProdInfo & dig6)
        Dim eanl As String = ProdInfo & dig6 & check
        Dim ean1 As String = String.Empty
        Dim ean2 As String = String.Empty

        For i As SByte = 1 To 6
            ean1 &= EAN13_Num_Code(eanl.Substring(i, 1), 0)
        Next
        For i As SByte = 7 To 12
            ean2 &= EAN13_Num_Code(eanl.Substring(i, 1), 1)
        Next
        'ean2 &= EAN13_Num_Code(check, 1)

        EAN13_Num = ProdInfo & dig6 & check
        Return start & ean1 & cents & ean2 & stops
    End Function

    Private Function EAN13_Num_Code(ByVal num As Byte, ByVal sect As Boolean)
        'sect (0) = Left [ODD] | (1) = Right
        Dim code As String = ""
        Select Case num
            Case 0
                code = IIf(Not sect, "0001101", "1110010")
            Case 1
                code = IIf(Not sect, "0011001", "1100110")
            Case 2
                code = IIf(Not sect, "0010011", "1101100")
            Case 3
                code = IIf(Not sect, "0111101", "1000010")
            Case 4
                code = IIf(Not sect, "0100011", "1011100")
            Case 5
                code = IIf(Not sect, "0110001", "1001110")
            Case 6
                code = IIf(Not sect, "0101111", "1010000")
            Case 7
                code = IIf(Not sect, "0111011", "1000100")
            Case 8
                code = IIf(Not sect, "0110111", "1001000")
            Case 9
                code = IIf(Not sect, "0001011", "1110100")
        End Select
        Return code
    End Function

    Private Function EAN13_Ck_Code(ByVal chk As String)
        Dim code As SByte = 0
        Dim plac As String() = {String.Empty}
        Dim weig As String() = {1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3}
        Dim cont As Byte = 0

        For i As SByte = 1 To 12
            cont += (chk.Substring((i - 1), 1) * weig((i - 1)))
        Next

        While cont Mod 10
            cont += 1
            code += 1
        End While

        Return code
    End Function

    Public Sub EAN13_Draw(ByVal dig6 As String, ByVal PicBox As PictureBox, _
                          Optional ByVal StartX As Short = 0, _
                          Optional ByVal StartY As Short = 0, _
                          Optional ByVal WidthX As Short = 0, _
                          Optional ByVal HightY As Short = 0, _
                          Optional ByVal Font As Font = Nothing)

        Dim code As String = EAN13_Gen(dig6)
        Dim Hl As Short = Math.Floor(PicBox.Height * 0.95)
        Dim Hs As Short = Math.Floor(PicBox.Height * 0.8)
        Dim xw As Byte = Math.Floor(PicBox.Width / code.Length)
        Dim tf As Boolean = False
        Dim strFormat As New StringFormat

        If Font Is Nothing Then
            Font = New Font("Courier New", 8)
        End If

        'Hl = Hs
        'PicBox.Width = (xw * code.Length)

        PicBox.CreateGraphics.FillRectangle(Brushes.White, 0, 0, PicBox.Width, PicBox.Height)

        ''MsgBox(EAN13_Num & " - " & code.Length & " - " & code)

        For i As SByte = 0 To code.Length - 1
            tf = code.Substring(i, 1)
            If tf Then
                'Deside Long, Short Black
                Deside_BW_Rect(PicBox, StartX, StartY, xw, 1, Hl, Hs, i)
            Else
                'Deside Long, Short White
                Deside_BW_Rect(PicBox, StartX, StartY, xw, 0, Hl, Hs, i)
            End If
            StartX += xw
        Next

        strFormat.Alignment = StringAlignment.Center
        strFormat.FormatFlags = StringFormatFlags.NoWrap
        'PicBox.CreateGraphics.DrawString(EAN13_Num, Font, New System.Drawing.SolidBrush(Color.Black), PicBox.Width / 2, PicBox.Height - 12, strFormat)

    End Sub

    Const First_Sec As SByte = 10
    Private Sub Deside_BW_Rect(ByVal PicBox As PictureBox, ByVal StartX As Short, ByVal StartY As Short, _
                             ByVal Width As Short, ByVal color As Boolean, _
                             ByVal HLS As Short, ByVal HSS As Short, ByVal num As Short)

        Dim HS As Boolean = False 'True = Long | False = Short

        If num < First_Sec Then
            HS = True
        ElseIf num < (First_Sec + 42) Then
            HS = False
        ElseIf num < (First_Sec + 42 + 5) Then
            HS = True
        ElseIf num < (First_Sec + 42 + 5 + 42) Then
            HS = False
        Else
            HS = True
        End If

        If HS Then
            Draw_BW_Rect(PicBox, StartX, StartY, Width, HLS, color)
        Else
            Draw_BW_Rect(PicBox, StartX, StartY, Width, HSS, color)
        End If

    End Sub

    Private Sub Draw_BW_Rect(ByVal PicBox As PictureBox, ByVal StartX As Short, ByVal StartY As Short, _
                             ByVal Width As Short, ByVal Height As Short, ByVal color As Boolean)
        'color (0) = White | (1) = Black
        If color Then
            'Black
            PicBox.CreateGraphics.FillRectangle(Brushes.Black, StartX, StartY, Width, Height)
        Else
            'White
            PicBox.CreateGraphics.FillRectangle(Brushes.White, StartX, StartY, Width, Height)
        End If
    End Sub

#End Region
    REM ----------------------------------------------------------------------------
#Region "Code 39"

    Private Function C39_Gen(ByVal C39 As String) As String
        'CHECK, ASCII, BARCODE
        Dim getchr() As String = {0, "0", "101001101101", 1, "1", "110100101011", 2, "2", "101100101011", _
                                  3, "3", "101001101101", 4, "4", "110100101011", 5, "5", "101100101011", _
                                  6, "6", "101001101101", 7, "7", "110100101011", 8, "8", "101100101011", _
                                  9, "9", "101001101101", 10, "A", "110100101011", 11, "B", "101100101011", _
                                  12, "C", "101001101101", 13, "D", "110100101011", 14, "E", "101100101011", _
                                  15, "F", "101001101101", 16, "G", "110100101011", 17, "H", "101100101011", _
                                  18, "I", "101001101101", 19, "J", "110100101011", 20, "K", "101100101011", _
                                  21, "L", "101001101101", 22, "M", "110100101011", 23, "N", "101100101011", _
                                  24, "O", "101001101101", 25, "P", "110100101011", 26, "Q", "101100101011", _
                                  27, "R", "101001101101", 28, "S", "110100101011", 29, "T", "101100101011", _
                                  30, "U", "101001101101", 31, "V", "110100101011", 32, "W", "101100101011", _
                                  33, "X", "101001101101", 34, "Y", "110100101011", 35, "Z", "101100101011", _
                                  36, "-", "101001101101", 37, ".", "110100101011", 38, " ", "101100101011", _
                                  39, "$", "101001101101", 40, "/", "110100101011", 41, "+", "101100101011", _
                                  42, "%", "101001101101"}
        Dim C39x As String = String.Empty
        Dim checks As String = String.Empty
        Dim start As String = "100101101101"
        Dim stops As String = "100101101101"

        Dim tf As Boolean = False

        For c As Short = 0 To C39.Length - 2
            For i As Byte = 0 To getchr.Length - 2 Step 3
                If C39.Substring(c, 1) = getchr(i + 1) Then
                    C39x &= getchr(i + 2)
                    tf = True
                End If
            Next
            If Not tf Then
                C39x &= getchr(2)
            End If
            tf = False
        Next

        'checks = C39Mod43(C39)

        Return (start & C39x & checks & stops)
    End Function

    Public Function C39Mod43(ByVal C39 As String) As String
        ' compute checksum for Code 39, translated by antiguide
        Dim charSet As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%"
        Dim rejected As String = ""
        Dim total As Integer = 0
        Dim ret As String = ""
        C39 = InputBox("Code to generate: ")
        For i = 1 To Len(C39)
            Dim rank
            rank = InStr(charSet, Mid(C39, i, 1)) - 1
            If (rank >= 0) Then
                total = total + rank
            Else
                rejected = rejected & Mid(C39, i, 1)
            End If
        Next
        If rejected = "" Then
            ret = C39 & Mid(charSet, (total Mod 43 + 1), 1)
            Return ret
        Else
            'MsgBox("wrong characters: " & rejected)
            Return "ERROR"
        End If
    End Function

    Public Sub C39_Draw(ByVal C39 As String)
        Dim C39I As String = C39_Gen(C39.ToUpper())

        'MsgBox(C39I)

        For i As Short = 0 To C39I.Length - 1
            If C39I.Substring(i, 1) = "0" Then
                'Draw a White Space
            Else
                'Draw a Black Space
            End If
        Next

    End Sub

#End Region

End Class
