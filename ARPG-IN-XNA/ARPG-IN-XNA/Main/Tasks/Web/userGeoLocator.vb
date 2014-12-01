Imports System.Net
Imports Newtonsoft.Json
Imports System.Threading


Public Class UserGeoLocator
    Private Shared urlString = "http://www.telize.com/geoip/"
    Private Shared geoData As geoData
    Private Shared trd As Thread

    Public Shared Sub asyncWebclient()
        trd = New Thread(AddressOf getGeoData)
        trd.IsBackground = True
        trd.Start()
    End Sub

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
