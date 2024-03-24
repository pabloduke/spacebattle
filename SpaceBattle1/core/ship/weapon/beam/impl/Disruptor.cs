namespace SpaceBattle1.core.ship.weapon.beam.impl;

public record Disruptor : IBeamWeapon {
    public string GetName() {
        return "Disruptor";
    }

    public int GetPower() {
        return 50;
    }

    public int GetSize() {
        return 30;
    }
}