using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Santa_Lost_The_Gifts.GameObjects.Ninja;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class Enemy : GameMovingObject
    {
        public enum EnemyType
        {
            evilSnowMan,
            angryEagle,
            murderousTree
        }
        private double _width;
        private double _height;
        private EnemyType _enemyType;
        // LevelEnvironment levelEnvironment
        public Enemy(Scene scene, string fileName, double placeX, double placeY, double width, EnemyType enemyType, double height) :
    base(scene, fileName, placeX, placeY)
        {
            _X = placeX;
            _Y = placeY;
            _width = width;
            _height = height;
            Image.Width = width;
            Image.Height = height;
            _fileName = fileName;
            _enemyType = enemyType;
            //Manager.GameEvent.OnKeyUp += KeyUp;
            // Manager.GameEvent.OnKeyDown += KeyDown;
            Collisional = true;
        }

    }
}
