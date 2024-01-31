using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Composition.Scenes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace GameEngine.GameObjects
{
    public abstract class GameObject
    {
        protected double _X;//מיקום נכחי
        protected double _Y;//מיקום נכחי
        protected double _placeX;//מיקום התחלתי
        protected double _placeY;//מיקום התחלתי
        public Image Image { get; set; }//תמונה
        protected string _fileName;
        public double Width => Image.Width;
        public double Height => Image.Height;
        public virtual Rect Rect => new Rect(_X, _Y, Width, Height);
        public bool Collisional { get; set; }
        protected Scene _scene;

        public GameObject(Scene scene, string fileName, double X, double Y)
        {
            _scene = scene;
            _fileName = fileName;
            _X = X;
            _Y = Y;
            _placeX = X;
            _placeY = Y;
            Image = new Image();
            Render();
            SetImage(_fileName);
        }

        public virtual void Render()
        {
            Canvas.SetLeft(Image, _X);
            Canvas.SetTop(Image, _Y);
        }
        protected void SetImage(string fileName)
        {
            Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{fileName}"));
        }
        public virtual void Init()
        {
            _placeX = _X;
            _placeY = _Y;
        }
        public virtual void Collide(GameObject gameObject)
        { }
    }
}
