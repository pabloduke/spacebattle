using NLog;
using NLog.Fluent;
using SFML.Window;

namespace SpaceBattle1.core.@event;

public static class KeyEvent {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public static void OnKeyPress(object sender, KeyEventArgs e) {
        log.Info($"You pressed {e.Code}");
            
        GlobalGameContext.getInstance().Keypress = e.Code;

        switch (e.Code) {
            case Keyboard.Key.Num1: GlobalGameContext.getInstance().SetGameStateMove();
                break;
            
            case Keyboard.Key.Num2: GlobalGameContext.getInstance().SetGameStateAttack();
                break;
            
            case Keyboard.Key.Escape: GlobalGameContext.getInstance().SetGameStateIdle();
                break;
            
            case Keyboard.Key.Q: Environment.Exit(0);
                log.Info("Quitting Game, Goodbye!");
                break;
        }
        
        GlobalGameContext.getInstance().Keypress = Keyboard.Key.Unknown;
    }
}