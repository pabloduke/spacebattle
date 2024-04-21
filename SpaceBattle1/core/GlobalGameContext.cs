using NLog;
using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core.data;
using SpaceBattle1.core.gamestate;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class GlobalGameContext {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public Sprite BackGroundSprite { get; set; }
    public PlayerFleet PlayerFleet;
    public EnemyFleet EnemyFleet;
    public List<SpaceShip> Ships { get; set; }
    public RenderWindow Window { get; set; }
    public int MouseClickX {
        get => _mouseClickX;
        set => _mouseClickX = value;
    }

    public int MouseClickY {
        get => _mouseClickY;
        set => _mouseClickY = value;
    }

    public Tuple<int, int> CursorLoc { get; set; }
    public GameState GetGameState() {
        return _gameState;
    }
    private GameState _gameState;
    
    public static readonly int  WIDTH = 1200;
    public static readonly int  HEIGHT = 1000;
    public static readonly int  CELL_SIZE = 100;

    private static GlobalGameContext _instance;
    private Boolean _leftButtonClickedInd;
    private int _mouseClickX;
    private int _mouseClickY;
    
    public Keyboard.Key Keypress { get; set; }

    private GlobalGameContext() {
        PlayerFleet = new PlayerFleet();
        EnemyFleet = new EnemyFleet();
        Ships = PlayerFleet.Concat(EnemyFleet).ToList();
        SetGameStateIdle();
        this._leftButtonClickedInd = false;
    }

    public static GlobalGameContext getInstance() {
        if (_instance == null) {
            _instance = new GlobalGameContext();
        }

        return _instance;
    }

    public Boolean getLeftButtonClickedInd() {
        return _leftButtonClickedInd;
    }

    public void setLeftButtonClickedInd(Boolean flag) {
        _leftButtonClickedInd = flag;
    }

    public void SetGameStateIdle() {
        log.Info("SETTING GAMESTATE TO IDLE");
        _gameState = GameState.IDLE;
    }

    public void SetGameStateAttack() {
        log.Info("SETTING GAMESTATE TO ATTACK");
        _gameState = GameState.ATTACK;
    }
    
    public void SetGameStateMove() {
        log.Info("SETTING GAMESTATE TO MOVE");
        _gameState = GameState.MOVE;
    }
}