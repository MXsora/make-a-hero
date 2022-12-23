using Godot;
using System;

public class Monster : AnimatedSprite
{
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public Node Database;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Database = GetNode<Node>("Database");
        maxHealth = 20;
        currentHealth = maxHealth;
        attack = 10;
        defense = 1;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
