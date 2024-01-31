using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameObjects;
using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        public GameManager(Scene scene) : base(scene)
        {
            scene.Ground = scene.ActualHeight - 60;
            Init();
        }

        public void Init()
        {
            Scene.RemoveAllObject();
            AppFloor();
            Ninja ninja = new Ninja(Scene, "Graphics/Glide_007.png", 9, 9,Ninja.NinjaType.standingRight, 80, 150);
            Scene.AddObject(ninja);
            Scene.Init();
        }
        private void AppFloor()
        {
            Random random = new Random();
            Floor floor;
            double y = 300;
            for (int i = 0; i < 4; i++) 
            {
                floor = new Floor(Scene, "Bar/Bar.png",random.Next(0, 350) , y, 200, 50);
                Scene.AddObject(floor);
                floor = new Floor(Scene, "Bar/Bar.png", random.Next(550, 900), y, 200, 50);
                Scene.AddObject(floor);
                y -= floor.Height + 34;
            }
        }
    }
}
