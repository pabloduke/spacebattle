using SFML.Window;

namespace SpaceBattle1.core.gamestate;

public struct GameContext {
    public GameState GameState { get; set; }
    public Tuple<int, int> ClickLocation_1 { get; set; }
    public Tuple<int, int> ClickLocation_2 { get; set; }
    public Keyboard.Key Keypress;
}