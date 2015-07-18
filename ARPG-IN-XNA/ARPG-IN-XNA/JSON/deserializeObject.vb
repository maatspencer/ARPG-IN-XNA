Imports Newtonsoft.Json
Imports System.IO
Public Class deserializeObject
    Public Shared Sub UserInfo(email As String)
        ' deserialize JSON directly from a file
        Dim data As userInfo
        Using stream As StreamReader = File.OpenText(My.Application.Info.DirectoryPath & "/AppData/accounts/" & email & ".json")
            Dim serializer As New JsonSerializer()
            data = serializer.Deserialize(stream, GetType(userInfo))
        End Using

        ' Set Globals
        Parameters.userInfo = data

        My.Settings.email = data.email
        My.Settings.Save()

    End Sub
End Class