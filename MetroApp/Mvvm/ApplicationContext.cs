using System.Data.Entity;
using MetroApp.Model;

namespace MetroApp.Mvvm
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PrimaryRole> PrimaryRoles { get; set; }
        public DbSet<SecondaryRole> SecondaryRoles { get; set; }
        public ApplicationContext() : base("MetroApp.Properties.Settings.DBIConnectionString") { }
    }
}
