namespace SpaceBattle1.core.ship.engine.impl;

public record Nuclear : IEngine {
    public string GetName() {
        return "Nuclear Engine";
    }

    public int GetSpeed() {
        return 10;
    }
}