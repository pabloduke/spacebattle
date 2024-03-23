using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.display;

namespace SpaceBattle1.core;

public class SpriteMover {
    public static void execute(
        RenderWindow window, 
        Sprite sprite, 
        Sprite backgroundSprite,
        Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        window.DispatchEvents();

        Tuple<int, int> slope = getSlope(from, to);
        float rise = slope.Item2;
        float run = slope.Item1;
        int xFinal = to.Item1 * GameContext.CELL_SIZE;
        int yFinal = to.Item2 * GameContext.CELL_SIZE;
        while (sprite.Position.X != xFinal || sprite.Position.Y != yFinal) {
            window.DispatchEvents();

            if (sprite.Position.X != xFinal) {
                sprite.Position = new Vector2f(sprite.Position.X + run, sprite.Position.Y);
            }

            if (sprite.Position.Y != yFinal) {
                sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y + rise);
            }
            
            window.Draw(backgroundSprite);
            GameGrid.Draw(window);
            MainMenu.Draw(window);
            window.Draw(sprite);
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