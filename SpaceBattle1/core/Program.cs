using NLog;
using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.data;
using SpaceBattle1.core.display;
using SpaceBattle1.core.gamestate;
using SpaceBattle1.core.ship;
using SpaceBattle1.display;
using static SpaceBattle1.core.GlobalGameContext;
using KeyEvent = SpaceBattle1.core.KeyEvent;


class Program {
    private static Logger log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {
        log.Info("Initializing");
        BattleGrid battleGrid = BattleGrid.GetInstance();
        RenderWindow window = new RenderWindow(new VideoMode((uint)WIDTH, (uint)HEIGHT), "Space Battle");
        window.SetFramerateLimit(60);
        window.Closed += (sender, e) => ((Window)sender).Close();

        getInstance().Window = window;
        Texture nebulaTexture =
            new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\alt_nebula.jpg");
        Sprite nebulaSprite = new Sprite(nebulaTexture);

        getInstance().BackGroundSprite = nebulaSprite;
        // PlayerFleet playerFleet = new PlayerFleet();
        // EnemyFleet enemyFleet = new EnemyFleet();
        //
        // List<SpaceShip> ships = playerFleet.Concat(enemyFleet).ToList();

        GameGridInitializer.init();
        window.MouseButtonPressed += new MouseEvent().OnLeftMouseButtonPressed;
        window.MouseMoved += new MouseEvent().OnMouseEntered;
        window.KeyPressed += KeyEvent.OnKeyPress;

        ScreenDrawer.Execute(window, getInstance().Ships, nebulaSprite);

        log.Info("Initialization Complete");

        //MAIN GAME LOOP
        while (window.IsOpen) {
            window.DispatchEvents();
            ScreenDrawer.Execute(
                window,
                getInstance().Ships,
                nebulaSprite
            );
            
            if (getInstance().getLeftButtonClickedInd()) {
                Tuple<int, int> clickedCell = new Tuple<int, int>(
                    GameGridGridResolver.getGridCoor(getInstance().MouseClickX, getInstance().MouseClickY).Item1,
                    GameGridGridResolver.getGridCoor(getInstance().MouseClickX, getInstance().MouseClickY).Item2
                );

                getInstance().setLeftButtonClickedInd(false);

                if (getInstance().GetGameState() == GameState.MOVE) {
                    if (battleGrid.isEmpty(clickedCell)) {
                        SpriteMover.execute(
                            window,
                            getInstance().PlayerFleet[0],
                            getInstance().Ships,
                            nebulaSprite,
                            clickedCell
                        );

                        getInstance().SetGameStateIdle();
                    }
                    else {
                        log.Info("That location is occupied");
                    }
                }

                if ((getInstance().GetGameState() == GameState.ATTACK)) {
                    log.Info("ATTACK!!!!");
                    getInstance().Keypress = Keyboard.Key.Unknown;
                }
            }
        }
    }
}