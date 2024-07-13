using Godot;
using System;

public partial class Ship : RigidBody2D
{
	public float speed { get; set; } = 400;

    public Vector2 ScreenSize;

	private bool choose = false;

	private bool action_ = false;

	private Vector2 newpos;

	private Vector2 procent;
    public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Left_Mouse") && !choose)
		{
            choose = true;
		}
		if (Input.IsActionPressed("Right_Mouse") && choose && !action_)
		{
            float gip = (float)Math.Sqrt(Math.Pow(newpos.X - Position.X, 2) + Math.Pow(newpos.Y - Position.Y, 2));
			newpos = GetGlobalMousePosition();
			procent.X = (newpos.X - Position.X) / gip;
			procent.Y = (newpos.Y - Position.Y) / gip;
			var velocity = Vector2.Zero;
			velocity.X = procent.X;
			velocity.Y = procent.Y;
			velocity = velocity.Normalized() * speed;
			action_ = true;
		}
		if (action_)
		{
			var Sprite2D = GetNode<Sprite2D>("Sprite2D");
        }
	}
}
