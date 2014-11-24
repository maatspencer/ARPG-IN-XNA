Public Class MainMenu
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 2

    Private MenuSize As New Vector2(800, 40)
    Private MenuPos As New Vector2(0, 537)

    Private AniTime As Double = 0
    Private Scale As Double = 1

    Private RegionX As Integer
    Private RegionY As Integer
    Private RegionWidth As Integer
    Private RegionHeight As Integer
    Private Color As New Color
    Private IsOver(5) As Boolean

    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active

        'Add Entries here
        AddEntry("github", True)
        AddEntry("servers", True)
        AddEntry("play", True)
        AddEntry("account", True)
        AddEntry("legends", True)
    End Sub

    Public Sub AddEntry(Text As String, Enabled As Boolean)
        Dim Entry As MenuEntry
        Entry = New MenuEntry
        With Entry
            .Text = Text
            .Enabled = Enabled
        End With
        Entries.Add(Entry)
    End Sub

    Public Overrides Sub HandleInput()
        ' Handle Mouse Input
        RegionX = MenuPos.X + 137
        For X = 0 To 4
            RegionY = MenuPos.Y
            RegionWidth = Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).X
            RegionHeight = Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).Y
            If X = 2 Then
                RegionY = MenuPos.Y - 7
                RegionHeight = RegionHeight * Scale
            End If
            If TitleScreen.ovrForm = False Then
                If Input.mMapX >= RegionX And Input.mMapX <= RegionX + RegionWidth Then
                    If Input.mMapY >= RegionY And Input.mMapY <= RegionY + RegionHeight Then
                        If Input.Click = True Then
                            Select Case X
                                Case 0
                                    Process.Start("https://github.com/maat7043/ARPG-IN-XNA")
                                Case 1
                                Case 2
                                    ScreenManager.UnloadScreen("TitleScreen")
                                    ScreenManager.UnloadScreen("MainMenu")
                                    ScreenManager.AddScreen(New WorldScreen)
                                Case 3
                                    If My.Settings.email = "" Then
                                        ScreenManager.AddScreen(New registerForm)
                                        TitleScreen.ovrForm = True
                                    Else
                                        ScreenManager.AddScreen(New accountForm)
                                        TitleScreen.ovrForm = True
                                    End If
                                Case 4
                            End Select
                        Else : IsOver(X) = True
                        End If
                    Else : IsOver(X) = False
                    End If
                Else : IsOver(X) = False
                End If
            End If
            RegionX += Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).X + 30
        Next

    End Sub
    Public Overrides Sub Update()
        ' Changing Size Effect
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime < 1000 Then
            Scale = 1.2 + 3 * AniTime / 10000
        ElseIf AniTime < 2000 Then
            Scale = 1.5 - (3 * (AniTime - 1000)) / 10000
        Else
            AniTime = 0
            Scale = 1.2
        End If

        ' 
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        ' Draw Menu Graphics

        ' Draw Menu Options
        Dim MenuX As Integer = MenuPos.X + 137
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(MenuPos.X, MenuPos.Y, MenuSize.X, MenuSize.Y), New Color(97, 97, 97))
        For X = 0 To 4
            If IsOver(X) = True Then Color = Color.LightBlue Else If X = 0 Then Color = Color.SteelBlue Else Color = Color.White
            If X = MenuSelect Then
                Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, Entries.Item(X).Text, New Vector2(MenuX - (Fonts.LargeROTMG.MeasureString(X).X * (Scale - 1)) / 2, MenuPos.Y + (MenuSize.Y / 2) - (Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).Y) / 2 - 7), Color, 0, New Vector2(0, 0), Scale, SpriteEffects.None, 1)
            ElseIf Entries.Item(X).Enabled = True Then
                Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, Entries.Item(X).Text, New Vector2(MenuX, MenuPos.Y + (MenuSize.Y / 2) - (Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).Y / 2)), Color)
            Else
                Globals.SpriteBatch.DrawString(Fonts.LargeROTMG, Entries.Item(X).Text, New Vector2(MenuX, MenuPos.Y + (MenuSize.Y / 2) - (Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).Y / 2)), New Color(153, 151, 0))
            End If

            MenuX += Fonts.LargeROTMG.MeasureString(Entries.Item(X).Text).X + 30
        Next

        Globals.SpriteBatch.End()
    End Sub
End Class
