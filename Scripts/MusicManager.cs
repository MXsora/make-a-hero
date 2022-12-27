using Godot;
using System;

public class MusicManager : Node
{
    static AudioStreamPlayer MusicPlayer;
    static AudioStream TitleTheme;
    static AudioStream IdleTheme;
    static AudioStream BattleTheme;
    public override void _Ready()
    {
        MusicPlayer = GetNode<AudioStreamPlayer>("MusicPlayer");
        TitleTheme = GD.Load<AudioStream>("res://Music/TitleTheme.mp3");
        IdleTheme = GD.Load<AudioStream>("res://Music/IdleTheme.mp3");
        BattleTheme = GD.Load<AudioStream>("res://Music/BattleTheme.mp3");
        MusicPlayer.Playing = true;
    }

    public static void PlayTitleTheme()
    {
        MusicPlayer.Stop();
        MusicPlayer.Stream = TitleTheme;
        MusicPlayer.Play(0);
    }
    public static void PlayIdleTheme()
    {
        MusicPlayer.Stop();
        MusicPlayer.Stream = IdleTheme;
        MusicPlayer.Play(0);
    }
    public static void PlayBattleTheme()
    {
        MusicPlayer.Stop();
        MusicPlayer.Stream = BattleTheme;
        MusicPlayer.Play(0);
    }
}
