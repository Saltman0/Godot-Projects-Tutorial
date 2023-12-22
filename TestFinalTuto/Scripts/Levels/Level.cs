using Godot;
using System;
using TestFinalTuto.Factory;
using TestFinalTuto.Scripts.Entities;

public partial class Level : Node2D
{
	private Node2D _projectiles;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_projectiles = GetNode<Node2D>("Projectiles");
		foreach (Scout scout in GetTree().GetNodesInGroup("Scouts"))
		{
			scout.FiredLaser += (position, direction) => OnScoutFiredLaser(position, direction);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/**
	 * Evénement qui se produit lorsqu'un laser est tiré par un joueur
	 */
	public void OnPlayerFiredLaser(Vector2 position, Vector2 direction)
	{
		_projectiles.AddChild(LaserFactory.CreateLaser(position, direction));
	}
	
	/**
	 * Evénement qui se produit lorsqu'une grenade est lancée
	 */
	public void OnPlayerThrowedGrenade(Vector2 position, Vector2 direction)
	{
		_projectiles.AddChild(GrenadeFactory.CreateGrenade(position, direction));
	}
	
	/**
	 * Evénement qui se produit lorsqu'un laser est tiré par un scout
	 */
	public void OnScoutFiredLaser(Vector2 position, Vector2 direction)
	{
		_projectiles.AddChild(LaserFactory.CreateLaser(position, direction));
	}

	public void OnPlayerHealthUpdated(int health)
	{
		GetNode<TextureProgressBar>("UserInterface/HealthBar").Value = health;
	}
	
	public void OnPlayerNbLaserUpdated(int nbLaser)
	{
		GetNode<Label>("UserInterface/Panel/LaserCounter/LaserLabel").Text = nbLaser.ToString();
	}

	public void OnPlayerNbGrenadeUpdated(int nbGrenade)
	{
		GetNode<Label>("UserInterface/Panel/GrenadeCounter/GrenadeLabel").Text = nbGrenade.ToString();
	}
}
