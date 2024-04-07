using NLog;
using SFML.Window;

namespace SpaceBattle1.core;

public class KeyEvent {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public static void OnKeyPress(object sender, KeyEventArgs e) {
        log.Info($"You pressed {e.Code}");
        GameContext.getInstance().Keypress = e.Code;
        if (GameContext.getInstance().Keypress == Keyboard.Key.Num1 || GameContext.getInstance().Keypress == Keyboard.Key.Numpad1) {
            if (!GameContext.getInstance().IsAttack()) {
                GameContext.getInstance().BeginAttack();
            }
            else {
                GameContext.getInstance().EndAttack();
            }
        }
    }
}