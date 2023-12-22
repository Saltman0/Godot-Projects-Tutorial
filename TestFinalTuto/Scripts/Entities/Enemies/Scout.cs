using Godot;
using System;
using TestFinalTuto.Factory;
using TestFinalTuto.Scripts.Entities;

public partial class Scout : Entity
{
	private bool _canShoot = false;

	private Player _player;
	
	private Timer _timer;
	
	[Signal]
	public delegate void FiredLaserEventHandler(Vector2 position, Vector2 direction);

	public override void _Ready()
	{
		_player = (Player)GetTree().GetFirstNodeInGroup("Players");
	}
	
	public override void _Process(double delta)
	{
		_timer = GetNode<Timer>("Timer");

		if (!_player.IsDead)
		{
			LookAt(_player.Position);
		
			// Tire un laser
			if (_timer.TimeLeft == 0 && _canShoot)
			{
				EmitSignal(
					SignalName.FiredLaser, 
					GetNode<Marker2D>("LeftLaserMarker").GlobalPosition, 
					(_player.Position - Position).Normalized()
				);
				EmitSignal(
					SignalName.FiredLaser, 
					GetNode<Marker2D>("RightLaserMarker").GlobalPosition, 
					(_player.Position - Position).Normalized()
				);
				_timer.Start();
			}
		}
	}

	public void Hit(int damage)
	{
		_health -= damage;
		if (_health <= 0) QueueFree();
	}

	public void OnDetectionAreaBodyEntered(Player player)
	{
		_canShoot = true;
	}
	
	public void OnDetectionAreaBodyExited(Player player)
	{
		_canShoot = false;
	}
}
