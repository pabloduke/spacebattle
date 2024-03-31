using SpaceBattle1.core.mouse;

namespace SpaceBattle1.core;

public class GameGridGridResolver : GridResolver {
    private readonly int width;
    private readonly int height;
    private readonly int cellSize;
    public GameGridGridResolver(int width, int height, int cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
    }

    public Tuple<int, int> getGridCoor(int mouseX, int mouseY) {
        int xCor = mouseX / cellSize;
        int yCor = mouseY / cellSize;
        
        return new Tuple<int, int>(xCor, yCor);
    }

    public Tuple<int, int> getScreenCoor(int gridX, int gridY) {
        int xCor = gridX * cellSize;
        int yCor = gridY * cellSize;
    
        Console.WriteLine($"FINAL COOR: ({xCor}, {yCor})");
        return new Tuple<int, int>(xCor, yCor);
    }
}