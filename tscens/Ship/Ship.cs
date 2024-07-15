using Godot;
using System;

public partial class Ship : RigidBody2D
{
	public float speed { get; set; } = 400;

    public Vector2 ScreenSize;

	private float gip;


    private bool choose = false;

	private bool action_ = false;

	private Vector2 startpos;

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
            gip = (float)Math.Sqrt(Math.Pow(newpos.X - Position.X, 2) + Math.Pow(newpos.Y - Position.Y, 2));
			newpos = GetGlobalMousePosition();
            startpos.X = Position.X;
            startpos.Y = Position.Y;
            procent.X = (newpos.X - Position.X) / gip;
			procent.Y = (newpos.Y - Position.Y) / gip;
			action_ = true;
		}
        GD.Print(GlobalPosition.X);
        if (action_)
		{
            var velocity = Vector2.Zero;
            var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            GD.Print(GlobalPosition.X);
            velocity.X += (newpos.X - Position.X) / gip;
            velocity.Y += (newpos.Y - Position.Y) / gip;
            velocity = velocity.Normalized() * speed;
            animatedSprite2D.Play();
            Position += velocity * (float)delta;
            Position = new Vector2(
                x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
                y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
            );
			GD.Print(GlobalPosition.X);
			action_ = false;
        }
        GD.Print(startpos.X);
        GD.Print(startpos.X);
    }
}
