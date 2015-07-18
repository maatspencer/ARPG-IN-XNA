Imports System.Windows.Forms

Public Class serverSelection
    Inherits BaseScreen

    Private divLine As New Rectangle(0, 100, 800, 3)
    Private bottomFrame As New Rectangle(0, 537, 800, 40)

    Public Shared servers As New List(Of server)

    Private isOver() As Boolean
    Private isSelected() As Boolean
    Private bestSelected As Boolean = True

    Private frameRect As New List(Of Rectangle)
    Private textRect As New List(Of Rectangle)

    Private ovrDone As Boolean
    Private ovrBest As Boolean

    Public Sub New()
        Name = "serverSelection"
        State = ScreenState.Active

        ' Add servers
        servers.Clear()
        addServer("localhost", "127.0.0.1")
        addServer("Server 1")
        addServer("Server 2")
        addServer("Server 3")
        addServer("Server 4")
        addServer("Server 5")
        addServer("Server 6")
        addServer("Server 7")
        addServer("Server 8")
        addServer("Server 9")

        ' servers() array
        Dim width As Integer = 300
        Dim height As Integer = 60
        Dim spacing As Integer = 20

        ' loop through each server
        For i = 0 To servers.Count - 1
            Dim frameX As Integer
            Dim frameY As Integer
            Dim textX As Integer
            Dim textY As Integer

            ' Determine frame locations
            If i Mod 2 = 0 Then
                ' left
                frameX = (Globals.GameSize.X - (2 * width) - spacing) / 2
                frameY = (i / 2 * (height + spacing)) + 125
            Else
                ' right
                frameX = (Globals.GameSize.X - (2 * width) - spacing) / 2 + width + spacing
                frameY = (i - 1) / 2 * (height + spacing) + 125
            End If

            ' determine text locations
            textX = frameX + width / 2 - Fonts.WascoSans_16.MeasureString(servers.Item(i).name).X / 2
            textY = frameY + height / 2 - Fonts.WascoSans_16.MeasureString(servers.Item(i).name).Y / 2

            ' create recatangles for each object
            frameRect.Add(New Rectangle(frameX, frameY, width, height))
            textRect.Add(New Rectangle(textX, textY, Fonts.WascoSans_16.MeasureString(servers.Item(i).name).X, Fonts.WascoSans_16.MeasureString(servers.Item(i).name).Y))
        Next

        ' Size the array for Mouse Handling
        Array.Resize(isOver, servers.Count)
        Array.Resize(isSelected, servers.Count)
    End Sub

    Public Overrides Sub HandleInput()
        '''' Handle Mouse Input ''''

        ' servers() array
        For i = 0 To servers.Count - 1
            isOver(i) = False
            Dim r As Rectangle = textRect.Item(i)
            If Input.MouseX > r.X - 5 And Input.MouseX < r.X + r.Width + 5 Then
                If Input.MouseY > r.Y - 5 And Input.MouseY < r.Y + r.Height + 5 Then
                    isOver(i) = True
                End If
            End If
        Next

        ' Best server
        ovrBest = False
        Dim x As Integer = 400 - Fonts.WascoSans_16.MeasureString("Best Server").X / 2
        Dim y As Integer = 60 - Fonts.WascoSans_16.MeasureString("Best Server").Y / 2
        If Input.MouseX > x - 5 And Input.MouseX < x + Fonts.WascoSans_16.MeasureString("Best Server").X + 5 Then
            If Input.MouseY > y - 5 And Input.MouseY < y + Fonts.WascoSans_16.MeasureString("Best Server").Y + 5 Then
                ovrBest = True
            End If
        End If

        ' Done
        ovrDone = False
        x = 400 - Fonts.WascoSans_16.MeasureString("done").X / 2 * 1.3
        y = 557 - Fonts.WascoSans_16.MeasureString("done").Y / 2 * 1.3
        If Input.MouseX > x - 5 And Input.MouseX < x + Fonts.WascoSans_16.MeasureString("done").X * 1.3 + 5 Then
            If Input.MouseY > y - 5 And Input.MouseY < y + Fonts.WascoSans_16.MeasureString("done").Y * 1.3 + 5 Then
                ovrDone = True
            End If
        End If

        ' Handle all clicks
        If Input.Click = True Then
            For i = 0 To servers.Count - 1
                If isOver(i) = True Then
                    deselectServer()
                    isSelected(i) = True
                    Parameters.selectedServer = servers.Item(i)
                End If
            Next

            ' Done button
            If ovrDone = True Then
                ScreenManager.UnloadScreen("serverSelection")
                ScreenManager.AddScreen(New MainMenu)
            End If

            ' Best Server
            If ovrBest = True Then
                deselectServer()
                bestSelected = True
                Parameters.selectedServer = UserGeoLocator.bestServer
            End If
        End If


    End Sub
    Public Overrides Sub Update()

    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        ' Define Transparency
        Dim a As Single = Textures.formOpacity

        ' Draw Menu Graphics
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, divLine, New Color(97, 97, 97) * a)
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, bottomFrame, New Color(97, 97, 97) * a)

        Dim scale As Single = 1.3
        Dim x As Integer = bottomFrame.X + (bottomFrame.Width / 2) - (Fonts.WascoSans_16.MeasureString("done").X / 2) * scale
        Dim y As Integer = bottomFrame.Y + (bottomFrame.Height / 2) - (Fonts.WascoSans_16.MeasureString("done").Y / 2) * scale

        If ovrDone = False Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "done", New Vector2(x, y), Color.White, 0, New Vector2(0, 0), scale, SpriteEffects.None, 0)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "done", New Vector2(x, y), Color.LightBlue, 0, New Vector2(0, 0), scale, SpriteEffects.None, 0)
        End If

        '''' Draw Best Server ''''
        ' Frame
        If bestSelected = False Then
            Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(250, 35, 300, 50), New Color(97, 97, 97) * a)
        Else
            Globals.SpriteBatch.Draw(Textures.WhiteSquare, New Rectangle(250, 35, 300, 50), Color.SteelBlue)
        End If

        ' Text
        If ovrBest = False Then
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "Best Server", New Vector2(400 - Fonts.WascoSans_16.MeasureString("Best Server").X / 2, 60 - Fonts.WascoSans_16.MeasureString("Best Server").Y / 2), Color.White, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        Else
            Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, "Best Server", New Vector2(400 - Fonts.WascoSans_16.MeasureString("Best Server").X / 2, 60 - Fonts.WascoSans_16.MeasureString("Best Server").Y / 2), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 1)
        End If

        '''' Draw servers() array ''''
        For i = 0 To servers.Count - 1
            ' Frame
            If isSelected(i) = False Then
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, frameRect.Item(i), New Color(97, 97, 97) * a)
            Else
                Globals.SpriteBatch.Draw(Textures.WhiteSquare, frameRect.Item(i), Color.SteelBlue)
            End If
            ' Text
            If isOver(i) = False Then
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, servers.Item(i).name, New Vector2(textRect.Item(i).X, textRect.Item(i).Y), Color.White, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
            Else
                Globals.SpriteBatch.DrawString(Fonts.WascoSans_16, servers.Item(i).name, New Vector2(textRect.Item(i).X, textRect.Item(i).Y), Color.LightBlue, 0, New Vector2(0, 0), 1, SpriteEffects.None, 0)
            End If
        Next

        Globals.SpriteBatch.End()
    End Sub

    Private Sub addServer(name As String, Optional ByVal ip As String = "", Optional ByVal latitude As Double = 0, Optional ByVal longitude As Double = 0)
        ' Add the server
        Dim server As server = New server
        server.name = name
        server.ip = ip
        server.latitude = latitude
        server.longitude = longitude
        servers.Add(server)
    End Sub

    Private Sub deselectServer()
        For i = 0 To servers.Count - 1
            isSelected(i) = False
        Next
        bestSelected = False
    End Sub
End Class
