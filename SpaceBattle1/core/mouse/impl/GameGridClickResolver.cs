using SpaceBattle1.core.mouse;

namespace SpaceBattle1.core;

public class GameGridClickResolver : ClickResolver {
    private readonly int width;
    private readonly int height;
    private readonly int cellSize;
    public GameGridClickResolver(int width, int height, int cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
    }

    public Tuple<int, int> getCoor(int mouseX, int mouseY) {
        int xCor = mouseX / cellSize;
        int yCor = mouseY / cellSize;
        
        return new Tuple<int, int>(xCor, yCor);
    }
}