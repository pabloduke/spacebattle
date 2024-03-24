namespace SpaceBattle1.core.ship.weapon.beam.impl;

public record Laser : IBeamWeapon {
    public string GetName() {
        return "Laser";
    }

    public int GetPower() {
        return 10;
    }

    public int GetSize() {
        return 10;
    }
}