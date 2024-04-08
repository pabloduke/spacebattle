using SFML.Window;

namespace SpaceBattle1.core;

public class MouseEvent {
    public void OnLeftMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GlobalGameContext.getInstance().getLeftButtonClickedInd();
            GlobalGameContext.getInstance().setLeftButtonClickedInd(!toggleState);
            GlobalGameContext.getInstance().MouseClickX = e.X;
            GlobalGameContext.getInstance().MouseClickY = e.Y;
        }
    }
}