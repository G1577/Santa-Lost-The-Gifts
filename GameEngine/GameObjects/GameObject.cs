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
        protected string _fileName;// הכתובת של התמונה(המיקום שלה)
        public double Width => Image.Width;//מחזיר את ברוכב של האובייקט
        public double Height => Image.Height;//מחיל את הגובה של האובייקט
        public virtual Rect Rect => new Rect(_X, _Y, Width, Height);//המלבן המקיף את האובייקט
        public bool Collisional { get; set; }//נתן לשלות אם האובייקט שקוף
        protected Scene _scene;//מגרש המשחקים

        public GameObject(Scene scene, string fileName, double X, double Y)
        {
            _scene = scene;
            _fileName = fileName;
            _X = X;
            _Y = Y;
            _placeX = X;
            _placeY = Y;//כך יזקור עצם היכן הוא נוצר
            Image = new Image();// כך יזקור עצם היכן הוא נוצר
            Render();
            SetImage(_fileName);
        }

        public virtual void Render()// מצייר את האובייקת על המסך
        {
            Canvas.SetLeft(Image, _X);
            Canvas.SetTop(Image, _Y);
        }
        protected void SetImage(string fileName)//קובעה מה התמונה של האובייקט
        {
            Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{fileName}"));
        }
        public virtual void Init()//מחזיר את האבייקט לנקודה האתחלתית
        {
            _placeX = _X;
            _placeY = _Y;
        }
        //הפעולה פועלת כל פעם שהאובייקט מתנגש אם אובייקט אחר. הפעולה רקה כי כל אובייקט דגובה אחרת
        public virtual void Collide(GameObject gameObject)
        { }
    }
}
