using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MetroApp.Naviganion;
using LoginDialog = MetroApp.Core.Dialog.LoginDialog;
using MenuItem = MetroApp.ViewModels.MenuItem;

namespace MetroApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly NavigationServiceEx navigationServiceEx;

        public LoginDialog LoginDialog;

        public MainWindow()
        {
            //ShowLoginDialog(this, new RoutedEventArgs());
            InitializeComponent();

            ShowLoginDialog(this, new RoutedEventArgs());

            this.navigationServiceEx = new NavigationServiceEx();
            this.navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            this.HamburgerMenuControl.Content = this.navigationServiceEx.Frame;

            // Navigate to the home page.
            this.Loaded += (sender, args) => this.navigationServiceEx.Navigate(new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void ShowLoginDialog(object sender, RoutedEventArgs e)
        {
            //this.MetroDialogOptions.ColorScheme = UseAccentForDialogsMenuItem.IsChecked ? MetroDialogColorScheme.Accented : MetroDialogColorScheme.Theme;
            LoginDialogData result = await this.ShowLoginAsync(title:"Авторизация", 
                                                               message:"Введите логин и пароль",
                                                               new LoginDialogSettings
                                                               {
                                                                   ColorScheme = this.MetroDialogOptions.ColorScheme,
                                                                   NegativeButtonVisibility = Visibility.Visible,
                                                                   AffirmativeButtonText = "Вход",
                                                                   NegativeButtonText = "Выход",
                                                                   UsernameWatermark = "Введите логин",
                                                                   PasswordWatermark = "Введите пароль",
                                                                   EnablePasswordPreview = true
                                                               });
            if (result == null)
            {
                this.Close();
            }
            else
            {
                var a = false;
                while (a == false)
                {
                    if (result.Username == "Admin" && result.Password == "Gfhjkm123!")
                    {
                        //MessageDialogResult messageResult = await this.ShowMessageAsync("Авторизация", "Вход успешно выполнен");
                        this.ShowProgressAsync("Пользователь " + result.Username.ToString() + " авторизован.", "Идет загрузка");
                        a = true;
                    }
                    else
                    {
                        MessageDialogResult messageResult = await this.ShowMessageAsync("Авторизация", "Введены неверные логин или пароль");
                        result = await this.ShowLoginAsync(title: "Авторизация",
                                                               message: "Введите логин и пароль",
                                                               new LoginDialogSettings
                                                               {
                                                                   ColorScheme = this.MetroDialogOptions.ColorScheme,
                                                                   NegativeButtonVisibility = Visibility.Visible,
                                                                   AffirmativeButtonText = "Вход",
                                                                   NegativeButtonText = "Выход",
                                                                   UsernameWatermark = "Введите логин",
                                                                   PasswordWatermark = "Введите пароль",
                                                                   EnablePasswordPreview = true
                                                               });
                    }
                }
                HamburgerMenuControl.Visibility = Visibility.Visible;
            }
        }
        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is MenuItem menuItem && menuItem.IsNavigation)
            {
                this.navigationServiceEx.Navigate(menuItem.NavigationDestination);
            }
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
            // select the menu item
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
                                                         .Items
                                                         .OfType<MenuItem>()
                                                         .FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
                                                                .OptionsItems
                                                                .OfType<MenuItem>()
                                                                .FirstOrDefault(x => x.NavigationDestination == e.Uri);

            // or when using the NavigationType on menu item
            // this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
            //                                              .Items
            //                                              .OfType<MenuItem>()
            //                                              .FirstOrDefault(x => x.NavigationType == e.Content?.GetType());
            // this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
            //                                                     .OptionsItems
            //                                                     .OfType<MenuItem>()
            //                                                     .FirstOrDefault(x => x.NavigationType == e.Content?.GetType());

            // update back button
            this.GoBackButton.Visibility = this.navigationServiceEx.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.navigationServiceEx.GoBack();
        }
    }
}
