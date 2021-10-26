using System;
using System.Data.Entity;
using System.Windows.Controls;
using MetroApp.Mvvm;

namespace MetroApp.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private ApplicationContext db;
        public UsersPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Users.Load();
            dataGrid.ItemsSource = db.Users.Local.ToBindingList();



        }
    }
}
