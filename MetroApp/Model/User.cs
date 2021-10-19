using System.ComponentModel.DataAnnotations;

namespace MetroApp.Model
{
    class User
    {
        [Key] public int u_id { get; set; }
        private string login, password;
        private int primary_role_id, secondary_role_id;
        private bool status;
        private string name;
 
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Primary_role_id
        {
            get { return primary_role_id; }
            set { primary_role_id = value; }
        }
        public int Secondary_role_id
        {
            get { return secondary_role_id; }
            set { secondary_role_id = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public User() { }

        public User(string login, string password, int primary_role_id, int secondary_role_id, bool status, string name)
        {
            this.login = login;
            this.password = password;
            this.primary_role_id = primary_role_id;
            this.secondary_role_id = secondary_role_id;
            this.status = status;
            this.name = name;
        }
    }
}
