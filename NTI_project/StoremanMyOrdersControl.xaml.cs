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
    /// Логика взаимодействия для StoremanMyOrdersControl.xaml
    /// </summary>
    public partial class StoremanMyOrdersControl : UserControl
    {
        Storeman CurrentStoreman;
        AppContext db;
        int ID;
        StoremanMainWindow mainWindow;
        public StoremanMyOrdersControl(Storeman storeman, StoremanMainWindow storemanMainWindow)
        {
            InitializeComponent();
            this.CurrentStoreman = storeman;
            db = new AppContext();
            checkBox.IsChecked = false;
            FillGrid();
            this.mainWindow = storemanMainWindow;
            comeBackButton.Visibility = Visibility.Collapsed;
        }
        public ObservableCollection<GridItemMyOrdersStoreman> Items { get; set; } = new ObservableCollection<GridItemMyOrdersStoreman>();
        private async void FillGrid()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            List<Order> myOrders = null;

            await Task.Run(() => myOrders = GetOrders());

            foreach (Order order in myOrders)
            {
                string status = "Укомплектован";
                if (order.Status == "packaging")
                {
                    status = "В процессе";
                }
                
                Items.Add(new GridItemMyOrdersStoreman
                {
                    OrderNum = order.id,
                    Weight = order.Weight.ToString(),
                    Size = $"{order.Width} x {order.Length} x {order.Height}",
                    AddServices = order.AddServicesList,
                    Date = order.DeliveryDate,
                    Time = order.DeliveryTime,
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
                List<int> ordersId = CurrentStoreman.Orders;
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
        private async void FillGridCurrent()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            List<Order> myOrders = null;

            await Task.Run(() => myOrders = GetCurrentOrders());

            foreach (Order order in myOrders)
            {
                string status = "Укомплектован";
                if (order.Status == "packaging")
                {
                    status = "В процессе";
                }

                Items.Add(new GridItemMyOrdersStoreman
                {
                    OrderNum = order.id,
                    Weight = order.Weight.ToString(),
                    Size = $"{order.Width} x {order.Length} x {order.Height}",
                    AddServices = order.AddServicesList,
                    Date = order.DeliveryDate,
                    Time = order.DeliveryTime,
                    Status = status
                });
            }

            OrdersGrid.ItemsSource = Items;

            loadborder.Visibility = Visibility.Hidden;
        }
        
        private List<Order> GetCurrentOrders()
        {
            List<Order> currentOrders = new List<Order>();
            try
            {
                List<int> ordersId = CurrentStoreman.CurrentOrders;
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
            checkBox.IsChecked = false;
            FillGrid();
            CurrentOrderPanel.Visibility = Visibility.Collapsed;
            GridPanel.Visibility = Visibility.Visible;
            comeBackButton.Visibility = Visibility.Collapsed;
        }

        private void OrdersGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (OrdersGrid.SelectedIndex != -1)
            {
                int curId = (OrdersGrid.SelectedItem as GridItemMyOrdersStoreman).OrderNum;
                ID = curId;

                FillOrder(curId, OrdersGrid.SelectedIndex);

                mainText.Text = $"Заказ №{curId}";
                GridPanel.Visibility = Visibility.Collapsed;
                CurrentOrderPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Visible;
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
        private async void FillOrder(int id, int index)
        {
            Order CurrentOrder = null;

            List<Client> clients = null;

            loadborder.Visibility = Visibility.Visible;

            add1.IsChecked = false;
            add2.IsChecked = false;
            add3.IsChecked = false;
            add4.IsChecked = false;
            add5.IsChecked = false;
            add6.IsChecked = false;
            add7.IsChecked = false;
            add8.IsChecked = false;

            NotDone.Visibility = Visibility.Collapsed;
            Done.Visibility = Visibility.Collapsed;

            await Task.Run(() => CurrentOrder = GetOrder(id));

            await Task.Run(() => clients = GetClients());

            if (CurrentOrder.Status == "packaging")
            {
                NotDone.Visibility = Visibility.Visible;
            }
            else
            {
                Done.Visibility = Visibility.Visible;
            }
            Weight.Text = CurrentOrder.Weight.ToString();
            Volume.Text = CurrentOrder.Volume.ToString();
            Width.Text = CurrentOrder.Width.ToString();
            Length.Text = CurrentOrder.Length.ToString();
            Height.Text = CurrentOrder.Height.ToString();
            Time.Text = $"{CurrentOrder.DeliveryDate} {CurrentOrder.DeliveryTime}";

            if (CurrentOrder.AddServices.Contains(PlacerButton.Content.ToString()))
            {
                PlacerButton.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(PalletButton.Content.ToString()))
            {
                PalletButton.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add1.Content.ToString()))
            {
                add1.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add2.Content.ToString()))
            {
                add2.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add3.Content.ToString()))
            {
                add3.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add4.Content.ToString()))
            {
                add4.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add5.Content.ToString()))
            {
                add5.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add6.Content.ToString()))
            {
                add6.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add7.Content.ToString()))
            {
                add7.IsChecked = true;
            }
            if (CurrentOrder.AddServices.Contains(add8.Content.ToString()))
            {
                add8.IsChecked = true;
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
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите отказаться от комплектации данного заказа?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                await Task.Run(() => ToStorage());
                
                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                checkBox.IsChecked = false;
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
                mainWindow.CurrentStoreman = this.CurrentStoreman;
            }
        }
        private void ToStorage()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "storage";

                    List<int> orders = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).First().Orders;
                    List<int> currentOrders = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).First().CurrentOrders;

                    orders.Remove(ID);
                    currentOrders.Remove(ID);

                    CurrentStoreman = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).FirstOrDefault();

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
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что укомплектовали заказ?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                await Task.Run(() => ToPackaged());
                
                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                checkBox.IsChecked = false;
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
                mainWindow.CurrentStoreman = this.CurrentStoreman;
            }
        }
        private void ToPackaged()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "packaged";

                    List<int> currentOrders = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).First().CurrentOrders;

                    currentOrders.Remove(ID);

                    CurrentStoreman = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).FirstOrDefault();

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


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
            {
                FillGridCurrent();
            }
            if (!(sender as CheckBox).IsChecked.Value)
            {
                FillGrid();
            }
        }
    }
    public class GridItemMyOrdersStoreman
    {
        public int OrderNum { get; set; }
        public string Weight { get; set; }
        public string Size { get; set; }
        public string AddServices { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}
