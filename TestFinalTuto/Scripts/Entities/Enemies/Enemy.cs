using Godot;
using System;
using TestFinalTuto.Scripts.Entities;

public partial class Enemy : Entity
{
	private Player _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = (Player)GetTree().GetFirstNodeInGroup("Players");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public Player Player
	{
		get => _player;
		set => _player = value;
	}
}