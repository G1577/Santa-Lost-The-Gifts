using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class MovingTile: GameMovingObject
    {
        private double _x;
        private double _y;
        public MovingTile(Scene scene, string fileName, double placeX, double placeY, double x, double y) :
        base(scene, fileName, placeX, placeY)
        {
            _x = x;
            _y = y;
            Image.Width = 200;
            Image.Height = 50;
            Collisional = true;
        }

        public void Move() 
        {
            if (_x == _X) 
            {

            }
        }
    }
}
