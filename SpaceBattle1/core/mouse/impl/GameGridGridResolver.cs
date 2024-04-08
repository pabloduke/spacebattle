using NLog;

namespace SpaceBattle1.core;

public class GameGridGridResolver{
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static Tuple<int, int> getGridCoor(int mouseX, int mouseY) {
        int xCor = mouseX / GlobalGameContext.CELL_SIZE;
        int yCor = mouseY / GlobalGameContext.CELL_SIZE;
        
        return new Tuple<int, int>(xCor, yCor);
    }

    public static Tuple<int, int> getScreenCoor(int gridX, int gridY) {
        int xCor = gridX * GlobalGameContext.CELL_SIZE;
        int yCor = gridY * GlobalGameContext.CELL_SIZE;
    
        log.Info($"FINAL COOR: ({xCor}, {yCor})");
        return new Tuple<int, int>(xCor, yCor);
    }
}