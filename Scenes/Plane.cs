using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	[Export] public float Grivaty = 9.8f;
	[Export] public float Power = -450.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += Grivaty;

		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = Power;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
