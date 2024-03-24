namespace SpaceBattle1.core.ship.weapon.beam.impl;

public record AdvancedLaser : IBeamWeapon {
    public string GetName() {
        return "Advanced Laser:";
    }

    public int GetPower() {
        return 30;
    }

    public int GetSize() {
        return 20;
    }
}