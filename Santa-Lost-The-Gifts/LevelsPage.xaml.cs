 using GameEngine.GameServices;
using SQLProject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using MongoProject;
using MongoProject.Modules;
using System.Net.Sockets;
using Santa_Lost_The_Gifts.GameServices;
using System.Text.RegularExpressions;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LevelsPage : Page
    {
        private static GameUser loggedInUser;
        private static bool loggedIn = false;

        public LevelsPage()
        {
            this.InitializeComponent();
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Level_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            Button button = sender as Button;

            string pattern = @"([a-zA-Z]+)(\d+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(button.Name);
            string chosenLevelType = match.Groups[1].Value;
            int chosenLevel = int.Parse(match.Groups[2].Value);

            GameParams gameParams = new GameParams
            {
                userData = loggedInUser,
                chosenLevel = chosenLevel,
                chosenLevelType = chosenLevelType
            };
            
            this.Frame.Navigate(typeof(GamePage), gameParams);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                var userData = (GameUser)e.Parameter;
                if (userData != null)
                {
                    loggedInUser = userData;
                    loggedIn = true;
                }
            }
            else
            {
                if (!loggedIn)
                {
                    loggedInUser = null;
                }
            }
            string levelType;
            int lastLevel;
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                var userData = (GameUser)e.Parameter;
                levelType = userData.LevelType;
                lastLevel = userData.LastLevel;
            }
            else
            {
                levelType = "NorthPole";
                lastLevel = 0;
            }
            bool isLevelOpen = true;
            
            long totalLevelsPerEnv = MongoServer.GetNumberOfLevelsPerEnv("NorthPole");
            for (int i = 0, column = 1; i < totalLevelsPerEnv; i++, column += 3)
            {
                Button northPole = new Button();
                Grid.SetRow(northPole, 1);
                Grid.SetRowSpan(northPole, 2);
                northPole.HorizontalAlignment = HorizontalAlignment.Stretch;
                northPole.VerticalAlignment = VerticalAlignment.Stretch;
                Grid.SetColumn(northPole, column);
                northPole.Click += Level_Click;
                northPole.Name = "NorthPole"+i.ToString();

                if (isLevelOpen)
                    northPole.Content = (i + 1).ToString();
                else
                    northPole.Content = "LOCKED";
                NorthPole.Children.Add(northPole);
                if (i == lastLevel && levelType.Equals("NorthPole"))
                    isLevelOpen = false;
            }

            totalLevelsPerEnv = MongoServer.GetNumberOfLevelsPerEnv("Desert");
            for (int i = 0, column = 1; i < totalLevelsPerEnv; i++, column += 3)
            {
                Button desert = new Button();
                Grid.SetRow(desert, 1);
                Grid.SetRowSpan(desert, 2);
                desert.HorizontalAlignment = HorizontalAlignment.Stretch;
                desert.VerticalAlignment = VerticalAlignment.Stretch;
                Grid.SetColumn(desert, column);
                desert.Click += Level_Click;
                desert.Name = "Desert"+i.ToString();

                if (isLevelOpen)
                    desert.Content = (i + 1).ToString();
                else
                    desert.Content = "LOCKED";
                Desert.Children.Add(desert);
                if (i == lastLevel && levelType.Equals("Desert"))
                    isLevelOpen = false;
            }

            totalLevelsPerEnv = MongoServer.GetNumberOfLevelsPerEnv("Forest");
            for (int i = 0, column = 1; i < totalLevelsPerEnv; i++, column += 3)
            {
                Button forest = new Button();
                Grid.SetRow(forest, 1);
                Grid.SetRowSpan(forest, 2);
                forest.HorizontalAlignment = HorizontalAlignment.Stretch;
                forest.VerticalAlignment = VerticalAlignment.Stretch;
                Grid.SetColumn(forest, column);
                forest.Click += Level_Click;
                forest.Name = "Forest" + i.ToString();

                if (isLevelOpen)
                    forest.Content = (i + 1).ToString();
                else
                    forest.Content = "LOCKED";
                Forest.Children.Add(forest);
                if (i == lastLevel && levelType.Equals("Forest"))
                    isLevelOpen = false;
            }

            
        }
    }
}
