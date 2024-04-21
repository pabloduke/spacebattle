using NLog;
using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core.display;

namespace SpaceBattle1.core;

public class MouseEvent {
    private static Logger log = LogManager.GetCurrentClassLogger();
    public void OnLeftMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GlobalGameContext.getInstance().getLeftButtonClickedInd();
            GlobalGameContext.getInstance().setLeftButtonClickedInd(!toggleState);
            GlobalGameContext.getInstance().MouseClickX = e.X;
            GlobalGameContext.getInstance().MouseClickY = e.Y;
        }
    }

    public void OnMouseEntered(object sender, MouseMoveEventArgs e) {
        GlobalGameContext.getInstance().Window.DispatchEvents();
        Tuple<int, int> gridCoor = GameGridGridResolver.getGridCoor(e.X, e.Y);
        
        GlobalGameContext.getInstance().CursorLoc = gridCoor;
        // log.Info($"Highlite tile {gridCoor.Item1}, {gridCoor.Item2}");
    }
}