using SFML.Window;

namespace SpaceBattle1.core.gamestate.state;

public class MoveFromGameState : IGameState {
    
    public bool IsMatch(GameContext gameContext) {
        return gameContext.Keypress == Keyboard.Key.Num2
               && gameContext.ClickLocation_1 == null
               && gameContext.ClickLocation_2 == null;
    }

    public GameState getGameState() {
        return GameState.MOVE;
    }
}