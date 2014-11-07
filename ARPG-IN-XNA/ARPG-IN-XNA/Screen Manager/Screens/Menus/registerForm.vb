Imports System.IO
Public Class registerForm
    Inherits BaseScreen

    Private ovrCancel As Boolean = False
    Private ovrRegister As Boolean = False
    Public Sub New()
        Name = "registerForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        ' Cancel Button
        If Input.mMapX >= 360 And Input.mMapX <= 425 Then
            If Input.mMapY >= 505 And Input.mMapY <= 525 Then
                ovrCancel = True
                If Input.Click = True Then
                    ScreenManager.UnloadScreen("registerForm")
                    TitleScreen.ovrForm = False
                    ovrCancel = False
                End If
            Else
                ovrCancel = False
            End If
        Else
            ovrCancel = False
        End If

        ' Register Button
        If Input.mMapX >= 460 And Input.mMapX <= 540 Then
            If Input.mMapY >= 505 And Input.mMapY <= 525 Then
                ovrRegister = True
                If Input.Click = True Then
                    ScreenManager.UnloadScreen("registerForm")
                    TitleScreen.ovrForm = False
                    ovrRegister = False
                End If
            Else
                ovrRegister = False
            End If
        Else
            ovrRegister = False
        End If



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
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Register
        If ovrRegister = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
