using Godot;
using System;
using TestFinalTuto.Scripts.Entities;

public partial class Drone : Enemy
{
	private AnimationPlayer _animationPlayer;
	
	[Export]
	private int _explosionDamage;

	private bool _canMove = false;

	private Player _player;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_player = (Player)GetTree().GetFirstNodeInGroup("Players");
	}
	
	public override void _Process(double delta)
	{
		if (_canMove)
		{
			Velocity = Position.DirectionTo(_player.Position) * Speed;
			MoveAndSlide();
		}
	}
	
	public void OnDetectionAreaBodyEntered(Player player)
	{
		_canMove = true;
	}

	public void OnDetectionAreaBodyExited(Player player)
	{
		_canMove = false;
	}
	
	public void OnEnableExplosionAreaBodyEntered(Player player)
	{
		_animationPlayer.Play("Blink");
	}
	
	public void OnExplosionAreaBodyEntered(Player player)
	{
		player.Health -= _explosionDamage;
	}
	
	public void PlayExplosionAnimation()
	{
		_animationPlayer.Play("Explosion");
	}
}
