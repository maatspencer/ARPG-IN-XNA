Public Class ClassSelection
    Inherits BaseScreen

    Public Sub New()
        Name = "ClassSelection"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
