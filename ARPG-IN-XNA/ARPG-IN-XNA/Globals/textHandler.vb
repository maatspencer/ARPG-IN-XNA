Imports System.Windows.Forms.Control

Public Class textHandler
    Public Shared Function stringMod(inputString As String, Optional stringMaxLength As Integer = Nothing) As String
        ' Shift?
        Dim shift As Boolean = False
        If Input.KeyDown(Keys.LeftShift) = True Or Input.KeyDown(Keys.RightShift) = True Then
            shift = True
        End If

        ' Capslock?
        Dim capsLock As Boolean = If(IsKeyLocked(Windows.Forms.Keys.CapsLock), True, False)

        ' numLock?
        Dim numLock As Boolean = If(IsKeyLocked(Windows.Forms.Keys.NumLock), True, False)

        ' Get currently pressed keys
        Dim pressedKeys() As Keys
        pressedKeys = Input.CurrentKeystate.GetPressedKeys()

        ' modify string for each key down
        For Each key As Keys In pressedKeys
            ' Pressed/Typed key
            If Input.KeyPressed(key) = True Then
                If key = Keys.Back Then
                    If inputString.Length > 0 Then
                        inputString = inputString.Remove(inputString.Length - 1, 1)
                    End If
                Else
                    inputString = inputString.Insert(inputString.Length, TranslateChar(key, shift, capsLock, numLock))
                End If
            End If

            ' Held Down key
            ''TODO
        Next

        ' Remove extra characters
        If Not stringMaxLength = Nothing Then
            If inputString.Length > stringMaxLength Then
                inputString = inputString.Remove(stringMaxLength)
            End If
        End If

        Return inputString

    End Function
    Public Shared Function TranslateChar(key As Keys, shift As Boolean, capsLock As Boolean, numLock As Boolean) As String
        Select Case key
            ' Alphabet a-Z
            Case Keys.A
                Return TranslateAlphabetic("a"c, shift, capsLock)

            Case Keys.B
                Return TranslateAlphabetic("b"c, shift, capsLock)

            Case Keys.C
                Return TranslateAlphabetic("c"c, shift, capsLock)

            Case Keys.D
                Return TranslateAlphabetic("d"c, shift, capsLock)

            Case Keys.E
                Return TranslateAlphabetic("e"c, shift, capsLock)

            Case Keys.F
                Return TranslateAlphabetic("f"c, shift, capsLock)

            Case Keys.G
                Return TranslateAlphabetic("g"c, shift, capsLock)

            Case Keys.H
                Return TranslateAlphabetic("h"c, shift, capsLock)

            Case Keys.I
                Return TranslateAlphabetic("i"c, shift, capsLock)

            Case Keys.J
                Return TranslateAlphabetic("j"c, shift, capsLock)

            Case Keys.K
                Return TranslateAlphabetic("k"c, shift, capsLock)

            Case Keys.L
                Return TranslateAlphabetic("l"c, shift, capsLock)

            Case Keys.M
                Return TranslateAlphabetic("m"c, shift, capsLock)

            Case Keys.N
                Return TranslateAlphabetic("n"c, shift, capsLock)

            Case Keys.O
                Return TranslateAlphabetic("o"c, shift, capsLock)

            Case Keys.P
                Return TranslateAlphabetic("p"c, shift, capsLock)

            Case Keys.Q
                Return TranslateAlphabetic("q"c, shift, capsLock)

            Case Keys.R
                Return TranslateAlphabetic("r"c, shift, capsLock)

            Case Keys.S
                Return TranslateAlphabetic("s"c, shift, capsLock)

            Case Keys.T
                Return TranslateAlphabetic("t"c, shift, capsLock)

            Case Keys.U
                Return TranslateAlphabetic("u"c, shift, capsLock)

            Case Keys.V
                Return TranslateAlphabetic("v"c, shift, capsLock)

            Case Keys.W
                Return TranslateAlphabetic("w"c, shift, capsLock)

            Case Keys.X
                Return TranslateAlphabetic("x"c, shift, capsLock)

            Case Keys.Y
                Return TranslateAlphabetic("y"c, shift, capsLock)

            Case Keys.Z
                Return TranslateAlphabetic("z"c, shift, capsLock)


                ' Symbols and left numeric
            Case Keys.D0
                Return If((shift), ")"c, "0"c)

            Case Keys.D1
                Return If((shift), "!"c, "1"c)

            Case Keys.D2
                Return If((shift), "@"c, "2"c)

            Case Keys.D3
                Return If((shift), "#"c, "3"c)

            Case Keys.D4
                Return If((shift), "$"c, "4"c)

            Case Keys.D5
                Return If((shift), "%"c, "5"c)

            Case Keys.D6
                Return If((shift), "^"c, "6"c)

            Case Keys.D7
                Return If((shift), "&"c, "7"c)

            Case Keys.D8
                Return If((shift), "*"c, "8"c)

            Case Keys.D9
                Return If((shift), "("c, "9"c)


                ' numpad math
            Case Keys.Add
                Return "+"c

            Case Keys.Divide
                Return "/"c

            Case Keys.Multiply
                Return "*"c

            Case Keys.Subtract
                Return "-"c


                ' White space
            Case Keys.Space
                Return " "c

                ' Case Keys.Tab
                'Return ControlChars.Tab


                ' Numpad
            Case Keys.[Decimal]
                If numLock AndAlso Not shift Then
                    Return "."c
                End If
                Exit Select

            Case Keys.NumPad0
                If numLock AndAlso Not shift Then
                    Return "0"c
                End If
                Exit Select

            Case Keys.NumPad1
                If numLock AndAlso Not shift Then
                    Return "1"c
                End If
                Exit Select

            Case Keys.NumPad2
                If numLock AndAlso Not shift Then
                    Return "2"c
                End If
                Exit Select

            Case Keys.NumPad3
                If numLock AndAlso Not shift Then
                    Return "3"c
                End If
                Exit Select

            Case Keys.NumPad4
                If numLock AndAlso Not shift Then
                    Return "4"c
                End If
                Exit Select

            Case Keys.NumPad5
                If numLock AndAlso Not shift Then
                    Return "5"c
                End If
                Exit Select

            Case Keys.NumPad6
                If numLock AndAlso Not shift Then
                    Return "6"c
                End If
                Exit Select

            Case Keys.NumPad7
                If numLock AndAlso Not shift Then
                    Return "7"c
                End If
                Exit Select

            Case Keys.NumPad8
                If numLock AndAlso Not shift Then
                    Return "8"c
                End If
                Exit Select

            Case Keys.NumPad9
                If numLock AndAlso Not shift Then
                    Return "9"c
                End If
                Exit Select


                ' Symbols
            Case Keys.OemBackslash
                Return If(shift, "|"c, "\"c)

            Case Keys.OemCloseBrackets
                Return If(shift, "}"c, "]"c)

            Case Keys.OemComma
                Return If(shift, "<"c, ","c)

            Case Keys.OemMinus
                Return If(shift, "_"c, "-"c)

            Case Keys.OemOpenBrackets
                Return If(shift, "{"c, "["c)

            Case Keys.OemPeriod
                Return If(shift, ">"c, "."c)

            Case Keys.OemPipe
                Return If(shift, "|"c, "\"c)

            Case Keys.OemPlus
                Return If(shift, "+"c, "="c)

            Case Keys.OemQuestion
                Return If(shift, "?"c, "/"c)

            Case Keys.OemQuotes
                Return If(shift, """"c, "'"c)

            Case Keys.OemSemicolon
                Return If(shift, ":"c, ";"c)

            Case Keys.OemTilde
                Return If(shift, "~"c, "`"c)
        End Select

        Return ""

    End Function

    Private Shared Function TranslateAlphabetic(baseChar As Char, shift As Boolean, capsLock As Boolean) As Char
        If capsLock = True Then
            If shift = True Then
                Return baseChar
            Else
                Return Char.ToUpper(baseChar)
            End If
        Else
            If shift = True Then
                Return Char.ToUpper(baseChar)
            Else
                Return baseChar
            End If
        End If
    End Function

    Public Shared Function wordWrap(inputString As String, font As SpriteFont, fontScale As Single, lineLength As Integer) As String
        ' Check to see if font is longer than lineLength
        Do Until font.MeasureString(inputString).X * fontScale <= lineLength
            inputString = inputString.Remove(0,1)
        Loop

        Return inputString
    End Function

    Public Shared Function cursorLocation(inputString As String, font As SpriteFont, fontScale As Single, lineLength As Integer, xCord As Integer) As Integer
        ' Check to see if font is longer than lineLength
        Do Until font.MeasureString(inputString).X * fontScale <= lineLength
            inputString = inputString.Remove(0, 1)
        Loop

        Return font.MeasureString(inputString).X * fontScale + xCord
    End Function
End Class
