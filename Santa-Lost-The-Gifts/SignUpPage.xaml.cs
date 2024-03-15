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
using Windows.System;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }
        private void SignInPage_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(SignInPage));
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            SoundPlay.Play("click-music.waw");
            this.Frame.Navigate(typeof(MainPage));
        }

        private string CheckStrongPassword(string password)
        {
            string errorMessage = "Your password is missing the following parameters:";
            if (password.Length < 8)
                errorMessage += "\n - Your password should be atleast 8 chars";
            bool containsBigChar = false;
            bool containsSmallChar = false;
            bool containsSpecialChar = false;
            bool containsDigit = false;
            for (int i = 0; i< password.Length; i++)
            {
                if (Char.IsLower(password[i]))
                    containsSmallChar = true;
                if (Char.IsUpper(password[i]))
                    containsBigChar = true;
                if (!Char.IsLetter(password[i]))
                    containsSpecialChar = true;
                if (!Char.IsDigit(password[i]))
                    containsDigit = true;
            }
            if (!containsSmallChar)
                errorMessage += "\n - Your password should contain atleast 1 small char";
            if (!containsBigChar)
                errorMessage += "\n - Your password should contain atleast 1 big char";
            if (!containsSpecialChar)
                errorMessage += "\n - Your password should contain atleast 1 special char";
            if (!containsDigit)
                errorMessage += "\n - Your password should contain atleast 1 digit";
            return errorMessage;
        }

        private async void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            string userPassword = Password.Password.ToString();
            string confirmPassword = Confirm_Password.Password.ToString();
            string userEmail = Email.Text.ToString();

            string checkStrongPasswordOutput = CheckStrongPassword(userPassword);
            if (checkStrongPasswordOutput.Contains('\n'))
            {
                var dialog = new Windows.UI.Popups.MessageDialog(checkStrongPasswordOutput, "Create Stronger Password");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                var result = await dialog.ShowAsync();
            }
            else
            {
                if (!userPassword.Equals(confirmPassword))
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Please check your password confirm ", "Passwords doesn't match");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
                    dialog.DefaultCommandIndex = 0;
                    var result = await dialog.ShowAsync();
                }
                else
                {
                    if (!userEmail.Contains('@'))
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog("Please validate your email ", "Incorrect Email");
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
                        dialog.DefaultCommandIndex = 0;
                        var result = await dialog.ShowAsync();
                    }
                    else
                    {
                        string username = Username.Text.ToString();
                        var dialog = new Windows.UI.Popups.MessageDialog("Thank you for signing up!", "Welcome "+username+"!");
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continue") { Id = 0 });
                        dialog.DefaultCommandIndex = 0;
                        var result = await dialog.ShowAsync();
                        if (result.Label == "Continue")
                        {
                            this.Frame.Navigate(typeof(MainPage));
                        }
                    }
                }
            }
            //string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\IMOE1\Desktop\SqlDB.mdb";
        }
    }
}
