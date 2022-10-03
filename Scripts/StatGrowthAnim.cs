using Godot;
using System;

public class StatGrowthAnim : Control
{
    private AnimationPlayer animPlayer;
    private Label lab;
    public override void _Ready()
    {

    }

    public void PlaynDestroy(String s)
    {
        animPlayer = GetNode<AnimationPlayer>("StatGrowthAnim");
        lab = GetNode<Label>("StatGrwthNum");
        lab.Text = s;
        animPlayer.Play("Grow");
    }

    private void _on_StatGrowthAnim_animation_finished()
    {
        QueueFree();
    }
}
