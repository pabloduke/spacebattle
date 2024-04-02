using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.ship.engine;
using SpaceBattle1.core.ship.hull;

namespace SpaceBattle1.core.ship;

public class SpaceShip {
    public String Name { get; }
    public IHull Hull { get; }
    public IEngine Engine { get; }

    public Sprite Sprite { get; }

    public Tuple<int, int> Location { get; set; }


    private SpaceShip(
        String name,
        IHull hull,
        IEngine engine,
        Sprite sprite,
        Tuple<int, int> location
    ) {
        Name = name;
        Hull = hull;
        Engine = engine;
        Sprite = sprite;
        Location = location;

        Tuple<int, int> calculatedPosition = GameGridGridResolver.getScreenCoor(location.Item1, location.Item2);
        sprite.Position = new Vector2f(calculatedPosition.Item1, calculatedPosition.Item2);
    }

    public static SpaceShip CreateShip(
        String name,
        IHull hull,
        IEngine engine,
        Sprite sprite,
        Tuple<int, int> location
    ) {
        return new SpaceShip(name, hull, engine, sprite, location);
    }
}