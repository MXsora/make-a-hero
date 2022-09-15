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
	private enum STATE {HEALTH, ATTACK, DEFENSE, EQUIPMENT, MAGIC};
	private STATE currentState;
	private AnimatedSprite idleAnims;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mainStat = (Label)GetNode("StatDisplay");
		currentState = STATE.HEALTH;
		idleAnims = GetNode<AnimatedSprite>("IdleAnimations");
		mainStat.Text = "Health";
		idleAnims.Frame = 0;
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
	}


	private void _on_AttackButton_pressed()
	{
		mainStat.Text = "Attack";
		idleAnims.Frame = 1;
	}


	private void _on_DefenseButton_pressed()
	{
		mainStat.Text = "Defense";
		idleAnims.Frame = 2;
	}


	private void _on_EquipmentButton_pressed()
	{
		mainStat.Text = "Equipment";
		idleAnims.Frame = 3;
	}


	private void _on_MagicButton_pressed()
	{
		mainStat.Text = "Magic";
		idleAnims.Frame = 4;
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
	
	//private void _on_HealthButton_toggled(bool button_pressed)
	//{
		// Replace with function body.
	//}
	private void stateChange (STATE s)
	{
		switch (s)
		{
			case STATE.HEALTH:
				currentState = STATE.HEALTH;
				break;
			case STATE.ATTACK:
				currentState = STATE.HEALTH;
				break;
			case STATE.DEFENSE:
				currentState = STATE.HEALTH;
				break;
			case STATE.EQUIPMENT:
				currentState = STATE.HEALTH;
				break;
			case STATE.MAGIC:
				currentState = STATE.HEALTH;
				break;
		}
	}

}
