Public Class userInfo
    ' User Name
    Public Property username() As String
        Get
            Return m_username
        End Get
        Set(value As String)
            m_username = value
        End Set
    End Property
    Private m_username As String

    ' User Password
    Public Property password() As String
        Get
            Return m_password
        End Get
        Set(value As String)
            m_password = value
        End Set
    End Property
    Private m_password As Boolean

    ' User Email
    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(value As String)
            m_email = value
        End Set
    End Property
    Private m_email As String

    ' User Date of Birth
    Public Property DOB() As String
        Get
            Return m_DOB
        End Get
        Set(value As String)
            m_DOB = value
        End Set
    End Property
    Private m_DOB As String

    ' User Gold
    Public Property userGold() As Integer
        Get
            Return m_userGold
        End Get
        Set(value As Integer)
            m_userGold = value
        End Set
    End Property
    Private m_userGold As Integer

    ' Recieve Special offers via email
    Public Property emailOffers() As Boolean
        Get
            Return m_emailOffers
        End Get
        Set(value As Boolean)
            m_emailOffers = value
        End Set
    End Property
    Private m_emailOffers As Integer

    ' Creation Date
    Public Property CreatedDate() As DateTime
        Get
            Return m_CreatedDate
        End Get
        Set(value As DateTime)
            m_CreatedDate = value
        End Set
    End Property
    Private m_CreatedDate As DateTime

    ' Player Stars
    Public Property playerStars() As Integer
        Get
            Return m_playerStars
        End Get
        Set(value As Integer)
            m_playerStars = value
        End Set
    End Property
    Private m_playerStars As Integer

    ' Player Fame
    Public Property playerFame() As Integer
        Get
            Return m_playerFame
        End Get
        Set(value As Integer)
            m_playerFame = value
        End Set
    End Property
    Private m_playerFame As Integer

    ' Player Exp
    Public Property playerExp() As Integer
        Get
            Return m_playerExp
        End Get
        Set(value As Integer)
            m_playerExp = value
        End Set
    End Property
    Private m_playerExp As Integer

    ' Guild Rank
    Public Property guildRank() As Integer
        Get
            Return m_guildRank
        End Get
        Set(value As Integer)
            m_guildRank = value
        End Set
    End Property
    Private m_guildRank As Integer

    ' Guild Name
    Public Property guildName() As String
        Get
            Return m_guildName
        End Get
        Set(value As String)
            m_guildName = value
        End Set
    End Property
    Private m_guildName As String
End Class

