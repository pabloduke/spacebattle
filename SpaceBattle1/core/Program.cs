using NLog;
using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.data;
using SpaceBattle1.core.display;
using SpaceBattle1.core.ship;
using static SpaceBattle1.core.GameContext;


class Program {
    private static Logger log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {
        log.Info("Initializing");
        BattleGrid battleGrid = BattleGrid.GetInstance();
        RenderWindow window = new RenderWindow(new VideoMode((uint)WIDTH, (uint)HEIGHT), "Space Battle");
        window.SetFramerateLimit(60);
        window.Closed += (sender, e) => ((Window)sender).Close();
        
        Texture nebulaTexture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\alt_nebula.jpg");
        Sprite nebulaSprite = new Sprite(nebulaTexture);

        PlayerFleet playerFleet = new PlayerFleet();
        EnemyFleet enemyFleet = new EnemyFleet();
        
        List<SpaceShip> ships = playerFleet.Concat(enemyFleet).ToList();

        window.MouseButtonPressed += OnMouseButtonPressed;
        window.KeyPressed += OnKeyPress;
        
        ScreenDrawer.Execute(window, ships, nebulaSprite);
        
        log.Info("Initialization Complete");
        
       //MAIN GAME LOOP
        while (window.IsOpen) {
            window.DispatchEvents();
            if (getInstance().getLeftButtonClickedInd()) {
                Tuple<int, int> clickedCell = new Tuple<int, int>(
                    GameGridGridResolver.getGridCoor(getInstance().MouseClickX, getInstance().MouseClickY).Item1,
                    GameGridGridResolver.getGridCoor(getInstance().MouseClickX, getInstance().MouseClickY).Item2
                );
                
                getInstance().setLeftButtonClickedInd(false);
                if (battleGrid.isEmpty(clickedCell)) {
                    SpriteMover.execute(
                        window,
                        playerFleet[0],
                        ships,
                        nebulaSprite,
                        clickedCell
                    );
                }
                else {
                    log.Info("That location is occupied");
                }

            }

            if (getInstance().Keypress == Keyboard.Key.Num1 || getInstance().Keypress == Keyboard.Key.Numpad1) {
                log.Info("ATTACK!!!!");
                getInstance().Keypress = Keyboard.Key.Unknown;
            }
        }
    }
    private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = getInstance().getLeftButtonClickedInd();
            getInstance().setLeftButtonClickedInd(!toggleState);
            getInstance().MouseClickX = e.X;
            getInstance().MouseClickY = e.Y;
        }
    }

    private static void OnKeyPress(object sender, KeyEventArgs e) {
        log.Info($"You pressed {e.Code}");
        getInstance().Keypress = e.Code;
    }
}