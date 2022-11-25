using Godot;
using System;

public class MainMenu : Control
{
	private AnimationPlayer TransRect;
	private ColorRect TransColor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TransRect = GetNode<AnimationPlayer>("Transition/AnimationPlayer");
		TransColor = GetNode<ColorRect>("Transition");
		TransColor.Visible = true;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private async void _on_StartButton_pressed()
	{
		TransRect.Play("Transition");
		await ToSignal(TransRect, "animation_finished");
		GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");

	}


	private async void _on_OptionsButton_pressed()
	{
		TransRect.Play("Transition");
		await ToSignal(TransRect, "animation_finished");
		GetTree().ChangeScene("res://Scenes/Menus/OptionMenu.tscn");
	}


	private async void _on_ExitButton_pressed()
	{
		TransRect.Play("Transition");
		await ToSignal(TransRect, "animation_finished");
		GetTree().Quit();
	}
}



