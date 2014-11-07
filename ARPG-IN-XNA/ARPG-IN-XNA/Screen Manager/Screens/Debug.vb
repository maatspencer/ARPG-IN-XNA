Public Class Debug
    Inherits BaseScreen

    Public Screens As String = ""
    Public FocusScreen As String = ""

    Private fps As Integer
    Private fpsCounter As Integer
    Private fpsTimer As Double
    Private fpsText As String = ""
    Private MousePos As String = ""
    Private FromCenter As String = ""
    Private IsClick As String = ""

    Private BGRect As Rectangle

    Private KeyDown As Boolean = False

    Public Sub New()
        Name = "Debug"
        State = ScreenState.Hidden
        GrabFocus = False
    End Sub

    Public Overrides Sub HandleInput()
        ' Temporary until input class is generated
        If Input.KeyPressed(Keys.F1) Then
            If State = ScreenState.Active Then
                State = ScreenState.Hidden
            ElseIf State = ScreenState.Hidden Then
                State = ScreenState.Active
            End If
        End If
    End Sub

    Public Overrides Sub Update()
        MyBase.Update()

        If Screens.Length > 0 Then
            Screens = Screens.Substring(0, Screens.Length - 2)
        End If

        Dim Textwidth As Integer = 0
        Dim TextHeight As Integer = 0

        If Fonts.Arial_8.MeasureString(Screens).X > Textwidth Then
            Textwidth = Fonts.Arial_8.MeasureString(Screens).X
        End If
        If Fonts.Arial_8.MeasureString(FocusScreen).X > Textwidth Then
            Textwidth = Fonts.Arial_8.MeasureString(FocusScreen).X
        End If
        MousePos = "( " & Input.mMapX & " , " & Input.mMapY & " )"
        FromCenter = "( " & Input.FromCenterX & " , " & Input.FromCenterY & " )"
        TextHeight = Fonts.Arial_8.MeasureString(fps).Y * 6
        BGRect = New Rectangle(0, 0, Textwidth + 20, TextHeight + 20)
        If Input.Click = True Then
            IsClick = "Click!"
        Else
            IsClick = "False"
        End If

    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        If Globals.GameTime.TotalGameTime.TotalMilliseconds > fpsTimer Then
            fps = fpsCounter
            fpsTimer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 1000
            fpsCounter = 1
            fpsText = "FPS: " & fps
        Else
            fpsCounter += 1
        End If

        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Textures.WhiteSquare, BGRect, Color.Turquoise * 0.6F)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, fpsText, New Vector2(10, 10), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, Screens, New Vector2(10, 22), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, FocusScreen, New Vector2(10, 34), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, MousePos, New Vector2(10, 46), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, Input.mAngle, New Vector2(10, 58), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, IsClick, New Vector2(10, 70), Color.White)
        Globals.SpriteBatch.End()

    End Sub
End Class
