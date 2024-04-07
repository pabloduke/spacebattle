using NLog;
using SFML.Graphics;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.engine.impl;
using SpaceBattle1.core.ship.hull.impl;
using SpaceBattle1.core.ship.weapon.beam.impl;

namespace SpaceBattle1.core.data;

public class PlayerFleet : List<SpaceShip> {
    private static Logger log = LogManager.GetCurrentClassLogger();
    public SpaceShip Enterpise { get; }
    
    
    public PlayerFleet() {
        Enterpise = InitEnterprise();
        Add(Enterpise);
    }

    private SpaceShip InitEnterprise() {
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
        return  enterprise;
    }
}