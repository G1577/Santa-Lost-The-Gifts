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
using System.Linq;

namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        public GameParams _gameParams; //מכיל מידע של המישתמש
        
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
        }

        // checks if the level the player chose is it last one.
        public bool CheckIfCurrentIsLast()
        {
            if (_gameParams.chosenLevel != _gameParams.userData.LastLevel || !_gameParams.chosenLevelType.Equals(_gameParams.userData.LevelType))
                return false;
            return true;
        }
        public void ChangeLevel()//מחליף שלב
        {
            if (CheckIfCurrentIsLast())
            {
                // update money or gains - not next locked level jump, only change chosen level
            }
            else
            {
                long numLevelPerEnv = MongoServer.GetNumberOfLevelsPerEnv(_gameParams.chosenLevelType);
                if (_gameParams.chosenLevel + 1 < numLevelPerEnv)
                {
                    SQLServer.UpdateUserLevel(_gameParams.userData, _gameParams.chosenLevel + 1, _gameParams.chosenLevelType);
                }
                else
                {
                    if (_gameParams.chosenLevelType.Equals("NorthPole"))
                    {
                        SQLServer.UpdateUserLevel(_gameParams.userData, 0, "Desert");
                    }
                    else if (_gameParams.chosenLevelType.Equals("Desert"))
                    {
                        SQLServer.UpdateUserLevel(_gameParams.userData, 0, "Forest");
                    }
                }
            }
        }

        // checks if the level the user just finished was the last level in the game
        public bool IsGameOver(int finishedLevelIndex, string levelType)
        {
            long lastLevelIndex= MongoServer.GetNumberOfLevelsPerEnv("Forest") - 1;
            if (levelType.Equals("Forest") && finishedLevelIndex == lastLevelIndex)
            {
                return true;
            }
            return false;
        }

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
            Gift gift = new Gift(Scene, "Graphics/gift.png", level.giftPositionX, level.giftPositionY, 64, 64);
            Scene.AddObject(gift);
            Resume();
        }
    }
}
