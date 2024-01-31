using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameObjects;
using Santa_Lost_The_Gifts.GameServices;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private GameManager _gameManager;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _gameManager = new GameManager(scene);
        }

    }
}
