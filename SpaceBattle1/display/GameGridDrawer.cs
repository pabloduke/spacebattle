using SFML.Graphics;
using SFML.System;

namespace SpaceBattle1.core.display;

public static class GameGridDrawer {
    public static void Draw(RenderWindow window) {
        for (int x = 0; x < GameContext.WIDTH; x++) {
            
            window.DispatchEvents(); // Process events
            // window.Clear(); // Clear the window before drawing
                
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(1, GameContext.HEIGHT));
            rectangleShape.Position = new Vector2f(x * GameContext.CELL_SIZE, 0);
            rectangleShape.OutlineColor = Color.Blue;
            rectangleShape.FillColor = Color.Blue;
            window.Draw(rectangleShape);
        }

        for (int y = 0; y < GameContext.HEIGHT; y++) {
            window.DispatchEvents(); // Process events
            // window.Clear(); // Clear the window before drawing
                
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(GameContext.WIDTH, 1));
            rectangleShape.Position = new Vector2f(0, y * GameContext.CELL_SIZE);
            rectangleShape.OutlineColor = Color.Blue;
            rectangleShape.FillColor = Color.Blue;
            window.Draw(rectangleShape);
        }
    }
}