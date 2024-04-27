using NLog;
using SFML.Graphics;
using SFML.System;
using SpaceBattle1.core;
using SpaceBattle1.core.ship.weapon;

namespace SpaceBattle1.display;

public static class AttackAnimator {
    private static Logger log = LogManager.GetCurrentClassLogger();

    public static void execute(IWeapon weapon, Tuple<int, int> from, Tuple<int, int> to) {
        GlobalGameContext.getInstance().Window.DispatchEvents();

        Tuple<int, int> f = GameGridGridResolver.getScreenCoor(from.Item1, from.Item2);
        Tuple<int, int> t = GameGridGridResolver.getScreenCoor(to.Item1, to.Item2);


        VertexArray line = new VertexArray(PrimitiveType.Lines, 2);
        line[0] = new Vertex(new Vector2f(f.Item1 + 25, f.Item2 + 25), Color.Red);
        line[1] = new Vertex(new Vector2f(t.Item1 + 25, t.Item2 + 25), Color.Red);
        
        GlobalGameContext.getInstance().Window.Draw(line);
        GlobalGameContext.getInstance().Window.Display();
        Thread.Sleep(1000);
    }
}