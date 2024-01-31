using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Santa_Lost_The_Gifts.GameObjects.Ninja;
using Windows.Foundation;
using Windows.System;
using GameEngine.GameObjects;
using static Santa_Lost_The_Gifts.GameObjects.Santa;

namespace Santa_Lost_The_Gifts.GameObjects
{
    public class Santa: GameMovingObject
    { 

        public enum SantaType
        {
            standingRight,
            goRight,
            jumpRight,
            goLeft,
            standingLeft,
            jumpLeft

        }
        private double _width;
        private double _height;
        private SantaType _santaType;
        private bool ifDown = false;

        public Santa(Scene scene, string fileName, double placeX, double placeY, SantaType santaType, double width, double height) :
            base(scene, fileName, placeX, placeY)
        {
            _X = placeX;
            _Y = _scene.ActualHeight - _height;
            _width = width;
            _height = height;
            Image.Width = width;
            Image.Height = height;
            _santaType = santaType;
            Manager.GameEvent.OnKeyUp += KeyUp;
            Manager.GameEvent.OnKeyDown += KeyDown;

        }

        private void KeyUp(VirtualKey key)
        {
            _dX = 0;
            if (_dY == _scene.ActualHeight - _height)
                _dY = 0;
            else _dY = 3;
        }

        private void KeyDown(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Left:
                    _dX = -3; break;
                case VirtualKey.Right:
                    _dX = 3; break;
                case VirtualKey.Up:
                    Jump(); break;
            }
            Render();
        }
        private void Jump()
        {
            if (_Y <= _scene.ActualHeight - _height - 150)
                ifDown = true;
            if (!ifDown)
                _dY = -3;
            if (ifDown)
                _dY = 3;
            if (_Y >= _scene.ActualHeight - _height)
            {
                _Y = _scene.ActualHeight - _height;
                ifDown = false;
            }
        }

        private void SetImage()
            {
                switch (_santaType)
                {
                case SantaType.standingRight://עומד ימין
                    base.SetImage(_fileName); break;
                case SantaType.goRight://הולך ימינה
                    base.SetImage(_fileName); break;
                case SantaType.jumpRight://קופץ ימינה
                    base.SetImage(_fileName); break;
                case SantaType.goLeft://קופץ שמולה
                    base.SetImage(_fileName); break;
                case SantaType.standingLeft://עומד שמול
                    base.SetImage(_fileName); break;
                case SantaType.jumpLeft://קפיצה לשמול
                    base.SetImage(_fileName); break;
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
    }
}
