using System.Diagnostics.Eventing.Reader;
using System.Linq;
using MetroApp.Model;
using MetroApp.Mvvm;

namespace MetroApp.ViewModels
{
    class CurrentUser
    {
        private User user; 
        private ApplicationContext db;

        public CurrentUser()
        {
            user = null;
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public bool AuthUser(string login, string password)
        {
            
            //login = login.TrimStart(' ');
            //login = login.TrimEnd(' ');
            //password = password.TrimStart(' ');
            //password = password.TrimEnd(' ');
            db = new ApplicationContext();
            using (db)
            {
                user = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
            }

            return user == null;
        }
        ~CurrentUser()
        {
            user = null;
            db = null;
        }

    }
}
