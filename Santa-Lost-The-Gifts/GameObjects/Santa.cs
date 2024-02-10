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
        public enum SantaType
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
        private bool _reachedMaxJump = false;

        public Santa(Scene scene, string fileName, double placeX, double placeY, SantaType santaType, double width, double height, int longJumpHeight, int shortJumpHeight) :
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
        }

        private void KeyUp(VirtualKey key)
        {
            _dX = 0;
            if (_dY == _scene.ActualHeight - _height)
                _dY = 0;
            else _dY = 3;
            if (_santaType != SantaType.idleLeft && _santaType != SantaType.idleRight)
            {
                if (_santaType == SantaType.runLeft)
                {
                    _santaType = SantaType.idleLeft;
                    SetImage();
                }
                if (_santaType == SantaType.runRight)
                {
                    _santaType = SantaType.idleRight;
                    SetImage();
                }
            }
        }

        private void KeyDown(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.A:
                    RunLeft(); break;
                case VirtualKey.D:
                    RunRight(); break;
                case VirtualKey.W:
                    Jump(); break;
            }
            Render();
        }

        private void Jump()
        {
            if (_santaType != SantaType.jumpLeft && _santaType != SantaType.jumpRight)
            {
                if (_santaType == SantaType.idleLeft || _santaType == SantaType.runLeft)
                    _santaType = SantaType.jumpLeft;
                else if (_santaType == SantaType.idleRight || _santaType == SantaType.runRight)
                    _santaType = SantaType.jumpRight;
                SetImage();
                if (_Y <= _scene.ActualHeight - _height - 150)
                    _reachedMaxJump = true;
                if (!_reachedMaxJump)
                    _dY = -3;
                if (_reachedMaxJump)
                    _dY = 3; // יורד למטה הציר הפוך
                if (_Y >= _scene.ActualHeight - _height)
                {
                    _Y = _scene.ActualHeight - _height;
                    _reachedMaxJump = false;
                }
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
            switch (_santaType)//-ezgif.com-crop
            {
                case SantaType.idleRight://עומד ימין
                    base.SetImage("Characters/Santa/santa_idle_right.gif"); break;
                case SantaType.runRight://רץ ימינה
                    base.SetImage("Characters/Santa/santa_running_right.gif"); break;
                case SantaType.jumpRight://קופץ ימינה
                    base.SetImage("Characters/Santa/santa_jump_right.gif"); break;
                case SantaType.runLeft://רץ שמאלה
                    base.SetImage("Characters/Santa/santa_running_left.gif"); break;
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
            if (Rect.Right >= _scene.ActualWidth)
            {
                _X = _scene.ActualWidth - _width;
            }
            if (Rect.Bottom >= _scene.ActualHeight)
            {
                _Y = _scene.ActualHeight - _height;
            }
        }

        public override void Collide(GameObject gameObject)
        {
            if (gameObject != null)
            {
                if (gameObject is Tile floor)
                {
                    var rect = RectHelper.Intersect(this.Rect, floor.Rect);
                    if (rect.Width > rect.Height)
                    {
                        _dY = 0;
                        _Y -= rect.Height;
                    }
                    else
                    {
                        if (_dX < 0)
                        {
                            _dX = 0;
                            _X += rect.Width;
                        }
                        else
                        {
                            _dX = 0;
                            _X -= rect.Width;
                        }
                    }
                }
                if (gameObject is Ninja ninja) 
                {
                    var rect = RectHelper.Intersect(this.Rect, ninja.Rect);
                    if (_dX < 0)
                    {
                        _dX = 0;
                        _X += rect.Width;
                    }
                    else
                    {
                        _dX = 0;
                        _X -= rect.Width;
                    }
                }
            }
        }
    }
}
