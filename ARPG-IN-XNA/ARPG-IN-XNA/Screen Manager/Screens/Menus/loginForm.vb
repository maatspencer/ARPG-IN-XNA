Public Class loginForm
    Inherits BaseScreen

    ' Buttons
    Private ovrCancel As Boolean = False
    Private ovrSignIn As Boolean = False

    ' Email
    Private ovrEmail As Boolean = False
    Private emailActive As Boolean = True
    Private emailString As String = ""
    Private emailXCord As Integer = 285

    ' Password
    Private ovrPassword As Boolean = False
    Private passwordActive As Boolean = False
    Private passwordString As String = ""
    Private passwordXCord As Integer = 285

    ' Links
    Private ovrNewUser As Boolean = False
    Private ovrForgot As Boolean = False

    ' Cursor Variables
    Private Timer As Integer = 0
    Private drawCur As Boolean = True

    ' Keyboard input
    Public Shared textString As String = ""

    Public Sub New()
        Name = "loginForm"
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

        ' Sign-In Button
        ovrSignIn = False
        If x >= 458 And x <= 525 Then
            If y >= 415 And y <= 535 Then
                ovrSignIn = True
            End If
        End If

        ' Email Form
        ovrEmail = False
        If x >= 278 And x <= 516 Then
            If y >= 220 And y <= 250 Then
                ovrEmail = True
            End If
        End If

        ' Password Form
        ovrPassword = False
        If x >= 278 And x <= 516 Then
            If y >= 310 And y <= 340 Then
                ovrPassword = True
            End If
        End If

        ' Forgot Link
        ovrForgot = False
        If x >= 278 And x <= 442 Then
            If y >= 360 And y <= 370 Then
                ovrForgot = True
            End If
        End If

        ' New user link
        ovrNewUser = False
        If x >= 278 And x <= 435 Then
            If y >= 380 And y <= 390 Then
                ovrNewUser = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then

            ' Register button
            If ovrSignIn = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("loginForm")
                TitleScreen.ovrForm = False

                ' Cancel Button
            ElseIf ovrCancel = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("loginForm")
                TitleScreen.ovrForm = False

                ' Email Form
            ElseIf ovrEmail = True Then
                deactivateAll()
                emailActive = True

                ' Password Form
            ElseIf ovrPassword = True Then
                deactivateAll()
                passwordActive = True

                ' Forgot link
            ElseIf ovrForgot = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("loginForm")
                ScreenManager.AddScreen(New forgotPassword)

                ' Cancel Button
            ElseIf ovrNewUser = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("loginForm")
                ScreenManager.AddScreen(New registerForm)

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

        ' Animation for Text Cursor
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > Timer Then
            Timer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 500 ' Draw every half of a sec
            drawCur = Not (drawCur)
        End If

        ' Draw Cursor at active location
        If drawCur = True Then ' Toggle cursor on and off
            If emailActive = True Then
                Dim cursorLocation = textHandler.cursorLocation(emailString, Fonts.LargeROTMG, 0.9, 215, emailXCord)
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 225, 2, 18), Color.LightGray)
            End If
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
        If ovrSignIn = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Sign in", New Vector2(X + 0.7 * Width, Y + 0.85 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Sign in", New Vector2(X + 0.7 * Width, Y + 0.85 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If


        ' Email String
        Dim cutString As String = textHandler.wordWrap(emailString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(emailXCord, 220), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Password String
        cutString = textHandler.wordWrap(passwordString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(passwordXCord, 307), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Forgot password
        If ovrForgot = True Then
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Forgot your password? Click here", New Vector2(278, 360), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "Forgot your password? Click here", New Vector2(278, 360), Color.LightGray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If

        ' New User
        If ovrNewUser = True Then
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "New user? Click here to Register", New Vector2(278, 380), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "New user? Click here to Register", New Vector2(278, 380), Color.LightGray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub

    Private Sub deactivateAll()
        emailActive = False
        passwordActive = False
    End Sub

    Private Function getActiveString() As String
        If emailActive = True Then
            Return emailString
        End If
        If passwordActive = True Then
            Return passwordString
        End If

        Return ""
    End Function
    Private Sub setActiveString(keyboardInput As String)
        If emailActive = True Then
            emailString = keyboardInput
        End If
        If passwordActive = True Then
            passwordString = keyboardInput
        End If
    End Sub
End Class
