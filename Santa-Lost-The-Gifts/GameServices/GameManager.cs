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
using Windows.UI.Xaml;
using SQLProject.Modules;
using SQLProject;
using static GameEngine.GameServices.Constants;
using Windows.UI.Xaml.Controls.Maps;


namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        private Gift _gift;
        public GameParams _gameParams;
        public GameManager(Scene scene, GameParams gameParams) :
            base(scene)
        {
            _gameParams = gameParams;
            scene.Ground = scene.ActualHeight - 60;
            if (_gameParams == null)
            {
                _gameParams = new GameParams();
                Init(0, "NorthPole");
            }
            else
            {
                Init(_gameParams.chosenLevel, _gameParams.chosenLevelType);
            }
            GameEvent.OnRun += ChangeLevel;
        }
        public void ChangeLevel()
        {
            if (_gift != null)
            {
                if (_gift.giftFound)
                {
                    //_gift.giftFound = false;
                    //_gift = null;
                    //_player.LastLevel++;
                   // Init(_player.LastLevel);
                }
            }
        }
        //public void LevelSelection(int phaseIndex, LevelEnvironment levelEnvironment)
        //{
        //    this.phaseIndex = phaseIndex;
        //    this.levelEnvironment = levelEnvironment;
        //}
        public void Init(int levelIndex, String levelEnvironment)
        {
            Scene.RemoveAllObject();
            Level level = MongoServer.GetLevel(levelIndex, levelEnvironment);
            Tile tile;
            int tileWidth = 64, tileHeight = 64;
            string LevelType = "";
            switch (level.levelEnvironment)
            {
                case LevelEnvironment.NorthPole:
                    LevelType = "NorthPole";
                    break;
                case LevelEnvironment.Forest:
                    LevelType = "Forest";
                    break;
                case LevelEnvironment.Desert:
                    LevelType = "Desert";
                    break;
            }
            //Decoration decoration;

            for (int i = 0; i < level.tiles.Length; i++)
            {
                TileInfo tileInfo = level.tiles[i];//typeLevel
                tile = new Tile(Scene, $"LevelDesign/Tiles/{LevelType}/{tileInfo.name}.png", tileWidth * tileInfo.column, tileHeight * tileInfo.row, tileWidth, tileHeight);
                Scene.AddObject(tile);
            }

            Santa santa = new Santa(Scene, "Characters/Santa/santa_idle_right.gif", level.playerFirstPositionX, level.playerFirstPositionY, Santa.SantaType.idleRight, 55, 80);
            Scene.AddObject(santa);
            _gift = new Gift(Scene, "Graphics/gift.png", level.giftPositionX, level.giftPositionY, 64, 64);
            Scene.AddObject(_gift);
            Resume();
        }
        //public bool IfAGameStarted()//בודק אם השחקן נימצה במהלך המישחק
        //{ return GameState == GameState.Started && !gift.giftFound; }
    }
}
