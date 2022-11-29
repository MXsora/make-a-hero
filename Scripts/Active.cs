using Godot;
using System;

public class Active : Node
{
    private enum STATE {PlayerTurn, EnemyTurn}
    private AnimatedSprite IntroAnims;
    private AnimationPlayer FadeControl;
    private AnimationPlayer TransitionControl;
    private Control Intros;
    private Control CutInControl;
    private AnimationPlayer CutIns;
    private ColorRect Transition;
    private Label TitleText;
    private Timer TimeKeeper;
    private bool IsPlayersTurn;
    private PackedScene StatPopUp = GD.Load<PackedScene>("res://Scenes/Idle/StatGrowthAnim.tscn");


    public override async void _Ready()
    {
        IntroAnims = GetNode<AnimatedSprite>("Intros/Sprites");
        FadeControl = GetNode<AnimationPlayer>("Intros/AnimationPlayer");
        Intros = GetNode<Control>("Intros");
        Transition = GetNode<ColorRect>("Transition");
        TransitionControl = GetNode<AnimationPlayer>("Transition/AnimationPlayer");
        TitleText = GetNode<Label>("Intros/Label");
        CutIns = GetNode<AnimationPlayer>("TurnCutIns/AnimationPlayer");
        CutInControl = GetNode<Control>("TurnCutIns");
        TimeKeeper = GetNode<Timer>("Timer");
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
        IsPlayersTurn = true;
        
    }

    private async void EnemyAction()
    {
        TimeKeeper.Start(1);
        StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		AddChild(instance);
		instance.SetPosition(new Vector2 (25,36));
		instance.PlaynDestroy("10");
		instance.QueueFree();
        ChangeTurns();
        await ToSignal(TimeKeeper, "timeout");
    }
    private async void ChangeTurns()
    {
        if(IsPlayersTurn)
        {
            CutInControl.Visible = true;
            CutIns.Play("EnemyTurn");
            await ToSignal(CutIns, "animation_finished");
            IsPlayersTurn = false;
            CutInControl.Visible = false;
            EnemyAction();
        }
        CutInControl.Visible = true;
        CutIns.Play("PlayerTurn");
        await ToSignal(CutIns, "animation_finished");
        IsPlayersTurn = true;
        CutInControl.Visible = false;
    }
    private int CalculateDamage(int dmg, int def)
    {
        return dmg*(100/(100+def));
    }
    private void _on_AttackButton_pressed()
    {
        if(IsPlayersTurn)
        {
            StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		    AddChild(instance);
		    instance.SetPosition(new Vector2 (118,36));
		    instance.PlaynDestroy("10");
		    instance.QueueFree();
            ChangeTurns();
        }
    }
    private void _on_DefenseButton_pressed()
    {
        ChangeTurns();
    }
    private void _on_MagicButton_pressed()
    {
        ChangeTurns();
    }
    private void _on_RetreatButton_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
    }
}
