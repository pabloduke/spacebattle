using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceBattle1.core.data;
using SpaceBattle1.core.ship;

namespace SpaceBattle1.Tests.core.data;

[TestClass]
[TestSubject(typeof(BattleGrid))]
public class BattleGridTest {

    [TestMethod]
    public void METHOD() {
        BattleGrid battleGrid = BattleGrid.GetInstance();
        SpaceShip ship = battleGrid.GetShiptAtLocation(new Tuple<int, int>(1, 1));
        
        Console.WriteLine($"IS GRID LOCATION EMPTY??? ->{battleGrid.isEmpty(new Tuple<int, int>(1, 1))}");

        if (!battleGrid.isEmpty(new Tuple<int, int>(1, 1))) {
            Console.WriteLine($"GRID LOCATION IS OCCUPIDED BY??? ->{ship.Name}");
        }
    }
}