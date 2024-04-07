using SFML.Window;

namespace SpaceBattle1.core;

public class MouseEvent {
    public static void OnLeftMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GameContext.getInstance().getLeftButtonClickedInd();
            GameContext.getInstance().setLeftButtonClickedInd(!toggleState);
            GameContext.getInstance().MouseClickX = e.X;
            GameContext.getInstance().MouseClickY = e.Y;
        }
    }
}