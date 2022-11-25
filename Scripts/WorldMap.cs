using Godot;
using System;

public class WorldMap : Control
{
    private Node2D Cursor;
    private Label StageText;
    private Vector2[] CursorPositions = new Vector2[] { new Vector2(76,59), new Vector2(62,73)};

    public override void _Ready()
    {
        Cursor = GetNode<Node2D>("Cursor");
        StageText = GetNode<Label>("StageText");
        Cursor.Position = CursorPositions[1];
    }

    
    private void _on_BackButton_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Idle/Idle.tscn");
    }

    private void _on_Farm_pressed()
    {
        Global.currentStage = "Farm";
        GetTree().ChangeScene("res://Scenes/Menus/Active.tscn");
    }
    private void _on_Farm_mouse_entered()
    {
        Cursor.Position = CursorPositions[1];
    }
    private void _on_Beach_pressed()
    {
        Global.currentStage = "Beach";
    }
    private void _on_Beach_mouse_entered()
    {
        Cursor.Position = CursorPositions[2];
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
