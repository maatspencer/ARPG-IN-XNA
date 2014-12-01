' GeoreferenceAPI Object from Telize.com
Public Class geoData
    ' ip (Visitor IP address, or IP address specified as parameter)
    Public Property ip() As String
        Get
            Return m_ip
        End Get
        Set(value As String)
            m_ip = value
        End Set
    End Property
    Private m_ip As String
    ' country_code (Two-letter ISO 3166-1 alpha-2 country code)
    Public Property country_code() As String
        Get
            Return m_country_code
        End Get
        Set(value As String)
            m_country_code = value
        End Set
    End Property
    Private m_country_code As String
    ' country_code3 (Three-letter ISO 3166-1 alpha-3 country code)
    Public Property country_code3() As String
        Get
            Return m_country_code3
        End Get
        Set(value As String)
            m_country_code3 = value
        End Set
    End Property
    Private m_country_code3 As String
    ' country (Name of the country)
    Public Property country() As String
        Get
            Return m_country
        End Get
        Set(value As String)
            m_country = value
        End Set
    End Property
    Private m_country As String
    ' region_code (Two-letter ISO-3166-2 state / region code)
    Public Property region_code() As String
        Get
            Return m_region_code
        End Get
        Set(value As String)
            m_region_code = value
        End Set
    End Property
    Private m_region_code As String
    ' region (Name of the region)
    Public Property region() As String
        Get
            Return m_region
        End Get
        Set(value As String)
            m_region = value
        End Set
    End Property
    Private m_region As String
    ' city (Name of the city)
    Public Property city() As String
        Get
            Return m_city
        End Get
        Set(value As String)
            m_city = value
        End Set
    End Property
    Private m_city As String
    ' postal_code (Postal code / Zip code)
    Public Property postal_code() As String
        Get
            Return m_postal_code
        End Get
        Set(value As String)
            m_postal_code = value
        End Set
    End Property
    Private m_postal_code As String
    ' continent_code (Two-letter continent code)
    Public Property continent_code() As String
        Get
            Return m_continent_code
        End Get
        Set(value As String)
            m_continent_code = value
        End Set
    End Property
    Private m_continent_code As String
    ' latitude (Latitude)
    Public Property latitude() As String
        Get
            Return m_latitude
        End Get
        Set(value As String)
            m_latitude = value
        End Set
    End Property
    Private m_latitude As String
    ' longitude (Longitude)
    Public Property longitude() As String
        Get
            Return m_longitude
        End Get
        Set(value As String)
            m_longitude = value
        End Set
    End Property
    Private m_longitude As String
    ' dma_code (DMA Code)
    Public Property dma_code() As String
        Get
            Return m_dma_code
        End Get
        Set(value As String)
            m_dma_code = value
        End Set
    End Property
    Private m_dma_code As String
    ' area_code (Area Code)
    Public Property area_code() As String
        Get
            Return m_area_code
        End Get
        Set(value As String)
            m_area_code = value
        End Set
    End Property
    Private m_area_code As String
    ' asn (Autonomous System Number)
    Public Property asn() As String
        Get
            Return m_asn
        End Get
        Set(value As String)
            m_asn = value
        End Set
    End Property
    Private m_asn As String
    ' isp (Internet service provider)
    Public Property isp() As String
        Get
            Return m_isp
        End Get
        Set(value As String)
            m_isp = value
        End Set
    End Property
    Private m_isp As String
    ' timezone (Time Zone)
    Public Property timezone() As String
        Get
            Return m_timezone
        End Get
        Set(value As String)
            m_timezone = value
        End Set
    End Property
    Private m_timezone As String
End Class
