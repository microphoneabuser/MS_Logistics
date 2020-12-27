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
    /// Логика взаимодействия для CourierMyOrdersControl.xaml
    /// </summary>
    public partial class CourierMyOrdersControl : UserControl
    {
        Courier CurrentCourier;
        AppContext db;
        int ID;
        CourierMainWindow mainWindow;
        public CourierMyOrdersControl(Courier courier, CourierMainWindow courierMainWindow)
        {
            InitializeComponent();
            this.CurrentCourier = courier;
            db = new AppContext();
            checkBox.IsChecked = false;
            FillGrid();
            this.mainWindow = courierMainWindow;
            comeBackButton.Visibility = Visibility.Collapsed;
        }
        public ObservableCollection<GridItemMyOrdersCourier> Items { get; set; } = new ObservableCollection<GridItemMyOrdersCourier>();
        private async void FillGrid()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            await Task.Run(() => GetOrders());

            OrdersGrid.ItemsSource = Items;

            loadborder.Visibility = Visibility.Hidden;
        }
        private void GetOrders()
        {
            try
            {
                List<string> ordersId = CurrentCourier.Orders;
                db = new AppContext();
                using (db)
                {
                    foreach (string id in ordersId)
                    {
                        int asd = int.Parse(id.Split('|')[0]);

                        Order myOrder = db.Orders.Where(order => order.id == asd).FirstOrDefault();

                        string status = "Выполнен";
                        if (myOrder.Status == "pickup" || myOrder.Status == "delivery")
                        {
                            status = "В процессе";
                        }
                        if (myOrder.Status == "delivery" && id.Split('|')[1] == "pickup")
                        {
                            status = "Выполнен";
                        }
                        if (id.Split('|')[1] == "pickup")
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                Items.Add(new GridItemMyOrdersCourier
                                {
                                    OrderNum = myOrder.id,
                                    Address = myOrder.SenderAddress,
                                    Date = myOrder.SenderDate,
                                    Time = myOrder.SenderTime,
                                    Weight = myOrder.Weight.ToString(),
                                    Size = $"{myOrder.Width} x {myOrder.Length} x {myOrder.Height}",
                                    Operation = "Забрать",
                                    Status = status
                                });
                            });
                        }
                        else if (id.Split('|')[1] == "delivery")
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                Items.Add(new GridItemMyOrdersCourier
                                {
                                    OrderNum = myOrder.id,
                                    Address = myOrder.DeliveryAddress,
                                    Date = myOrder.DeliveryDate,
                                    Time = myOrder.DeliveryTime,
                                    Weight = myOrder.Weight.ToString(),
                                    Size = $"{myOrder.Width} x {myOrder.Length} x {myOrder.Height}",
                                    Operation = "Доставить",
                                    Status = status
                                });
                            });
                        }
                    }
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
        private async void FillGridCurrent()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            await Task.Run(() => GetCurrentOrders());

            OrdersGrid.ItemsSource = Items;

            loadborder.Visibility = Visibility.Hidden;
        }
        
        private void GetCurrentOrders()
        {
            try
            {
                List<string> ordersId = CurrentCourier.CurrentOrders;
                db = new AppContext();
                using (db)
                {
                    foreach (string id in ordersId)
                    {
                        int asd = int.Parse(id.Split('|')[0]);

                        Order myOrder = db.Orders.Where(order => order.id == asd).FirstOrDefault();

                        string status = "Выполнен";
                        if (myOrder.Status == "pickup" || myOrder.Status == "delivery")
                        {
                            status = "В процессе";
                        }
                        if (id.Split('|')[1] == "pickup")
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                Items.Add(new GridItemMyOrdersCourier{
                                    OrderNum = myOrder.id,
                                    Address = myOrder.SenderAddress,
                                    Date = myOrder.SenderDate,
                                    Time = myOrder.SenderTime,
                                    Weight = myOrder.Weight.ToString(),
                                    Size = $"{myOrder.Width} x {myOrder.Length} x {myOrder.Height}",
                                    Operation = "Забрать",
                                    Status = status
                                });
                            });
                        }
                        else if (id.Split('|')[1] == "delivery")
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                Items.Add(new GridItemMyOrdersCourier{
                                    OrderNum = myOrder.id,
                                    Address = myOrder.DeliveryAddress,
                                    Date = myOrder.DeliveryDate,
                                    Time = myOrder.DeliveryTime,
                                    Weight = myOrder.Weight.ToString(),
                                    Size = $"{myOrder.Width} x {myOrder.Length} x {myOrder.Height}",
                                    Operation = "Доставить",
                                    Status = status
                                });
                            });
                        }
                    }
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
                int curId = (OrdersGrid.SelectedItem as GridItemMyOrdersCourier).OrderNum;
                ID = curId;

                string status = (OrdersGrid.SelectedItem as GridItemMyOrdersCourier).Status;

                string operation = (OrdersGrid.SelectedItem as GridItemMyOrdersCourier).Operation;

                FillOrder(curId, OrdersGrid.SelectedIndex,status, operation);

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
        private async void FillOrder(int id, int index, string status, string operation)
        {
            Order CurrentOrder = null;

            List<Client> clients = null;

            loadborder.Visibility = Visibility.Visible;

            NotDone.Visibility = Visibility.Collapsed;
            Done.Visibility = Visibility.Collapsed;

            await Task.Run(() => CurrentOrder = GetOrder(id));

            await Task.Run(() => clients = GetClients());

            if(status == "Выполнен")
            {
                Done.Visibility = Visibility.Visible;
                if(operation == "Забрать")
                {
                    Address.Text = CurrentOrder.SenderAddress;
                    Phonenumber.Text = CurrentOrder.SenderPhonenumber;
                    Client cl = clients.Where(client => client.id == CurrentOrder.ClientId).FirstOrDefault();
                    Name.Text = $"{cl.Name} {cl.Lastname}";
                    Date.Text = CurrentOrder.SenderDate;
                    Time.Text = CurrentOrder.SenderTime;
                    Weight.Text = CurrentOrder.Weight.ToString();
                    Volume.Text = CurrentOrder.Volume.ToString();
                    Width.Text = CurrentOrder.Width.ToString();
                    Length.Text = CurrentOrder.Length.ToString();
                    Height.Text = CurrentOrder.Height.ToString();
                    Operation.Text = "Забрать";
                }
                else
                {
                    Address.Text = CurrentOrder.DeliveryAddress;
                    Phonenumber.Text = CurrentOrder.AddresseePhonenumber;
                    Name.Text = CurrentOrder.AddresseeName;
                    Date.Text = CurrentOrder.DeliveryDate;
                    Time.Text = CurrentOrder.DeliveryTime;
                    Weight.Text = CurrentOrder.Weight.ToString();
                    Volume.Text = CurrentOrder.Volume.ToString();
                    Width.Text = CurrentOrder.Width.ToString();
                    Length.Text = CurrentOrder.Length.ToString();
                    Height.Text = CurrentOrder.Height.ToString();
                    Operation.Text = "Доставить";
                }
            }
            else
            {
                if (CurrentOrder.Status == "pickup")
                {
                    NotDone.Visibility = Visibility.Visible;
                    Address.Text = CurrentOrder.SenderAddress;
                    Phonenumber.Text = CurrentOrder.SenderPhonenumber;
                    Client cl = clients.Where(client => client.id == CurrentOrder.ClientId).FirstOrDefault();
                    Name.Text = $"{cl.Name} {cl.Lastname}";
                    Date.Text = CurrentOrder.SenderDate;
                    Time.Text = CurrentOrder.SenderTime;
                    Weight.Text = CurrentOrder.Weight.ToString();
                    Volume.Text = CurrentOrder.Volume.ToString();
                    Width.Text = CurrentOrder.Width.ToString();
                    Length.Text = CurrentOrder.Length.ToString();
                    Height.Text = CurrentOrder.Height.ToString();
                    Operation.Text = "Забрать";
                }
                else if (CurrentOrder.Status == "delivery")
                {
                    NotDone.Visibility = Visibility.Visible;
                    Address.Text = CurrentOrder.DeliveryAddress;
                    Phonenumber.Text = CurrentOrder.AddresseePhonenumber;
                    Name.Text = CurrentOrder.AddresseeName;
                    Date.Text = CurrentOrder.DeliveryDate;
                    Time.Text = CurrentOrder.DeliveryTime;
                    Weight.Text = CurrentOrder.Weight.ToString();
                    Volume.Text = CurrentOrder.Volume.ToString();
                    Width.Text = CurrentOrder.Width.ToString();
                    Length.Text = CurrentOrder.Length.ToString();
                    Height.Text = CurrentOrder.Height.ToString();
                    Operation.Text = "Доставить";
                }
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
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите отказаться от выполнения данного заказа?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                if(Operation.Text == "Забрать")
                {
                    await Task.Run(() => ToPaid());
                }
                else
                {
                    await Task.Run(() => ToPackaged());
                }

                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                checkBox.IsChecked = false;
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
                mainWindow.CurrentCourier = this.CurrentCourier;
            }
        }
        private void ToPaid()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "paid";
                    List<string> orders = null;
                    List<string> currentOrders = null;
                    orders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().Orders;
                    currentOrders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().CurrentOrders;

                    orders.Remove(orders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "pickup")).First());
                    currentOrders.Remove(currentOrders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "pickup")).First());

                    CurrentCourier = db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault();
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
        private void ToPackaged()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "packaged";
                    List<string> orders = null;
                    List<string> currentOrders = null;
                    orders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().Orders;
                    currentOrders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().CurrentOrders;
                    orders.Remove(orders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "delivery")).FirstOrDefault());
                    currentOrders.Remove(currentOrders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "delivery")).FirstOrDefault());

                    CurrentCourier = db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault();

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
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что выполнили заказ?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                loadborder.Visibility = Visibility.Visible;

                if (Operation.Text == "Забрать")
                {
                    await Task.Run(() => ToStorage());
                }
                else
                {
                    await Task.Run(() => ToDelivered());
                }

                loadborder.Visibility = Visibility.Collapsed;

                mainText.Text = "Мои заказы";
                checkBox.IsChecked = false;
                FillGrid();
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                GridPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Collapsed;
                mainWindow.CurrentCourier = this.CurrentCourier;

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
                    List<string> currentOrders = null;
                    currentOrders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().CurrentOrders;
                    currentOrders.Remove(currentOrders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "pickup")).FirstOrDefault());

                    CurrentCourier = db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault();

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
        private void ToDelivered()
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Orders.Where(order => order.id == ID).FirstOrDefault().Status = "delivered";
                    List<string> currentOrders = null;
                    currentOrders = db.Couriers.Where(courier => courier.id == CurrentCourier.id).First().CurrentOrders;
                    currentOrders.Remove(currentOrders.Where(str => (int.Parse(str.Split('|')[0]) == ID && str.Split('|')[1] == "delivery")).FirstOrDefault());

                    CurrentCourier = db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault();

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
    public class GridItemMyOrdersCourier
    {
        public int OrderNum { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Weight { get; set; }
        public string Size { get; set; }
        public string Operation { get; set; }
        public string Status { get; set; }
    }
}
