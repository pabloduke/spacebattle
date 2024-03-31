namespace SpaceBattle1.core.mouse;

public interface GridResolver {
    /**
     * This will retrieve the x,y GameGrid location based on the screen X, Y position
     */
    Tuple<int, int> getGridCoor(int mouseX, int mouseY);
   
    /**
     * This will retrieve the Screen X, Y location based on the GameGrid X, Y position
     *
     * The Screen Coor returned will represent the upper left corner of the entire GameGrid square
     */
    Tuple<int, int> getScreenCoor(int gridX, int gridY);
}