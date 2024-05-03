using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using MongoProject;
using MongoProject.Modules;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Documents;

namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        private Gift gift;
        private LevelEnvironment levelEnvironment;
        //public static GameUser player = new GameUser();
        //private int maxNumberOfLevel;
        //private int phaseIndex = 1;

        public GameManager(Scene scene):
            base(scene)
        {
            scene.Ground = scene.ActualHeight - 60;
            GameEvent.OnRun += ChangeLevel;
            Init();
        }

        public void Init()
        {
            Level level = MongoServer.GetLevel(1, LevelEnvironment.NorthPole);
            Scene.RemoveAllObject();
            Tile tile;
            //Decoration decoration;
            int tileWidth = 64, tileHeight = 64;

            for (int i = 0; i < level.tiles.Length; i++)
            {
                TileInfo tileInfo = level.tiles[i];
                tile = new Tile(Scene, $"LevelDesign/Tiles/NorthPole/{tileInfo.name}.png", tileWidth * tileInfo.column, tileHeight * tileInfo.row, tileWidth, tileHeight);
                Scene.AddObject(tile);

            }

            Santa santa = new Santa(Scene, "Characters/Santa/santa_idle_right.gif", level.playerFirstPositionX , level.playerFirstPositionY, Santa.SantaType.idleRight, 55, 80);
            Scene.AddObject(santa);
            Scene.Init();
        }
        public void ChangeLevel()
        {
            if (gift != null)
            {
                //if (gift.giftFound)
                //{
                //    gift.giftFound = false;
                //    GameOver();
                //    phaseIndex++;
                //    if (phaseIndex == maxNumberOfLevel + 1)
                //    {
                //        switch (levelEnvironment)
                //        {
                //            case LevelEnvironment.NorthPole:
                //                levelEnvironment = LevelEnvironment.Forest;
                //                break;
                //            case LevelEnvironment.Forest:
                //                levelEnvironment = LevelEnvironment.Dessert;
                //                break;
                //            case LevelEnvironment.Dessert:
                //                break;
                //        }
                //        phaseIndex = 1;
                //    }
                //    Init();
                //}
            }
        }
        public void Init(bool b)
        {
            Level level = MongoServer.GetLevel(0, levelEnvironment);
            Scene.RemoveAllObject();
            Tile tile;
            string typeLevel = "NorthPole";
            switch (levelEnvironment)
            {
                case LevelEnvironment.Forest:
                    typeLevel = "Forest";
                    break;
                case LevelEnvironment.Dessert:
                    typeLevel = "Dessert";
                    break;
            }
            //Decoration decoration;
            int tileWidth = 64, tileHeight = 64;

            for (int i = 0; i < level.tiles.Length; i++)
            {
                TileInfo tileInfo = level.tiles[i];
                tile = new Tile(Scene, $"LevelDesign/Tiles/{typeLevel}/{tileInfo.name}.png", tileWidth * tileInfo.column, tileHeight * tileInfo.row, tileWidth, tileHeight);
                Scene.AddObject(tile);
            }

            Santa santa = new Santa(Scene, "Characters/Santa/santa_idle_right.gif", level.playerFirstPositionX, level.playerFirstPositionY, Santa.SantaType.idleRight, 55, 80);
            Scene.AddObject(santa);
            Resume();
        }
    }
}
