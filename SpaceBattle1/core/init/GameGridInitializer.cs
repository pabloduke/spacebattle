using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core;

namespace SpaceBattle1.display;

public static class GameGridInitializer {
    public static void init() {
        List<RectangleShape> rectangleShapes = new List<RectangleShape>();
        for (int x = 0; x < GlobalGameContext.WIDTH; x++) {
            
            GlobalGameContext.getInstance().Window.DispatchEvents(); // Process events
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(1, GlobalGameContext.HEIGHT));
            rectangleShape.Position = new Vector2f(x * GlobalGameContext.CELL_SIZE, 0);
            rectangleShape.OutlineColor = Color.Blue;
            rectangleShape.FillColor = Color.Blue;
            rectangleShapes.Add(rectangleShape);
        }

        for (int y = 0; y < GlobalGameContext.HEIGHT; y++) {
            GlobalGameContext.getInstance().Window.DispatchEvents(); // Process events
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(GlobalGameContext.WIDTH, 1));
            rectangleShape.Position = new Vector2f(0, y * GlobalGameContext.CELL_SIZE);
            rectangleShape.OutlineColor = Color.Blue;
            rectangleShape.FillColor = Color.Blue;
            rectangleShapes.Add(rectangleShape);
        }

        GlobalGameContext.getInstance().Grid = rectangleShapes;
    }
}