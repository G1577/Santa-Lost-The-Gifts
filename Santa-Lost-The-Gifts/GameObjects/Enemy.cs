using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Santa_Lost_The_Gifts.GameObjects.Santa;
using Windows.UI.Xaml;

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
            _ddY = 0.5;
            _dX = 5;
            Collisional = true;
        }
        public override void Collide(GameObject gameObject)
        {

            if (gameObject is Tile tile)
            {
                var rect = RectHelper.Intersect(this.Rect, tile.Rect);
                if (rect.Height != 0 && rect.Width != 0)
                {
                    if (rect.Height > rect.Width)
                    {
                        _dX *= -1;
                    }
                    else
                    {
                        _dX = 0;
                    }
                }
                if (gameObject is Santa)
                {
                    _dX *= -1;
                    _dY = 10;
                }
            }
        }
        public override void Render()
        {
            base.Render();
            if (_X <= 0)
            {
                _X = 0;
            }
            if (_Y <= 0)
            {
                _Y = 0;
            }
            if (_X >= _scene.ActualWidth - _width)
            {
                _X = _scene.ActualWidth - _width;
            }
            if (_Y >= _scene.ActualHeight - _height)
            {
                _Y = _scene.ActualHeight - _height;
                _dY = 0;
            }
            Random rand = new Random();
            if (rand.Next(1, 4) == 0)
            {
                _dX *= -1;
            }
        }
    }
}
