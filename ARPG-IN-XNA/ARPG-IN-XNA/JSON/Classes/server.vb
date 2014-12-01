Public Class server
    ' server name
    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Private m_name As String
    ' server ip 
    Public Property ip() As String
        Get
            Return m_ip
        End Get
        Set(value As String)
            m_ip = value
        End Set
    End Property
    Private m_ip As String
    ' latitude
    Public Property latitude() As Double
        Get
            Return m_latitude
        End Get
        Set(value As Double)
            m_latitude = value
        End Set
    End Property
    Private m_latitude As Double
    ' longitude
    Public Property longitude() As Double
        Get
            Return m_longitude
        End Get
        Set(value As Double)
            m_longitude = value
        End Set
    End Property
    Private m_longitude As Double
End Class
