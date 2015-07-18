Imports System.Net
Imports Newtonsoft.Json
Imports System.Threading


Public Class UserGeoLocator
    Private Shared urlString = "http://www.telize.com/geoip/"
    Private Shared geoData As geoData
    Public Shared trd As Thread

    Public Shared Sub asyncWebclient()
        trd = New Thread(AddressOf getGeoData)
        trd.IsBackground = True
        trd.Start()
    End Sub
    Public Shared Function bestServer() As server
        ' temp until servers are used
        Dim server As server = New server
        server.name = "local host"
        server.ip = "127.0.0.1"
        server.latitude = 0
        server.longitude = 0
        Return server
    End Function

    Private Shared Function GetUserIP() As String
        Using wc As New WebClient
            Return wc.DownloadString("http://tools.feron.it/php/ip.php")
        End Using
    End Function
    Private Shared Sub getGeoData()
        Using wc As New WebClient()
            Dim ip As String = GetUserIP()
            Dim data As String = wc.DownloadString(urlString & ip)
            geoData = JsonConvert.DeserializeObject(Of geoData)(data)
        End Using

        Parameters.geoData = geoData
        trd.Abort()
    End Sub
End Class
