Imports System
Imports System.IO
Imports System.Net.Mail
Imports System.Threading
Imports Newtonsoft.Json
Imports System.Net

Public Class accountForm
    Inherits BaseScreen

    ' Buttons
    Private ovrContinue As Boolean = False

    ' Links
    Private ovrNotYou As Boolean = False
    Private ovrChangePassword As Boolean = False



    Public Sub New()
        Name = "accountForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()

        ' Handle Mouse input
        Dim x = Input.mMapX
        Dim y = Input.mMapY

        ' Continue Button
        ovrContinue = False
        If x >= 440 And x <= 525 Then
            If y >= 339 And y <= 360 Then
                ovrContinue = True
            End If
        End If

        ' Not you Link
        ovrNotYou = False
        If x >= 274 And x <= 375 Then
            If y >= 300 And y <= 315 Then
                ovrNotYou = True
            End If
        End If

        ' Change password Link
        ovrChangePassword = False
        If x >= 274 And x <= 428 Then
            If y >= 280 And y <= 295 Then
                ovrChangePassword = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then

            ' Submit button
            If ovrContinue = True Then
                ScreenManager.UnloadScreen("accountForm")
                TitleScreen.ovrForm = False

                ' Not You Link
            ElseIf ovrNotYou = True Then
                ScreenManager.UnloadScreen("accountForm")
                TitleScreen.ovrForm = False
                TitleScreen.logout()

                ' Not You Link
            ElseIf ovrChangePassword = True Then
                ScreenManager.UnloadScreen("accountForm")
                ScreenManager.AddScreen(New changePasswordForm)
            End If
        End If

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Form Dimensions
        Dim X = Globals.GameSize.X / 2 - Textures.loginForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.loginForm.Height / 2
        Dim Width = Textures.currentAccountForm.Width
        Dim Height = Textures.currentAccountForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.currentAccountForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Continue Button
        If ovrContinue = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Continue", New Vector2(X + 0.65 * Width, Y + 0.85 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Continue", New Vector2(X + 0.65 * Width, Y + 0.85 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Change Password Link
        If ovrChangePassword = True Then
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Click here to change password", New Vector2(278, Y + 0.6 * Height), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Click here to change password", New Vector2(278, Y + 0.6 * Height), Color.LightGray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If

        ' Not You Link
        If ovrNotYou = True Then
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Not you? Click here", New Vector2(278, Y + 0.7 * Height), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Not you? Click here", New Vector2(278, Y + 0.7 * Height), Color.LightGray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If

        ' Logged in as
        Dim scale As Single = 250 / Fonts.LargeROTMG.MeasureString(Parameters.userInfo.userEmail).X ' Email always drawn at 250 pixels
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, Parameters.userInfo.userEmail, New Vector2(278, Y + 0.3 * Height), Color.LightGray, 0, New Vector2(0, 0), scale, SpriteEffects.None, 1)


        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
