using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NTI_project
{
    /// <summary>
    /// Логика взаимодействия для ManagerMyOrdersControl.xaml
    /// </summary>
    public partial class ManagerMyOrdersControl : UserControl
    {
        //Client CurrentClient;
        Manager CurrentManager;
        AppContext db;
        int ID;
        ManagerMainWindow mainWindow;
        public ManagerMyOrdersControl(Manager manager, ManagerMainWindow mainWindow)
        {
            InitializeComponent();
            this.CurrentManager = manager;
            db = new AppContext();
            FillGrid();
            this.mainWindow = mainWindow;
            comeBackButton.Visibility = Visibility.Collapsed;
        }
        public ObservableCollection<GridItemMyOrders> Items { get; set; } = new ObservableCollection<GridItemMyOrders>();
        private async void FillGrid()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            List<Client> clients = null;

            await Task.Run(() => clients = GetClients());

            List<Order> myOrders = null;

            await Task.Run(() => myOrders = GetOrders());

            foreach (Order order in myOrders)
            {
                string status = "";
                if (order.Status == "requested")
                {
                    status = "Заявка подана";
                }
                else if (order.Status == "processing")
                {
                    status = "Принят менеджером на обработку";
                }
                else if (order.Status == "accepted")
                {
                    status = "Подтвержден менеджером";
                }
                else if (order.Status == "paid")
                {
                    status = "Отправлен на выполнение";
                }
                else if (order.Status == "pickup")
                {
                    status = "Курьер отправлен забирать заказ";
                }
                else if (order.Status == "storage")
                {
                    status = "Доставлен на склад";
                }
                else if (order.Status == "packaging")
                {
                    status = "Комплектуется";
                }
                else if (order.Status == "packaged")
                {
                    status = "Укомплектован";
                }
                else if (order.Status == "delivery")
                {
                    status = "Доставляется";
                }
                else if (order.Status == "delivered")
                {
                    status = "Доставлен";
                }
                else if (order.Status == "cancelled")
                {
                    status = "Отменен";
                }
                Client Client = clients.Where(client => client.id == order.ClientId).FirstOrDefault();
                Items.Add(new GridItemMyOrders
                {
                    OrderNum = order.id,
                    Client = $"{Client.Name} {Client.Lastname}",
                    TimeStamp = order.TimeStamp,
                    SenderDate = order.SenderDate,
                    DeliveryDate = order.DeliveryDate,
                    Status = status
                });
            }
            OrdersGrid.ItemsSource = Items;

            loadborder.Visibility = Visibility.Hidden;
        }
        private List<Order> GetOrders()
        {
            List<Order> currentOrders = new List<Order>();
            try
            {
                List<int> ordersId = CurrentManager.Orders;
                db = new AppContext();
                using (db)
                {
                    foreach (int id in ordersId)
                    {
                        currentOrders.Add(db.Orders.Where(order => order.id == id).FirstOrDefault());
                    }
                }
                return currentOrders;
        }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return currentOrders;
            }
        }
        private List<Client> GetClients()
        {
            List<Client> clients = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    clients = db.Clients.ToList<Client>();
                }
                return clients;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return clients;
            }
        }
        private void comeBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            comeBackButton.Foreground = Brushes.LightSlateGray;
        }

        private void comeBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            comeBackButton.Foreground = Brushes.LightGray;
        }

        private void comeBackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            comeBackButton.Foreground = Brushes.White;
        }

        private void comeBackButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainText.Text = "Мои заказы";
            FillGrid();
            CurrentOrderPanel.Visibility = Visibility.Collapsed;
            GridPanel.Visibility = Visibility.Visible;
            comeBackButton.Visibility = Visibility.Collapsed;
        }

        private void OrdersGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (OrdersGrid.SelectedIndex != -1)
            {
                int curId = (OrdersGrid.SelectedItem as GridItemMyOrders).OrderNum;
                ID = curId;

                FillOrder(curId);

                mainText.Text = $"Заказ №{curId}";
                GridPanel.Visibility = Visibility.Collapsed;
                CurrentOrderPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Visible;
            }

        }
        private Client GetClient(int id)
        {
            Client client = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    client = db.Clients.Where(cl => cl.id == id).FirstOrDefault();
                }
                return client;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return client;
            }
        }
        private Courier GetFirstCourier(int id)
        {
            Courier courier = null;
            List<Courier> couriers = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    couriers = db.Couriers.ToList();
                    courier = couriers.Where(cl => cl.Orders.Contains($"{id}|pickup")).FirstOrDefault();
                }
                return courier;
            }
            catch
            {
                
                return courier;
            }
        }
        private Courier GetSecondCourier(int id)
        {
            List<Courier> couriers = null;
            Courier courier = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    couriers = db.Couriers.ToList();
                    courier = couriers.Where(cl => cl.Orders.Contains($"{id}|delivery")).FirstOrDefault();
                }
                return courier;
            }
            catch
            {
                
                return courier;
            }
        }
        private Storeman GetStoreman(int id)
        {
            Storeman storeman = null;
            List<Storeman> storemen = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    storemen = db.Storemen.ToList();
                    storeman = storemen.Where(cl => cl.Orders.Contains(id)).FirstOrDefault();
                }
                return storeman;
            }
            catch
            {
                
                return storeman;
            }
        }
        private async void FillOrder(int id)
        {
            Order CurrentOrder = null;

            loadborder.Visibility = Visibility.Visible;

            await Task.Run(() => CurrentOrder = GetOrder(id));

            slider.Visibility = Visibility.Visible;

            status1.Visibility = Visibility.Collapsed;
            status2.Visibility = Visibility.Collapsed;
            status3.Visibility = Visibility.Collapsed;
            status4.Visibility = Visibility.Collapsed;
            status5.Visibility = Visibility.Collapsed;
            status6.Visibility = Visibility.Collapsed;
            status7.Visibility = Visibility.Collapsed;
            status8.Visibility = Visibility.Collapsed;
            status9.Visibility = Visibility.Collapsed;
            status10.Visibility = Visibility.Collapsed;
            status11.Visibility = Visibility.Collapsed;

            CancelButton.Visibility = Visibility.Visible;
            ClientButton.Visibility = Visibility.Visible;
            PaidButton.Visibility = Visibility.Collapsed;

            SenderAddress.Text = CurrentOrder.SenderAddress;

            Client cl = GetClient(CurrentOrder.ClientId);
            SenderName.Text = cl.Name + " " + cl.Lastname;

            SenderDate.Text = CurrentOrder.SenderDate;
            SenderTime.Text = CurrentOrder.SenderTime;
            SenderPhonenumber.Text = CurrentOrder.SenderPhonenumber;
            TimeStamp.Text = CurrentOrder.TimeStamp;

            Storeman storeman = GetStoreman(CurrentOrder.id);
            if (storeman != null)
            {
                Storeman.Text = storeman.Name + " " + storeman.Lastname;
            }
            else
            {
                Storeman.Text = " - ";
            }

            Courier fCourier = GetFirstCourier(CurrentOrder.id);
            if (fCourier != null) 
            { 
                FirstCourier.Text = fCourier.Name + " " + fCourier.Lastname; 
            }
            else
            {
                FirstCourier.Text = " - ";
            }

            Courier sCourier = GetSecondCourier(CurrentOrder.id);
            if (sCourier != null)
            {
                SecondCourier.Text = sCourier.Name + " " + sCourier.Lastname;
            }
            else
            {
                SecondCourier.Text = " - ";
            }

            AddresseeAddress.Text = CurrentOrder.DeliveryAddress;
            AddresseeName.Text = CurrentOrder.AddresseeName;
            AddresseePhonenumber.Text = CurrentOrder.AddresseePhonenumber;
            DeliveryDate.Text = CurrentOrder.DeliveryDate;
            DeliveryTime.Text = CurrentOrder.DeliveryTime;
            Weight.Text = CurrentOrder.Weight.ToString();
            Volume.Text = CurrentOrder.Volume.ToString();
            Width.Text = CurrentOrder.Width.ToString();
            Length.Text = CurrentOrder.Length.ToString();
            Height.Text = CurrentOrder.Height.ToString();
            Price.Text = CurrentOrder.Price.ToString();
            //string addInfo = "";
            //foreach (string t in CurrentOrder.AddServices)
            //{
            //    addInfo += $"{t}, ";
            //}
            //addInfo.Remove(addInfo.Length - 2);
            AddInfo.Text = CurrentOrder.AddServicesList;

            string status = CurrentOrder.Status;
            if (status == "requested")
            {
                status1.Visibility = Visibility.Visible;
                slider.Value = 0;
            }
            else if (status == "processing")
            {
                status2.Visibility = Visibility.Visible;
                slider.Value = 1;
            }
            else if (status == "accepted")
            {
                status3.Visibility = Visibility.Visible;
                slider.Value = 2;
                PaidButton.Visibility = Visibility.Visible;
            }
            else if (status == "paid")
            {
                status4.Visibility = Visibility.Visible;
                slider.Value = 3;
            }
            else if (status == "pickup")
            {
                status5.Visibility = Visibility.Visible;
                slider.Value = 4;
            }
            else if (status == "storage")
            {
                status6.Visibility = Visibility.Visible;
                slider.Value = 5;
            }
            else if (status == "packaging")
            {
                status7.Visibility = Visibility.Visible;
                slider.Value = 6;
            }
            else if (status == "packaged")
            {
                status8.Visibility = Visibility.Visible;
                slider.Value = 7;
            }
            else if (status == "delivery")
            {
                status9.Visibility = Visibility.Visible;
                slider.Value = 8;
            }
            else if (status == "delivered")
            {
                status10.Visibility = Visibility.Visible;
                slider.Value = 9;
                CancelButton.Visibility = Visibility.Collapsed;
            }
            else if (status == "cancelled")
            {
                status11.Visibility = Visibility.Visible;
                slider.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
                ClientButton.Visibility = Visibility.Collapsed;
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private Order GetOrder(int id)
        {
            Order CurrentOrder = null;
            db = new AppContext();
            try
            {
                using (db)
                {
                    CurrentOrder = db.Orders.Where(order => order.id == id).FirstOrDefault();
                }
                return CurrentOrder;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return CurrentOrder;
            }
        }

        private async void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите отменить заказ?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                await Task.Run(() => Cancel());

                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
            }
        }
        private void Cancel()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "cancelled";
                    db.SaveChanges();
                }

            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
            }
        }
        private void Paid()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "paid";
                    db.SaveChanges();
                }

            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
            }
        }
        private async void PaidButton_Click(object sender, RoutedEventArgs e)
        {
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите отправить заказ на выпонение?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                await Task.Run(() => Paid());

                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WorkersButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
    public class GridItemMyOrders
    {
        public int OrderNum { get; set; }
        public string Client { get; set; }
        public string TimeStamp { get; set; }
        public string SenderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
