Public Class LoadingTitle
    Inherits BaseScreen

    Private AniTime As Double = 0
    Private LoadStr As String = ""

    Public Sub New()
        Name = "LoadingTitle"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
    End Sub

    Public Overrides Sub Update()
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime < 1000 Then
            LoadStr = "Loading."
        ElseIf AniTime < 2000 Then
            LoadStr = "Loading.."
        ElseIf AniTime < 3000 Then
            LoadStr = "Loading..."
        Else
            ScreenManager.UnloadScreen("LoadingTitle")
            ScreenManager.AddScreen(New TitleScreen)
            ScreenManager.AddScreen(New MainMenu)
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(0, 537, 800, 40), New Color(97, 97, 97))
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, LoadStr, New Vector2(400 - Fonts.LargeROTMG.MeasureString(LoadStr).X / 2, 557 - Fonts.LargeROTMG.MeasureString(LoadStr).Y / 2), Color.White)
        Globals.SpriteBatch.End()
    End Sub
End Class
