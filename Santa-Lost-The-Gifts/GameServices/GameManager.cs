using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        //public static GameUser player = new GameUser();
        public Dictionary<short, string> tiles = new Dictionary<short, string>(){
            {1, "flying_ground_end_left"},
            {2, "flying_ground_end_right"},
            {3, "flying_ground_middle"},
            {4, "flying_island_left"},
            {5, "flying_island_middle"},
            {6, "flying_island_right"},
            {7, "ground_end_left"},
            {8, "ground_end_right"},
            {9, "ground_snow_end_left"},
            {10, "ground_snow_end_right"},
            {11, "ground_snow_middle"},
            {12, "inner_ground_end_left"},
            {13, "inner_ground_end_right"},
            {14, "inner_ground_middle"},
            {15, "water_middle"},
            {16, "water_top"}
        };
        public Dictionary<short, string> decorations = new Dictionary<short, string>(){
            {17, "Crate"},
            {18, "Crystal"},
            { 19, "IceBox"},
            { 20, "Igloo"},
            { 21, "Sign_1"},
            { 22, "Sign_2"},
            { 23, "SnowMan"},
            { 24, "Stone"},
            { 25, "Tree_1"},
            { 26, "Tree_2"}
        };
                  
        short[,] levelOneTiles = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 11, 11, 11, 10, 0 },

            { 0, 0, 0 ,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 7, 14 ,14, 14, 8, 0 },

            { 20, 0, 0 ,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 7, 14 ,14, 14, 8, 0 },

            { 11, 11, 11, 11, 10, 0, 0, 0, 0, 0, 0 ,0, 9, 11, 11, 11, 11, 11, 11 ,11 },

            { 14, 14, 14 ,14, 13, 10, 16 ,16, 16, 16, 16 ,16, 7, 14, 14 ,14, 14, 14, 14 ,14 }
        };
        public GameManager(Scene scene):
            base(scene)
        {
            scene.Ground = scene.ActualHeight - 60;
            Init();
        }

        public void Init()
        {
            Scene.RemoveAllObject();
            Tile tile;
            Decoration decoration;
            string tileName, decorationName;
            int x = 0 , y = 0;
            int tileWidth = 64, tileHeight = 64;
            for (int  i = 0; i < 8; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (levelOneTiles[i, j] > 0 && levelOneTiles[i, j] < 17)
                    {
                        tileName = tiles[levelOneTiles[i, j]];
                        tile = new Tile(Scene, $"LevelDesign/Tiles/NorthPole/{tileName}.png", x, y, tileWidth, tileHeight);
                        Scene.AddObject(tile);
                    }
                    else if (levelOneTiles[i, j] > 0 && levelOneTiles[i, j] > 17)
                    {
                        decorationName = decorations[levelOneTiles[i, j]];
                        decoration = new Decoration(Scene, $"LevelDesign/Decorations/NorthPole/{decorationName}.png", x, y, tileWidth, tileHeight);
                        Scene.AddObject(decoration);

                    }
                    x += 64;
                }
                x = 0;
                y += 64;
            }
            // Ninja ninja = new Ninja(Scene, "Characters/Ninja/ninja_idle_right.gif", 10, Scene.ActualHeight - 64, Ninja.NinjaType.idleRight, 119, 186, 300, 150);
            //Scene.AddObject(ninja);
            Santa santa = new Santa(Scene, "Characters/Santa/santa_idle_right.gif", 0 , Scene.ActualHeight - 128 - 80, Santa.SantaType.idleRight, 55, 80);
            Scene.AddObject(santa);
            Scene.Init();
        }
    }
}
