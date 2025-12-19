using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class Game : Node2D
{
	//private static readonly PackedScene Main_Scene = GD.Load<PackedScene>("res://Scenes/Main.tscn");
	[Export] private Node2D _pipesHolder;
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;

	[Export] private PackedScene _pipeScene;

	[Export] private float _spawnInterval = 2.0f;
	[Export] private Timer _spawnTimer;

	//[Export] private Plane _plane;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Game Ready"); 
		//_gameOver = false;
		_spawnTimer.Timeout += SpawnPipes;
		//_plane.OnPlaneDied += GameOver;
		SignalManager.Instance.OnPlaneDied += GameOver;

		//SignalManager.Instance.Connect(SignalManager.SignalName.OnPlaneDied, Callable.From(GameOver));

		ScoreManager.ResetScore();

		CallDeferred("DeferStuff");
	}

	private void DeferStuff()
	{
		GD.Print("Defer Stuff called");
	}

    public override void _ExitTree()
    {
        SignalManager.Instance.OnPlaneDied -= GameOver;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{ 
		// if(_gameOver && Input.IsActionJustPressed("fly"))
		// {
		// 	ChangeToMainScene();
		// }

		if(Input.IsKeyPressed(Key.Q))
		{
			ChangeToMainScene();
		}
	}

	// private void StopPipesSpawning()
	// {
		

	// 	// foreach (Pipes pipe in _pipesHolder.GetChildren())
	// 	// {
	// 	// 	pipe.SetProcess(false);
	// 	// }
	// }

	private void GameOver()
	{
		GD.Print("Game Over!");
		_spawnTimer.Stop();
		//StopPipesSpawning();

		//_gameOver = true;
		
	}

	//private bool _gameOver = false;
	private void ChangeToMainScene()
	{
		//GetTree().ChangeSceneToPacked(Main_Scene);	
		GameManager.LoadMainMenu();
	}

	public float GetSpawnY()
	{
		return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y)	;
	}

	private void SpawnPipes()
	{
		GD.Print("Spawning Pipes...");
		Pipes pipeInstance = (Pipes)_pipeScene.Instantiate<Pipes>();		
		_pipesHolder.AddChild(pipeInstance);
		float spawnY = GetSpawnY();		
		pipeInstance.Position = new Vector2(_spawnUpper.Position.X, spawnY);
	}


}
