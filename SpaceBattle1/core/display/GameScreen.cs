using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SpaceBattle1.core.display;

public class GameScreen {
    private static GameScreen _instance;

    private static Texture backgroundTexture =
        new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\alt_nebula.jpg");

    private RenderWindow window;
    private Sprite backgroundSprite;

    private GameScreen() {
        window = new RenderWindow(new VideoMode((uint)GameContext.WIDTH, (uint)GameContext.HEIGHT), "Space Battle");
        window.SetFramerateLimit(60);
        window.Closed += (sender, e) => ((Window)sender).Close();
        Sprite backgroundSprite = new Sprite(backgroundTexture);
        Console.WriteLine("Initialization Complete");
    }

    public static GameScreen GetInstance() {
        if (_instance == null) {
            _instance = new GameScreen();
        }

        return _instance;
    }

    public RenderWindow GetRenderWindow() {
        return window;
    }

    public void DrawScreen() {
        window.DispatchEvents();
        window.Draw(backgroundSprite);
        GameGrid.Draw(window);
        window.Display();
    }
}