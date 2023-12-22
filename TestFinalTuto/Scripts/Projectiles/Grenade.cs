using Godot;
using System;
using TestFinalTuto.Scripts.Entities;

public partial class Grenade : RigidBody2D
{
	[Signal]
	public delegate void GrenadeExplodedEventHandler(Grenade grenade);
	
	private Vector2 _direction;
	
	[Export]
	private int _speed = 800;
	
	[Export]
	private int _damage = 50;

	public Vector2 Direction
	{
		get => _direction;
		set => _direction = value;
	}

	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LinearVelocity = _direction * _speed;
		if (_speed > 0)
		{
			_speed -= 10;
		}
	}

	public void OnGrenadeTimerTimeout()
	{
		GetNode<Sprite2D>("GrenadeSprite").Visible = false;
		GetNode<CollisionShape2D>("GrenadeCollision").Disabled = true;
		GetNode<PointLight2D>("GrenadeLight").Visible = false;
		
		GetNode<Area2D>("GrenadeExplosion").Visible = true;
		GetNode<CollisionShape2D>("GrenadeExplosion/GrenadeExplosionCollision").Disabled = false;
		GetNode<AnimatedSprite2D>("GrenadeExplosion/GrenadeExplosionAnimatedSprite").Play();
	}

	public void OnGrenadeExplosionBodyEntered(Node2D body)
	{
		if (body is Player player) player.Hit(_damage);
		if (body is Scout scout) scout.Hit(_damage);
	}

	public void OnGrenadeExplosionAnimationFinished()
	{
		QueueFree();
	}
}
