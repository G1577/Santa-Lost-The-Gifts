using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Lost_The_Gifts.GameObjects
{
    internal class Tile : GameObject
    {
        public Tile(Scene scene, string fileName, double placeX, double placeY, double width, double height) :
             base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = height;
            Collisional = true;
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject != null)
            {
                if (gameObject is Santa santa)
                {
                    //var rect = RectHelper.Intersect(this.Rect, floor.Rect);
                    
                }
            }
        }
    }
}
