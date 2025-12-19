using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class ScoreManager : Node
{

	private int _score = 0;
	private int _highScore = 0;

	private const string Score_File = "user://tappy.save";

	public static ScoreManager Instance { get; private set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		LoadScoreFromFile();
	}

	public static void AddScore(int amount)
	{
		Instance._score += amount;
		GD.Print($"Score: {Instance._score}");
	}

	public static int GetScore()
	{
		return Instance._score;
	}

	public static int GetHighScore()
	{
		return Instance._highScore;
	}

	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void SetScore(int score)
	{
		Instance._score = score;
		if(Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
		}

		GD.Print($"Score set to: {Instance._score}, High Score: {Instance._highScore}");
		SignalManager.EmitOnScored();
	}


	public static void IncreaseScore(int amount)
	{
		SetScore(GetScore() + amount);
	}

	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(Score_File, FileAccess.ModeFlags.Read);
		if(file != null)
		{
			string scoreString = file.GetAsText();
			if(int.TryParse(scoreString, out int savedHighScore))
			{
				_highScore = savedHighScore;
			}
			//_highScore = (int)file.Get32();
		}
	}
	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(Score_File, FileAccess.ModeFlags.Write);
		if(file != null)
		{
			file.StoreString(_highScore.ToString());
			//file.Store32((uint)_highScore);
		}
	}

	public override void _ExitTree()
	{
		SaveScoreToFile();
	}
}
