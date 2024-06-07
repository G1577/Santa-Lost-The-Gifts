using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameEngine.GameServices
{
    public abstract class Scene : Canvas
    {
        private List<GameObject> _gameObjects = new List<GameObject>();//רשימה של כל האוביקטים
        protected List<GameObject> _gameObjectsSnapshot => _gameObjects.ToList();//העתק
        public double Ground { get; set; }//האדמה של המשחק

        public Scene()
        {
            Manager.GameEvent.OnRun += Run;//כך אתה נרשם ל'OnRun'
            Manager.GameEvent.OnRun += CheckCollisional;
        }

        private void CheckCollisional()//הפעולה דועגת להפעיל את הפעולות התנגשות של האובייקטים
        {
            foreach (var gameObject in _gameObjectsSnapshot)
            {
                if (gameObject.Collisional)
                {
                    var otherObject = _gameObjectsSnapshot.FirstOrDefault(g => !ReferenceEquals(g, gameObject) && g.Collisional
                    && !RectHelper.Intersect(g.Rect, gameObject.Rect).IsEmpty);
                    if (otherObject != null)
                        gameObject.Collide(otherObject);
                    else
                        gameObject.NoCollide();
                }
            }
        }

        private void Run()//הפעולה מפעילה את את הפעולות של האובייקטים האחריים לתזוזה שלהם
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject is GameMovingObject obj)
                {
                    obj.Render();
                }
            }
        }
        public void Init()//הפעולה מחזירה את כל האובייקטים למיקום ההתחלתי
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.Init();
            }
        }
        public void RemoveObject(GameObject obj)//מוצי אובייקט ספציפי
        {
            if (_gameObjects.Contains(obj))
            {
                _gameObjects.Remove(obj);
                Children.Remove(obj.Image);
            }
        }
        public void RemoveAllObject()//מוצי את כל האובייקטים
        {
            foreach (GameObject obj in _gameObjects)
            {
                RemoveObject(obj);
            }
        }
        public void AddObject(GameObject obj)//מוסיף עוד אובייקט לרשימה
        {
            _gameObjects.Add(obj);
            Children.Add(obj.Image);
        }
    }
}
