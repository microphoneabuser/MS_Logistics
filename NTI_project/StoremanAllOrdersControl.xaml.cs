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
    /// Логика взаимодействия для StoremanAllOrdersControl.xaml
    /// </summary>
    public partial class StoremanAllOrdersControl : UserControl
    {
        Storeman CurrentStoreman;
        AppContext db;
        int ID;
        StoremanMainWindow StoremanMainWindow;
        List<Order> myOrders;
        public ObservableCollection<GridItemStoremans> Items { get; set; } = new ObservableCollection<GridItemStoremans>();
        List<int> idList = new List<int>();
        public StoremanAllOrdersControl(Storeman storeman, StoremanMainWindow storemanMainWindow)
        {
            InitializeComponent();
            this.StoremanMainWindow = storemanMainWindow;
            this.CurrentStoreman = storeman;
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
                Items.Add(new GridItemStoremans
                {
                    OrderNum = order.id,
                    Weight = order.Weight.ToString(),
                    Size = $"{order.Width} x {order.Length} x {order.Height}",
                    AddServices = order.AddServicesList,
                    Date = order.DeliveryDate,
                    Time = order.DeliveryTime
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
                    currentOrders = db.Orders.Where(order => (order.Status == "storage")).ToList<Order>();
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
                GridItemStoremans gridItemStoremans = (sender as CheckBox).DataContext as GridItemStoremans;
                idList.Add(gridItemStoremans.OrderNum);
            }
            if (!(sender as CheckBox).IsChecked.Value)
            {
                GridItemStoremans gridItemStoremans = (sender as CheckBox).DataContext as GridItemStoremans;
                idList.Remove(gridItemStoremans.OrderNum);
            }
        }

        private void ToProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            if (idList.Count != 0)
            {
                CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите перейти к комплектации выбранных посылок?", false);
                ctrlMessageBox.ShowDialog();

                if (ctrlMessageBox.flag)
                {
                    db = new AppContext();

                    using (db)
                    {
                        foreach (int id in idList)
                        {
                            db.Orders.Where(order => order.id == id).FirstOrDefault().Status = "packaging";
                            db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).FirstOrDefault().CurrentOrders.Add(id);
                            db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).FirstOrDefault().Orders.Add(id);
                            
                            db.SaveChanges();
                        }

                        CurrentStoreman = db.Storemen.Where(storeman => storeman.id == CurrentStoreman.id).FirstOrDefault();
                        db.SaveChanges();
                    }
                    UserControl usc = new StoremanMyOrdersControl(CurrentStoreman, StoremanMainWindow);
                    StoremanMainWindow.CurrentStoreman = this.CurrentStoreman;
                    StoremanMainWindow.GridMain.Children.Clear();
                    StoremanMainWindow.GridMain.Children.Add(usc);
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
    public class GridItemStoremans
    {
        public int OrderNum { get; set; }
        public string Weight { get; set; }
        public string Size { get; set; }
        public string AddServices { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
}
