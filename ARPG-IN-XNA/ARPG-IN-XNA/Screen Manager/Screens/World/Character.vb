Partial Public Class WorldScreen
    ' Screen Position For Moving Map Rather Than Character
    Public CharScreenX As Integer = 12
    Public CharScreenY As Integer = 9

    ' Char's Map Coordinates
    Public CharX As Integer = 0
    Public CharY As Integer = 0

    ' Char's Map Offset for smooth walking
    Public CharoffsetX As Integer = 0
    Public CharoffsetY As Integer = 0

    ' Movement
    Public CharMoving As Boolean = True
    Public MoveTime As Double = 0
    Public MoveSpeed As Integer = 3
    Public MoveDir As Integer = 0
    Public LastDir As Integer = 1

    Private CharFrame As Integer = 1

    Public Sub Move(dir As Integer)
        MoveDir = dir

        Select Case dir
            Case 1 ' Down
                CharoffsetY -= MoveSpeed

                If CharoffsetY <= -32 Then
                    MapY += 1
                    CharoffsetY = 0
                End If
            Case 2 ' Up
                CharoffsetY += MoveSpeed

                If CharoffsetY >= 32 Then
                    MapY -= 1
                    CharoffsetY = 0
                End If
            Case 3 ' Left
                CharoffsetX += MoveSpeed

                If CharoffsetX >= 32 Then
                    MapX -= 1
                    CharoffsetX = 0
                End If
            Case 4 ' Right
                CharoffsetX -= MoveSpeed

                If CharoffsetX <= -32 Then
                    MapX += 1
                    CharoffsetX = 0
                End If
        End Select

        If dir = 1 Or dir = 2 Then
            If CharoffsetX <> 0 Then
                If Math.Abs(CharoffsetX) < 16 Then
                    CharFrame = 1
                Else
                    CharFrame = 2
                End If
            ElseIf CharoffsetY <> 0 Then
                If Math.Abs(CharoffsetY) < 16 Then
                    CharFrame = 1
                Else
                    CharFrame = 2
                End If
            Else
                CharFrame = 0
            End If
        Else
            If CharoffsetX <> 0 Then
                If Math.Abs(CharoffsetX) < 16 Then
                    CharFrame = 1
                Else
                    CharFrame = 0
                End If
            ElseIf CharoffsetY <> 0 Then
                If Math.Abs(CharoffsetY) < 16 Then
                    CharFrame = 1
                Else
                    CharFrame = 0
                End If
            Else
                CharFrame = 0
            End If
            End If

        If MoveDir <> 0 Then
            LastDir = dir
        End If
    End Sub

    Public Sub MoveChar(dir As Integer, CharX As Integer, CharY As Integer)
        If Map.TileList(CharX, CharY).NoWalk = False Then
            MoveDir = dir
            CharMoving = True
        Else
            CharMoving = False
        End If
    End Sub

    Private Function FetchSpriteSrc(dir As Integer) As Rectangle
        ' Integer Value to set class
        Dim ClassId As Integer = Information.ClassId
        Select Case dir
            Case 1 ' Down
                sRect = New Rectangle(CharFrame * 8, 8 + (ClassId * 24), 8, 8)
            Case 2 ' Up
                sRect = New Rectangle(CharFrame * 8, 16 + (ClassId * 24), 8, 8)
            Case 3 ' Left
                sRect = New Rectangle(CharFrame * 8, 0 + (ClassId * 24), 8, 8)
            Case 4 ' Right
                sRect = New Rectangle(CharFrame * 8, 0 + (ClassId * 24), 8, 8)
        End Select

        Return sRect
    End Function

End Class
