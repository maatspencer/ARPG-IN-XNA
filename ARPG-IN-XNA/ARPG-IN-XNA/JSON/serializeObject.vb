Imports Newtonsoft.Json
Imports System.IO
Public Class serializeObject
    Public Shared Sub userInfo(data As userInfo)
        ' Write user information to a file for caching
        My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "/AppData/Accounts/")
        File.WriteAllText(My.Application.Info.DirectoryPath & "/AppData/Accounts/" & data.email & ".json", JsonConvert.SerializeObject(data, Formatting.Indented))
    End Sub
    Public Shared Sub character(data As characters)
        ' Write user information to a file for caching
        File.AppendAllText(My.Application.Info.DirectoryPath & "/AppData/characters.json", JsonConvert.SerializeObject(data, Formatting.Indented))
    End Sub
End Class