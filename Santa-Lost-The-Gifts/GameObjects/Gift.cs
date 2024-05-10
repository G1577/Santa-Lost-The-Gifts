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
        public bool giftFound {  get; set; }

        public Gift(Scene scene,string fileName, double placeX, double placeY, double width, double height) :
             base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = height;
            Collisional = true;
            giftFound = false;
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject is Santa)
            {
                giftFound = true;
               // Collisional = false;
                var dialog = new Windows.UI.Popups.MessageDialog("her success", "Well done, you managed to pass the stage ");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
            }
        }
    }
}
