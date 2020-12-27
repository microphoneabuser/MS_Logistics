using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTI_project
{
    public class Admin
    {
        public int id { get; set; }
        private string login;
        private string password;
        private string email;
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Admin(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }
        public Admin()
        {
            
        }
    }
}
