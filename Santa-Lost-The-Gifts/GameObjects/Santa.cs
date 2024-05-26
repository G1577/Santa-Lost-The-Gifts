using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using GameEngine.GameObjects;
using Windows.UI.Xaml;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class Santa : GameMovingObject
    {
        public enum SantaType//המצב שבו הדמות יכולה ליהיות לדוגמה לרוץ יצינה או לעמוד לקיבון סמול
        {
            idleRight,
            runRight,
            jumpRight,
            runLeft,
            idleLeft,
            jumpLeft
        }
        private double _width;
        private double _height;
        private SantaType _santaType;

        private int _lives = 3;

        public Santa(Scene scene, string fileName, double placeX, double placeY, SantaType santaType, double width, double height) :
            base(scene, fileName, placeX, placeY)
        {
            _X = placeX;
            _Y = placeY;
            _width = width;
            _height = height;
            Image.Width = width;
            Image.Height = height;
            _santaType = santaType;
            Manager.GameEvent.OnKeyUp += KeyUp;
            Manager.GameEvent.OnKeyDown += KeyDown;
            Collisional = true;
            _ddY = 0.5;
        }

        private void KeyUp(VirtualKey key)
        {
            _dX = 0;
            switch (key)
            {
                case VirtualKey.Left:
                    IdleLeft();
                    break;
                case VirtualKey.Right:
                    IdleRight();
                    break;
            }
        }
    
        private void KeyDown(VirtualKey key)
        {

            switch (key)
            {
                case VirtualKey.Left:
                    RunLeft(); break;
                case VirtualKey.Right:
                    RunRight(); break;
                case VirtualKey.Up:
                    Jump(); break;
            }
            Render();
        }  

        private void Jump()
        {
            if (_dY == 0)
            {
                if (_santaType == SantaType.idleLeft || _santaType == SantaType.runLeft)
                {
                    _santaType = SantaType.jumpLeft;
                }
                if (_santaType == SantaType.idleRight || _santaType == SantaType.runRight)
                {
                    _santaType = SantaType.jumpRight;
                }
                SetImage();
                _dY = -15;
                
            }
        }

        private void RunRight()
        {
            if (_santaType != SantaType.runRight)
            {
                _santaType = SantaType.runRight;
                SetImage();
                _dX = 3;
            }
        }

        private void RunLeft()
        {
            if (_santaType != SantaType.runLeft)
            {
                _santaType = SantaType.runLeft;
                SetImage();
                _dX = -3;
            }
        }

        private void IdleLeft()
        {
            if (_santaType != SantaType.idleLeft)
            {
                _santaType = SantaType.idleLeft;
                SetImage();
                _dX = 0;
                _dY = 0;
            }
        }

        private void IdleRight()
        {
            if (_santaType != SantaType.idleRight)
            {
                _santaType = SantaType.idleRight;
                SetImage();
                _dX = 0;
                _dY = 0;
            }
        }

        private void SetImage()
        {
            switch (_santaType)
            {
                case SantaType.idleRight://עומד ימין
                    base.SetImage("Characters/Santa/santa_idle_right.gif"); break;
                case SantaType.runRight://רץ ימינה
                    base.SetImage("Characters/Santa/santa_run_right.gif"); break;
                case SantaType.jumpRight://קופץ ימינה
                    base.SetImage("Characters/Santa/santa_jump_right.gif"); break;
                case SantaType.runLeft://רץ שמאלה
                    base.SetImage("Characters/Santa/santa_run_left.gif"); break;
                case SantaType.idleLeft://עומד שמאל
                    base.SetImage("Characters/Santa/santa_idle_left.gif"); break;
                case SantaType.jumpLeft://קפיצה שמאלה
                    base.SetImage("Characters/Santa/santa_jump_left.gif"); break;
            }
        }
        public override void Render()
        {
            base.Render();
            
            if (_X <= 0)
            {
                _X = 0;
            }
            if (_Y <= 0)
            {
                _Y = 0;
            }
            if (_X >= _scene.ActualWidth - _width)
            {
                _X = _scene.ActualWidth - _width;
            }
            if (_Y >= _scene.ActualHeight - _height)
            {
                _Y = _scene.ActualHeight - _height;
                _dY = 0;
                _lives = 0;
                //Manager.GameEvent.removeLives(_lives);
                if (_santaType == SantaType.jumpLeft) 
                    IdleLeft();
                if (_santaType == SantaType.jumpRight)
                    IdleRight();
            }
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject is Gift gift)
            {
                if (Manager.GameEvent.OnWin != null)
                {
                    Manager.GameEvent.OnWin();
                    //Manager.GameOver();
                }
                Manager.GameEvent.OnKeyUp -= KeyUp;
                Manager.GameEvent.OnKeyDown -= KeyDown;
                _dX = 0;
                _dY = 0;
                SetImage("Characters/Santa/santa_idle_right.gif");
            }
            if (gameObject is Tile tile)
            {
                var rect = RectHelper.Intersect(this.Rect, tile.Rect);
                if (rect.Height != 0 && rect.Width != 0)
                {
                    if (rect.Height > rect.Width)
                    {
                        if (_dX > 0) // moving right
                        {
                            _dX = 0;
                            _dY = 0;
                            _X -= rect.Width;
                        }
                        else if (_dX < 0)
                        {
                            _dX = 0;
                            _dY = 0;
                            _X += rect.Width;
                        }
                    }
                    else
                    {
                        if (_dY > 0) // moving down
                        {
                            if (_santaType == SantaType.jumpLeft)
                            {
                                IdleLeft();
                            }
                            else if (_santaType == SantaType.jumpRight)
                            {
                                IdleRight();
                            }
                            else
                            {
                                _dY = 0;
                            }
                            _Y -= rect.Height;
                        }
                        else if (_dY < 0) //moving up
                        {
                            _dY = 0;
                            _Y += rect.Height;
                        }
                    }
                }
            }
            if (gameObject is Enemy)
            {
                _dX *= -1;
                _dY = 10;
                _lives--;
                Manager.GameEvent.removeLives(_lives);
            }
        }
    }
}
