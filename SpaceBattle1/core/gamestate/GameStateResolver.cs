using SpaceBattle1.core.gamestate.list;

namespace SpaceBattle1.core.gamestate;



public class GameStateResolver : IGameStateResolver {
    private GameStateList _gameStateList;
    
    public GameState resolve(GameContext gameContext) {
        _gameStateList = new GameStateList();

        foreach (IGameState gameState in _gameStateList) {
            if (gameState.IsMatch(gameContext)) {
                return gameState.getGameState();
            }
        }

        return GameState.UNKNOWN;
    }
}