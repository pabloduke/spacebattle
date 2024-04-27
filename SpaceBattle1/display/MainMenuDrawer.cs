using SFML.Graphics;
using SFML.System;

namespace SpaceBattle1.core.display;

public class MainMenuDrawer {
    public static void Draw(RenderWindow window) {
        RectangleShape mainMenu = new RectangleShape(new Vector2f(1190, 195));
        mainMenu.Position = new Vector2f(5, 795);
        mainMenu.FillColor = Color.Black;
        mainMenu.OutlineColor = Color.Green;
        mainMenu.OutlineThickness = 5;
        
        window.Draw(mainMenu);
        Font menuFont = GlobalGameContext.getInstance().MenuFont;
        Text attackText = new Text("2. Attack", menuFont);
        drawMoveMenuText(window, menuFont, mainMenu);
        drawAttackMenuText(window, menuFont, mainMenu);
    }

    private static void drawMoveMenuText(RenderWindow window, Font font, RectangleShape mainMenu) {
        Text text = new Text("1. Move", font);
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