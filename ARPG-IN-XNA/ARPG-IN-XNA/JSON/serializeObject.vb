Imports Newtonsoft.Json
Imports System.IO
Public Class serializeObject
    Public Sub userInfo(data As userInfo)
        ' Serialize JSON to a String
        File.WriteAllText(My.Application.Info.DirectoryPath & "/accounts/" & data.username & ".json", JsonConvert.SerializeObject(data))
    End Sub
End Class