using NLog;
using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.ship;
using SpaceBattle1.display;

namespace SpaceBattle1.core.display;

public static class ScreenDrawer {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static void Execute(
        RenderWindow window,
        List<SpaceShip> ships,
        Sprite backgroundSprite
    ) {
        GlobalGameContext.getInstance().Window.DispatchEvents();
        log.Debug("Drawing Screen Started");
        window.Draw(backgroundSprite);
        GameGridDrawer.Draw(window);
        MainMenuDrawer.Draw(window);
        // highliteTile(GlobalGameContext.getInstance().CursorLoc);
        foreach (SpaceShip ship in ships) {
            window.Draw(ship.Sprite);
        }

        window.Display();
        log.Debug("Drawing Screen Completed");
    }

    public static void highliteTile(Tuple<int, int> gridCoor) {
        GlobalGameContext.getInstance().Window.DispatchEvents();
        float x = gridCoor.Item1 * GlobalGameContext.CELL_SIZE;
        float y = gridCoor.Item2 * GlobalGameContext.CELL_SIZE;
        RectangleShape rectangleShape = new RectangleShape(new Vector2f(GlobalGameContext.CELL_SIZE, GlobalGameContext.CELL_SIZE));
        rectangleShape.Position = new Vector2f(x, y);
        rectangleShape.OutlineColor = new Color(10, 10, 200, 128);
        rectangleShape.FillColor = new Color(10, 10, 200, 128);
        
        GlobalGameContext.getInstance().Window.Draw(rectangleShape);
        
    }
}