using SFML.Graphics;
using SpaceBattle1.core;

namespace SpaceBattle1.display;

public static class GameGridDrawer {
    public static void Draw(RenderWindow window) {
        foreach (RectangleShape shape in GlobalGameContext.getInstance().Grid) {
            window.DispatchEvents();
            window.Draw(shape);
        }
        // for (int x = 0; x < GlobalGameContext.WIDTH; x++) {
        //     
        //     window.DispatchEvents(); // Process events
        //     // window.Clear(); // Clear the window before drawing
        //         
        //     RectangleShape rectangleShape = new RectangleShape(new Vector2f(1, GlobalGameContext.HEIGHT));
        //     rectangleShape.Position = new Vector2f(x * GlobalGameContext.CELL_SIZE, 0);
        //     rectangleShape.OutlineColor = Color.Blue;
        //     rectangleShape.FillColor = Color.Blue;
        //     window.Draw(rectangleShape);
        // }
        //
        // for (int y = 0; y < GlobalGameContext.HEIGHT; y++) {
        //     window.DispatchEvents(); // Process events
        //     // window.Clear(); // Clear the window before drawing
        //         
        //     RectangleShape rectangleShape = new RectangleShape(new Vector2f(GlobalGameContext.WIDTH, 1));
        //     rectangleShape.Position = new Vector2f(0, y * GlobalGameContext.CELL_SIZE);
        //     rectangleShape.OutlineColor = Color.Blue;
        //     rectangleShape.FillColor = Color.Blue;
        //     window.Draw(rectangleShape);
        // }
    }
}