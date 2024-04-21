namespace SpaceBattle1.core.gamestate;

public interface IGameStateResolver {
    public GameState resolve(GameContext gameContext);
}