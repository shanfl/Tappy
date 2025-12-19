using Godot;
using System;

public partial class GameOver : Control
{
	[Export] private Label _gameoverLabel;
	[Export] private Label _spaceLabel;
	[Export] private Timer _timer;

	private bool _enableChange = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameoverLabel.Visible = true;
		_spaceLabel.Visible = false;
		_timer.Timeout += OnTimerTimeout;

		


		SignalManager.Instance.OnPlaneDied += OnPlaneDied;

	}

	public override void _ExitTree()
    {
        SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
    }

    private void OnPlaneDied()
    {
        _timer.Start();
		Visible = true;
		Show();	
    }


    private void OnTimerTimeout()
    {
		_gameoverLabel.Visible = false;
		_spaceLabel.Visible = true;
		_enableChange = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("fly") && _enableChange)
		{
			GameManager.LoadMainMenu();
		}
	}
}
