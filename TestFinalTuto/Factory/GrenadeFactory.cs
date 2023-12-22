using Godot;

namespace TestFinalTuto.Factory;

public class GrenadeFactory
{
    /**
     * Crée une grenade
     */
    public static Grenade CreateGrenade(Vector2 position, Vector2 direction)
    {
        Grenade grenade = (Grenade)GD.Load<PackedScene>("res://Scenes/Projectiles/Grenade.tscn").Instantiate();
        grenade.Position = position;
        grenade.Direction = direction;

        return grenade;
    }
}