using Godot;
using System;

public class StatGrowthAnim : Control
{
    private AnimationPlayer animPlayer;
    private Label lab;
    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("StatGrowthAnim");
        lab = GetNode<Label>("StatGrwthNum");
    }

    public async void PlaynDestroy(String s, bool dmg)
    {
        if(dmg)
        {
            lab.Text = s;
        }
        else
        {
            lab.Text = "+" + s;
        }
        animPlayer.Play("Grow");
        await ToSignal(animPlayer, "animation_finished");
        QueueFree();
    }
}
