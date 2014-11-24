Imports System.IO
Imports Newtonsoft.Json

Public Class changePasswordForm
    Inherits BaseScreen

    ' Buttons
    Private ovrCancel As Boolean = False
    Private ovrSubmit As Boolean = False

    ' Password
    Private ovrPassword As Boolean = False
    Private passwordActive As Boolean = False
    Private passwordString As String = ""
    Private passwordXCord As Integer = 285
    Private passwordError As Boolean = False

    ' New Password
    Private ovrNew As Boolean = False
    Private newActive As Boolean = False
    Private newString As String = ""
    Private newXcord As Integer = 285
    Private newError As Boolean = False

    ' Retype Password
    Private ovrRetype As Boolean = False
    Private retypeActive As Boolean = False
    Private retypeString As String = ""
    Private retypeXcord As Integer = 285
    Private retypeError As Boolean = False

    ' Cursor Variables
    Private Timer As Integer = 0
    Private drawCur As Boolean = True

    ' Keyboard input
    Public Shared textString As String = ""

    Public Sub New()
        Name = "changePassword"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        ' Handle Text input
        textString = getActiveString()
        textString = textHandler.stringMod(textString)
        setActiveString(textString)

        ' Handle Mouse input
        Dim x = Input.mMapX
        Dim y = Input.mMapY

        ' Cancel Button
        ovrCancel = False
        If x >= 370 And x <= 430 Then
            If y >= 415 And y <= 435 Then
                ovrCancel = True
            End If
        End If

        ' Submit Button
        ovrSubmit = False
        If x >= 458 And x <= 525 Then
            If y >= 415 And y <= 535 Then
                ovrSubmit = True
            End If
        End If

        ' Password Form
        ovrPassword = False
        If x >= 278 And x <= 516 Then
            If y >= 220 And y <= 250 Then
                ovrPassword = True
            End If
        End If

        ' New Password Form
        ovrNew = False
        If x >= 278 And x <= 516 Then
            If y >= 310 And y <= 340 Then
                ovrNew = True
            End If
        End If

        ' Retype Password Form
        ovrRetype = False
        If x >= 278 And x <= 516 Then
            If y >= 310 And y <= 340 Then
                ovrRetype = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then

            ' Submit button
            If ovrSubmit = True Then
                deactivateAll()
                deserializeUserInfo()

                ' Cancel Button
            ElseIf ovrCancel = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("loginForm")
                TitleScreen.ovrForm = False

                ' Password Form
            ElseIf ovrPassword = True Then
                deactivateAll()
                passwordActive = True

                ' Stray Click
            Else
                deactivateAll()
            End If
        End If

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Form Dimensions
        Dim X = Globals.GameSize.X / 2 - Textures.loginForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.loginForm.Height / 2
        Dim Width = Textures.loginForm.Width
        Dim Height = Textures.loginForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.loginForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Error Boxes
        If passwordError = True Then
            Globals.SpriteBatch.Draw(Textures.errorFrameLogin, New Vector2(278, 308), Color.White)
        End If

        ' Animation for Text Cursor
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > Timer Then
            Timer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 500 ' Draw every half of a sec
            drawCur = Not (drawCur)
        End If

        ' Draw Cursor at active location
        If drawCur = True Then ' Toggle cursor on and off
            If passwordActive = True Then
                Dim cursorLocation = textHandler.cursorLocation(passwordString, Fonts.LargeROTMG, 0.9, 215, passwordXCord)
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 312, 2, 18), Color.LightGray)
            End If
        End If

        ' Cancel Button
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.85 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.85 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Sign-In Button
        If ovrSubmit = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Sign in", New Vector2(X + 0.7 * Width, Y + 0.85 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Sign in", New Vector2(X + 0.7 * Width, Y + 0.85 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Password String
        Dim cutString As String = textHandler.wordWrap(passwordString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(passwordXCord, 307), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
    ' Deactive all forms
    Private Sub deactivateAll()
        passwordActive = False
    End Sub
    ' Function to retrieve the string in the active form
    Private Function getActiveString() As String
        If passwordActive = True Then
            Return passwordString
        End If

        Return ""
    End Function
    ' Updates the active sting value after keyboard input
    Private Sub setActiveString(keyboardInput As String)
        If passwordActive = True Then
            passwordString = keyboardInput
        End If
    End Sub
    ' Deserialize userinfo
    Private Sub deserializeUserInfo()

    End Sub
End Class
