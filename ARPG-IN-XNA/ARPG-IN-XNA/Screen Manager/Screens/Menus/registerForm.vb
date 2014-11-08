Imports System.IO
Public Class registerForm
    Inherits BaseScreen

    ' Buttons
    Private ovrCancel As Boolean = False
    Private ovrRegister As Boolean = False

    ' DOB
    Private ovrMonth As Boolean = False
    Private monthEmpty As Boolean = True
    Private monthActive As Boolean = False
    Private monthString As String = ""
    Private monthXCord As Integer = 265

    Private ovrDay As Boolean = False
    Private dayEmpty As Boolean = True
    Private dayActive As Boolean = False
    Private dayString As String = ""
    Private dayXCord As Integer

    Private ovrYear As Boolean = False
    Private yearEmpty As Boolean = True
    Private yearActive As Boolean = False
    Private yearString As String = ""
    Private yearXCord As Integer

    ' Email
    Private ovrEmail As Boolean = False
    Private emailActive As Boolean = False
    Private emailString As String
    Private emailXCord As Integer = 265

    ' Password
    Private ovrPassword As Boolean = False
    Private passwordActive As Boolean = False
    Private passwordString As String
    Private passwordXCord As Integer = 265

    ' Retype Password
    Private ovrRetype As Boolean = False
    Private retypeActive As Boolean = False
    Private retypeString As String
    Private retypeXCord As Integer = 265

    ' Offers
    Private ovrOffers As Boolean = False
    Private offersClicked As Boolean = False

    ' Cursor Variables
    Dim Timer As Integer = 0
    Dim drawCur As Boolean = True


    Public Sub New()
        Name = "registerForm"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        Dim x = Input.mMapX
        Dim y = Input.mMapY

        ' Cancel Button
        ovrCancel = False
        If x >= 360 And x <= 425 Then
            If y >= 505 And y <= 525 Then
                ovrCancel = True
            End If
        End If

        ' Register Button
        ovrRegister = False
        If x >= 460 And x <= 540 Then
            If y >= 505 And y <= 525 Then
                ovrRegister = True
            End If
        End If

        ' Email Form
        ovrEmail = False
        If x >= 260 And x <= 535 Then
            If y >= 123 And y <= 153 Then
                ovrEmail = True
            End If
        End If

        ' Password Form
        ovrPassword = False
        If x >= 260 And x <= 535 Then
            If y >= 191 And y <= 221 Then
                ovrPassword = True
            End If
        End If

        ' Retype Password Form
        ovrRetype = False
        If x >= 260 And x <= 535 Then
            If y >= 260 And y <= 290 Then
                ovrRetype = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then

            ' Register button
            If ovrRegister = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("registerForm")
                TitleScreen.ovrForm = False

                ' Cancel Button
            ElseIf ovrCancel = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("registerForm")
                TitleScreen.ovrForm = False

                ' Email Form
            ElseIf ovrEmail = True Then
                deactivateAll()
                emailActive = True

                ' Password Form
            ElseIf ovrPassword = True Then
                deactivateAll()
                passwordActive = True

                ' Retype Form
            ElseIf ovrRetype = True Then
                deactivateAll()
                retypeActive = True

                ' Stray Click
            Else
                deactivateAll()
            End If
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Form Dimensions
        Dim X = Globals.GameSize.X / 2 - Textures.registerForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.registerForm.Height / 2
        Dim Width = Textures.registerForm.Width
        Dim Height = Textures.registerForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.registerForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Animation for Text Cursor
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > Timer Then
            Timer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 500 ' Draw every half of a sec
            If drawCur = True Then
                drawCur = False
            Else
                drawCur = True
            End If
        End If

        ' Draw Cursor at active location
        If drawCur = True Then ' Toggle cursor on and off
            If emailActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(emailXCord, 130, 2, 15), Color.LightGray)
            End If
            If passwordActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(passwordXCord, 195, 2, 15), Color.LightGray)
            End If
            If retypeActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(retypeXCord, 265, 2, 15), Color.LightGray)
            End If
            If monthActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(262, 325, 2, 15), Color.LightGray)
            End If
            If dayActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(320, 325, 2, 15), Color.LightGray)
            End If
            If yearActive = True Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(372, 325, 2, 15), Color.LightGray)
            End If
        End If

        ' Cancel Button
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Register Button
        If ovrRegister = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Register", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.LightGoldenrodYellow, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Day/Month/Year Place Holders
        If monthString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "MM", New Vector2(X + 25, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If
        If dayString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "DD", New Vector2(X + 85, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If
        If yearString = "" Then
            Globals.SpriteBatch.DrawString(Fonts.SmallROTMG, "YYYY", New Vector2(X + 140, Y + 280), Color.Gray, 0, New Vector2(0, 0), 1.3, SpriteEffects.None, 0)
        End If

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub

    Private Sub deactivateAll()
        monthActive = False
        dayActive = False
        yearActive = False
        emailActive = False
        passwordActive = False
        retypeActive = False
    End Sub
End Class
