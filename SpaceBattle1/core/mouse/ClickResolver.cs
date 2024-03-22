namespace SpaceBattle1.core.mouse;

public interface ClickResolver {
    Tuple<int, int> getCoor(int mouseX, int mouseY);
}