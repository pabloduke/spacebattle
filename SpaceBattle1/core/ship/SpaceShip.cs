using SFML.Graphics;
using SpaceBattle1.core.ship.engine;
using SpaceBattle1.core.ship.hull;

namespace SpaceBattle1.core.ship;

public class SpaceShip {
    public String Name { get; }
    public IHull Hull { get; }
    public IEngine Engine { get; }

    public Sprite Sprite { get; }


    private SpaceShip(
        String name,
        IHull hull,
        IEngine engine,
        Sprite sprite
    ) {
        Name = name;
        Hull = hull;
        Engine = engine;
        Sprite = sprite;
    }

    public static SpaceShip CreateShip(
        String name,
        IHull hull,
        IEngine engine,
        Sprite sprite
    ) {
        return new SpaceShip(name, hull, engine, sprite);
    }
}