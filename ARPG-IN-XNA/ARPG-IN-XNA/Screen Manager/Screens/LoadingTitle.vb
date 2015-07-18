Imports System.Threading
Imports System.Windows.Forms

Public Class LoadingTitle
    Inherits BaseScreen

    Private AniTime As Double = 0
    Private LoadStr As String = ""
    Private trd As Thread

    Public Sub New()
        Name = "LoadingTitle"
        State = ScreenState.Active

        trd = New Thread(AddressOf Events.load)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Public Overrides Sub HandleInput()
    End Sub

    Public Overrides Sub Update()
        AniTime = (AniTime + 1) Mod 300
        If Not Events.loadFinished = True Then
            If AniTime < 50 Then
                LoadStr = "Loading."
            ElseIf AniTime < 100 Then
                LoadStr = "Loading.."
            ElseIf AniTime < 150 Then
                LoadStr = "Loading..."
            ElseIf AniTime < 200 Then
                LoadStr = "Loading...."
            ElseIf AniTime < 250 Then
                LoadStr = "Loading....."
            Else
                LoadStr = "Loading......"
            End If
        Else
            trd.Abort()
            ScreenManager.UnloadScreen("LoadingTitle")
            ScreenManager.AddScreen(New TitleScreen)
            ScreenManager.AddScreen(New MainMenu)
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(0, 537, 800, 40), New Color(97, 97, 97) * Textures.formOpacity)
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, LoadStr, New Vector2(400 - Fonts.WascoSans_16.MeasureString(LoadStr).X / 2, 557 - Fonts.WascoSans_16.MeasureString(LoadStr).Y / 2), Color.White)
        Globals.SpriteBatch.End()
    End Sub
End Class
