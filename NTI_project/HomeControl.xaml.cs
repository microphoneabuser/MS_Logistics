using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Логика взаимодействия для HomeControl.xaml
    /// </summary>

    public partial class HomeControl : UserControl
    {
        Client CurrentClient;
        AppContext db;
        int ID;
        MainWindow mainWindow;
        public HomeControl(Client client, MainWindow mainWindow)
        {
            InitializeComponent();
            CurrentClient = client;
            db = new AppContext();
            FillGrid();
            this.mainWindow = mainWindow;
            comeBackButton.Visibility = Visibility.Collapsed;
        }
        public ObservableCollection<GridItem> Items { get; set; } = new ObservableCollection<GridItem>();
        private void FillGrid()
        {
            Items.Clear();
            foreach (Order order in GetData())
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
                Items.Add(new GridItem
                {
                    OrderNum = order.id,
                    Addressee = order.AddresseeName,
                    Address = order.DeliveryAddress,
                    TimeStamp = order.TimeStamp,
                    Status = status
                }); 
            }

            OrdersGrid.ItemsSource = Items;
        }
        private List<Order> GetData()
        {
            List<Order> currentOrders = new List<Order>();
            try
            {
                db = new AppContext();
                using (db)
                {
                    currentOrders = db.Orders.Where(order => order.ClientId == CurrentClient.id).ToList<Order>();
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
                int curId = (OrdersGrid.SelectedItem as GridItem).OrderNum;
                ID = curId;

                FillOrder(curId);

                mainText.Text = $"Заказ №{curId}";
                GridPanel.Visibility = Visibility.Collapsed;
                CurrentOrderPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Visible;
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
            ManagerButton.Visibility = Visibility.Visible;


            SenderAddress.Text = CurrentOrder.SenderAddress;
            SenderDate.Text = CurrentOrder.SenderDate;
            SenderTime.Text = CurrentOrder.SenderTime;
            SenderPhonenumber.Text = CurrentOrder.SenderPhonenumber;
            TimeStamp.Text = CurrentOrder.TimeStamp;
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
                ManagerButton.Visibility = Visibility.Collapsed;
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

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private async void CancelButton_Click(object sender, RoutedEventArgs e)
        { 
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Вы уверены, что хотите отменить заказ?", "", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
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
        
    }
    public class GridItem
    {
        public int OrderNum { get; set; }
        public string Addressee { get; set; }
        public string Address { get; set; }
        public string TimeStamp { get; set; }
        public string Status { get; set; }
    }
}

