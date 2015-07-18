' JSON Class to store each character that is created
Public Class characters
    ' Array Primary Keys
    Private m_uniqueKey As String
    Private m_userEmail As String

    ' Character Information
    Private m_alive As Boolean
    Private m_creationDate As Date
    Private m_deathDate As Date

    ' Class type
    Private m_class As Integer

    ' Stats
    Private m_fame As Integer
    Private m_level As Integer
    Private m_exp As Integer

    ' Stats Points
    Private m_hp As Integer
    Private m_mp As Integer
    Private m_atk As Integer
    Private m_spd As Integer
    Private m_vit As Integer
    Private m_def As Integer
    Private m_dex As Integer
    Private m_wis As Integer

    ' Unique Generated Key (10 chars)
    Public Property uniqueKey() As String
        Get
            Return m_uniqueKey
        End Get
        Set(value As String)
            m_uniqueKey = value
        End Set
    End Property

    ' User the character belongs to
    Public Property userEmail() As String
        Get
            Return m_userEmail
        End Get
        Set(value As String)
            m_userEmail = value
        End Set
    End Property

    ' Is the character still living?
    Public Property alive() As Boolean
        Get
            Return m_alive
        End Get
        Set(value As Boolean)
            m_alive = value
        End Set
    End Property

    ' Character creation date
    Public Property creationDate() As Date
        Get
            Return m_creationDate
        End Get
        Set(value As Date)
            m_creationDate = value
        End Set
    End Property

    ' Character death date
    Public Property deathDate() As Date
        Get
            Return m_deathDate
        End Get
        Set(value As Date)
            m_deathDate = value
        End Set
    End Property

    ' Character death date
    Public Property charClass() As Integer
        Get
            Return m_class
        End Get
        Set(value As Integer)
            m_class = value
        End Set
    End Property

    ' Character fame
    Public Property fame() As Integer
        Get
            Return m_fame
        End Get
        Set(value As Integer)
            m_fame = value
        End Set
    End Property

    ' Character level
    Public Property level() As Integer
        Get
            Return m_level
        End Get
        Set(value As Integer)
            m_fame = value
        End Set
    End Property

    ' Character experience
    Public Property experience() As Integer
        Get
            Return m_exp
        End Get
        Set(value As Integer)
            m_exp = value
        End Set
    End Property

    ' Character Health Points
    Public Property hp() As Integer
        Get
            Return m_hp
        End Get
        Set(value As Integer)
            m_hp = value
        End Set
    End Property

    ' Character Magic Points
    Public Property mp() As Integer
        Get
            Return m_mp
        End Get
        Set(value As Integer)
            m_mp = value
        End Set
    End Property

    ' Character Attak Points
    Public Property atk() As Integer
        Get
            Return m_atk
        End Get
        Set(value As Integer)
            m_atk = value
        End Set
    End Property

    ' Character Speed Points
    Public Property spd() As Integer
        Get
            Return m_spd
        End Get
        Set(value As Integer)
            m_spd = value
        End Set
    End Property

    ' Character Vitality Points
    Public Property vit() As Integer
        Get
            Return m_vit
        End Get
        Set(value As Integer)
            m_vit = value
        End Set
    End Property

    ' Character Defense Points
    Public Property def() As Integer
        Get
            Return m_def
        End Get
        Set(value As Integer)
            m_def = value
        End Set
    End Property

    ' Character Dexterity Points
    Public Property dex() As Integer
        Get
            Return m_dex
        End Get
        Set(value As Integer)
            m_dex = value
        End Set
    End Property

    ' Character Wisdom Points
    Public Property wis() As Integer
        Get
            Return m_wis
        End Get
        Set(value As Integer)
            m_wis = value
        End Set
    End Property
End Class
