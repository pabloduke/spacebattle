using NLog;
using SFML.Graphics;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.armor.impl;
using SpaceBattle1.core.ship.engine.impl;
using SpaceBattle1.core.ship.hull.impl;
using SpaceBattle1.core.ship.weapon.beam.impl;

namespace SpaceBattle1.core.data;

public class EnemyFleet : List<SpaceShip> {
    private static Logger log = LogManager.GetCurrentClassLogger();
    public SpaceShip EnemyShip { get; }
    
    
    public EnemyFleet() {
        EnemyShip = InitEnemyShip();
        Add(EnemyShip);
    }

    private SpaceShip InitEnemyShip() {
        log.Info("Initializing ENEMY Ship");

        Texture ship_b_texture = new Texture("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\images\\enemyship.png");
        Sprite shipBSprite = new Sprite(ship_b_texture);
        
        SpaceShip enemyShip = SpaceShip.CreateShip(
            "Enemy Ship",
            new MediumHull(new Laser(), new Laser()),
            new TitaniumArmor(),
            new Nuclear(),
            shipBSprite,
            new Tuple<int, int>(8, 5)
        );

        log.Info("COMPLETED Initializing Player Ships");
        return enemyShip;
    }
}