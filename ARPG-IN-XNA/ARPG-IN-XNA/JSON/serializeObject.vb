Imports Newtonsoft.Json
Imports System.IO
Public Class serializeObject
    Public Shared Sub userInfo(data As userInfo)
        ' Write user information to a file for caching
        My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "/accounts")
        File.WriteAllText(My.Application.Info.DirectoryPath & "/accounts/" & data.email & ".json", JsonConvert.SerializeObject(data))
    End Sub
End Class