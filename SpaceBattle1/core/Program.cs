// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata.Ecma335;
using System.Runtime.Loader;
using Microsoft.Extensions.Logging;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.display;
using SpaceBattle1.core.mouse;


class Program {
    static void Main(string[] args) {
        // ILogger log = LoggerFactory.Create().CreateLogger("Main");
        Console.WriteLine("Initializing");
        int width = 1200;
        int height = 800;
        int cellSize = 100;
        GameContext gameContext = GameContext.getInstance();
        ClickResolver clickResolver = new GameGridClickResolver(width, height, cellSize);

        int totalCols = width / cellSize;
        int totalRows = height / cellSize;
        
        int shipX = 0;
        int shipY = 100;
        RenderWindow window = new RenderWindow(new VideoMode((uint)width, (uint)height), "Space Battle");
        RenderTexture backgroundTexture = new RenderTexture((uint)width, (uint)height);
        
        window.SetFramerateLimit(60);
        window.Closed += (sender, e) => ((Window)sender).Close();
        

        Texture nebulaTexture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\alt_nebula.jpg");
        Texture ship_a_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\nx01.png");
        Sprite nebulaSprite = new Sprite(nebulaTexture);
        Sprite shipASprite = new Sprite(ship_a_texture);
        shipASprite.Position = new Vector2f(shipX, shipY);
        window.MouseButtonPressed += OnMouseButtonPressed;
        // shipASprite.TextureRect = new IntRect(0, 0, 100, 100);
        window.Draw(nebulaSprite);
        window.Draw(shipASprite);

        DrawGrid.execute(window);

        Console.WriteLine("Initialization Complete");
        
        window.Display();

        //MAIN GAME LOOP
        while (window.IsOpen) {
            window.DispatchEvents();
            if (gameContext.getLeftButtonClickedInd()) {
                Console.WriteLine("PREV COOR:");
                Tuple<int, int> from = new Tuple<int, int>(
                    clickResolver.getCoor(gameContext.PrevMouseClickX, gameContext.PrevMouseClickY).Item1,
                    clickResolver.getCoor(gameContext.PrevMouseClickX, gameContext.PrevMouseClickY).Item2
                );
                
                Console.WriteLine("NEW COOR");
                Tuple<int, int> to = new Tuple<int, int>(
                    clickResolver.getCoor(gameContext.MouseClickX, gameContext.MouseClickY).Item1,
                    clickResolver.getCoor(gameContext.MouseClickX, gameContext.MouseClickY).Item2
                );
                
                gameContext.setLeftButtonClickedInd(false);
                SpriteMover.execute(
                    window,
                    shipASprite,
                    nebulaSprite,
                    from,
                    to
                );
            }
        }
    }
    private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GameContext.getInstance().getLeftButtonClickedInd();
            GameContext.getInstance().setLeftButtonClickedInd(!toggleState);
            GameContext.getInstance().MouseClickX = e.X;
            GameContext.getInstance().MouseClickY = e.Y;
            
            Console.WriteLine("TOGGLE STATE FLIPPED TO-> " + !toggleState);
        }
    }
}