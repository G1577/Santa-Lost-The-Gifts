using GameEngine.GameServices;
using MongoProject.Modules;
using Santa_Lost_The_Gifts.GameObjects;
using Santa_Lost_The_Gifts.GameServices;
using SQLProject;
using SQLProject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
        private static GameParams gameParams;
        private static bool loggedIn = false;

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
            WinGrid.Visibility = Visibility.Collapsed;
            WinGridNoSignIn.Visibility = Visibility.Collapsed;

            GameOverGrid.Visibility = Visibility.Collapsed;
            FailureGrid.Visibility = Visibility.Collapsed;

            base.OnNavigatedTo(e);
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                gameParams = (GameParams)e.Parameter;
                loggedIn = true;
                _gameManager = new GameManager(scene, gameParams);
            }
            else
            {
                if (!loggedIn)
                {
                    gameParams = null;
                    _gameManager = new GameManager(scene, null);
                }
            }
            Manager.GameEvent.OnWin += WonGame;
            Manager.GameEvent.removeLives += RemoveLives;
            Manager.GameEvent.addLives += AddLives;
        }

        private void NextLevel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage), _gameManager._gameParams);
            WinGrid.Visibility = Visibility.Collapsed;
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            if (gameParams != null && gameParams.userData != null)
                this.Frame.Navigate(typeof(MainPage), gameParams.userData);
            else
                this.Frame.Navigate(typeof(MainPage), null);
            WinGrid.Visibility = Visibility.Collapsed;
            GameOverGrid.Visibility = Visibility.Collapsed;
            FailureGrid.Visibility = Visibility.Collapsed;
        }

        private void WonGame()
        {
            if (gameParams != null)
            {
                if (_gameManager.IsGameOver(gameParams.chosenLevel, gameParams.chosenLevelType))
                {
                    GameOverGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    _gameManager.ChangeLevel();
                    if (_gameManager.CheckIfCurrentIsLast())
                    {
                        gameParams.userData = SQLServer.GetUser(gameParams.userData.UserId);
                        gameParams.chosenLevel = gameParams.userData.LastLevel;
                        gameParams.chosenLevelType = gameParams.userData.LevelType;
                        WinGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        WinGrid.Visibility = Visibility.Visible;
                        NextLevel.Visibility = Visibility.Collapsed;
                    }

                }
            }
            else
            {
                // NO ACTUAL USER TO SAVE DATA
                WinGridNoSignIn.Visibility = Visibility.Visible;
            }
        }
        private void RemoveLives(int lives)
        {
            switch (lives)
            {
                case 2: lives3.Visibility = Visibility.Collapsed; break;
                case 1: lives2.Visibility = Visibility.Collapsed; break;
                case 0: 
                    lives1.Visibility = Visibility.Collapsed;
                    FailureGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void AddLives(int lives)
        {
            switch (lives)
            {
                case 3: lives3.Visibility = Visibility.Visible; break;
                case 2: lives2.Visibility = Visibility.Visible; break;
            }
        }

        private void SignInNonUser_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignInPage));
        }
    }
}
