using NLog;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.display;
using SpaceBattle1.core.mouse;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.engine.impl;
using SpaceBattle1.core.ship.hull.impl;
using SpaceBattle1.core.ship.weapon.beam.impl;
using static SpaceBattle1.core.GameContext;


class Program {
    private static Logger log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {
        // ILogger log = LoggerFactory.Create().CreateLogger("Main");
        log.Info("Initializing");
        int width = 1200;
        int height = 1000;
        int cellSize = 100;
        GameContext gameContext = GameContext.getInstance();
        GridResolver gridResolver = new GameGridGridResolver(width, height, cellSize);
        
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

        SpaceShip enterprise = SpaceShip.CreateShip(
            "Enterprise",
            new MediumHull(new Laser(), new Laser()),
            new Nuclear(),
            shipASprite
        );
        
        Texture ship_b_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\enemyship.png");
        Sprite shipBSprite = new Sprite(ship_b_texture);
        shipBSprite.Position = new Vector2f(800, 500);

        SpaceShip enemyShip = SpaceShip.CreateShip(
            "Enemy Ship",
            new MediumHull(new Laser(), new Laser()),
            new Nuclear(),
            shipBSprite
        );

        window.MouseButtonPressed += OnMouseButtonPressed;
        window.KeyPressed += OnKeyPress;
        
        window.Draw(nebulaSprite);
        window.Draw(enterprise.Sprite);
        window.Draw(enemyShip.Sprite);
        GameGrid.Draw(window);
        MainMenu.Draw(window);
        
        log.Info("Initialization Complete");
        
        window.Display();

        //MAIN GAME LOOP
        while (window.IsOpen) {
            window.DispatchEvents();
            if (gameContext.getLeftButtonClickedInd()) {
                
                
                //I think this is wrong.  It should be the ship's current location, not the previous click.
                Tuple<int, int> from = new Tuple<int, int>(
                    gridResolver.getGridCoor(gameContext.PrevMouseClickX, gameContext.PrevMouseClickY).Item1,
                    gridResolver.getGridCoor(gameContext.PrevMouseClickX, gameContext.PrevMouseClickY).Item2
                );
                
                Tuple<int, int> clickedCell = new Tuple<int, int>(
                    gridResolver.getGridCoor(gameContext.MouseClickX, gameContext.MouseClickY).Item1,
                    gridResolver.getGridCoor(gameContext.MouseClickX, gameContext.MouseClickY).Item2
                );
                
                gameContext.setLeftButtonClickedInd(false);
                SpriteMover.execute(
                    window,
                    enterprise,
                    nebulaSprite,
                    clickedCell
                );
            }

            if (gameContext.Keypress == Keyboard.Key.Num1 || gameContext.Keypress == Keyboard.Key.Numpad1) {
                log.Info("ATTACK!!!!");
                gameContext.Keypress = Keyboard.Key.Unknown;
            }
        }
    }
    private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GameContext.getInstance().getLeftButtonClickedInd();
            getInstance().setLeftButtonClickedInd(!toggleState);
            getInstance().MouseClickX = e.X;
            getInstance().MouseClickY = e.Y;
        }
    }

    private static void OnKeyPress(object sender, KeyEventArgs e) {
        log.Info($"You pressed {e.Code}");
        GameContext.getInstance().Keypress = e.Code;
    }
}