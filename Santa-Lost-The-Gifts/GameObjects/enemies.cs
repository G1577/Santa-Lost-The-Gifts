using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Santa_Lost_The_Gifts.GameObjects.Santa;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class enemies : GameMovingObject
    {
        private double _width;
        private double _height;

        public enemies(Scene scene, string fileName, double placeX, double placeY, double width, double height) :
            base(scene, fileName, placeX, placeY)
        {
            _X = placeX;
            _Y = placeY;
            _width = width;
            _height = height;
            Image.Width = width;
            Image.Height = height;
            Collisional = true;
            _ddY = 0.8;
        }
        public override void Collide(GameObject gameObject)
        {

        }
    }
}
