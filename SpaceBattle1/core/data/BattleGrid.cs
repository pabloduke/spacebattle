using NLog;
using SpaceBattle1.core.init;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core.data;

public class BattleGrid {
    private static Logger log = LogManager.GetCurrentClassLogger();
    private static BattleGrid _instance;
    private SpaceShip[,] _shipLocations;

    private BattleGrid() {
       _shipLocations = InitShipLocations(new PlayerFleet(), new EnemyFleet());
    }

    public static BattleGrid GetInstance() {
        if (_instance == null) {
            _instance = new BattleGrid();
        }

        return _instance;
    }

    public bool isEmpty(Tuple<int, int> location) {
        return _shipLocations[location.Item1, location.Item2] == null;
    }

    public SpaceShip GetShiptAtLocation(Tuple<int, int> location) {
        return _shipLocations[location.Item1, location.Item2];
    }

    public void UpdateShipLocation(SpaceShip ship, Tuple<int, int> location) {
        if (_shipLocations[location.Item1, location.Item2] == null) {
            log.Info($"Updating ship location From ({ship.Location.Item1}, {ship.Location.Item2}) To ({location.Item1}, {location.Item2})");
            _shipLocations[ship.Location.Item1, ship.Location.Item2] = null;
            _shipLocations[ship.Location.Item1 + 1, ship.Location.Item2] = null;
            _shipLocations[ship.Location.Item1, ship.Location.Item2 + 1] = null;
            _shipLocations[ship.Location.Item1 + 1, ship.Location.Item2 + 1] = null;
            
            _shipLocations[location.Item1, location.Item2] = ship;
            _shipLocations[location.Item1 + 1, location.Item2] = ship;
            _shipLocations[location.Item1, location.Item2 + 1] = ship;
            _shipLocations[location.Item1 + 1, location.Item2 + 1] = ship;
            

            ship.Location = location;
        }
    }
    
    private SpaceShip[,] InitShipLocations(PlayerFleet playerFleet, EnemyFleet enemyFleet) {
        SpaceShip[,] battleGrid = new SpaceShip[GlobalGameContext.HEIGHT, GlobalGameContext.WIDTH];
        foreach (SpaceShip ship in playerFleet) {
            battleGrid[ship.Location.Item1, ship.Location.Item2] = ship;
            battleGrid[ship.Location.Item1 + 1, ship.Location.Item2] = ship;
            battleGrid[ship.Location.Item1 , ship.Location.Item2 + 1] = ship;
            battleGrid[ship.Location.Item1 + 1 , ship.Location.Item2 + 1] = ship;
        }
        
        foreach (SpaceShip ship in enemyFleet) {
            battleGrid[ship.Location.Item1, ship.Location.Item2] = ship;
            battleGrid[ship.Location.Item1 + 1, ship.Location.Item2] = ship;
            battleGrid[ship.Location.Item1 , ship.Location.Item2 + 1] = ship;
            battleGrid[ship.Location.Item1 + 1, ship.Location.Item2 + 1] = ship;
        }

        return battleGrid;
    }
}