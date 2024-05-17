using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text
    ;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using static GameEngine.GameServices.Constants;

namespace GameEngine.GameServices
{
    public abstract class Manager
    {
        public Scene Scene { get; private set; }//מגרש המגרש
        public static GameState GameState { get; set; } = GameState.Loaded;//מכיל באיזה מצב המישחק נמצה
        private static DispatcherTimer _runTimer;//תיימר שיפעל כל הזמן
        public static GameEvents GameEvent { get; } = new GameEvents();//


        public Manager(Scene scene)
        {
            Scene = scene;
            _runTimer = new DispatcherTimer();//הגדרת תיימר
            _runTimer.Interval = TimeSpan.FromMilliseconds(1);
            _runTimer.Start();
            _runTimer.Tick += _runTimer_Tick;//מגדיר איזו פעולה התיימר מפעיל

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;//הושפת הפעולה לארוע
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;//הושפת הפעולה לארוע
        }

        private void _runTimer_Tick(object sender, object e)//הזאת הפעולה שהגדרנו על שהתיימר יפעיל
        {
            if (GameEvent.OnRun != null)
            {
                GameEvent.OnRun();
            }
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)//הפעולה שקורת כל פעם שאוזבים מקש
        {
            if (GameEvent.OnKeyUp != null)
            {
                GameEvent.OnKeyUp(args.VirtualKey);
            }
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)//הפעולה שקורת שלוחצים על מקש
        {
            if (GameEvent.OnKeyDown != null)
            {
                GameEvent.OnKeyDown(args.VirtualKey);
            }
        }


        public void Resume()//
        {
            Scene.Init();
            GameState = GameState.Started;
        }
        public void Pause()//
        {
            GameState = GameState.Paused;
        }
        public bool GameOver()//
        {
            if (GameState != GameState.GameOver)
            {
                GameState = GameState.GameOver;
                return true;
            }
            return false;
        }
    }
}
