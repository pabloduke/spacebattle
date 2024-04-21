namespace SpaceBattle1.core.gamestate;

public interface IGameState {
    bool IsMatch(GameContext gameContext);
    GameState getGameState();
}
