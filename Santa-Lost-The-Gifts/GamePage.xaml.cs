using GameEngine.GameServices;
using MongoProject.Modules;
using Santa_Lost_The_Gifts.GameObjects;
using Santa_Lost_The_Gifts.GameServices;
using SQLProject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using static GameEngine.GameServices.Constants;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private GameManager _gameManager;
        private DispatcherTimer timeToCombine;
        private int timeLeft = 70;
        public GamePage()
        {
            this.InitializeComponent();
        }
        private async void Main_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            var dialog = new Windows.UI.Popups.MessageDialog(
               "Are you sure you want to exit? ",
               "Message");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();
            if (result.Label == "Yes")
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                var userData = (GameUser)e.Parameter;
                _gameManager = new GameManager(scene, null);
            }
            else
            {
                _gameManager = new GameManager(scene, null);
            }
        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)//, NavigationEventArgs navigationEvent)
        //{
        //    //base.OnNavigatedTo(navigationEvent);
        //    //if (navigationEvent.Parameter != null && !navigationEvent.Parameter.Equals(""))
        //    //{
        //    //    var userData = (GameUser)navigationEvent.Parameter;
        //    //    _gameManager = new GameManager(scene, userData);
        //    //}
        //    //else
        //    //{
        //    //    _gameManager = new GameManager(scene, null);
        //    //}
        //    _gameManager = new GameManager(scene, null);
        //    //_gameManager.LevelSelection(1, LevelEnvironment.NorthPole);
        //    //timeToCombine = new DispatcherTimer();//הגדרת טיימר
        //    //timeToCombine.Interval = TimeSpan.FromSeconds(1);
        //    //timeToCombine.Start();
        //    //timeToCombine.Tick += TimeToCombine;
        //}
        //private void TimeToCombine(object sender, object e)//הזאת הפעולה שהגדרנו על שהתיימר יפעיל
        //{
        //    if (_gameManager.IfAGameStarted())
        //    {
        //        timeLeft--;
        //        if (timeLeft <= 0)
        //        {
        //            timeLeft = 70;
        //            var dialog = new Windows.UI.Popups.MessageDialog("you failed", "I couldn't get through the stage in time.\n try again");
        //            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
        //            dialog.DefaultCommandIndex = 0;
        //        }
        //    }
        //}
    }
}
