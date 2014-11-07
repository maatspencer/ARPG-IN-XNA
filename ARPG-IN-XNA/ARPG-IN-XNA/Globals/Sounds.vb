Public Class Sounds
    ' Sound Parameters
    Public Shared Muted As Boolean
    Public Shared MusicVolume As Single = 0.8

    Public Shared Main As SoundEffect
    Public Shared Music As SoundEffectInstance


    Public Shared Sub Load()
        Main = Globals.Content.Load(Of SoundEffect)("Sounds/sorc")
        Music = Main.CreateInstance
        PlaySong(Sounds.Main, True)
    End Sub
    Public Shared Sub Update()
        If Muted = False Then
            Music.Volume = MusicVolume
        Else
            Music.Volume = 0
        End If
    End Sub
    Public Shared Sub PlaySong(song As SoundEffect, looped As Boolean)
        Music.Dispose()
        Music = song.CreateInstance
        With Music
            .Volume = MusicVolume
            .IsLooped = looped
            .Play()
        End With
    End Sub
End Class
