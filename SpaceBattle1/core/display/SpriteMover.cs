using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.display;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class SpriteMover {
    public static void execute(
        RenderWindow window,
        SpaceShip ship,
        Sprite backgroundSprite,
        Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        Console.WriteLine($"Move {ship.Name} Sprite From: ({from.Item1}, {from.Item2})");
        Console.WriteLine($"Move {ship.Name} Sprite To: ({to.Item1}, {to.Item2})");
        window.DispatchEvents();

        Tuple<int, int> slope = getSlope(from, to);
        float rise = slope.Item2 / 2;
        float run = slope.Item1 / 2;
        int xFinal = to.Item1 * GameContext.CELL_SIZE;
        int yFinal = to.Item2 * GameContext.CELL_SIZE;
        while (ship.Sprite.Position.X != xFinal || ship.Sprite.Position.Y != yFinal) {
            window.DispatchEvents();

            if (ship.Sprite.Position.X != xFinal) {
                ship.Sprite.Position = new Vector2f(
                    ship.Sprite.Position.X + run,
                    ship.Sprite.Position.Y
                );
            }

            if (ship.Sprite.Position.Y != yFinal) {
                ship.Sprite.Position = new Vector2f(
                    ship.Sprite.Position.X,
                    ship.Sprite.Position.Y + rise
                );
            }

            window.Draw(backgroundSprite);
            GameGrid.Draw(window);
            MainMenu.Draw(window);
            window.Draw(ship.Sprite);
            window.Display();
        }
    }

    private static Tuple<int, int> getSlope(
        Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        int run = to.Item1 - from.Item1;
        int rise = to.Item2 - from.Item2;

        Console.WriteLine($"Slope = {rise} / {run}");
        return new Tuple<int, int>(run, rise);
    }
}