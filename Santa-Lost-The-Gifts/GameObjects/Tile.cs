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
            if (!fileName.Contains("water_middle") && !fileName.Contains("water_top"))
                Collisional = true;
            else
                Collisional = false;
        }
        
    }
}
