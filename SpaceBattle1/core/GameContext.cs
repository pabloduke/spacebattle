using SFML.Window;
using SpaceBattle1.core.data;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class GameContext {
    public int MouseClickX {
        get => _mouseClickX;
        set {
            _prevMouseClickX = _mouseClickX;
            _mouseClickX = value;
        }
    }

    public int MouseClickY {
        get => _mouseClickY;
        set {
            _prevMouseClickY = _mouseClickY;
            _mouseClickY = value;
        }
        
    }
    
    public BattleGrid BattleGrid { get; set; }

    public int PrevMouseClickX => _prevMouseClickX;
    public int PrevMouseClickY => _prevMouseClickY;
    
    public static readonly int  WIDTH = 1200;
    public static readonly int  HEIGHT = 800;
    public static readonly int  CELL_SIZE = 100;

    private static GameContext _instance;
    private Boolean _leftButtonClickedInd;
    private int _mouseClickX;
    private int _mouseClickY;
    private int _prevMouseClickX;
    private int _prevMouseClickY;
    
    public Keyboard.Key Keypress { get; set; }

    private GameContext() {
        this._leftButtonClickedInd = false;
    }

    public static GameContext getInstance() {
        if (_instance == null) {
            _instance = new GameContext();
        }

        return _instance;
    }

    public Boolean getLeftButtonClickedInd() {
        return _leftButtonClickedInd;
    }

    public void setLeftButtonClickedInd(Boolean flag) {
        _leftButtonClickedInd = flag;
    }
}