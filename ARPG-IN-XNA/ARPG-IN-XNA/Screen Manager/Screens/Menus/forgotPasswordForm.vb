Imports System
Imports System.IO
Imports System.Net.Mail
Imports System.Threading
Imports Newtonsoft.Json
Imports System.Net

Public Class forgotPassword
    Inherits BaseScreen

    ' Buttons
    Private ovrCancel As Boolean = False
    Private ovrSubmit As Boolean = False

    ' Email
    Private ovrEmail As Boolean = False
    Private emailActive As Boolean = True
    Private emailString As String = ""
    Private emailXCord As Integer = 285
    Private emailError As Boolean = False

    ' Links
    Private ovrNewUser As Boolean = False

    ' Cursor Variables
    Private Timer As Integer = 0
    Private drawCur As Boolean = True

    ' Keyboard input
    Public Shared textString As String = ""

    ' Threading for email
    Private trd As Thread
    Private data As userInfo

    Public Sub New()
        Name = "forgotPassword"
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
            If y >= 312 And y <= 332 Then
                ovrCancel = True
            End If
        End If

        ' Submit Button
        ovrSubmit = False
        If x >= 457 And x <= 523 Then
            If y >= 312 And y <= 332 Then
                ovrSubmit = True
            End If
        End If

        ' Email Form
        ovrEmail = False
        If x >= 278 And x <= 516 Then
            If y >= 216 And y <= 250 Then
                ovrEmail = True
            End If
        End If

        ' New user link
        ovrNewUser = False
        If x >= 282 And x <= 442 Then
            If y >= 268 And y <= 281 Then
                ovrNewUser = True
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
                ScreenManager.UnloadScreen("forgotPassword")
                TitleScreen.ovrForm = False

                ' Email Form
            ElseIf ovrEmail = True Then
                deactivateAll()
                emailActive = True

                ' New user Link
            ElseIf ovrNewUser = True Then
                deactivateAll()
                ScreenManager.UnloadScreen("forgotPassword")
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
        Dim Width = Textures.forgotPasswordForm.Width
        Dim Height = Textures.forgotPasswordForm.Height

        ' Main Form
        Globals.SpriteBatch.Draw(Textures.forgotPasswordForm, New Rectangle(X, Y, Width, Height), Color.White)

        ' Error Boxes
        If emailError = True Then
            Globals.SpriteBatch.Draw(Textures.errorFrameLogin, New Vector2(278, 218), Color.White)
        End If

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
        End If

        ' Cancel Button
        If ovrCancel = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.8 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Cancel", New Vector2(X + 0.4 * Width, Y + 0.8 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If

        ' Submit Button
        If ovrSubmit = False Then
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Submit", New Vector2(X + 0.7 * Width, Y + 0.8 * Height), Color.White, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, "Submit", New Vector2(X + 0.7 * Width, Y + 0.8 * Height), Color.LightBlue, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)
        End If


        ' Email String
        Dim cutString As String = textHandler.wordWrap(emailString, Fonts.LargeROTMG, 0.9, 215)
        Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, cutString, New Vector2(emailXCord, 220), Color.Gray, 0, New Vector2(0, 0), 0.9, SpriteEffects.None, 0)

        ' New User Link
        If ovrNewUser = True Then
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "New user? Click here to Register", New Vector2(278, Y + 0.6 * Height), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.Arial_8, "New user? Click here to Register", New Vector2(278, Y + 0.6 * Height), Color.LightGray, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
    ' Deactive all forms
    Private Sub deactivateAll()
        emailActive = False
    End Sub
    ' Function to retrieve the string in the active form
    Private Function getActiveString() As String
        If emailActive = True Then
            Return emailString
        End If

        Return ""
    End Function
    ' Updates the active sting value after keyboard input
    Private Sub setActiveString(keyboardInput As String)
        If emailActive = True Then
            emailString = keyboardInput
        End If
    End Sub
    ' Deserialize userinfo
    Private Sub deserializeUserInfo()
        ' Check to see if the JSON Exists
        If Not My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "/accounts/" & emailString & ".json") Then
            emailError = True
            Exit Sub
        End If

        ' deserialize JSON
        Using stream As StreamReader = File.OpenText(My.Application.Info.DirectoryPath & "/accounts/" & emailString & ".json")
            Dim serializer As New JsonSerializer()
            data = serializer.Deserialize(stream, GetType(userInfo))
        End Using

        ' Send Email
        trd = New Thread(AddressOf SendMail)
        trd.IsBackground = True
        trd.Start()

        ScreenManager.UnloadScreen("forgotPassword")
        TitleScreen.ovrForm = False
    End Sub
    Private Sub SendMail()
        ' SMTP options
        Dim Host As String = "smtp.gmail.com"
        Dim Port As Int16 = 587
        Dim SSL As Boolean = True
        Dim Username As String = "arpg.in.xna@gmail.com"
        Dim Password As String = "Civilengineering#1"

        ' Mail options
        Dim [To] As String = emailString
        Dim From As String = "arpg.in.xna@gmail.com"
        Dim Subject As String = "ARPG-IN-XNA"
        Dim Body As String = "email: " & data.email & vbNewLine & "password: " & data.password
        Dim mm As New MailMessage(From, [To], Subject, Body)

        ' Send Async
        Dim sc As SmtpClient = New SmtpClient(Host, Port)
        sc.EnableSsl = SSL
        sc.UseDefaultCredentials = False
        Dim netCred As New NetworkCredential(Username, Password)
        sc.Credentials = netCred
        sc.Send(mm)

        trd.Abort()
    End Sub
End Class
