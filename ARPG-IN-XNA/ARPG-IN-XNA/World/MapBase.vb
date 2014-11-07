Public Class MapBase
    Public TileList(0, 0) As Tile

    Public Sub New(width As Integer, height As Integer, start As Vector2)
        ' ^ height width and start location within the map
        ReDim TileList(width, height)
        ' Temporary Map
        For X = 0 To width
            For Y = 0 To height
                TileList(X, Y) = New Tile
                With TileList(X, Y)
                    .TerrainType = TileType.Water1
                    .TileGFX = Textures.Tileset4
                    .AniFrame = 0
                    .NoWalk = False
                End With
            Next
        Next

        ' Simple Island
        For z = 22 To 33
            For c = 22 To 31
                TileList(z, c).TerrainType = TileType.Grass1
            Next
        Next

        TileList(27, 25).TerrainType = TileType.Barren1
        TileList(30, 28).TerrainType = TileType.Barren1
        TileList(29, 28).TerrainType = TileType.Barren1
        TileList(27, 27).TerrainType = TileType.Barren1
        TileList(27, 27).NoWalk = True

        For x = 0 To width
            For y = 0 To height
                TileList(x, y).SrcRect = GetTileSource(TileList(x, y).TerrainType)
            Next
        Next

    End Sub

    Private Function GetTileSource(TType As TileType) As Rectangle
        Dim xRect As Rectangle
        Select Case TType
            Case TileType.Grass1
                xRect = New Rectangle(8, 56, 8, 8)
            Case TileType.Grass2
                xRect = New Rectangle(8, 64, 8, 8)
            Case TileType.BeachLight
                xRect = New Rectangle(104, 88, 8, 8)
            Case TileType.BeachDark
                xRect = New Rectangle(112, 88, 8, 8)
            Case TileType.DarkWater1
                xRect = New Rectangle(96, 88, 8, 8)
            Case TileType.DarkWater2
                xRect = New Rectangle(96, 96, 8, 8)
            Case TileType.Water1
                xRect = New Rectangle(16, 56, 8, 8)
            Case TileType.Water2
                xRect = New Rectangle(16, 64, 8, 8)
        End Select
        Return xRect
    End Function
End Class
