Imports System.Text
Public Class uniqueRandomString
    Private Shared allocated As List(Of StringBuilder) = New List(Of StringBuilder)
    Public Shared Function generate() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As Random = New Random
        Dim sb As StringBuilder = New StringBuilder
        Do
            For i As Integer = 1 To 10
                Dim idx As Integer = r.Next(0, 35) '26 letters + 10 digits
                sb.Append(s.Substring(idx, 1))
            Next
        Loop Until Not allocated.Contains(sb)
        allocated.Add(sb)
        Return sb.ToString()
    End Function
End Class
