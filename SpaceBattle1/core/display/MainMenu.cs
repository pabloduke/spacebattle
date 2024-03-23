﻿using System.Net.Mime;
using SFML.Graphics;
using SFML.System;

namespace SpaceBattle1.core.display;

public class MainMenu {
    public static void Draw(RenderWindow window) {
        RectangleShape mainMenu = new RectangleShape(new Vector2f(1190, 195));
        mainMenu.Position = new Vector2f(5, 795);
        mainMenu.FillColor = Color.Black;
        mainMenu.OutlineColor = Color.Green;
        mainMenu.OutlineThickness = 5;

        Font font = new Font("C:\\Users\\steph\\RiderProjects\\SpaceBattle1\\SpaceBattle1\\font\\Roboto-Black.ttf");
        Text text = new Text("1. Attack", font);
        text.FillColor = Color.Green;
        text.Position = new Vector2f(10, 820);
        window.Draw(mainMenu);
        window.Draw(text);
    }
}