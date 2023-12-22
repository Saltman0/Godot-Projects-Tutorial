using Godot;
using System;

public partial class Entity : CharacterBody2D
{
	[Export]
	protected float _speed = 300.0f;
	
	[Export]
	protected int _health = 100;
	
	[Export]
	protected bool _isDead = false;
	
	public float Speed
	{
		get => _speed;
		set => _speed = value;
	}
	
	public int Health
	{
		get => _health;
		set => _health = value;
	}
	
	public bool IsDead
	{
		get => _isDead;
		set => _isDead = value;
	}
}
