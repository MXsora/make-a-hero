using Godot;
using System;

public class Idle : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Node activeMenu;
	private Timer Timer;
	private Label mainStat;
	private enum STATE {Health, Attack, Defense, Equipment, Magic};
	private STATE currentState;
	private AnimatedSprite idleAnims;
	private RandomNumberGenerator rng = new RandomNumberGenerator();

	private PackedScene StatPopUp = GD.Load<PackedScene>("res://Scenes/Idle/StatGrowthAnim.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mainStat = (Label)GetNode("StatDisplay");
		currentState = STATE.Health;
		idleAnims = GetNode<AnimatedSprite>("IdleAnimations");
		mainStat.Text = "Health";
		idleAnims.Frame = 0;
		rng.Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	/*public override void _Process(float delta)
	{
		switch (currentState)
		{
			case STATE.HEALTH:
				mainStat.Text = "Health";
				idleAnims.Frame = 0;
				break;
			case STATE.ATTACK:
				mainStat.Text = "Attack";
				idleAnims.Frame = 1;
				break;
			case STATE.DEFENSE:
				mainStat.Text = "Defense";
				idleAnims.Frame = 2;
				break;
			case STATE.EQUIPMENT:
				mainStat.Text = "Equipment";
				idleAnims.Frame = 3;
				break;
			case STATE.MAGIC:
				mainStat.Text = "Magic";
				idleAnims.Frame = 4;
				break;
		}
	}*/

	private void _on_HealthButton_pressed()
	{
		mainStat.Text = "Health";
		idleAnims.Frame = 0;
		stateChange(STATE.Health);
	}


	private void _on_AttackButton_pressed()
	{
		mainStat.Text = "Attack";
		idleAnims.Frame = 1;
		stateChange(STATE.Health);
	}


	private void _on_DefenseButton_pressed()
	{
		mainStat.Text = "Defense";
		idleAnims.Frame = 2;
		stateChange(STATE.Health);
	}


	private void _on_EquipmentButton_pressed()
	{
		mainStat.Text = "Equipment";
		idleAnims.Frame = 3;
		stateChange(STATE.Health);
	}


	private void _on_MagicButton_pressed()
	{
		mainStat.Text = "Magic";
		idleAnims.Frame = 4;
		stateChange(STATE.Health);
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
				break;
			case STATE.Attack:
				currentState = STATE.Attack;
				break;
			case STATE.Defense:
				currentState = STATE.Defense;
				break;
			case STATE.Equipment:
				currentState = STATE.Equipment;
				break;
			case STATE.Magic:
				currentState = STATE.Magic;
				break;
		}
	}

}
