Public Class Input
    Public Shared CurrentKeystate As KeyboardState
    Public Shared LastKeyState As KeyboardState

    Public Shared CurrentMouseState As MouseState
    Public Shared LastMouseState As MouseState

    Public Shared MouseX As Integer
    Public Shared MouseY As Integer
    Public Shared mMapX As Integer
    Public Shared mMapY As Integer
    Public Shared mAngle As Double
    Public Shared FromCenterX As Integer
    Public Shared FromCenterY As Integer
    Public Shared Click As Boolean


    Public Shared Sub Update()
        ' Reset IsClicked to False
        Click = False

        ' Keys
        LastKeyState = CurrentKeystate
        CurrentKeystate = Keyboard.GetState

        ' Left Button
        LastMouseState = CurrentMouseState
        CurrentMouseState = Mouse.GetState

        ' Click
        If LastMouseState.LeftButton = ButtonState.Pressed And CurrentMouseState.LeftButton = ButtonState.Released Then
            Click = True
        End If

        MouseX = CurrentMouseState.X
        MouseY = CurrentMouseState.Y
        mMapX = MouseX
        mMapY = MouseY

        'Mouse X Boundaries
        If MouseX >= Globals.GameSize.X Then
            mMapX = Globals.GameSize.X
        ElseIf MouseX <= 0 Then
            mMapX = 0
        End If

        ' Mouse Y Boundaries
        If MouseY >= Globals.GameSize.Y Then
            mMapY = Globals.GameSize.Y
        ElseIf MouseY <= 0 Then
            mMapY = 0
        End If

        ' Fire Angle
        FromCenterX = mMapX - Globals.GameSize.X / 2
        FromCenterY = (Globals.GameSize.Y - mMapY) - Globals.GameSize.Y / 2
        If FromCenterX >= 0 Then
            If FromCenterY >= 0 Then
                mAngle = Math.Round(Math.Atan(FromCenterY / FromCenterX) * (180 / Math.PI))
            Else
                mAngle = Math.Round(Math.Atan(FromCenterY / FromCenterX) * (180 / Math.PI) + 360)
            End If
        Else
            If FromCenterY >= 0 Then
                mAngle = Math.Round(Math.Atan(FromCenterY / FromCenterX) * (180 / Math.PI) + 180)
            Else
                mAngle = Math.Round(Math.Atan(FromCenterY / FromCenterX) * (180 / Math.PI) + 180)
            End If
        End If


    End Sub
    Public Shared Function KeyDown(key As Keys) As Boolean
        Return CurrentKeystate.IsKeyDown(key)
    End Function
    Public Shared Function KeyPressed(key As Keys) As Boolean
        If CurrentKeystate.IsKeyDown(key) And LastKeyState.IsKeyUp(key) Then
            Return True
        End If
        Return False
    End Function
End Class
