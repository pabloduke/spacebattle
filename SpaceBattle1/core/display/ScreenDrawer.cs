using NLog;
using SFML.Graphics;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core.display;

public static class ScreenDrawer {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static void Execute(
        RenderWindow window,
        List<SpaceShip> ships,
        Sprite backgroundSprite
    ) {
        log.Debug("Drawing Screen Started");
        window.Draw(backgroundSprite);
        GameGridDrawer.Draw(window);
        MainMenu.Draw(window);

        foreach (SpaceShip ship in ships) {
            window.Draw(ship.Sprite);
        }

        window.Display();
        log.Debug("Drawing Screen Completed");
    }
}