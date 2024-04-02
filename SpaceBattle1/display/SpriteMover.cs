using NLog;
using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.display;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class SpriteMover {
    private static Logger log = LogManager.GetCurrentClassLogger();
    public static void execute(
        RenderWindow window,
        SpaceShip ship,
        List<SpaceShip> ships,
        Sprite backgroundSprite,
        // Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        log.Info($"Moving Sprite {ship.Name}");
        
        Tuple<int, int> from = new Tuple<int, int>(
            GameGridGridResolver.getGridCoor((int)ship.Sprite.Position.X, (int)ship.Sprite.Position.Y).Item1,
            GameGridGridResolver.getGridCoor((int)ship.Sprite.Position.X, (int)ship.Sprite.Position.Y).Item2
        );
        
        log.Info($"Move {ship.Name} Sprite From: ({from.Item1}, {from.Item2})");
        log.Info($"Move {ship.Name} Sprite To: ({to.Item1}, {to.Item2})");
        window.DispatchEvents();
        
        Tuple<int, int> slope = GetSlope(from, to);
        float rise = slope.Item2;
        float run = slope.Item1;

        Tuple<int, int> currentLoc = GameGridGridResolver.getGridCoor((int) ship.Sprite.Position.X, (int) ship.Sprite.Position.Y);
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

            ScreenDrawer.Execute(window, ships, backgroundSprite);

            currentLoc = GameGridGridResolver.getGridCoor((int) ship.Sprite.Position.X, (int) ship.Sprite.Position.Y);
            log.Trace($"CurrentX: {currentLoc.Item1}, CurrentY: {currentLoc.Item2}");
        }

        ship.Sprite.Position = new Vector2f(
            GameGridGridResolver.getScreenCoor(
                to.Item1,
                to.Item2
            ).Item1,
            
            GameGridGridResolver.getScreenCoor(
                to.Item1,
                to.Item2
            ).Item2
        );
        
        ScreenDrawer.Execute(window, ships, backgroundSprite);

        ship.Location = to;
        log.Info($"Completed Moving Sprite {ship.Name}");
    }

    private static Tuple<int, int> GetSlope(
        Tuple<int, int> from,
        Tuple<int, int> to
    ) {
        int run = to.Item1 - from.Item1;
        int rise = to.Item2 - from.Item2;

        log.Info($"Slope = {rise} / {run}");
        return new Tuple<int, int>(run, rise);
    }
}