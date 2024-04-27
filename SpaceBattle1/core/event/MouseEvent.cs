using System.Diagnostics;
using NLog;
using SFML.Window;
using SpaceBattle1.display;

namespace SpaceBattle1.core;

public class MouseEvent {
    private static Logger log = LogManager.GetCurrentClassLogger();
    private static GameTick _tick = new GameTick(0);
    private static Stopwatch _stopwatch = Stopwatch.StartNew();
    public void OnLeftMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            Boolean toggleState = GlobalGameContext.getInstance().getLeftButtonClickedInd();
            GlobalGameContext.getInstance().setLeftButtonClickedInd(!toggleState);
            GlobalGameContext.getInstance().MouseClickX = e.X;
            GlobalGameContext.getInstance().MouseClickY = e.Y;
        }
    }

    public void OnMouseEntered(object sender, MouseMoveEventArgs e) {
        _stopwatch.Stop();
        long elapsedTime = _stopwatch.ElapsedMilliseconds;

        if (elapsedTime > 100) {
            GlobalGameContext.getInstance().Window.DispatchEvents();
            Tuple<int, int> gridCoor = GameGridGridResolver.getGridCoor(e.X, e.Y);
        
            GlobalGameContext.getInstance().CursorLoc = gridCoor;
            // log.Info($"Highlite tile {gridCoor.Item1}, {gridCoor.Item2}");
        }
        
        _stopwatch.Start();

    }
}

 struct GameTick {
    public long Tick { get; set; }

    public GameTick(long _tick) {
        _tick = Tick;
    }
}