using Godot;
using System;

public class Active : Node
{
    private enum STATE {Attack, Defense, Magic}

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        switch (Global.currentStage)
        {
            case "Beach":
                //load from correct database
                break;
        }
                
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
