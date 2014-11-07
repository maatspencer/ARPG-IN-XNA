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
        Globals.SpriteBatch.Draw(Textures.registerForm, New Rectangle(Globals.GameSize.X / 2 - Textures.registerForm.Width / 2, Globals.GameSize.Y / 2 - Textures.registerForm.Height / 2, 327, 507), Color.White)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
