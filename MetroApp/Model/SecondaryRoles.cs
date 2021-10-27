using System.ComponentModel.DataAnnotations;

namespace MetroApp.Model
{
    class SecondaryRole
    {
        [Key] public int role_id { get; set; }
        private string role_name;
        private int role_perm;

        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }
        public int Role_perm
        {
            get { return role_perm; }
            set { role_perm = value; }
        }

        public SecondaryRole() { }

        public SecondaryRole(string role_name, int role_perm)
        {
            this.role_name = role_name;
            this.role_perm = role_perm;
        }
    }
}
