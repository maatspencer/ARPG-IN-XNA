Public Class Fonts
    Public Shared Arial_8 As SpriteFont
    Public Shared Georgia_16 As SpriteFont
    Public Shared WascoSans_16 As SpriteFont
    Public Shared WascoSans_12 As SpriteFont

    Public Shared Sub Load()
        Arial_8 = Globals.Content.Load(Of SpriteFont)("Fonts/Arial")
        WascoSans_16 = Globals.Content.Load(Of SpriteFont)("Fonts/WascoSansBold")
        WascoSans_12 = Globals.Content.Load(Of SpriteFont)("Fonts/WascoSans")
    End Sub
End Class
