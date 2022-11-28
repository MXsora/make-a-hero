using Godot;
using System;

public class Active : Node
{
    private enum STATE {PlayerTurn, EnemyTurn}
    private AnimatedSprite IntroAnims;
    private AnimationPlayer FadeControl;
    private AnimationPlayer TransitionControl;
    private Control Intros;
    private ColorRect Transition;
    private Label TitleText;

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        IntroAnims = GetNode<AnimatedSprite>("Intros/Sprites");
        FadeControl = GetNode<AnimationPlayer>("Intros/AnimationPlayer");
        Intros = GetNode<Control>("Intros");
        Transition = GetNode<ColorRect>("Transition");
        TransitionControl = GetNode<AnimationPlayer>("Transition/AnimationPlayer");
        TitleText = GetNode<Label>("Intros/Label");
        Transition.Visible = true;
        Intros.Visible = true;
        switch (Global.currentStage)
        {
            case "Farm":
                IntroAnims.Animation = "Farm";
                TitleText.Text = ("HillShire Farm");
                break;
            case "Beach":
                //load from correct database
                break;
            case "River":
                //load from correct database
                break;
        }
        FadeControl.Play("Fade");
        await ToSignal(FadeControl, "animation_finished");
        FadeControl.Play("Title");
        await ToSignal(FadeControl, "animation_finished");
        FadeControl.PlayBackwards("Fade");
        await ToSignal(FadeControl, "animation_finished");
        Intros.Visible = false;
        TransitionControl.PlayBackwards("Transition");
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
