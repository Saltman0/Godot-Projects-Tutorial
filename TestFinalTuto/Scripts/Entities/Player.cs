namespace TestFinalTuto.Scripts.Entities;

using Godot;
using System;

public partial class Player : Entity
{
	[Export]
	private int _nbLaser = 5;

	[Export]
	private int _nbGrenade = 1;
	
	private Timer _laserTimer;
	
	private Timer _grenadeTimer;
	
	[Signal]
	public delegate void FiredLaserEventHandler(Vector2 position, Vector2 direction);
	
	[Signal]
	public delegate void ThrowedGrenadeEventHandler(Vector2 position, Vector2 direction);

	[Signal]
	public delegate void HealthUpdatedEventHandler(int health);
	
	[Signal]
	public delegate void NbLaserUpdatedEventHandler(int nbLaser);
	
	[Signal]
	public delegate void NbGrenadeUpdatedEventHandler(int nbGrenade);

	public new int Health
	{
		get => _health;
		set {
			_health = value;
			EmitSignal(SignalName.HealthUpdated, _health);
		}
	}
	
	public new bool IsDead
	{
		get => _isDead;
		set {
			_isDead = value;
			Modulate = new Color("FF0000");
		}
	}
	
	public int NbLaser
	{
		get => _nbLaser;
		set {
			_nbLaser = value;
			EmitSignal(SignalName.NbLaserUpdated, _nbLaser);
		}
	}
	
	public int NbGrenade
	{
		get => _nbGrenade;
		set {
			_nbGrenade = value;
			EmitSignal(SignalName.NbGrenadeUpdated, _nbGrenade);
		}
	}
	
	/**
	 * Reçoit des dégâts
	 */
	public void Hit(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			IsDead = true;
		}
	}

	public override void _Ready()
	{
		_laserTimer = GetNode<Timer>("LaserTimer");
		_grenadeTimer = GetNode<Timer>("GrenadeTimer");
		EmitSignal(SignalName.HealthUpdated, Health);
		EmitSignal(SignalName.NbLaserUpdated, NbLaser);
		EmitSignal(SignalName.NbGrenadeUpdated, NbGrenade);
	}

	public override void _Process(double delta)
	{
		// Déplace le joueur
		Velocity = Input.GetVector("move_left", "move_right", "move_up", "move_down") * _speed;
		MoveAndSlide();
		
		// Regarde vers le clic de la souris
		LookAt(GetGlobalMousePosition());

		// Tire un laser lorsque le bouton principal est enclenché
		if (Input.IsActionJustPressed("primary action") && NbLaser > 0 && _laserTimer.TimeLeft == 0)
		{
			EmitSignal(
				SignalName.FiredLaser, 
				GetNode<Marker2D>("PlayerMarker").GlobalPosition, 
				(GetGlobalMousePosition() - Position).Normalized()
			);
			NbLaser--;
			_laserTimer.Start();
		}
		
		// Lance une grenade lorsque le bouton secondaire est enclenché
		if (Input.IsActionJustPressed("secondary action") && NbGrenade > 0 && _grenadeTimer.TimeLeft == 0)
		{
			EmitSignal(
				SignalName.ThrowedGrenade, 
				GetNode<Marker2D>("PlayerMarker").GlobalPosition, 
				(GetGlobalMousePosition() - Position).Normalized()
			);
			NbGrenade--;
			_grenadeTimer.Start();
		}
	}
}
