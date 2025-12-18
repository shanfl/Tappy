using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	private  PackedScene _gamescene = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	private PackedScene _mainscene = GD.Load<PackedScene>("res://Scenes/Main.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static  void LoadMainMenu()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._mainscene);
	}


	public static  void LoadGame()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._gamescene);
	}
}
