using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	[Export] public float Grivaty = 9.8f;
	[Export] public float Power = -450.0f;

	[Export] public AnimationPlayer _aniplayer;

	//[Signal] public delegate void OnPlaneDiedEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//OnPlaneDied += Die;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += Grivaty;

		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = Power;
			//GetNode<AnimationPlayer>("AnimationPlayer").Play("power");
			_aniplayer.Play("power");
		}

		Velocity = velocity;
		
		MoveAndSlide();

		if (IsOnFloor())
		{
			
			Die();
		}
	}

	public void Die()
	{
		SetPhysicsProcess(false);
		GD.Print("Die");
		//EmitSignal(SignalName.OnPlaneDied);
		SignalManager.EmitOnPlaneDied();
	}
}
