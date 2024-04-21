using System.Collections;
using SpaceBattle1.core.gamestate.state;

namespace SpaceBattle1.core.gamestate.list;

public class GameStateList : HashSet<IGameState> {
    private MoveFromGameState _moveFromGameState;
    private AttackGameState _attackGameState;
    
    public GameStateList() {
        _moveFromGameState = new MoveFromGameState();
        _attackGameState = new AttackGameState();

        Add(_moveFromGameState);
        Add(_attackGameState);
    }
}