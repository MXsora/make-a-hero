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

    private Player player;
    private Monster monster;


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
        player = GetNode<Player>("Player");
        monster = GetNode<Monster>("Monster");
        Transition.Visible = true;
        Intros.Visible = true;
        MusicManager.PlayBattleTheme();
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

    private void EnemyAction()
    {
        int enemdmg = CalculateDamage(monster.attack, player.defense);
        StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		AddChild(instance);
		instance.SetPosition(new Vector2 (25,36));
		instance.PlaynDestroy(enemdmg.ToString(), true);
        player.currentHealth -= enemdmg;
        if(player.currentHealth <= 0)
        {
            //respawn at idle
        }
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
            CutInControl.Visible = true;
            CutIns.Play("PlayerTurn");
            await ToSignal(CutIns, "animation_finished");
            player.defense = Defense.baseStat;
            IsPlayersTurn = true;
            CutInControl.Visible = false;
        }
    }
    private int CalculateDamage(int dmg, int def)
    {
        float defcalc = (100f/(100f+def));
        return (int)(dmg*defcalc);
    }
    private async void _on_AttackButton_pressed()
    {
        if(IsPlayersTurn)
        {
            int playerdmg = CalculateDamage(player.attack, monster.defense);
            StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		    AddChild(instance);
		    instance.SetPosition(new Vector2 (118,36));
		    instance.PlaynDestroy(playerdmg.ToString(), true);
            monster.currentHealth -= playerdmg;
            if(monster.currentHealth <= 0)
            {
                monster.Visible = false;
                CutIns.Play("Win");
                CutInControl.Visible = true;
                await ToSignal(CutIns, "animation_finished");
                TransitionControl.Play("Transition");
                await ToSignal(TransitionControl, "animation_finished");
                GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
            }
            ChangeTurns();
        }
    }
    private void _on_DefenseButton_pressed()
    {
        if(IsPlayersTurn)
        {
            player.defense = player.defense*2;
            ChangeTurns();
        }
    }
    private void _on_MagicButton_pressed()
    {
        if(IsPlayersTurn)
        {
            ChangeTurns();
        }
    }
    private void _on_RetreatButton_pressed()
    {
        if(IsPlayersTurn)
        {
            GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
        }
    }
}
