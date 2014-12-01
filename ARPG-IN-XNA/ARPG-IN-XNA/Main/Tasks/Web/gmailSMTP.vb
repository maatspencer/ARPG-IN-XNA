Imports System.Net.Mail
Imports System.Net
Imports System.Threading

Public Class gmailSMTP

    Private Shared mm As MailMessage
    Private Shared trd As Thread
    Private data As userInfo

    Public Shared Sub asyncClient(mailMessage As MailMessage)
        ' Set Mail Options
        mm = mailMessage

        ' Send Email
        trd = New Thread(AddressOf SendMail)
        trd.IsBackground = True
        trd.Start()

    End Sub

    Private Shared Sub SendMail()
        ' SMTP options
        Dim Host As String = "smtp.gmail.com"
        Dim Port As Int16 = 587
        Dim SSL As Boolean = True
        Dim Username As String = "arpg.in.xna@gmail.com"
        Dim Password As String = "Civilengineering#1"

        ' Send Async
        Dim sc As SmtpClient = New SmtpClient(Host, Port)
        sc.EnableSsl = SSL
        sc.UseDefaultCredentials = False
        Dim netCred As New NetworkCredential(Username, Password)
        sc.Credentials = netCred
        sc.Send(mm)

        trd.Abort()
    End Sub
End Class
