using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameServices
{
    public sealed class Constants
    {
        public enum GameState//המצבים שבהם המשחק יהיה בהם
        {
            Loaded,
            Started,
            Paused,
            GameOver
        }
        public static double SpeedUnit = 6;
    }
}
