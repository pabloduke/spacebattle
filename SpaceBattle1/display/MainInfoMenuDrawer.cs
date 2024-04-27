using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.display;

public class MainInfoMenuDrawer {
    public static void Draw(SpaceShip ship) {
        RenderWindow window = GlobalGameContext.getInstance().Window;
        
        RectangleShape mainMenu = new RectangleShape(new Vector2f(1190, 195));
        mainMenu.Position = new Vector2f(5, 795);
        mainMenu.FillColor = Color.Black;
        mainMenu.OutlineColor = Color.Green;
        mainMenu.OutlineThickness = 5;
        
        window.Draw(mainMenu);
        Font menuFont = GlobalGameContext.getInstance().MenuFont;
        drawText(window, menuFont, ship);
    }

    private static void drawText(RenderWindow window, Font font, SpaceShip ship) {
        Text text = new Text("Ship Name: " + ship.Name, font);
        text.FillColor = Color.Green;
        text.Position = new Vector2f(10, 810);
        window.Draw(text);
    }
    
    private static void drawAttackMenuText(RenderWindow window, Font font, RectangleShape mainMenu) {
        Text text = new Text("2. Attack", font);
        text.FillColor = Color.Green;
        text.Position = new Vector2f(10, 850);
        window.Draw(text);
    }
}