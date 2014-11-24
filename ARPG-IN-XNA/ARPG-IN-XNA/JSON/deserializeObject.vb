Imports Newtonsoft.Json
Imports System.IO
Public Class deserializeObject
    Public Shared Sub UserInfo(email As String)
        ' deserialize JSON directly from a file
        Dim data As userInfo
        Using stream As StreamReader = File.OpenText(My.Application.Info.DirectoryPath & "/accounts/" & email & ".json")
            Dim serializer As New JsonSerializer()
            data = serializer.Deserialize(stream, GetType(userInfo))
        End Using

        ' Set Globals
        Parameters.userInfo.userEmail = data.email
        Parameters.userInfo.userPassword = data.password
        Parameters.userInfo.userName = data.username

        Parameters.userInfo.userDOB = data.DOB
        Parameters.userInfo.userGold = data.userGold

        Parameters.userInfo.playerStars = data.playerStars
        Parameters.userInfo.playerFame = data.playerFame
        Parameters.userInfo.playerExp = data.playerExp

        Parameters.userInfo.guildRank = data.guildRank
        Parameters.userInfo.guildName = data.guildName

        Parameters.userInfo.emailOffers = data.emailOffers
        Parameters.userInfo.createdDate = data.CreatedDate

        My.Settings.email = data.email
        My.Settings.Save()

    End Sub
End Class