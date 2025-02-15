﻿using SpaceBattle1.core.ship.weapon;
using SpaceBattle1.core.ship.weapon.missile;

namespace SpaceBattle1.core.ship.hull.impl;

public struct LargeHull : IHull {
    private List<IWeapon> _weapons { get; set; }
    public LargeHull(IBeamWeapon beamWeapon1, IBeamWeapon beamWeapon2, IMissileWeapon missileWeapon) {
        BeamWeapon1 = beamWeapon1;
        BeamWeapon2 = beamWeapon2;
        MissileWeapon = missileWeapon;
        _weapons = new List<IWeapon>() { beamWeapon1, beamWeapon2, missileWeapon };
    }
    public IBeamWeapon BeamWeapon1 { get; }
    public IBeamWeapon BeamWeapon2 { get; }
    public IMissileWeapon MissileWeapon { get; }
    
    public string GetName() {
        return "Large Hull";
    }

    public int GetSize() {
        return 100;
    }

    public int GetBaseHitPoints() {
        return 100;
    }

    public List<IWeapon> GetWeapons() {
        return _weapons;
    }
}