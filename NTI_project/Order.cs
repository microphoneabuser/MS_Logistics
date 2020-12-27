using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTI_project
{
    public class Order
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        private string senderAddress, senderPhonenumber, senderDate, 
            senderTime, deliveryAddress, 
            addresseeName, addresseePhonenumber,
            deliveryDate, deliveryTime, timeStamp, status;
        public List<string> AddServices;
        private double weight, volume, width, length, height, price;
        public string SenderAddress { get { return senderAddress; } set { senderAddress = value; } }
        public string SenderPhonenumber { get { return senderPhonenumber; } set { senderPhonenumber = value; } }
        public string SenderDate { get { return senderDate; } set { senderDate = value; } }
        public string SenderTime { get { return senderTime; } set { senderTime = value; } }
        public string DeliveryAddress { get { return deliveryAddress; } set { deliveryAddress = value; } }
        public string AddresseeName { get { return addresseeName; } set { addresseeName = value; } }
        public string AddresseePhonenumber { get { return addresseePhonenumber; } set { addresseePhonenumber = value; } }
        public string DeliveryDate { get { return deliveryDate; } set { deliveryDate = value; } }
        public string DeliveryTime { get { return deliveryTime; } set { deliveryTime = value; } }
        public string TimeStamp { get { return timeStamp; } set { timeStamp = value; } }
        public string Status { get { return status; } set { status = value; } }
        public double Weight { get { return weight; } set { weight = value; } }
        public double Volume { get { return volume; } set { volume = value; } }
        public double Width { get { return width; } set { width = value; } }
        public double Length { get { return length; } set { length = value; } }
        public double Height { get { return height; } set { height = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Order() { }
        public Order(int clientId, string senderAddress, string senderPhonenumber, 
            string senderDate,
            string senderTime, string deliveryAddress,
            string addresseeName, string addresseePhonenumber,
            string deliveryDate, string deliveryTime, string timeStamp, string status,
            double weight, double volume,
            double width, double length,
            double height, double price,
            List<string> addServices)
        {
            this.ClientId = clientId;
            this.senderAddress = senderAddress;
            this.senderPhonenumber = senderPhonenumber;
            this.senderDate = senderDate;
            this.senderTime = senderTime;
            this.deliveryAddress = deliveryAddress;
            this.addresseeName = addresseeName;
            this.addresseePhonenumber = addresseePhonenumber;
            this.deliveryDate = deliveryDate;
            this.deliveryTime = deliveryTime;
            this.timeStamp = timeStamp;
            this.status = status;
            this.weight = weight;
            this.volume = volume;
            this.width = width;
            this.length = length;
            this.height = height;
            this.price = price;
            this.AddServices = addServices;
        }
        public string AddServicesList
        {
            get
            {
                string result = "";
                foreach (string num in AddServices)
                {
                    result += num + ",";
                }
                return result.Remove(result.Length - 1);
            }
            set
            {
                if (value != null && value != "")
                {
                    AddServices = value.Split(',').ToList();
                }
            }
        }
    }
}
