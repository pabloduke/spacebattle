using NLog;

namespace SpaceBattle1.core.action.attack;

public static class Attack {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static void execute() {
        log.Info("ATTACK!!!!");
    }


}