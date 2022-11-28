using Godot;
using System;

public class Player : AnimatedSprite
{
    int health;
    int attack;
    int defense;
    int magic;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        health = Health.baseStat;
        attack = Attack.baseStat;
        defense = Defense.baseStat;
        magic = Magic.baseStat;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
