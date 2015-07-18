Public Class characterSelection
    Inherits BaseScreen

    Private horLine As New Rectangle(0, 100, 800, 3)
    Private verLine As New Rectangle(500, 103, 3, 434)
    Private bottomFrame As New Rectangle(0, 537, 800, 40)

    Private aniTime As Double = 0
    Private aniScale As Single = 1

    Private charActive As Boolean = True
    Private ovrChar As Boolean

    Private hisActive As Boolean = False
    Private ovrHis As Boolean

    Private ovrPlay As Boolean
    Private ovrMain As Boolean
    Private ovrClasses As Boolean

    Public Sub New()
        Name = "characterSelection"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub Update()
        ' Changing Size Effect
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime < 1000 Then
            aniScale = 1.2 + 3 * aniTime / 10000
        ElseIf AniTime < 2000 Then
            aniScale = 1.5 - (3 * (aniTime - 1000)) / 10000
        Else
            AniTime = 0
            aniScale = 1.2
        End If
    End Sub

    Public Overrides Sub HandleInput()
        '''' Handle Mouse Input ''''

        ' Characters Tab
        ovrChar = False
        If Input.MouseX > 34 And Input.MouseX < 125 Then
            If Input.MouseY > 75 And 95 Then
                ovrChar = True
            End If
        End If

        ' History Tab
        ovrHis = False
        If Input.MouseX > 168 And Input.MouseX < 230 Then
            If Input.MouseY > 75 And 95 Then
                ovrChar = True
            End If
        End If

        ' Play button
        ovrPlay = False
        If Input.MouseX > 370 And Input.MouseX < 430 Then
            If Input.MouseY > 546 And 566 Then
                ovrPlay = True
            End If
        End If

        ' Main button
        ovrMain = False
        If Input.MouseX > 275 And Input.MouseX < 327 Then
            If Input.MouseY > 549 And 563 Then
                ovrMain = True
            End If
        End If

        ' Classes button
        ovrClasses = False
        If Input.MouseX > 463 And Input.MouseX < 538 Then
            If Input.MouseY > 549 And 563 Then
                ovrClasses = True
            End If
        End If

        ''''' Handle all clicks
        If Input.Click = True Then

            ' Characters Tab
            If ovrChar = True Then
                charActive = Not (charActive)
                hisActive = Not (hisActive)
            End If

            ' History Tab
            If ovrHis = True Then
                charActive = Not (charActive)
                hisActive = Not (hisActive)
            End If

            ' Main Buntton
            ' Play button
            ' Classes Button
        End If
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        ' Define Transparency
        Dim a As Single = Textures.formOpacity

        '''' Draw Menu Graphics
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, horLine, New Color(97, 97, 97) * a)
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, verLine, New Color(97, 97, 97) * a)
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, bottomFrame, New Color(97, 97, 97) * a)

        '''' Draw Menu Strip Text
        Dim x As Integer = bottomFrame.X + (bottomFrame.Width / 2)
        Dim y As Integer = bottomFrame.Y + (bottomFrame.Height / 2)
        ' Play
        If ovrPlay = False Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "play", New Vector2(x - (Fonts.WascoSans_16.MeasureString("play").X / 2) * aniScale, y - (Fonts.WascoSans_16.MeasureString("play").Y / 2) * aniScale), Color.White, 0, New Vector2(0, 0), aniScale, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "play", New Vector2(x - (Fonts.WascoSans_16.MeasureString("play").X / 2) * aniScale, y - (Fonts.WascoSans_16.MeasureString("play").Y / 2) * aniScale), Color.LightBlue, 0, New Vector2(0, 0), aniScale, SpriteEffects.None, 0)
        End If
        ' Main
        If ovrMain = False Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "main", New Vector2(0.75 * x - (Fonts.WascoSans_16.MeasureString("main").X / 2), y - (Fonts.WascoSans_16.MeasureString("main").Y / 2)), Color.White, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "main", New Vector2(0.75 * x - (Fonts.WascoSans_16.MeasureString("main").X / 2), y - (Fonts.WascoSans_16.MeasureString("main").Y / 2)), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
        End If
        'Classes
        If ovrClasses = False Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "classes", New Vector2(1.25 * x - (Fonts.WascoSans_16.MeasureString("classes").X / 2), y - (Fonts.WascoSans_16.MeasureString("classes").Y / 2)), Color.White, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "classes", New Vector2(1.25 * x - (Fonts.WascoSans_16.MeasureString("classes").X / 2), y - (Fonts.WascoSans_16.MeasureString("classes").Y / 2)), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
        End If
        '''' Top Bar Info
        ' Username
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, Parameters.userInfo.username, New Vector2(x - (Fonts.WascoSans_16.MeasureString(Parameters.userInfo.username).X / 2), 30), Color.LightGray)
        Dim tabScale As Single = 0.8

        Dim goldFameX = 750
        ' Fame Icon
        Globals.SpriteBatch.Draw(Textures.goldFame, New Rectangle(goldFameX, 32, 16, 16), New Rectangle(0, 0, 8, 8), Color.White)
        goldFameX -= 10

        ' Fame Text
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, Parameters.userInfo.playerFame, New Vector2(goldFameX - (Fonts.WascoSans_12.MeasureString(Parameters.userInfo.playerFame).X), 30), Color.LightGray)
        goldFameX -= (16 + 10 + Fonts.WascoSans_12.MeasureString(Parameters.userInfo.playerFame).X)

        ' Gold Icon
        Globals.SpriteBatch.Draw(Textures.goldFame, New Rectangle(goldFameX, 32, 16, 16), New Rectangle(8, 0, 8, 8), Color.White)
        goldFameX -= 10

        ' Gold Text
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_12, Parameters.userInfo.userGold, New Vector2(goldFameX - (Fonts.WascoSans_12.MeasureString(Parameters.userInfo.userGold).X), 30), Color.LightGray)


        ' Characters Tab
        If charActive = True Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "Characters", New Vector2(0.2 * x - (Fonts.WascoSans_16.MeasureString("Characters").X / 2) * tabScale, 75), Color.White, 0, New Vector2(0, 0), tabScale, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "Characters", New Vector2(0.2 * x - (Fonts.WascoSans_16.MeasureString("Characters").X / 2) * tabScale, 75), Color.LightGray, 0, New Vector2(0, 0), tabScale, SpriteEffects.None, 0)
        End If
        ' Graveyard Tab
        If hisActive = True Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "History", New Vector2(0.5 * x - (Fonts.WascoSans_16.MeasureString("History").X / 2) * tabScale, 75), Color.White, 0, New Vector2(0, 0), tabScale, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "History", New Vector2(0.5 * x - (Fonts.WascoSans_16.MeasureString("History").X / 2) * tabScale, 75), Color.LightGray, 0, New Vector2(0, 0), tabScale, SpriteEffects.None, 0)
        End If
        ' News Tab
        Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "News", New Vector2(1.4 * x - (Fonts.WascoSans_16.MeasureString("News").X / 2) * tabScale, 75), Color.White, 0, New Vector2(0, 0), tabScale, SpriteEffects.None, 0)

        Globals.SpriteBatch.End()

    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
