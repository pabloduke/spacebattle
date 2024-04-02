using NLog;
using SFML.Graphics;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.engine.impl;
using SpaceBattle1.core.ship.hull.impl;
using SpaceBattle1.core.ship.weapon.beam.impl;

namespace SpaceBattle1.core.init;

public class SpaceShipInitializer {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static List<SpaceShip> InitPlayerShips() {
        log.Info("Initializing Player Ships");
        Texture ship_a_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\nx01.png");
        Sprite shipASprite = new Sprite(ship_a_texture);
    
        SpaceShip enterprise = SpaceShip.CreateShip(
            "Enterprise",
            new MediumHull(new Laser(), new Laser()),
            new Nuclear(),
            shipASprite,
            new Tuple<int, int>(1, 1)
        );

        log.Info("COMPLETED Initializing Player Ships");
        return new List<SpaceShip> { enterprise };
    }

    public static List<SpaceShip> InitEnemyShips() {
        log.Info("Initializing ENEMY Ships");

        Texture ship_b_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\enemyship.png");
        Sprite shipBSprite = new Sprite(ship_b_texture);
        
        SpaceShip enemyShip = SpaceShip.CreateShip(
            "Enemy Ship",
            new MediumHull(new Laser(), new Laser()),
            new Nuclear(),
            shipBSprite,
            new Tuple<int, int>(8, 5)
        );

        log.Info("COMPLETED Initializing Player Ships");
        return new List<SpaceShip> { enemyShip };
    }
}