using SFML.Graphics;
using SpaceBattle1.core;

namespace SpaceBattle1.display;

public static class GameGridDrawer {
    public static void Draw(RenderWindow window) {
        foreach (RectangleShape shape in GlobalGameContext.getInstance().Grid) {
            window.DispatchEvents();
            window.Draw(shape);
        }
    }
}