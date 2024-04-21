using NLog;
using SFML.Window;
using SpaceBattle1.core.gamestate;

namespace SpaceBattle1.core;

public class KeyEvent {
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
        }
    }
}