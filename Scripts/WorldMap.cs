using Godot;
using System;

public class WorldMap : Control
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
    private void _on_BackButton_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
    }

    private void _on_Farm_pressed()
    {
        Global.currentStage = "Farm";
    }
    private void _on_Beach_pressed()
    {
        Global.currentStage = "Beach";
    }
    private void _on_River_pressed()
    {
        Global.currentStage = "River";
    }
    private void _on_MuntainBase_pressed()
    {
        Global.currentStage = "MountainBase";
    }
    private void _on_Swamp_pressed()
    {
        Global.currentStage = "Swamp";
    }
    private void _on_MountainTop_pressed()
    {
        Global.currentStage = "MountainTop";
    }
    private void _on_Forest_pressed()
    {
        Global.currentStage = "Forest";
    }
    private void _on_Castle_pressed()
    {
        Global.currentStage = "Castle";
    }
    private void _on_Spire_pressed()
    {
        Global.currentStage = "Spire";
    }
}
