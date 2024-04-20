using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using MongoProject.Modules;

namespace MongoProject.Modules
{
    public enum LevelEnvironment
    {
        NorthPole,
        Forest,
        Dessert
    }
    public class Level
    {
        int index;
        LevelEnvironment levelEnvironment;
        Tile[] tiles;
        Decoration[] decorations;
        int playerFirstPositionX;
        int playerFirstPositionY;
        // We will have enemies array in the future;


    }
}