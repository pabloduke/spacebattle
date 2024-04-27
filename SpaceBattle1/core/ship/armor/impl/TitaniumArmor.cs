﻿namespace SpaceBattle1.core.ship.armor.impl;

public class TitaniumArmor : IArmor {
    public string GetName() {
        return "Titanium";
    }

    public int GetBaseHitPoints() {
        return 50;
    }

    public double GetBaseDefense() {
        return 10.0;
    }
}