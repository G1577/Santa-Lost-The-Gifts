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
using SQLProject.Modules;
using SQLProject;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInPage()
        {
            this.InitializeComponent();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(SignUpPage));
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            string userPassword = Password.Password.ToString();
            string username = Username.Text.ToString();

            int? userId = SQLServer.ValidateUser(username, userPassword);
            if (userId == null)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("User or password incorrect, try again", "Incorrect creds");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                var result = await dialog.ShowAsync();
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Thank you for signing in!", "Welcome " + username + "!");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continue") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                var result = await dialog.ShowAsync();
                if (result.Label == "Continue")
                {
                    this.Frame.Navigate(typeof(MainPage), username);
                }
            }

        }
    }
}
