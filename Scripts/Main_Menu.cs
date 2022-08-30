using Godot;
using System;

public class Main_Menu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
private void _on_StartButton_pressed()
{
	GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
}


private void _on_OptionsButton_pressed()
{
	GetTree().ChangeScene("res://Scenes/Menus/Options.tscn");
}


private void _on_ExitButton_pressed()
{
	GetTree().Quit();
}

}



