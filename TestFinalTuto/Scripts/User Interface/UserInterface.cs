using Godot;
using System;
using TestFinalTuto.Scripts.Entities;

public partial class UserInterface : CanvasLayer
{
	/*private Player _player;*/
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*_player = (Player)GetTree().GetFirstNodeInGroup("Players");
		_player.Connect("HealthUpdated", Callable.From(OnHealthBarValueChanged()));
		_globals.Connect("StatChange", Callable.From(UpdateStatText));
		_player.HealthUpdated += (health) => OnHealthBarValueChanged(position, direction);*/
		// TODO VOIR POUR PLUTOT PASSER PAR CE SCRIPT QUE LE SCRIPT LEVEL
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
