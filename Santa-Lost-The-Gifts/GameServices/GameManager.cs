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
            // soon will be with matrix 8*20, each tile will be 64*64 
            Tile tile = new Tile(Scene, "Tiles/inner_ground_middle.png", 0, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/inner_ground_middle.png", 64, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/inner_ground_middle.png", 128, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/inner_ground_middle.png", 192, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/inner_ground_end_right.png", 256, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/water_top.png", 320, Scene.ActualHeight - 64, 64, 80);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/water_top.png", 384, Scene.ActualHeight - 64, 64, 80);
            Scene.AddObject(tile);

            tile = new Tile(Scene, "Tiles/ground_snow_middle.png", 0, Scene.ActualHeight - 128, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/ground_snow_middle.png", 64, Scene.ActualHeight - 128, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/ground_snow_middle.png", 128, Scene.ActualHeight - 128, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/ground_snow_middle.png", 192, Scene.ActualHeight - 128, 64, 64);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/ground_snow_end_right.png", 256, Scene.ActualHeight - 128, 64, 64);
            Scene.AddObject(tile);

            tile = new Tile(Scene, "Tiles/ground_snow_end_right.png", 320, Scene.ActualHeight - 64, 64, 64);
            Scene.AddObject(tile);

            tile = new Tile(Scene, "Tiles/water_top.png", 448, Scene.ActualHeight - 64, 64, 80);
            Scene.AddObject(tile);
            tile = new Tile(Scene, "Tiles/water_top.png", 512, Scene.ActualHeight - 64, 64, 80);
            Scene.AddObject(tile);
            // Ninja ninja = new Ninja(Scene, "Characters/Ninja/ninja_idle_right.gif", 10, Scene.ActualHeight - 64, Ninja.NinjaType.idleRight, 119, 186, 300, 150);
            Santa santa = new Santa(Scene, "Characters/Santa/santa_jump_left.gif", 1100, Scene.ActualHeight - 64, Santa.SantaType.idleLeft, 119, 186, 300, 150);
            //Scene.AddObject(ninja);
            Scene.AddObject(santa);
            Scene.Init();
        }
    }
}
