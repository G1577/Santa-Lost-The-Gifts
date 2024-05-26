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
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Santa_Lost_The_Gifts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StorePage : Page
    {
        private GameUser player;
        private List<Product> _productsList = null;

        public StorePage()
        {
            this.InitializeComponent();
        }
        private void ViewProducts(List<Product> products)
        {
            //Image productImage = null;
            //StackPanel stackPanel = null;
            //TextBlock textBlock = null;
            productsViewList.ItemsSource = products;

            //foreach (Product product in products)
            //{
            //    if (product != null)
            //    {
            //        stackPanel = new StackPanel();
            //        stackPanel.Orientation = Orientation.Horizontal;
            //        stackPanel.Width = productsViewList.ActualWidth;
            //        stackPanel.Margin = new Thickness(14);

            //        productImage = new Image();
            //        productImage.Width = 200;
            //        productImage.Height = 200;
            //        productImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Products/{product.ProductName}.png"));
            //        productImage.Tag = product.ProductId;

            //        textBlock = new TextBlock();
            //        textBlock.FontSize = 60;
            //        textBlock.Text = product.ProductName +" - "+product.ProductPrice.ToString();
            //        textBlock.Margin = new Thickness(10);
            //        textBlock.FontFamily = new FontFamily("Broadway");
            //        textBlock.Foreground = new SolidColorBrush(Colors.Red);

            //        stackPanel.Children.Add(productImage);
            //        stackPanel.Children.Add(textBlock);

            //        productsViewList.Items.Add(stackPanel);
            //    }
            //}
        }
        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            productsViewList.SelectedIndex = -1;
        }
        private async void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (player == null)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Not registered", "If you want to buy you have to register");

                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Go To Login") { Id = 0 });
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;

                var result = await dialog.ShowAsync();
                if (result.Label == "Yes")
                {
                    this.Frame.Navigate(typeof(SignInPage));
                }
            }
            int index = productsViewList.SelectedIndex;
            if (index == -1)  //לא נעשתה הבחירה
            {
                await new MessageDialog("MyGame", "You didn't choose!").ShowAsync();
            }
            else
            {
                Product desiredProduct = _productsList[index];     //זה המוצר שבחרת
                if (desiredProduct.ProductPrice > player.Money) //לא מספיק כסף
                {
                    await new MessageDialog("MyGame", "You don't have a budget, go work!").ShowAsync();
                }
                else
                {
                    //שנמצאים בבעלותו של המשתמש Fitchers -מקבלים רשימת מספרי ה
                    List<int> idOwnList = SQLServer.GetOwnProductsId(player);
                    //יש לבדוק שהמוצר שבחרת נמצא כבר בבעלות השחקן, חבל לקנות את מה שיש לו כבר
                    if (idOwnList.Contains(desiredProduct.ProductId))
                    {
                        await new MessageDialog("MyGame", "The product you selected is already available!").ShowAsync();
                    }
                    else //אפשר לקנות
                    {
                        player.CurrentProduct = desiredProduct.ProductName;
                        player.Money -= desiredProduct.ProductPrice;
                        SQLServer.AddUserProduct(player.UserId, desiredProduct.ProductId);
                        await new MessageDialog("MyGame", "Your purchase was successful!").ShowAsync();
                        Frame.Navigate(typeof(MainPage));
                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                player = (GameUser)e.Parameter;
            }
            _productsList = SQLServer.GetProducts();
            ViewProducts(_productsList);
        }
    }
}
