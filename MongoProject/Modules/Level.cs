using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        short[,] tilesAndObjects;
        // Enemy[] enemies;
        int playerFirstPositionX;
        int playerFirstPositionY;
        short[,] levelTiles = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 2, 0, 0 },

            { 0, 0, 0, 0, 0, 1, 3, 2, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0 },

            { 9, 11, 11 ,10, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0 , 0, 0, 0, 0 },

            { 14, 14, 13, 10, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0 ,0 },

            { 14, 14, 14 ,13, 10, 16, 16 ,16, 16, 16, 16 ,16, 16, 16, 16 ,16, 16, 16, 16 ,16 }
        };
    }
}
