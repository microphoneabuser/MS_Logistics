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
    /// Логика взаимодействия для ManagerAllOrdersControl.xaml
    /// </summary>
    public partial class ManagerAllOrdersControl : UserControl
    {
        Manager CurrentManager;
        AppContext db;
        int ID;
        ManagerMainWindow ManagerMainWindow;
        public ObservableCollection<GridItemManagers> Items { get; set; } = new ObservableCollection<GridItemManagers>();
        List<int> idList = new List<int>();
        public ManagerAllOrdersControl(Manager manager, ManagerMainWindow managerMainWindow)
        {
            InitializeComponent();
            this.ManagerMainWindow = managerMainWindow;
            this.CurrentManager = manager;
            db = new AppContext();
            FillGrid();
        }

        private async void FillGrid()
        {
            Items.Clear();

            List<Client> clients = new List<Client>();
            List<Order> myOrders = new List<Order>();

            loadborder.Visibility = Visibility.Visible;

            await Task.Run(() => clients = GetClients());

            await Task.Run(() => myOrders = GetOrders());

            foreach (Order order in myOrders)
            {
                Client Client = clients.Where(client => client.id == order.ClientId).FirstOrDefault();
                Items.Add(new GridItemManagers
                {
                    OrderNum = order.id,
                    Client = $"{Client.Name} {Client.Lastname}",
                    TimeStamp = order.TimeStamp,
                    SenderDate = order.SenderDate,
                    DeliveryDate = order.DeliveryDate
                });
            }
            OrdersGrid.ItemsSource = Items;
            loadborder.Visibility = Visibility.Collapsed;
        }

        private List<Order> GetOrders()
        {
            List<Order> currentOrders = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    currentOrders = db.Orders.Where(order => order.Status == "requested").ToList<Order>();
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

        private void checkOrder_Click(object sender, RoutedEventArgs e)
        {
            if((sender as CheckBox).IsChecked.Value)
            {
                GridItemManagers gridItemManagers = (sender as CheckBox).DataContext as GridItemManagers;
                idList.Add(gridItemManagers.OrderNum);
            }
            if(!(sender as CheckBox).IsChecked.Value)
            {
                GridItemManagers gridItemManagers = (sender as CheckBox).DataContext as GridItemManagers;
                idList.Remove(gridItemManagers.OrderNum);
            }
        }

        private void ToProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            if (idList.Count != 0)
            {
                CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите перейти к обработке?", false);
                ctrlMessageBox.ShowDialog();

                if (ctrlMessageBox.flag)
                {
                    db = new AppContext();

                    using (db)
                    {
                        foreach (int id in idList)
                        {
                            db.Orders.Where(order => order.id == id).FirstOrDefault().Status = "processing";
                            db.Managers.Where(manager => manager.id == CurrentManager.id).FirstOrDefault().CurrentOrders.Add(id);
                            db.Managers.Where(manager => manager.id == CurrentManager.id).FirstOrDefault().Orders.Add(id);
                            db.SaveChanges();
                        }

                        CurrentManager = db.Managers.Where(manager => manager.id == CurrentManager.id).FirstOrDefault();
                        db.SaveChanges();
                    }
                    UserControl usc = new ManagerProcessingControl(CurrentManager, ManagerMainWindow);
                    ManagerMainWindow.CurrentManager = this.CurrentManager;
                    ManagerMainWindow.GridMain.Children.Clear();
                    ManagerMainWindow.GridMain.Children.Add(usc);
                }
            }
            else
            {
                CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Нет выделенных заявок.", "Сначала выберите заявки для последующей обработки.", true);
                ctrlMessageBox.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillGrid();
        }
    }
    public class GridItemManagers
    {
        public int OrderNum { get; set; }
        public string Client { get; set; }
        public string TimeStamp { get; set; }
        public string SenderDate { get; set; }
        public string DeliveryDate { get; set; }
    }
}
