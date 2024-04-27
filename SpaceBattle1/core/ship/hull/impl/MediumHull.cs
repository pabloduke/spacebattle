using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.core.ship.hull.impl;

public record MediumHull : IHull {
    public MediumHull(IBeamWeapon beamWeapon, IWeapon weapon) {
        BeamWeapon = beamWeapon;
        Weapon = weapon;
    }
    public IBeamWeapon BeamWeapon { get; }
    public IWeapon Weapon { get; }
    
    public string GetName() {
        return "Medium Hull";
    }

    public int GetSize() {
        return 75;
    }
    
    public int GetBaseHitPoints() {
        return 75;
    }
}