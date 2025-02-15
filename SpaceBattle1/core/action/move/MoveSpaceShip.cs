﻿using NLog;
using SpaceBattle1.core.data;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core.action.move;

/**
 * When the a spaceship is to be moved
 * logic here is executed to determine where the spaceship is
 * to be moved to
 */
public static class MoveSpaceShip {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public static void execute(SpaceShip movingShip, Tuple<int, int> moveToCell) {
        if (BattleGrid.GetInstance().isEmpty(moveToCell)) {
            SpriteMover.execute(
                GlobalGameContext.getInstance().Window,
                movingShip,
                GlobalGameContext.getInstance().Ships,
                GlobalGameContext.getInstance().BackGroundSprite,
                moveToCell
            );

           GlobalGameContext.getInstance().SetGameStateIdle();
        }
        else {
            log.Info("That location is occupied");
        }
    }
}