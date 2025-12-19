using Godot;
using System;
using System.ComponentModel;

public partial class Parallax2d : Parallax2D
{
	[Export] private Texture2D _texture;
	[Export] private Sprite2D _sprite;
	[Export] private float _speedScale;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Autoscroll = new Vector2(-GameManager.Scroll_Speed * _speedScale, 0);
		float scalefactor = GetViewportRect().Size.Y / _texture.GetSize().Y;

		_sprite.Texture = _texture;
		_sprite.Scale = new Vector2(scalefactor, scalefactor);
		RepeatSize = new Vector2(_texture.GetSize().X * scalefactor, _texture.GetSize().Y * scalefactor);


		SignalManager.Instance.OnPlaneDied += OnPlaneDied;
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
	}

    private void OnPlaneDied()
    {
        Autoscroll = Vector2.Zero;
    }

}
