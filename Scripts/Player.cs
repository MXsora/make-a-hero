using Godot;
using System;

public class Player : AnimatedSprite
{
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public int magic;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        maxHealth = Health.baseStat;
        currentHealth = maxHealth;
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
