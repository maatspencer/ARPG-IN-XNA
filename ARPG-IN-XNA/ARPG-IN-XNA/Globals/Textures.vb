Public Class Textures
    'General
    Public Shared WhiteSquare As Texture2D
    Public Shared Icons As Texture2D

    'Forms
    Public Shared registerForm As Texture2D
    Public Shared loginForm As Texture2D
    Public Shared forgotPasswordForm As Texture2D

    'Title Screen
    Public Shared Scrolling As Texture2D
    Public Shared TitleScreen As Texture2D
    Public Shared BlankStar As Texture2D
    Public Shared StarsMenu As Texture2D
    Public Shared TransStarMenu As Texture2D

    'Tiles
    Public Shared Tileset1 As Texture2D
    Public Shared Tileset2 As Texture2D
    Public Shared Tileset3 As Texture2D
    Public Shared Tileset4 As Texture2D

    'Character Sprites
    Public Shared Classes As Texture2D

    Public Shared Sub Load()
        'General
        WhiteSquare = Globals.Content.Load(Of Texture2D)("GFX/General/WhiteSquare")
        Icons = Globals.Content.Load(Of Texture2D)("GFX/General/Icons")

        'Forms
        loginForm = Globals.Content.Load(Of Texture2D)("GFX/Forms/loginForm")
        registerForm = Globals.Content.Load(Of Texture2D)("GFX/Forms/registerForm")
        forgotPasswordForm = Globals.Content.Load(Of Texture2D)("GFX/Forms/forgotPasswordForm")

        'Title Screen
        Scrolling = Globals.Content.Load(Of Texture2D)("GFX/TitleScreen/Scrolling")
        TitleScreen = Globals.Content.Load(Of Texture2D)("GFX/TitleScreen/TitleScreen")
        BlankStar = Globals.Content.Load(Of Texture2D)("GFX/TitleScreen/BlankStar")
        StarsMenu = Globals.Content.Load(Of Texture2D)("GFX/TitleScreen/StarsMenu")
        TransStarMenu = Globals.Content.Load(Of Texture2D)("GFX/TitleScreen/TransStarMenu")

        'Tiles
        Tileset1 = Globals.Content.Load(Of Texture2D)("GFX/World/Tile1")
        Tileset2 = Globals.Content.Load(Of Texture2D)("GFX/World/Tile2")
        Tileset3 = Globals.Content.Load(Of Texture2D)("GFX/World/Tile3")
        Tileset4 = Globals.Content.Load(Of Texture2D)("GFX/World/Tile4")

        'Character Sprites
        Classes = Globals.Content.Load(Of Texture2D)("GFX/Classes/Classes")
    End Sub
End Class
