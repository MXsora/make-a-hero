using Godot;
using System;

public class Transition : ColorRect
{
    public AnimationPlayer AnimPlay;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AnimPlay = GetNode<AnimationPlayer>("AnimationPlayer");
        AnimPlay.PlayBackwards("Transition");
    }

    public async void TransOut()
    {
        AnimPlay.Play("Transition");
        await ToSignal(AnimPlay, "animation_finished");
    }

    public async void TransIn()
    {
        AnimPlay.PlayBackwards("Transition");
        await ToSignal(AnimPlay, "animation_finished");
    }
}
