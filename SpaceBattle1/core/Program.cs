using NLog;
using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core;
using SpaceBattle1.core.data;
using SpaceBattle1.core.display;
using SpaceBattle1.core.ship;
using static SpaceBattle1.core.GameContext;
using KeyEvent = SpaceBattle1.core.KeyEvent;


class Program {
    private static Logger log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {
        log.Info("Initializing");
        BattleGrid battleGrid = BattleGrid.GetInstance();
        RenderWindow window = new RenderWindow(new VideoMode((uint)WIDTH, (uint)HEIGHT), "Space Battle");
        window.SetFramerateLimit(60);
        window.Closed += (sender, e) => ((Window)sender).Close();

        Texture nebulaTexture =
            new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\alt_nebula.jpg");
        Sprite nebulaSprite = new Sprite(nebulaTexture);

        PlayerFleet playerFleet = new PlayerFleet();
        EnemyFleet enemyFleet = new EnemyFleet();

        List<SpaceShip> ships = playerFleet.Concat(enemyFleet).ToList();

        window.MouseButtonPressed += MouseEvent.OnLeftMouseButtonPressed;
        window.KeyPressed += KeyEvent.OnKeyPress;

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

                if (!getInstance().IsAttack()) {
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

                if (getInstance().IsAttack()) {
                    log.Info("ATTACK!!!!");
                    getInstance().Keypress = Keyboard.Key.Unknown;
                }
            }
        }
    }


}