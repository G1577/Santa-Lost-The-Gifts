using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using static Santa_Lost_The_Gifts.GameObjects.Ninja;
using static Santa_Lost_The_Gifts.GameObjects.Santa;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class Ninja : GameMovingObject
    {
        public enum NinjaType
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
        private NinjaType _ninjaType;
        private bool _reachedMaxJump = false;
        //private int _longJumpHeight;
        private int _shortJumpHeight;

        public Ninja(Scene scene, string fileName, double placeX, double placeY, NinjaType ninjaType, double width, double height, int longJumpHeight, int shortJumpHeight) :
            base(scene, fileName, placeX, placeY)
        {
            _X = placeX;
            _Y = placeY;
            _width = width;
            _height = height;
            Image.Width = width;
            Image.Height = height;
            _ninjaType = ninjaType;
            //_longJumpHeight = longJumpHeight;
            _shortJumpHeight = shortJumpHeight;
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
            if (_ninjaType != NinjaType.idleLeft && _ninjaType != NinjaType.idleRight)
            {
                if (_ninjaType == NinjaType.runLeft)
                {
                    _ninjaType = NinjaType.idleLeft;
                    SetImage();
                }
                if (_ninjaType == NinjaType.runRight)
                {
                    _ninjaType = NinjaType.idleRight;
                    SetImage();
                }

                if (_ninjaType == NinjaType.jumpRight)
                {
                    if (_Y >= _scene.ActualHeight - _height)
                    {
                        _ninjaType = NinjaType.idleRight;
                        SetImage();
                    }
                }
                if (_ninjaType == NinjaType.jumpLeft)
                {
                    if (_Y >= _scene.ActualHeight - _height)
                    {
                        _ninjaType = NinjaType.idleLeft;
                        SetImage();
                    }
                }
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
            if (_ninjaType != NinjaType.jumpLeft && _ninjaType != NinjaType.jumpRight)
            {
                if (_ninjaType == NinjaType.idleLeft || _ninjaType == NinjaType.runLeft)
                    _ninjaType = NinjaType.jumpLeft;
                else if (_ninjaType == NinjaType.idleRight || _ninjaType == NinjaType.runRight)
                    _ninjaType = NinjaType.jumpRight;
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
            if (_ninjaType != NinjaType.runRight)
            {
                _ninjaType = NinjaType.runRight;
                SetImage();
                this._dX = 3;
            }
        }

        private void RunLeft()
        {
            if (_ninjaType != NinjaType.runLeft)
            {
                _ninjaType = NinjaType.runLeft;
                SetImage();
                this._dX = -3;
            }
        }

        internal void IdleLeft()
        {
            if (_ninjaType != NinjaType.idleLeft)
            {
                _ninjaType = NinjaType.idleLeft;
                SetImage();
                _dX = 0;
                _dY = 0;
            }
        }

        private void IdleRight()
        {
            if (_ninjaType != NinjaType.idleRight)
            {
                _ninjaType = NinjaType.idleRight;
                SetImage();
                _dX = 0;
                _dY = 0;
            }
        }

        private void SetImage()
        {
            switch (_ninjaType)
            {
                case NinjaType.idleRight://עומד ימין
                    base.SetImage("Characters/Ninja/ninja_idle_right.gif"); break;
                case NinjaType.runRight://רץ ימינה
                    base.SetImage("Characters/Ninja/ninja_running_right.gif"); break;
                case NinjaType.jumpRight://קופץ ימינה
                    base.SetImage("Characters/Ninja/ninja_jump_right.gif"); break;
                case NinjaType.runLeft://רץ שמאלה
                    base.SetImage("Characters/Ninja/ninja_running_left.gif"); break;
                case NinjaType.idleLeft://עומד שמאל
                    base.SetImage("Characters/Ninja/ninja_idle_left.gif"); break;
                case NinjaType.jumpLeft://קפיצה שמאלה
                    base.SetImage("Characters/Ninja/ninja_jump_left.gif"); break;
            }
        }
        public override void Render()
        {
            base.Render();
            if (_X <= 0)
            {
                _X = 3;
            }
            if (_Y <= 0)
            {
                _Y = 3;
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
                if (gameObject is Santa santa)
                {
                    var rect = RectHelper.Intersect(this.Rect, santa.Rect);
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
