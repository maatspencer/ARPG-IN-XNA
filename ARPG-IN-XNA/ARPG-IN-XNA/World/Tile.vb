Public Enum TileType
    Grass1
    Grass2
    Water1
    Water2
    DarkWater1
    DarkWater2
    Snowy1
    Snowy2
    Snowy3
    Snowy4
    BeachLight
    BeachDark
    Barren1
    Barren2
    Lava1
    Lava2
    FireStone1
    FireStone2
End Enum

Public Structure Tile
    Public Property TerrainType As TileType
    Public Property TileGFX As Texture2D
    Public Property SrcRect As Rectangle
    Public Property Location As Vector2
    Public Property AniFrame As Integer

    ' Tile Actions
    Public Property IsActivated As Boolean
    Public Property NoWalk As Boolean
    Public Property IsStatic As Boolean
    Public Property IsTouchTrigger As Boolean
    Public Property IsStepTrigger As Boolean

End Structure
