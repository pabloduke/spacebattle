namespace SpaceBattle1.core.gamestate.state;

public class AttackGameState : IGameState {
    public bool IsMatch(GameContext gameContext) {
        throw new NotImplementedException();
    }

    public GameState getGameState() {
        return GameState.ATTACK;
    }
}