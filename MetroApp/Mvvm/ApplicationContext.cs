using System.Data.Entity;
using MetroApp.Model;

namespace MetroApp.Mvvm
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext() : base("MetroApp.Properties.Settings.DBIConnectionString") { }
    }
}
