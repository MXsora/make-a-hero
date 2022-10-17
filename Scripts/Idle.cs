using Godot;
using System;

public class Idle : Node
{
	private Node activeMenu;
	private Timer timer;
	private Label statLabel;
	private RichTextLabel details;
	private enum STATE {Health, Attack, Defense, Equipment, Magic, First};
	private STATE currentState;
	private AnimatedSprite idleAnims;
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private int currentStat;
	private int currentIncrease;
	private float currentMultiplier;

	private PackedScene StatPopUp = GD.Load<PackedScene>("res://Scenes/Idle/StatGrowthAnim.tscn");

	public override void _Ready()
	{
		statLabel = GetNode<Label>("StatDisplay");
		idleAnims = GetNode<AnimatedSprite>("IdleAnimations");
		details = GetNode<RichTextLabel>("Details");
		timer = GetNode<Timer>("Timer");
		currentState = STATE.First;
		stateChange(STATE.Health);
		rng.Randomize();
	}

	public override void _Process(float delta)
	{
		details.Text = "Current Stat Value: " + Health.baseStat.ToString();
		
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
		int x = (int)(currentIncrease * currentMultiplier);
		currentStat += x;
		StatGrowthAnim instance = (StatGrowthAnim)StatPopUp.Instance();
		AddChild(instance);
		instance.SetPosition(new Vector2 (rng.RandfRange(20,40),rng.RandfRange(20,40)));
		instance.PlaynDestroy(x.ToString());
	}

	private void IncreaseStat()
	{
		currentStat += (int)(currentIncrease * currentMultiplier);
	}
	
	private void stateChange (STATE s)
	{
		switch(currentState)
		{
			case STATE.Health:
				Health.baseStat = currentStat;
				Health.increaseBy = currentIncrease;
				Health.multiplier = currentMultiplier;
				break;
			case STATE.Attack:
				Attack.baseStat = currentStat;
				Attack.increaseBy = currentIncrease;
				Attack.multiplier = currentMultiplier;
				break;
			case STATE.Defense:
				Defense.baseStat = currentStat;
				Defense.increaseBy = currentIncrease;
				Defense.multiplier = currentMultiplier;
				break;
			case STATE.Equipment:
				Equipment.baseStat = currentStat;
				Equipment.increaseBy = currentIncrease;
				Equipment.multiplier = currentMultiplier;
				break;
			case STATE.Magic:
				Magic.baseStat = currentStat;
				Magic.increaseBy = currentIncrease;
				Magic.multiplier = currentMultiplier;
				break;
			case STATE.First:
				break;
		}
		switch (s)
		{
			case STATE.Health:
				currentState = STATE.Health;
				statLabel.Text = "Health";
				idleAnims.Frame = 0;
				currentStat = Health.baseStat;
				currentIncrease = Health.increaseBy;
				currentMultiplier = Health.multiplier;
				break;
			case STATE.Attack:
				currentState = STATE.Attack;
				statLabel.Text = "Attack";
				idleAnims.Frame = 1;
				currentStat = Attack.baseStat;
				currentIncrease = Attack.increaseBy;
				currentMultiplier = Attack.multiplier;
				break;
			case STATE.Defense:
				currentState = STATE.Defense;
				statLabel.Text = "Defense";
				idleAnims.Frame = 2;
				currentStat = Defense.baseStat;
				currentIncrease = Defense.increaseBy;
				currentMultiplier = Defense.multiplier;
				break;
			case STATE.Equipment:
				currentState = STATE.Equipment;
				statLabel.Text = "Equipment";
				idleAnims.Frame = 3;
				currentStat = Equipment.baseStat;
				currentIncrease = Equipment.increaseBy;
				currentMultiplier = Equipment.multiplier;
				break;
			case STATE.Magic:
				currentState = STATE.Magic;
				statLabel.Text = "Magic";
				idleAnims.Frame = 4;
				currentStat = Magic.baseStat;
				currentIncrease = Magic.increaseBy;
				currentMultiplier = Magic.multiplier;
				break;
		}
		timer.Start();
	}

}
