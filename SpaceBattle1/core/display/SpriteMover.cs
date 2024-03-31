using NLog;
using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.display;
using SpaceBattle1.core.mouse;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class SpriteMover {
    private static Logger log = LogManager.GetCurrentClassLogger();
    public static void execute(
        RenderWindow window,
        SpaceShip ship,
        Sprite backgroundSprite,
        // Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        GridResolver gridResolver = new GameGridGridResolver(GameContext.WIDTH, GameContext.HEIGHT, GameContext.CELL_SIZE);
        
        Tuple<int, int> from = new Tuple<int, int>(
            gridResolver.getGridCoor((int)ship.Sprite.Position.X, (int)ship.Sprite.Position.Y).Item1,
            gridResolver.getGridCoor((int)ship.Sprite.Position.X, (int)ship.Sprite.Position.Y).Item2
        );
        
        log.Info($"Move {ship.Name} Sprite From: ({from.Item1}, {from.Item2})");
        log.Info($"Move {ship.Name} Sprite To: ({to.Item1}, {to.Item2})");
        window.DispatchEvents();
        
        Tuple<int, int> slope = getSlope(from, to);
        float rise = slope.Item2;
        float run = slope.Item1;

        Tuple<int, int> currentLoc = gridResolver.getGridCoor((int) ship.Sprite.Position.X, (int) ship.Sprite.Position.Y);
        while (currentLoc.Item1 != to.Item1 || currentLoc.Item2 != to.Item2) {
            window.DispatchEvents();
            
            if (currentLoc.Item1 != to.Item1) {
                ship.Sprite.Position = new Vector2f(
                    ship.Sprite.Position.X + run,
                    ship.Sprite.Position.Y
                );
            }

            if (currentLoc.Item2 != to.Item2) {
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
            currentLoc = gridResolver.getGridCoor((int) ship.Sprite.Position.X, (int) ship.Sprite.Position.Y);
            log.Trace($"CurrentX: {currentLoc.Item1}, CurrentY: {currentLoc.Item2}");
        }

        ship.Sprite.Position = new Vector2f(
            gridResolver.getScreenCoor(
                to.Item1,
                to.Item2
            ).Item1,
            
            gridResolver.getScreenCoor(
                to.Item1,
                to.Item2
            ).Item2
        );
        
        window.Draw(backgroundSprite);
        GameGrid.Draw(window);
        MainMenu.Draw(window);
        window.Draw(ship.Sprite);
        window.Display();
    }

    private static Tuple<int, int> getSlope(
        Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        int run = to.Item1 - from.Item1;
        int rise = to.Item2 - from.Item2;

        log.Info($"Slope = {rise} / {run}");
        return new Tuple<int, int>(run, rise);
    }
}