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

    public void TransOut()
    {
        AnimPlay.Play("Transition");
    }

    public void TransInNOut()
    {
        AnimPlay.Play("Transition");
        AnimPlay.PlayBackwards("Transition");
    }
}
