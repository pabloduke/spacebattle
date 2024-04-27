using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.core.ship.hull.impl;

public record MediumHull : IHull {
    private List<IWeapon> _weapons { get; set; }
    public MediumHull(IBeamWeapon beamWeapon, IWeapon weapon) {
        BeamWeapon = beamWeapon;
        Weapon = weapon;
        _weapons = new List<IWeapon>() { beamWeapon, weapon };
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

    public List<IWeapon> GetWeapons() {
        return _weapons;
    }
}