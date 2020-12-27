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
    /// Логика взаимодействия для CourierAllOrdersControl.xaml
    /// </summary>
    public partial class CourierAllOrdersControl : UserControl
    {
        Courier CurrentCourier;
        AppContext db;
        int ID;
        CourierMainWindow CourierMainWindow;
        List<Order> myOrders;
        public ObservableCollection<GridItemCouriers> Items { get; set; } = new ObservableCollection<GridItemCouriers>();
        List<int> idList = new List<int>();
        public CourierAllOrdersControl(Courier courier, CourierMainWindow courierMainWindow)
        {
            InitializeComponent();
            this.CourierMainWindow = courierMainWindow;
            this.CurrentCourier = courier;
            db = new AppContext();
            FillGrid();
        }
        private async void FillGrid()
        {
            Items.Clear();

            myOrders = new List<Order>();

            loadborder.Visibility = Visibility.Visible;

            await Task.Run(() => myOrders = GetOrders());

            foreach (Order order in myOrders)
            {
                if (order.Status == "paid")
                {
                    Items.Add(new GridItemCouriers
                    {
                        OrderNum = order.id,
                        Address = order.SenderAddress,
                        Date = order.SenderDate,
                        Time = order.SenderTime,
                        Weight = order.Weight.ToString(),
                        Size = $"{order.Width}x{order.Length}x{order.Height}",
                        Operation = "Забрать"
                    });
                }
                else if (order.Status == "packaged")
                {
                    Items.Add(new GridItemCouriers
                    {
                        OrderNum = order.id,
                        Address = order.DeliveryAddress,
                        Date = order.DeliveryDate,
                        Time = order.DeliveryTime,
                        Weight = order.Weight.ToString(),
                        Size = $"{order.Width}x{order.Length}x{order.Height}",
                        Operation = "Доставить"
                    });
                }
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
                    currentOrders = db.Orders.Where(order => (order.Status == "paid" || order.Status == "packaged")).ToList<Order>();
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

        private void checkOrder_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
            {
                GridItemCouriers gridItemCouriers = (sender as CheckBox).DataContext as GridItemCouriers;
                idList.Add(gridItemCouriers.OrderNum);
            }
            if (!(sender as CheckBox).IsChecked.Value)
            {
                GridItemCouriers gridItemCouriers = (sender as CheckBox).DataContext as GridItemCouriers;
                idList.Remove(gridItemCouriers.OrderNum);
            }
        }

        private void ToProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            if (idList.Count != 0)
            {
                CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите перейти к выполнению выбранных заказов?", false);
                ctrlMessageBox.ShowDialog();

                if (ctrlMessageBox.flag)
                {
                    db = new AppContext();

                    using (db)
                    {
                        foreach (int id in idList)
                        {
                            if (myOrders.Where(order => order.id == id).FirstOrDefault().Status == "paid")
                            {
                                db.Orders.Where(order => order.id == id).FirstOrDefault().Status = "pickup";
                                db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault().CurrentOrders.Add($"{id}|pickup");
                                db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault().Orders.Add($"{id}|pickup");
                            }
                            else if (myOrders.Where(order => order.id == id).FirstOrDefault().Status == "packaged")
                            {
                                db.Orders.Where(order => order.id == id).FirstOrDefault().Status = "delivery";
                                db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault().CurrentOrders.Add($"{id}|delivery");
                                db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault().Orders.Add($"{id}|delivery");
                            }
                            db.SaveChanges();
                        }

                        CurrentCourier = db.Couriers.Where(courier => courier.id == CurrentCourier.id).FirstOrDefault();
                        db.SaveChanges();
                    }
                    UserControl usc = new CourierMyOrdersControl(CurrentCourier, CourierMainWindow);
                    CourierMainWindow.CurrentCourier = this.CurrentCourier;
                    CourierMainWindow.GridMain.Children.Clear();
                    CourierMainWindow.GridMain.Children.Add(usc);
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
    public class GridItemCouriers
    {
        public int OrderNum { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Weight { get; set; }
        public string Size { get; set; }
        public string Operation { get; set; }

    }
}
