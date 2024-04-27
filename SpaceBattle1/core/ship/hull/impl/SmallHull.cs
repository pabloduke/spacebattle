using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.core.ship.hull.impl;

public record SmallHull : IHull {
    private List<IWeapon> _weapons { get; set; }
    public SmallHull(IBeamWeapon beamWeapon) {
        BeamWeapon = beamWeapon;
        _weapons = new List<IWeapon>() { beamWeapon };
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

    public List<IWeapon> GetWeapons() {
        return _weapons;
    }
}
