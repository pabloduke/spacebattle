using SFML.Graphics;
using SFML.Window;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.core.action.attack;

public class Attack {


    public void Execute(RenderWindow window, SpaceShip attackingShip) {
        window.KeyPressed += AttackOnKeyPress;
        while (GlobalGameContext.getInstance().IsAttack()) {
            window.DispatchEvents();
        }
    }
    
    private static void AttackOnKeyPress(object sender, KeyEventArgs e) {
        
    }
    
    private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e) {
        if (e.Button == Mouse.Button.Left) {
            
        }
    }
}