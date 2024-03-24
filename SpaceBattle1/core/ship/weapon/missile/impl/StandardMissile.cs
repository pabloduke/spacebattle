namespace SpaceBattle1.core.ship.weapon.missile.impl;

public record StandardMissile : IMissileWeapon {
    public string GetName() {
        return "Standard Missile";
    }

    public int GetPower() {
        return 50;
    }

    public int GetSize() {
        return 20;
    }
}