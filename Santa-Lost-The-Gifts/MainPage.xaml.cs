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
using GameEngine.GameServices;
using Windows.Storage;
using MongoDB.Bson;
using SQLProject.Modules;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static GameUser loggedInUser;
        private static bool loggedIn = false;

        public MainPage()
        {
            this.InitializeComponent();
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
                    UserLogin.Content = "Hello " + userData.UserName + "! logout";
                }
            }
            else
            {
                if (!loggedIn)
                {
                    loggedInUser = null;
                    UserLogin.Content = "Hello Guest!";
                }
                else
                {
                    UserLogin.Content = "Hello " + loggedInUser.UserName + "! logout";
                }
            }
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            this.Frame.Navigate(typeof(GamePage));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            UserLogin.Content = "Hello Guest!";
            loggedInUser = null;
            loggedIn = false;
        }

        private void LevelsPage_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            this.Frame.Navigate(typeof(LevelsPage));
        }

        private void SignInPage_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            this.Frame.Navigate(typeof(SignInPage));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            this.Frame.Navigate(typeof(HelpPage));
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.wav");
            if (!MusicPopup.IsOpen) { MusicPopup.IsOpen = true; }
        }

        private void CloseSettings_Click(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            SoundPlay.Play("click-music.wav");
            if (MusicPopup.IsOpen) { MusicPopup.IsOpen = false; }
        }

        private void MusicButtonControl_Click(object sender, RoutedEventArgs e)
        {
            if (!MusicPlay.isOn)
            {
                Music.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/MusicUp.png"));
                MusicPlay.Play("background-music.mp3");
            }
            else
            {
                Music.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/MusicDown.png"));
                MusicPlay.Pause();
            }
        }

        private void BackgroundMusic_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                SoundPlay.IsOn = toggleSwitch.IsOn;
            }
        }

        private void Volume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MusicPlay.Volume = Volume.Value;
        }

        private void soundEffect_Toggled(object sender, RoutedEventArgs e)
        {
            SoundPlay.IsOn = soundEffect.IsOn;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Volume.Value = MusicPlay.Volume;
            soundEffect.IsOn = SoundPlay.IsOn;
            if (MusicPlay.isOn)
            {
                Music.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/MusicUp.png"));
                MusicPlay.Play("background-music.mp3");
            }
            else
            {
                Music.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/MusicDown.png"));
                MusicPlay.Pause();
            }
        }
    }
}
