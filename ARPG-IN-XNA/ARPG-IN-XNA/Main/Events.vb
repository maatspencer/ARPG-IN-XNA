Public Class Events

    Public Shared loadFinished As Boolean = False
    Public Shared Sub load()
        ' Determine users IP and geoData
        UserGeoLocator.asyncWebclient()

        ' Load user settings
        If Not My.Settings.email = "" Then
            deserializeObject.UserInfo(My.Settings.email)
        Else
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

            data.characters = ""

            Parameters.userInfo = data
        End If

        Do While Not UserGeoLocator.trd.ThreadState = Threading.ThreadState.Stopped
            Threading.Thread.Sleep(100)
        Loop

        loadFinished = True
    End Sub
End Class
