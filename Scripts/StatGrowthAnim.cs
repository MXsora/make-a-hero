using Godot;
using System;

public class StatGrowthAnim : Control
{
    private AnimationPlayer animPlayer;
    private Label lab;
    public override void _Ready()
    {

    }

    public async void PlaynDestroy(String s)
    {
        animPlayer = GetNode<AnimationPlayer>("StatGrowthAnim");
        lab = GetNode<Label>("StatGrwthNum");
        lab.Text = "+" + s;
        animPlayer.Play("Grow");
        await ToSignal(animPlayer, "animation_finished");
        QueueFree();
    }
}
