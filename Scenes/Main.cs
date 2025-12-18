using Godot;
using System;

public partial class Main : Control
{
	//private static readonly PackedScene Game_Scene = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("fly"))
		{
			//GetTree().ChangeSceneToPacked(Game_Scene);
			GameManager.LoadGame();
		}
	}
}
