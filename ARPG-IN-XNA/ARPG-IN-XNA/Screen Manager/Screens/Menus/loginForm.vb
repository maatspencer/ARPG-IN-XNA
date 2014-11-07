Public Class loginForm
    Inherits BaseScreen

    Public Sub New()
        Name = "loginForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.loginForm, New Rectangle(Globals.GameSize.X / 2 - Textures.loginForm.Width / 2, Globals.GameSize.Y / 2 - Textures.loginForm.Height / 2, 289, 317), Color.White)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
