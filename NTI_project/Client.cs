using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTI_project
{
    public class Client
    {
        public int id { get; set; }
        private string username, password, email, name, lastname;
        public bool isPhysical;
        public bool isLegal;
        public int IsPhysical 
        { 
            get 
            { 
                if(isPhysical)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value == 1) 
                {
                    isPhysical = true;
                }
                else
                {
                    isPhysical = false;
                }
            }
        }
        public int IsLegal
        {
            get
            {
                if (isLegal)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value == 1)
                {
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }
        }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public Client() { }
        public Client(string username, string password, string email,
            bool isPhysical, bool isLegal, string name, string lastname)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.isPhysical = isPhysical;
            this.isLegal = isLegal;
            this.name = name;
            this.lastname = lastname;
        }
    }
}
