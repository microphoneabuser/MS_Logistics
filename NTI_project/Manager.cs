using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTI_project
{
    public class Manager
    {
        public int id { get; set; }
        private string name, lastname, login, password, phonenumber, email;
        public List<int> Orders = new List<int>() , CurrentOrders = new List<int>();
        public string Name { get { return name; } set { name = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Phonenumber { get { return phonenumber; } set { phonenumber = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Manager() { }
        public Manager(string name, string lastname, string login, string password, string phonenumber, string email) 
        {
            this.name = name;
            this.lastname = lastname;
            this.login = login;
            this.password = password;
            this.phonenumber = phonenumber;
            this.email = email;
            this.Orders = new List<int>();
            this.CurrentOrders = new List<int>();
        }
        public string OrdersList
        {
            get
            {
                string result = "";
                foreach (int num in Orders)
                {
                    result += num + ",";
                }
                try
                {
                    return result.Remove(result.Length - 1);
                }
                catch
                {
                    return result;
                }
            }
            set
            {
                if (value != null && value != "")
                {
                    Orders = value.Split(',').Select(Int32.Parse).ToList();
                }
            }
        }
        public string CurrentOrdersList
        {
            get
            {
                string result = "";
                foreach (int num in CurrentOrders)
                {
                    result += num + ",";
                }
                try 
                { 
                    return result.Remove(result.Length - 1); 
                }
                catch
                {
                    return result;
                }
            }
            set
            {
                if (value != null && value != "")
                {
                    CurrentOrders = value.Split(',').Select(Int32.Parse).ToList();
                }
            }
        }
    }
}
