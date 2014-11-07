Public Class WorldScreen
    Inherits BaseScreen

    ' Map Dimensions
    Public Map As MapBase
    Public MapWidth As Integer = 100
    Public MapHeight As Integer = 100
    Public TileSize As Integer = 32

    ' Current Coordinate
    Public MapX As Integer = 20
    Public MapY As Integer = 20

    ' Sprite Sources
    Private sRect As Rectangle

    Public Sub New()
        Name = "WorldScreen"
        Map = New MapBase(MapWidth, MapHeight, New Vector2(0, 0))
    End Sub

    Public Overrides Sub HandleInput()
        If CharoffsetX = 0 And CharoffsetY = 0 And CharMoving = False Then
            If Input.KeyDown(Keys.S) Then
                MoveChar(1, CharScreenX, CharY + 1)
                LastDir = 1
            ElseIf Input.KeyDown(Keys.W) Then
                MoveChar(2, CharScreenX, CharY - 1)
                LastDir = 2
            ElseIf Input.KeyDown(Keys.A) Then
                MoveChar(3, CharScreenX - 1, CharY)
                LastDir = 3
            ElseIf Input.KeyDown(Keys.D) Then
                MoveChar(4, CharScreenX + 1, CharY)
                LastDir = 4
            End If
        End If
    End Sub

    Public Overrides Sub Update()
        ' ***Character Movement Updates***
        MoveTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If MoveTime > 25 And CharMoving = True Then
            If MoveDir = 0 And (CharoffsetX <> 0 Or CharoffsetY <> 0) Then
                ' Complete Move Cycle before accepting new inputs
                Move(LastDir)
            Else
                Move(MoveDir)
            End If

            If CharoffsetX = 0 And CharoffsetY = 0 Then
                CharMoving = False
            End If

            MoveTime = 0
        End If
        ' Update Character Coordinates
        CharX = MapX + CharScreenX
        CharY = MapY + CharScreenY

        ' ***End Character Movement Updates***
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        'Draw Tile Layer
        For DrawX = -1 To 16
            For DrawY = -1 To 15
                Dim x As Integer = DrawX + MapX
                Dim y As Integer = DrawY + MapY

                If x >= 0 And x <= MapWidth And y >= 0 And y <= MapHeight Then
                    Globals.SpriteBatch.Draw(Map.TileList(x, y).TileGFX, New Rectangle(DrawX * TileSize + CharoffsetX, DrawY * TileSize + CharoffsetY, TileSize, TileSize), Map.TileList(x, y).SrcRect, Color.White)
                    ' View Coordinates On Tile to Test Tile Locations
                    ' Globals.SpriteBatch.DrawString(Fonts.Arial_8, "X: " & x & vbCrLf & "Y: " & y, New Vector2(DrawX * TileSize, DrawY * TileSize), Color.Black)
                End If
            Next
        Next

        ' Draw Character
        If LastDir = 3 Then
            Globals.SpriteBatch.Draw(Textures.Classes, New Rectangle(CharScreenX * 32, CharScreenY * 32, 32, 32), FetchSpriteSrc(LastDir), Color.White, 0, New Vector2(0, 0), SpriteEffects.FlipHorizontally, 0)
        Else
            Globals.SpriteBatch.Draw(Textures.Classes, New Rectangle(CharScreenX * 32, CharScreenY * 32, 32, 32), FetchSpriteSrc(LastDir), Color.White)
        End If
        Globals.SpriteBatch.End()
    End Sub
End Class
