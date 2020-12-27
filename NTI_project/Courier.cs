using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTI_project
{
    public class Courier
    {
        public int id { get; set; }
        private string name, lastname, login, password, phonenumber;
        public List<string> Orders = new List<string>(), CurrentOrders = new List<string>();// содержит номера заказов и виды услуг пр: "1|pickup" или "2|delivery"
        public string Name { get { return name; } set { name = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Phonenumber { get { return phonenumber; } set { phonenumber = value; } }
        public Courier() { }
        public Courier(string name, string lastname, string login, string password, string phonenumber)
        {
            this.name = name;
            this.lastname = lastname;
            this.login = login;
            this.password = password;
            this.phonenumber = phonenumber;
            this.Orders = new List<string>();
            this.CurrentOrders = new List<string>();
        }
        public string OrdersList
        {
            get
            {
                string result = "";
                foreach (string num in Orders)
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
                    Orders = value.Split(',').ToList();
                }
            }
        }
        public string CurrentOrdersList
        {
            get
            {
                string result = "";
                foreach (string num in CurrentOrders)
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
                    CurrentOrders = value.Split(',').ToList();
                }
            }
        }
    }
}
