using Godot;
using System;

public class Monster : AnimatedSprite
{
    int health;
    int attack;
    int speed;
    public Node Database;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Database = GetNode<Node>("Database");
        health = 10;
        attack = 10;
        speed = 1;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
