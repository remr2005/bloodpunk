using Godot;
using System;

public partial class SETTINGS : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += _on_settings_pressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_settings_pressed()
	{
		GetTree().ChangeSceneToFile("res://tscens/settings/settings.tscn");
	}
}
