using NLog;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.display;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.engine.impl;
using SpaceBattle1.core.ship.hull.impl;
using SpaceBattle1.core.ship.weapon.beam.impl;
using static SpaceBattle1.core.GameContext;


class Program {
    private static Logger log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {
        log.Info("Initializing");
        int width = 1200;
        int height = 1000;
        int cellSize = 100;
        
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
            shipASprite,
            new Tuple<int, int>(1, 1)
        );
        
        Texture ship_b_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\enemyship.png");
        Sprite shipBSprite = new Sprite(ship_b_texture);
        shipBSprite.Position = new Vector2f(800, 500);

        SpaceShip enemyShip = SpaceShip.CreateShip(
            "Enemy Ship",
            new MediumHull(new Laser(), new Laser()),
            new Nuclear(),
            shipBSprite,
            new Tuple<int, int>(8, 5)
        );

        List<SpaceShip> ships = new List<SpaceShip>();
        ships.Add(enterprise);
        ships.Add(enemyShip);
        window.MouseButtonPressed += OnMouseButtonPressed;
        window.KeyPressed += OnKeyPress;
        
        ScreenDrawer.Execute(window, ships, nebulaSprite);
        
        log.Info("Initialization Complete");
        
       //MAIN GAME LOOP
        while (window.IsOpen) {
            window.DispatchEvents();
            if (GameContext.getInstance().getLeftButtonClickedInd()) {
                Tuple<int, int> clickedCell = new Tuple<int, int>(
                    GameGridGridResolver.getGridCoor(GameContext.getInstance().MouseClickX, GameContext.getInstance().MouseClickY).Item1,
                    GameGridGridResolver.getGridCoor(GameContext.getInstance().MouseClickX, GameContext.getInstance().MouseClickY).Item2
                );
                
                GameContext.getInstance().setLeftButtonClickedInd(false);
                SpriteMover.execute(
                    window,
                    enterprise,
                    ships,
                    nebulaSprite,
                    clickedCell
                );
            }

            if (GameContext.getInstance().Keypress == Keyboard.Key.Num1 || GameContext.getInstance().Keypress == Keyboard.Key.Numpad1) {
                log.Info("ATTACK!!!!");
                GameContext.getInstance().Keypress = Keyboard.Key.Unknown;
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