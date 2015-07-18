Public Class Parallax
    Inherits BaseScreen
    Private scrollX As Integer = 0

    Public Sub New()
        Name = "Parallax"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()
        ' Adjust Scroll
        scrollX = (scrollX + 1) Mod 1120
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        Globals.SpriteBatch.Draw(Textures.Scrolling, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), New Rectangle(scrollX, 0, 800, 600), Color.White, 0, New Vector2(0, 0), SpriteEffects.None, 1)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
