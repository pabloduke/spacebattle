using NLog;
using SFML.Window;

namespace SpaceBattle1.core;

public class KeyEvent {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public static void OnKeyPress(object sender, KeyEventArgs e) {
        log.Info($"You pressed {e.Code}");
        GlobalGameContext.getInstance().Keypress = e.Code;
        if (GlobalGameContext.getInstance().Keypress == Keyboard.Key.Num1 || GlobalGameContext.getInstance().Keypress == Keyboard.Key.Numpad1) {
            if (!GlobalGameContext.getInstance().IsAttack()) {
                GlobalGameContext.getInstance().BeginAttack();
            }
            else {
                GlobalGameContext.getInstance().EndAttack();
            }
        }
    }
}