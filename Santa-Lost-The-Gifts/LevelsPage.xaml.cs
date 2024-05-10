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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LevelsPage : Page
    {
        public LevelsPage()
        {
            this.InitializeComponent();
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(MainPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int totalLevelsPerEnv = 3;

            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                var userData = (GameUser)e.Parameter;
                string levelType = userData.LevelType;

                if (levelType.Equals("Forest"))
                {
                    int column = 1;
                    for (int i = 0; i < totalLevelsPerEnv; i++, column += 3)
                    {
                        Button northPole = new Button();
                        Grid.SetRow(northPole, 1);
                        Grid.SetRowSpan(northPole, 2);
                        northPole.HorizontalAlignment = HorizontalAlignment.Stretch;
                        northPole.VerticalAlignment = VerticalAlignment.Stretch;
                        northPole.Content = (i+1).ToString();
                        Grid.SetColumn(northPole, column);
                        NorthPole.Children.Add(northPole);

                        Button desert = new Button();
                        Grid.SetRow(desert, 1);
                        Grid.SetRowSpan(desert, 2);
                        desert.HorizontalAlignment = HorizontalAlignment.Stretch;
                        desert.VerticalAlignment = VerticalAlignment.Stretch;
                        desert.Content = (i + 1).ToString();
                        Grid.SetColumn(desert, column);
                        Desert.Children.Add(desert);

                        Button forest = new Button();
                        Grid.SetRow(forest, 1);
                        Grid.SetRowSpan(forest, 2);
                        forest.HorizontalAlignment = HorizontalAlignment.Stretch;
                        forest.VerticalAlignment = VerticalAlignment.Stretch;
                        Grid.SetColumn(forest, column);

                        if (i <= userData.LastLevel)
                        {
                            forest.Content = (i + 1).ToString();
                            Forest.Children.Add(forest);
                        }
                        else
                        {
                            forest.Content = "LOCKED";
                            Forest.Children.Add(forest);
                        }
                    }
                }
                else if (levelType.Equals("Desert"))
                {
                    int column = 1;
                    for (int i = 0; i < totalLevelsPerEnv; i++, column += 3)
                    {
                        Button northPole = new Button();
                        Grid.SetRow(northPole, 1);
                        Grid.SetRowSpan(northPole, 2);
                        northPole.HorizontalAlignment = HorizontalAlignment.Stretch;
                        northPole.VerticalAlignment = VerticalAlignment.Stretch;
                        northPole.Content = (i + 1).ToString();
                        Grid.SetColumn(northPole, column);
                        NorthPole.Children.Add(northPole);

                        Button forest = new Button();
                        Grid.SetRow(forest, 1);
                        Grid.SetRowSpan(forest, 2);
                        forest.HorizontalAlignment = HorizontalAlignment.Stretch;
                        forest.VerticalAlignment = VerticalAlignment.Stretch;
                        forest.Content = "LOCKED";
                        Grid.SetColumn(forest, column);
                        Forest.Children.Add(forest);

                        Button desert = new Button();
                        Grid.SetRow(desert, 1);
                        Grid.SetRowSpan(desert, 2);
                        northPole.HorizontalAlignment = HorizontalAlignment.Stretch;
                        northPole.VerticalAlignment = VerticalAlignment.Stretch;
                        Grid.SetColumn(desert, column);

                        if (i <= userData.LastLevel)
                        {
                            desert.Content = (i + 1).ToString();
                            Desert.Children.Add(desert);
                        }
                        else
                        {
                            desert.Content = "LOCKED";
                            Desert.Children.Add(desert);
                        }
                    }
                    
                }
                else if (levelType.Equals("NorthPole"))
                {
                    int column = 1;
                    for (int i = 0; i < totalLevelsPerEnv; i++, column += 3)
                    {
                        Button desert = new Button();
                        Grid.SetRow(desert, 1);
                        Grid.SetRowSpan(desert, 2);
                        desert.HorizontalAlignment = HorizontalAlignment.Stretch;
                        desert.VerticalAlignment = VerticalAlignment.Stretch;
                        desert.Content = "LOCKED";
                        Grid.SetColumn(desert, column);
                        Desert.Children.Add(desert);

                        Button forest = new Button();
                        Grid.SetRow(forest, 1);
                        Grid.SetRowSpan(forest, 2);
                        forest.HorizontalAlignment = HorizontalAlignment.Stretch;
                        forest.VerticalAlignment = VerticalAlignment.Stretch;
                        forest.Content = "LOCKED";
                        Grid.SetColumn(forest, column);
                        Forest.Children.Add(forest);

                        Button northPole = new Button();
                        Grid.SetRow(northPole, 1);
                        Grid.SetRowSpan(northPole, 2);
                        northPole.HorizontalAlignment = HorizontalAlignment.Stretch;
                        northPole.VerticalAlignment = VerticalAlignment.Stretch;
                        Grid.SetColumn(northPole, column);

                        if (i <= userData.LastLevel)
                        {
                            northPole.Content = (i + 1).ToString();
                            NorthPole.Children.Add(northPole);
                        }
                        else
                        {
                            northPole.Content = "LOCKED";
                            NorthPole.Children.Add(northPole);
                        }
                    }
                }
            }
        }
    }

}
