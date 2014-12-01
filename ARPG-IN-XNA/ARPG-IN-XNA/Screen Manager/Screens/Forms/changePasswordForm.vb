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
        If x >= 372 And x <= 430 Then
            If y >= 474 And y <= 492 Then
                ovrCancel = True
            End If
        End If

        ' Submit Button
        ovrSubmit = False
        If x >= 457 And x <= 521 Then
            If y >= 476 And y <= 491 Then
                ovrSubmit = True
            End If
        End If

        ' Password Form
        ovrPassword = False
        If x >= 277 And x <= 517 Then
            If y >= 217 And y <= 250 Then
                ovrPassword = True
            End If
        End If

        ' New Password Form
        ovrNew = False
        If x >= 277 And x <= 517 Then
            If y >= 305 And y <= 338 Then
                ovrNew = True
            End If
        End If

        ' Retype Password Form
        ovrRetype = False
        If x >= 277 And x <= 517 Then
            If y >= 394 And y <= 427 Then
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
                ScreenManager.UnloadScreen("changePassword")
                TitleScreen.ovrForm = False

                ' Password Form
            ElseIf ovrPassword = True Then
                deactivateAll()
                passwordActive = True

            ElseIf ovrNew = True Then
                deactivateAll()
                newActive = True

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
        Dim X = Globals.GameSize.X / 2 - Textures.loginForm.Width / 2
        Dim Y = Globals.GameSize.Y / 2 - Textures.loginForm.Height / 2
        Dim Width = Textures.changePasswordForm.Width
        Dim Height = Textures.changePasswordForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.changePasswordForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Error Boxes
        If passwordError = True Then
            Globals.SpriteBatch.Draw(Textures.errorFrameLogin, New Vector2(277, 217), Color.White)
        End If
        If newError = True Then
            Globals.SpriteBatch.Draw(Textures.errorFrameLogin, New Vector2(277, 305), Color.White)
        End If
        If retypeError = True Then
            Globals.SpriteBatch.Draw(Textures.errorFrameLogin, New Vector2(277, 394), Color.White)
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
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 225, 2, 18), Color.LightGray)
            End If
            If newActive = True Then
                Dim cursorLocation = textHandler.cursorLocation(newString, Fonts.LargeROTMG, 0.9, 215, newXcord)
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 312, 2, 18), Color.LightGray)
            End If
            If retypeActive = True Then
                Dim cursorLocation = textHandler.cursorLocation(retypeString, Fonts.LargeROTMG, 0.9, 215, retypeXcord)
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(cursorLocation, 401, 2, 18), Color.LightGray)
            End If
        End If

        ' Cancel Button
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.9 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Submit Button
        If ovrSubmit = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Submit", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Submit", New Vector2(X + 0.7 * Width, Y + 0.9 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Password String
        Dim cutString As String = textHandler.wordWrap(passwordString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(passwordXCord, 220), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' New Password String
        cutString = textHandler.wordWrap(newString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(newXcord, 307), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' Retype Password String
        cutString = textHandler.wordWrap(retypeString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(retypeXcord, 396), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
    ' Deactive all forms
    Private Sub deactivateAll()
        passwordActive = False
        newActive = False
        retypeActive = False
    End Sub
    ' Function to retrieve the string in the active form
    Private Function getActiveString() As String
        If passwordActive = True Then
            Return passwordString
        End If

        If newActive = True Then
            Return newString
        End If

        If retypeActive = True Then
            Return retypeString
        End If

        Return ""
    End Function
    ' Updates the active sting value after keyboard input
    Private Sub setActiveString(keyboardInput As String)
        If passwordActive = True Then
            passwordString = keyboardInput
        End If

        If newActive = True Then
            newString = keyboardInput
        End If

        If retypeActive = True Then
            retypeString = keyboardInput
        End If
    End Sub
    ' Deserialize userinfo
    Private Sub deserializeUserInfo()
        Dim allPassed As Boolean = True

        ' deserialize JSON
        Dim data As New userInfo
        Using stream As StreamReader = File.OpenText(My.Application.Info.DirectoryPath & "/accounts/" & Parameters.userInfo.email & ".json")
            Dim serializer As New JsonSerializer()
            data = serializer.Deserialize(stream, GetType(userInfo))
        End Using

        ' Check to see if passwords match
        passwordError = False
        If Not data.password = passwordString Then
            passwordError = True
            allPassed = False
        End If

        ' Check new password length
        newError = False
        If newString.Length < 5 Then
            newError = True
            allPassed = False
        End If

        ' Check to see if new passwords match
        retypeError = False
        If Not newString = retypeString Then
            retypeError = True
            allPassed = False
        End If

        ' Success
        If allPassed = True Then
            ' Serialize new password
            data.password = newString
            serializeObject.userInfo(data)

            ' Update Globals
            Parameters.userInfo.password = data.password

            ' close form
            ScreenManager.UnloadScreen("changePassword")
            TitleScreen.ovrForm = False
        End If

    End Sub
End Class
