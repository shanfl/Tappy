using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Hud : Control
{
	[Export] private Label _scoreLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("HUD Ready");
		SignalManager.Instance.OnScored += OnScoreChanged;
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnScored -= OnScoreChanged;
	}

    private void OnScoreChanged()
    {
        _scoreLabel.Text = $"{ScoreManager.GetScore():0000}";
    }

}
