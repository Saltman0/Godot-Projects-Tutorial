namespace TestFinalTuto.Factory;

using Godot;

public class LaserFactory
{
    /**
     * Crée un laser
     */
    public static Laser CreateLaser(Vector2 position, Vector2 direction)
    {
        Laser laser = (Laser)GD.Load<PackedScene>("res://Scenes/Projectiles/Laser.tscn").Instantiate();
        laser.Position = position;
        laser.Direction = direction;
        laser.Rotation += laser.Direction.Angle();

        return laser;
    }
}