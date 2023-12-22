using Godot;
using System;
using TestFinalTuto.Scripts.Entities;

public partial class Laser : Area2D
{
	[Export]
	private int _speed = 1000;
	
	[Export]
	private int _damage = 10;
	
	private Vector2 _direction;

	public Vector2 Direction
	{
		get => _direction;
		set => _direction = value;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += _direction * _speed * (float)delta;
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body is Player player) player.Hit(_damage);
		if (body is Scout scout) scout.Hit(_damage);
		QueueFree();
	}

	public void OnLaserTimerTimeout()
	{
		QueueFree();
	}
}
