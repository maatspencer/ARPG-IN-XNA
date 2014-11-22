Public Class Parameters
    Public Shared Version As String = "#1.0.0"
    Public Shared ClassId As Integer = 5
    Public Shared Paused As Boolean = False
    Public Shared starColor As Color
    Public Shared statsChanged As Boolean = True
    Public Shared userChanged As Boolean = True


    Public Shared Sub Update()
        ' Determine Star Color
        Select Case userinfo.playerStars
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
    End Sub
    Public Structure userInfo

        Public Shared userEmail As String
        Public Shared userPassword As String
        Public Shared userName As String

        Public Shared userDOB As String
        Public Shared userGold As Integer

        Public Shared playerStars As Integer
        Public Shared playerFame As Integer
        Public Shared playerExp As Integer

        Public Shared guildRank As Integer
        Public Shared guildName As String

        Public Shared emailOffers As Boolean
        Public Shared createdDate As Date

    End Structure
End Class
