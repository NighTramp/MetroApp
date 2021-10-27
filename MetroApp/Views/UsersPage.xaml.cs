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
            db.PrimaryRoles.Load();
            db.SecondaryRoles.Load();
            //UserDataGrid.ItemsSource = db.Users.Local.ToBindingList();
            UserSearchPrimaryRoleComboBox.ItemsSource = db.PrimaryRoles.Local.
            UserChangePrimaryRoleComboBox.ItemsSource = db.PrimaryRoles.Local.ToBindingList();

            UserSearchSecondaryRoleComboBox.ItemsSource = db.SecondaryRoles.Local.ToBindingList();
            UserChangeSecondaryRoleComboBox.ItemsSource = db.SecondaryRoles.Local.ToBindingList();



        }
    }
}
