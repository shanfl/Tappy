using Godot;
using System;

public partial class ComplexTrans : CanvasLayer
{
	[Export] private AnimationPlayer _animPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{		
		_animPlayer.AnimationFinished += OnAnimationFinished;
	}

    private void OnAnimationFinished(StringName animName)
    {
       QueueFree();
    }


	private void SwitchScene()
	{
		GD.Print("Switching Scene");
		GetTree().ChangeSceneToPacked(GameManager.GetNextScene());
	}
}
