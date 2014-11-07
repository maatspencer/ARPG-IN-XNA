Public Class forgotPassword
    Inherits BaseScreen

    Public Sub New()
        Name = "forgotPassword"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.forgotPasswordForm, New Rectangle(Globals.GameSize.X / 2 - Textures.forgotPasswordForm.Width / 2, Globals.GameSize.Y / 2 - Textures.forgotPasswordForm.Height / 2, 289, 209), Color.White)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
