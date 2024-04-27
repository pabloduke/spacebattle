using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.core.ship.hull;

public interface IHull {
    String GetName();
    int GetSize();
    int GetBaseHitPoints();
    List<IWeapon> GetWeapons();
}