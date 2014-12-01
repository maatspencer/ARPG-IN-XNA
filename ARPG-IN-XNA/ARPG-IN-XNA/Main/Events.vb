Public Class Events
    Public Shared Sub initialize()
        ' Load user settings
        If Not My.Settings.email = "" Then
            deserializeObject.UserInfo(My.Settings.email)
        End If

        ' Determine users IP and geoData
        UserGeoLocator.asyncWebclient()
    End Sub
End Class
