Public Class TitleScreen
    Inherits BaseScreen
    Private SoundOn As New Rectangle(48, 0, 16, 16)
    Private SoundOff As New Rectangle(64, 0, 16, 16)
    Private SoundToggle As Boolean = True
    Private SoundIcon As New Rectangle(48, 0, 16, 16)
    Private guildIcon As New Rectangle(16 * Parameters.userinfo.guildRank, 16, 16, 16)
    Private DrawStars As Boolean = False
    Private ovrLogout = False
    Private ovrLogin = False
    Private ovrRegister = False
    Public Shared ovrForm = False

    Public Sub New()
        Name = "TitleScreen"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()
        ' Toggle Sound
        If Input.mMapX >= 0 And Input.mMapX <= 32 Then
            If Input.mMapY >= 0 And Input.mMapY <= 32 Then
                If Input.Click = True Then
                    If SoundToggle = True Then ' Sound Off
                        SoundToggle = False
                        SoundIcon = SoundOff
                        Sounds.Muted = True
                    Else
                        SoundToggle = True ' Sound On
                        SoundIcon = SoundOn
                        Sounds.Muted = False
                    End If
                End If
            End If
        End If

        ' Draw Stars Menu
        If Input.mMapX >= 37 And Input.mMapX <= 73 Then
            If Input.mMapY >= 5 And Input.mMapY <= 26 Then
                DrawStars = True
            Else
                DrawStars = False
            End If
        Else
            DrawStars = False
        End If

        ' Verify a form is not currently open
        If ovrForm = False Then
            ' Login/Register options
            If Not Parameters.userInfo.username = vbNullString Then
                ' Logout Button
                If Input.mMapX >= 730 And Input.mMapX <= 790 Then
                    If Input.mMapY <= 25 Then
                        ovrLogout = True
                        If Input.Click = True Then
                            logout()
                        End If
                    Else
                        ovrLogout = False
                    End If
                Else
                    ovrLogout = False
                End If
            Else
                ' Login Button
                If Input.mMapX >= 740 And Input.mMapX <= 790 Then
                    If Input.mMapY >= 5 And Input.mMapY <= 26 Then
                        ovrLogin = True
                        If Input.Click = True Then
                            ScreenManager.AddScreen(New loginForm)
                            ovrForm = True
                            ovrLogin = False
                        End If
                    Else
                        ovrLogin = False
                    End If
                Else
                    ovrLogin = False
                End If

                ' Register Button
                If Input.mMapX >= 645 And Input.mMapX <= 710 Then
                    If Input.mMapY >= 5 And Input.mMapY <= 26 Then
                        ovrRegister = True
                        If Input.Click = True Then
                            ScreenManager.AddScreen(New registerForm)
                            ovrForm = True
                            ovrRegister = False
                        End If
                    Else
                        ovrRegister = False
                    End If
                Else
                    ovrRegister = False
                End If

            End If
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Speaker Icon
        Globals.SpriteBatch.Draw(Textures.Icons, New Rectangle(0, 0, 32, 32), SoundIcon, Color.White)

        ' Guild
        If Not Parameters.userInfo.guildName = vbNullString Then
            Globals.SpriteBatch.Draw(Textures.Icons, New Rectangle(95, 10, 16, 16), guildIcon, Color.White, 0, New Vector2(0, 0), SpriteEffects.None, 1)
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, Parameters.userInfo.guildName, New Vector2(120, 6), Color.White)
        End If
        ' Check to see if login data is cached
        If Not Parameters.userInfo.username = vbNullString Then
            ' Logout
            If ovrLogout = False Then
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "log out", New Vector2(730, 4), Color.White, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            Else
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "log out", New Vector2(730, 4), Color.LightBlue, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            End If

            ' Email
            Dim str = "logged in as " & Parameters.userInfo.email
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, str, New Vector2(720 - Fonts.WascoSans_12.MeasureString(str).X, 6), Color.LightGray)

        Else
            'Guest
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, "guest account  -", New Vector2(510, 6), Color.LightGray)

            'Register
            If ovrRegister = False Then
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "register", New Vector2(645, 4), Color.White, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            Else
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "register", New Vector2(645, 4), Color.LightBlue, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            End If

            ' "-" seperation character
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, "-", New Vector2(720, 6), Color.LightGray)

            'Login
            If ovrLogin = False Then
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "login", New Vector2(740, 4), Color.White, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            Else
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "login", New Vector2(740, 4), Color.LightBlue, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
            End If

        End If

        ' Stars Menu
        Globals.SpriteBatch.Draw(Textures.TransStarMenu, New Rectangle(33, 5, 39, 25), New Rectangle(0, 0, 39, 25), Color.White * Textures.formOpacity)
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, Parameters.userInfo.playerStars, New Vector2(37, 5), Color.Gray, 0, New Vector2(0, 0), 0.8, SpriteEffects.None, 0)
        ' Star Color
        Dim starColor As Color
        Select Case Parameters.userInfo.playerStars
            Case Is <= 13
                starColor = New Color(138, 150, 222)
            Case Is <= 27
                starColor = New Color(48, 77, 219)
            Case Is <= 41
                starColor = New Color(191, 38, 43)
            Case Is <= 55
                starColor = New Color(247, 149, 30)
            Case Is <= 69
                starColor = New Color(255, 255, 0)
            Case Else
                starColor = New Color(255, 255, 255)
        End Select

        Globals.SpriteBatch.Draw(Textures.BlankStar, New Rectangle(60, 8, 18, 18), New Rectangle(0, 0, 18, 17), starColor)
        If DrawStars = True Then
            Globals.SpriteBatch.Draw(Textures.StarsMenu, New Rectangle(Input.mMapX, Input.mMapY, 199, 192), Color.White)
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, Parameters.userInfo.playerStars, New Vector2(Input.mMapX + 122, Input.mMapY + 13), Color.LightGray, 0, New Vector2(0, 0), 0.5, SpriteEffects.None, 0)
        End If

        ' Version Number
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, "ARPG-IN-XNA " & Parameters.Version, New Vector2(5, 585), Color.LightGray, 0, New Vector2(0, 0), 0.7, SpriteEffects.None, 0)

        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub

    Public Shared Sub logout()
        ' Remove cached email
        My.Settings.email = ""
        My.Settings.Save()

        ' Update Globals
        Dim data As New userInfo
        data.email = ""
        data.password = ""
        data.username = ""

        data.DOB = ""
        data.userGold = 100

        data.playerStars = 0
        data.playerFame = 0
        data.playerExp = 0

        data.guildRank = 5
        data.guildName = ""

        data.emailOffers = False
        data.CreatedDate = DateAndTime.Today

        Parameters.userInfo = data

    End Sub

End Class
