using Godot;
using System;
using System.ComponentModel;

public partial class Game : Node2D
{
	[Export] private Node2D _pipesHolder;
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;

	[Export] private PackedScene _pipeScene;

	[Export] private float _spawnInterval = 2.0f;
	[Export] private Timer _spawnTimer;

	[Export] private Plane _plane;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print($"GetSpawnY()");

		_spawnTimer.Timeout += SpawnPipes;
		_plane.OnPlaneDied += GameOver;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void StopPipesSpawning()
	{
		_spawnTimer.Stop();

		foreach (Pipes pipe in _pipesHolder.GetChildren())
		{
			pipe.SetProcess(false);
		}
	}

	private void GameOver()
	{
		GD.Print("Game Over!");
		StopPipesSpawning();
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
