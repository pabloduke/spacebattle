using SFML.Window;
using SpaceBattle1.core.data;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core;

public class GlobalGameContext {
    public int MouseClickX {
        get => _mouseClickX;
        set => _mouseClickX = value;
    }

    public int MouseClickY {
        get => _mouseClickY;
        set => _mouseClickY = value;
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
        this._leftButtonClickedInd = false;
        _gameState = new GameState();

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

    public void BeginAttack() {
        if (!_gameState.IsAttack) {
            _gameState.IsAttack = true;
        }
    }

    public void EndAttack() {
        if (_gameState.IsAttack) {
            _gameState.IsAttack = false;
        }
    }

    public bool IsAttack() {
        return _gameState.IsAttack;
    }

    private class GameState {
        public bool IsAttack { get; set; }
    }
}