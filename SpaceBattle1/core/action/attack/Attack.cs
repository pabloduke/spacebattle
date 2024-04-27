using NLog;
using SpaceBattle1.core.data;
using SpaceBattle1.core.ship;
using SpaceBattle1.core.ship.weapon;
using SpaceBattle1.display;

namespace SpaceBattle1.core.action.attack;

public static class Attack {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static void execute(SpaceShip attackingShip, Tuple<int, int> cellToAttack) {
        SpaceShip ship = BattleGrid.GetInstance().GetShiptAtLocation(cellToAttack);

        if (ship == null) {
            log.Info("There is nothing to attack at that location.");
            return;
        }

        foreach (IWeapon weapon in attackingShip.Hull.GetWeapons()) {
            log.Info($"Firing {weapon.GetName()}");
            int attackDmg = Math.Max(weapon.GetPower() - ship.Armor.GetBaseDefense(), 0);
            log.Info($"{weapon.GetName()} did {attackDmg} damage to {ship.Name}");

            AttackAnimator.execute(weapon, attackingShip.Location, cellToAttack);
            ship.HitPoints = Math.Max(ship.HitPoints - attackDmg, 0);
            if (ship.HitPoints == 0) {
                log.Info($"{ship.Name} has been destroyed!");
            }
            
            GlobalGameContext.getInstance().SetGameStateIdle();
        }
    }
}