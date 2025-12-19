using Godot;
using System;
using System.Reflection.Metadata;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	public static  float Scroll_Speed = 120.0f;	

	private  PackedScene _gamescene = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	private PackedScene _mainscene = GD.Load<PackedScene>("res://Scenes/Main.tscn");

	private PackedScene _complexscene = GD.Load<PackedScene>("res://Scenes/ComplexTrans.tscn");


	private PackedScene _nextScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static  void LoadMainMenu()
	{
		//Instance.GetTree().ChangeSceneToPacked(Instance._mainscene);
		LoadNextScene(Instance._mainscene);
	}


	public static  void LoadGame()
	{
		LoadNextScene(Instance._gamescene);
		//Instance.GetTree().ChangeSceneToPacked(Instance._gamescene);
	}

	public static void LoadComplexTransition()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._complexscene);
	}

	public static PackedScene GetNextScene()
	{
		return Instance._nextScene;
	}

	public static void LoadNextScene(PackedScene scene)
	{
		Instance._nextScene = scene;
		CanvasLayer cxt = (CanvasLayer)Instance._complexscene.Instantiate();
		Instance.AddChild(cxt);
		//Instance.GetTree().ChangeSceneToPacked(Instance._complexscene);
	}
}
