using SpaceBattle1.core.ship;

namespace SpaceBattle1.core.data;

public class BattleGrid {
    private static BattleGrid _instance;
    public SpaceShip[,] Map { get; set; }

    private BattleGrid() {
        
    }

    public static BattleGrid GetInstance() {
        if (_instance == null) {
            _instance = new BattleGrid();
        }

        return _instance;
    }
}