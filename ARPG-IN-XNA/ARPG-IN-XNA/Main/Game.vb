Imports System.Windows.Forms
Public Class Game
    Inherits Microsoft.Xna.Framework.Game
    Private ScreenManager As ScreenManager

    Public Sub New()
        Globals.Graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub

    Protected Overrides Sub Initialize()
        Me.IsMouseVisible = True
        Window.AllowUserResizing = True

        Globals.GameSize = New Vector2(800, 600)
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        Globals.Graphics.ApplyChanges()

        Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)

        MyBase.Initialize()
    End Sub

    Protected Overrides Sub LoadContent()
        Globals.SpriteBatch = New SpriteBatch(GraphicsDevice)
        Globals.Content = Me.Content

        ' Loads Textures Fonts and Sounds
        Fonts.Load()
        Textures.Load()
        Sounds.Load()

        ' Add Default Screens
        ScreenManager = New ScreenManager
        ScreenManager.AddScreen(New Parallax)

        ' Load
        ScreenManager.AddScreen(New LoadingTitle)
    End Sub
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        ' TODO: Add your update logic here
        MyBase.Update(gameTime)

        Globals.WindowFocused = Me.IsActive
        Globals.GameTime = gameTime

        ' Update Our Screens
        ScreenManager.Update()

        ' Input Updates
        Input.Update()

        ' Sound Updates
        Sounds.Update()
    End Sub

    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer)
        GraphicsDevice.Clear(Color.Black)
        MyBase.Draw(gameTime)

        'Draw Contents of our screen manager
        ScreenManager.Draw()

        Globals.Graphics.GraphicsDevice.SetRenderTarget(Nothing)

        ' Draw Back Buffer to Screen
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Globals.BackBuffer, New Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), Color.White)

        Globals.SpriteBatch.End()

    End Sub

    Protected Overrides Sub OnExiting(sender As Object, args As EventArgs)
        ' TODO

        MyBase.OnExiting(sender, args)
    End Sub

End Class
