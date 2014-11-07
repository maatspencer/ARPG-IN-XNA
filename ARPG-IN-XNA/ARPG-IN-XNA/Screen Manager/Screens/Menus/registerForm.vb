Public Class registerForm
    Inherits BaseScreen

    Public Sub New()
        Name = "registerForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        'Dimensions
        Dim X = Globals.GameSize.X / 2 - Textures.registerForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.registerForm.Height / 2
        Dim Width = Textures.registerForm.Width
        Dim Height = Textures.registerForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.registerForm, New Rectangle(X, Y, Width, Height), Color.White)
        ' Cancel
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Register
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
