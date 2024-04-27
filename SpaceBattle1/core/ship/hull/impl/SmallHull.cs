using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.core.ship.hull.impl;

public record SmallHull : IHull {
    public SmallHull(IBeamWeapon beamWeapon) {
        BeamWeapon = beamWeapon;
    }
    public IBeamWeapon BeamWeapon { get; }
    public string GetName() {
        return "Small Hull";
    }

    public int GetSize() {
        return 20;
    }
    
    public int GetBaseHitPoints() {
        return 50;
    }
}
