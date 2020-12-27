using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ManagerProcessingControl.xaml
    /// </summary>
    public partial class ManagerProcessingControl : UserControl
    {
        Manager CurrentManager;
        ManagerMainWindow ManagerMainWindow;
        AppContext db;
        int currentNum;
        int curID;
        public ManagerProcessingControl(Manager manager, ManagerMainWindow managerMainWindow)
        {
            InitializeComponent();
            this.CurrentManager = manager;
            this.ManagerMainWindow = managerMainWindow;
            loadborder.Visibility = Visibility.Visible;
            FillForm(0);
        }
        private List<Order> FillOrders(List<int> ordersId)
        {
            List<Order> orders = new List<Order>();
            db = new AppContext();
            using (db)
            {
                foreach (int id in ordersId)
                {
                    Order order1 = db.Orders.Where(order => order.id == id).FirstOrDefault();
                    if (order1.Status == "processing")
                    {
                        orders.Add(order1);
                        db.SaveChanges();
                    }
                }
            }
            return orders;
        }
        private async void FillForm(int num)
        {
            text.Text = "Вам следует проверить (по надобности, изменить) информацию о данном заказе. А затем нажать на кнопку \"Подтвердить заказ\".";
            TrackNum.Visibility = Visibility.Visible;
            loadborder.Visibility = Visibility.Visible;
            List<int> ordersId = CurrentManager.CurrentOrders;
            List<Order> orders = new List<Order>();

            await Task.Run(() => orders = FillOrders(ordersId));

            if (orders.Count == 0)
            {
                mainText.Text = "Обработка заявок";
                text.Text = "Нет не обработанных заявок.";
                CurrentOrderPanel.Visibility = Visibility.Collapsed;
                TrackNum.Visibility = Visibility.Collapsed;
            }
            else if (num < orders.Count && num > -1)
            {
                if (orders[num] != null)
                {
                    currentNum = num;
                    curID = orders[num].id;

                    mainText.Text = $"Заказ №{curID}";
                    TrackNum.Text = $"{num + 1} из {orders.Count}";

                    SenderAddress.Text = orders[num].SenderAddress;
                    SenderName.Text = GetClientName(orders[num].ClientId);
                    SenderPhonenumber.Text = orders[num].SenderPhonenumber;
                    SenderDate.SelectedDate = DateTime.Parse(orders[num].SenderDate);
                    SenderTime.SelectedTime = DateTime.Parse(orders[num].SenderTime);
                    TimeStamp.Text = orders[num].TimeStamp;
                    AddresseeAddress.Text = orders[num].DeliveryAddress;
                    AddresseeName.Text = orders[num].AddresseeName;
                    AddresseePhonenumber.Text = orders[num].AddresseePhonenumber;
                    DeliveryDate.SelectedDate = DateTime.Parse(orders[num].DeliveryDate);
                    DeliveryTime.SelectedTime = DateTime.Parse(orders[num].DeliveryTime);
                    Weight.Text = orders[num].Weight.ToString();
                    Volume.Text = orders[num].Volume.ToString();
                    Height.Text = orders[num].Height.ToString();
                    Width.Text = orders[num].Width.ToString();
                    Length.Text = orders[num].Length.ToString();
                    Price.Text = orders[num].Price.ToString();

                    add1.IsChecked = false;
                    add2.IsChecked = false;
                    add3.IsChecked = false;
                    add4.IsChecked = false;
                    add5.IsChecked = false;
                    add6.IsChecked = false;
                    add7.IsChecked = false;
                    add8.IsChecked = false;

                    if (orders[num].AddServices.Contains(add1.Content))
                    {
                        add1.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add2.Content))
                    {
                        add2.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add3.Content))
                    {
                        add3.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add4.Content))
                    {
                        add4.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add5.Content))
                    {
                        add5.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add6.Content))
                    {
                        add6.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add7.Content))
                    {
                        add7.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(add8.Content))
                    {
                        add8.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(PlacerButton.Content))
                    {
                        PlacerButton.IsChecked = true;
                    }
                    if (orders[num].AddServices.Contains(PalletButton.Content))
                    {
                        PalletButton.IsChecked = true;
                    }

                }
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private string GetClientName(int id)
        {
            Client ThisClient = null;
            string name = "";
            db = new AppContext();
            using (db)
            {
                ThisClient = db.Clients.Where(client => client.id == id).FirstOrDefault();
            }
            return name = $"{ThisClient.Name} {ThisClient.Lastname}";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillForm(currentNum + 1);
            }
            catch
            {
                
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillForm(currentNum - 1);
            }
            catch
            {

            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            bool fiiled = true;

            if (SenderName.Text.Length < 1)
            {
                SenderName.ToolTip = "Это поле должно быть заполнено!";
                SenderName.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeAddress.Text.Length < 1)
            {
                AddresseeAddress.ToolTip = "Это поле должно быть заполнено!";
                AddresseeAddress.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeName.Text.Length < 1)
            {
                AddresseeName.ToolTip = "Это поле должно быть заполнено!";
                AddresseeName.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseePhonenumber.Text.Contains("_"))
            {
                AddresseePhonenumber.ToolTip = "Введите полный номер телефона";
                AddresseePhonenumber.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (SenderDate.SelectedDate == null)
            {
                SenderDate.ToolTip = "Это поле должно быть заполнено";
                SenderDate.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (SenderTime.SelectedTime == null)
            {
                SenderTime.ToolTip = "Это поле должно быть заполнено";
                SenderTime.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Weight.Text.Length < 1)
            {
                Weight.ToolTip = "Это поле должно быть заполнено";
                Weight.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Weight.Text != "" && Weight.Text != null)
            {
                if (double.Parse(Weight.Text) > 10000)
                {
                    Weight.ToolTip = "Слишком большой вес!";
                    Weight.Background = Brushes.DarkRed;
                    fiiled = false;
                }
            }
            if (Volume.Text.Length < 1)
            {
                Volume.ToolTip = "Это поле должно быть заполнено";
                Volume.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Volume.Text != "" && Volume.Text != null)
            {
                if (double.Parse(Volume.Text) > 40)
                {
                    Volume.ToolTip = "Слишком большой объём!";
                    Volume.Background = Brushes.DarkRed;
                    fiiled = false;
                }
            }
            if (DeliveryDate.SelectedDate == null)
            {
                DeliveryDate.ToolTip = "Это поле должно быть заполнено";
                DeliveryDate.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (DeliveryTime.SelectedTime == null)
            {
                DeliveryTime.ToolTip = "Это поле должно быть заполнено";
                DeliveryTime.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Width.Text.Length < 1)
            {
                Width.ToolTip = "Это поле должно быть заполнено";
                Width.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Length.Text.Length < 1)
            {
                Length.ToolTip = "Это поле должно быть заполнено";
                Length.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (Height.Text.Length < 1)
            {
                Height.ToolTip = "Это поле должно быть заполнено";
                Height.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (fiiled) 
            {
                CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите подтвердить заявку?", false);
                ctrlMessageBox.ShowDialog();

                if (ctrlMessageBox.flag)
                {
                    Order myOrder = null;

                    db = new AppContext();
                    using (db)
                    {
                        myOrder = (db.Orders.Where(order => order.id == curID).FirstOrDefault());

                        myOrder.AddresseeName = AddresseeName.Text;
                        myOrder.AddresseePhonenumber = AddresseePhonenumber.Text;

                        myOrder.AddServices.Clear();

                        if (PlacerButton.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(PlacerButton.Content.ToString());
                        }
                        if (PalletButton.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(PalletButton.Content.ToString());
                        }
                        if (add1.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add1.Content.ToString());
                        }
                        if (add2.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add2.Content.ToString());
                        }
                        if (add3.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add3.Content.ToString());
                        }
                        if (add4.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add4.Content.ToString());
                        }
                        if (add5.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add5.Content.ToString());
                        }
                        if (add6.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add6.Content.ToString());
                        }
                        if (add7.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add7.Content.ToString());
                        }
                        if (add8.IsChecked.Value)
                        {
                            myOrder.AddServices.Add(add8.Content.ToString());
                        }

                        myOrder.DeliveryAddress = AddresseeAddress.Text;
                        myOrder.DeliveryDate = DeliveryDate.SelectedDate.Value.ToShortDateString();
                        myOrder.DeliveryTime = DeliveryTime.SelectedTime.Value.ToShortTimeString();
                        myOrder.Height = double.Parse(Height.Text);
                        myOrder.Length = double.Parse(Length.Text);
                        myOrder.Price = double.Parse(Price.Text);
                        myOrder.SenderAddress = SenderAddress.Text;
                        myOrder.SenderDate = SenderDate.SelectedDate.Value.ToShortDateString();
                        myOrder.SenderPhonenumber = SenderPhonenumber.Text;
                        myOrder.SenderTime = SenderTime.SelectedTime.Value.ToShortTimeString();
                        myOrder.Status = "accepted";
                        myOrder.Volume = double.Parse(Volume.Text);
                        myOrder.Weight = double.Parse(Weight.Text);
                        myOrder.Width = double.Parse(Width.Text);

                        db.SaveChanges();
                    }
                    try
                    {
                        FillForm(currentNum);
                    }
                    catch { FillForm(currentNum - 1); }
                }
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Подтвердите действие!", "Вы уверены, что хотите отменить заявку?", false);
            ctrlMessageBox.ShowDialog();

            if (ctrlMessageBox.flag)
            {
                Order myOrder = null;

                db = new AppContext();
                using (db)
                {
                    myOrder = (db.Orders.Where(order => order.id == curID).FirstOrDefault());
                    myOrder.Status = "cancelled";
                    db.SaveChanges();
                }
                try
                {
                    FillForm(currentNum);
                }
                catch { FillForm(currentNum - 1); }
            }
        }
        private double GetPrice()
        {
            try
            {
                double mainPrice = 0;
                double weight = double.Parse(Weight.Text);
                double volume = double.Parse(Volume.Text);

                if (weight < 5)
                {
                    mainPrice = 355;
                }
                if (weight < 50 && weight >= 5)
                {
                    mainPrice = 565;
                }
                if (weight < 100 && weight >= 50)
                {
                    mainPrice = 705;
                }
                if (weight < 500 && weight >= 100)
                {
                    mainPrice = 1110;
                }
                if (weight < 1000 && weight >= 500)
                {
                    mainPrice = 1420;
                }
                if (weight < 1500 && weight >= 1000)
                {
                    mainPrice = 1825;
                }
                if (weight < 3000 && weight >= 1500)
                {
                    mainPrice = 2650;
                }
                if (weight < 5000 && weight >= 3000)
                {
                    mainPrice = 5510;
                }
                if (weight < 10000 && weight >= 5000)
                {
                    mainPrice = 7140;
                }
                if (add1.IsChecked.Value)
                {
                    double additionalPrice1 = 600 * volume;
                    mainPrice += additionalPrice1;
                }
                if (add2.IsChecked.Value)
                {
                    double additionalPrice2 = 30 * volume;
                    mainPrice += additionalPrice2;
                }
                if (add3.IsChecked.Value)
                {
                    double additionalPrice3 = 250 * volume / 2;
                    mainPrice += additionalPrice3;
                }
                if (add4.IsChecked.Value)
                {
                    double additionalPrice4 = 300 * volume;
                    mainPrice += additionalPrice4;
                }
                if (add5.IsChecked.Value)
                {
                    double additionalPrice5 = 100 * volume;
                    mainPrice += additionalPrice5;
                }
                if (add6.IsChecked.Value)
                {
                    double additionalPrice6 = 55 * 7 * volume;
                    mainPrice += additionalPrice6;
                }
                if (add7.IsChecked.Value)
                {
                    double additionalPrice7 = 500 * volume;
                    mainPrice += additionalPrice7;
                }
                if (add8.IsChecked.Value)
                {
                    double additionalPrice8 = 100 * volume;
                    mainPrice += additionalPrice8;
                }

                return mainPrice;
            }
            catch { return 0; }
        }
        private void CalculateVolume()
        {
            try
            {
                if (Width.Text != "0" && Width.Text != "" && Length.Text != "0" && Length.Text != "" && Height.Text != "0" && Height.Text != "")
                {
                    Volume.Text = (double.Parse(Width.Text) * double.Parse(Length.Text) * double.Parse(Height.Text)).ToString();
                }
            }
            catch
            {

            }
        }
        
        private void Weight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void Volume_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;
        }

        private void Width_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;
        }

        private void Length_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void Height_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void DeliveryDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DeliveryDate.ToolTip = null;
            DeliveryDate.Background = Brushes.Transparent;
        }

        private void DeliveryTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            DeliveryTime.ToolTip = null;
            DeliveryTime.Background = Brushes.Transparent;
        }

        private void SenderDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SenderDate.ToolTip = null;
            SenderDate.Background = Brushes.Transparent;
            DeliveryDate.DisplayDateStart = SenderDate.SelectedDate;
        }

        private void SenderTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            SenderTime.ToolTip = null;
            SenderTime.Background = Brushes.Transparent;
        }

        private void SenderAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            SenderAddress.ToolTip = null;
            SenderAddress.Background = Brushes.Transparent;
        }

        private void SenderPhonenumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SenderPhonenumber.ToolTip = null;
            SenderPhonenumber.Background = Brushes.Transparent;
        }

        private void AddresseeAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeAddress.ToolTip = null;
            AddresseeAddress.Background = Brushes.Transparent;
        }

        private void AddresseeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeName.ToolTip = null;
            AddresseeName.Background = Brushes.Transparent;
        }

        private void AddresseePhonenumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseePhonenumber.ToolTip = null;
            AddresseePhonenumber.Background = Brushes.Transparent;
        }

        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            Weight.ToolTip = null;
            Weight.Background = Brushes.Transparent;
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void Volume_TextChanged(object sender, TextChangedEventArgs e)
        {
            Volume.ToolTip = null;
            Volume.Background = Brushes.Transparent;
        }

        private void Width_TextChanged(object sender, TextChangedEventArgs e)
        {
            Width.ToolTip = null;
            Width.Background = Brushes.Transparent;
            CalculateVolume();

        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            Length.ToolTip = null;
            Length.Background = Brushes.Transparent;
            CalculateVolume();

        }

        private void Height_TextChanged(object sender, TextChangedEventArgs e)
        {
            Height.ToolTip = null;
            Height.Background = Brushes.Transparent;
            CalculateVolume();

        }
        private void add1_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add1_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add2_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add2_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add3_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add3_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add4_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add4_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add5_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add5_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }

        }

        private void add6_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add6_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add7_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add7_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add8_Checked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }

        private void add8_Unchecked(object sender, RoutedEventArgs e)
        {
            try { Price.Text = GetPrice().ToString(); }
            catch { }
        }
    }
}
