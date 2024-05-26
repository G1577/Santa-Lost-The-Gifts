using GameEngine.GameObjects;
using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.GameServices.Constants;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class Gift : GameObject
    {
        public Gift(Scene scene,string fileName, double placeX, double placeY, double width, double height):
             base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = height;
            Collisional = true;
        }   
    }
}
