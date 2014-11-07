Public Class Fonts
    Public Shared Arial_8 As SpriteFont
    Public Shared Georgia_16 As SpriteFont
    Public Shared LargeROTMG As SpriteFont
    Public Shared SmallROTMG As SpriteFont

    Public Shared Sub Load()
        Georgia_16 = Globals.Content.Load(Of SpriteFont)("Fonts/Georgia")
        Arial_8 = Globals.Content.Load(Of SpriteFont)("Fonts/Arial")
        LargeROTMG = Globals.Content.Load(Of SpriteFont)("Fonts/LargeROTMG")
        SmallROTMG = Globals.Content.Load(Of SpriteFont)("Fonts/SmallROTMG")
    End Sub
End Class
