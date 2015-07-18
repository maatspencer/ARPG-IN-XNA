Public Class objectHandler
    Public Enum textAlignment
        left
        right
        centered
    End Enum
    Public Structure textObject
        Public font As SpriteFont
        Public text As String
        Public location As Vector2
        Public textAlignment As textAlignment
        Public isOver As Boolean
        Public isClicked As Boolean
    End Structure

    ''' <summary>
    ''' Summary for the method goes here
    ''' </summary>
    ''' <param name="textObject">Object for the text</param>
    Public Sub addText(textObject As textObject)

    End Sub
End Class
