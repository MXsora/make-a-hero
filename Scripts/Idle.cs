using Godot;
using System;

public class Idle : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Node activeMenu;
	private Timer Timer;
	private Label statLabel;
	private enum STATE {Health, Attack, Defense, Equipment, Magic};
	private STATE currentState;
	private AnimatedSprite idleAnims;
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private int currentStat;
	private int currentIncrease;
	private float currentMultiplier;

	private PackedScene StatPopUp = GD.Load<PackedScene>("res://Scenes/Idle/StatGrowthAnim.tscn");
	private Node attScript;
	private Node helScript;
	private Node defScript;
	private Node equScript;
	private Node magScript;


	public override void _Ready()
	{
		attScript = GetNode<Node>("Attack");
		helScript = GetNode<Node>("Health");
		defScript = GetNode<Node>("Defense");
		equScript = GetNode<Node>("Equipment");
		magScript = GetNode<Node>("Magic");
		
		statLabel = GetNode<Label>("StatDisplay");
		idleAnims = GetNode<AnimatedSprite>("IdleAnimations");
		stateChange(STATE.Health);
		rng.Randomize();
	}

	private void _on_HealthButton_pressed()
	{
		stateChange(STATE.Health);
	}


	private void _on_AttackButton_pressed()
	{
		stateChange(STATE.Attack);
	}


	private void _on_DefenseButton_pressed()
	{
		stateChange(STATE.Defense);
	}


	private void _on_EquipmentButton_pressed()
	{
		stateChange(STATE.Equipment);
	}


	private void _on_MagicButton_pressed()
	{
		stateChange(STATE.Magic);
	}


	private void _on_MenuButton_pressed()
	{
		GetTree().ChangeScene("res://Scenes/Menus/MainMenu.tscn");
	}


	private void _on_ShopButton_pressed()
	{
		// Replace with function body.
	}

	private void _on_ActionButton_pressed()
	{
		 GetTree().ChangeScene("res://Scenes/Menus/WorldMap.tscn");
	}

	private void _on_Timer_timeout()
	{
		StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		AddChild(instance);
		instance.PlaynDestroy("1");
		instance.SetPosition(new Vector2 (rng.RandfRange(20,40),rng.RandfRange(20,40)));
	}

	private void IncreaseStat()
	{
		currentStat += (int)(currentIncrease * currentMultiplier);
	}
	
	//private void _on_HealthButton_toggled(bool button_pressed)
	//{
		// Replace with function body.
	//}
	private void stateChange (STATE s)
	{
		switch (s)
		{
			case STATE.Health:
				currentState = STATE.Health;
				statLabel.Text = "Health";
				idleAnims.Frame = 0;
				currentStat = 0;
				break;
			case STATE.Attack:
				currentState = STATE.Attack;
				statLabel.Text = "Attack";
				idleAnims.Frame = 1;
				break;
			case STATE.Defense:
				currentState = STATE.Defense;
				statLabel.Text = "Defense";
				idleAnims.Frame = 2;
				break;
			case STATE.Equipment:
				currentState = STATE.Equipment;
				statLabel.Text = "Equipment";
				idleAnims.Frame = 3;
				break;
			case STATE.Magic:
				currentState = STATE.Magic;
				statLabel.Text = "Magic";
				idleAnims.Frame = 4;
				break;
		}
	}

}
