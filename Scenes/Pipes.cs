using Godot;
using System;

public partial class Pipes : Node2D
{

	[Export] private float Scroll_Speed = 120.0f;	
	[Export] private VisibleOnScreenNotifier2D _screenNotifier;

	[Export] private Area2D _pipeUpper;
	[Export] private Area2D _pipeLower;

	[Export] private Area2D _laser;



    private void OnScreenExited()
	{
		GD.Print("Pipe exited screen, freeing...");
		QueueFree();
	}


	private void OnPlaneDied()
	{
		SetProcess(false);
	}




	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ 
		_screenNotifier.ScreenExited += OnScreenExited;

		_pipeLower.BodyEntered += OnPipeBodyEntered;
		_pipeUpper.BodyEntered += OnPipeBodyEntered;
		_laser.BodyEntered += OnLaserBodyEntered;


		SignalManager.Instance.OnPlaneDied  += OnPlaneDied;
		
	}

	
    public override void _ExitTree()
    {
        SignalManager.Instance.OnPlaneDied  -= OnPlaneDied;
    }

	public void OnPipeBodyEntered(Node2D body)
	{
		GD.Print("Pipe body entered: " + body.Name);
		// if (body is Plane)
		// {
		// 	GD.Print("Plane hit pipe , died!");
		// 	(body as Plane).Die();
		// }

		if (body.IsInGroup("plane"))
		{
			GD.Print("Plane hit pipe , died!   in plane group");
			(body as Plane).Die();
		}
	}

	public void OnLaserBodyEntered(Node2D body)
	{
		GD.Print("Laser body entered: " + body.Name);
		if (body is Plane)
		{
			GD.Print("Plane hit laser, game over!");
			//(body as Plane).Die();
			ScoreManager.IncreaseScore(1);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 position = Position;
		position.X -= Scroll_Speed * (float)delta;
		Position = position;
	}
}
