using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceBattle1.core;
using SpaceBattle1.core.mouse;

namespace SpaceBattle1.Tests.core.mouse.impl;

[TestClass]
[TestSubject(typeof(GameGridGridResolver))]
public class GameGridGridResolverTest {
    private readonly GridResolver _gridResolver = new GameGridGridResolver(1200,800,100);
    
    
    [DataTestMethod]
    [DataRow(250, 350, 2, 3)]
    [DataRow(100, 100, 1, 1)]
    [DataRow(0, 0, 0, 0)]
    [DataRow(1199, 799, 11, 7)] // Edge case
    public void TestGridLocationIsCorrectlyResolved(int x, int y, int expectedX, int expectedY) {
        Tuple<int, int> coor = _gridResolver.getGridCoor(x, y);
        Console.WriteLine($"Expecting: (mouseX{x}, mouseY{y}) -> ({expectedX}, {expectedY})");
        Assert.AreEqual(expectedX, coor.Item1, $"X coordinate is incorrect for input ({x},{y})");
        Assert.AreEqual(expectedY, coor.Item2, $"Y coordinate is incorrect for input ({x},{y})");
    }
}