using NLog;
using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core.data;
using SpaceBattle1.core.gamestate;
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
        highliteTile();
        foreach (SpaceShip ship in ships) {
            window.Draw(ship.Sprite);
        }

        window.Display();
        log.Debug("Drawing Screen Completed");
    }

    public static void highliteTile() {
        Tuple<int, int> gridCoor = GlobalGameContext.getInstance().CursorLoc;

        if (GlobalGameContext.getInstance().GetGameState() == GameState.MOVE && gridCoor != null) {
            float x = gridCoor.Item1 * GlobalGameContext.CELL_SIZE;
            float y = gridCoor.Item2 * GlobalGameContext.CELL_SIZE;
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(GlobalGameContext.CELL_SIZE, GlobalGameContext.CELL_SIZE));
            rectangleShape.Position = new Vector2f(x, y);
            
            Color tileColor = getTileColor(gridCoor);
            rectangleShape.OutlineColor = tileColor;
            rectangleShape.FillColor = tileColor;
        
            GlobalGameContext.getInstance().Window.Draw(rectangleShape);
        }
    }
    
    private static Color getTileColor(Tuple<int, int> gridCoor) {
        if (BattleGrid.GetInstance().GetShiptAtLocation(gridCoor) == null) {
            return new Color(10, 10, 200, 128);
        }
        
        return new Color(200, 10, 10, 175);
    }
}