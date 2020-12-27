using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CreateOrderControl.xaml
    /// </summary>
    public partial class CreateOrderControl : UserControl
    {
        Client CurrentClient;
        AppContext db;
        MainWindow mainWindow;
        public CreateOrderControl(Client client, MainWindow mainWindow)
        {
            InitializeComponent();
            SecondPage.Visibility = Visibility.Collapsed;
            ThirdPage.Visibility = Visibility.Collapsed;
            FourthPage.Visibility = Visibility.Collapsed;
            CurrentClient = client;
            db = new AppContext();
            this.mainWindow = mainWindow;
            DatePicker.DisplayDateStart = DateTime.Now;
        }

        private void NextFirst_Click(object sender, RoutedEventArgs e)
        {
            bool fiiled = true;
            if(StreetBox.Text.Length < 2)
            {
                StreetBox.ToolTip = "Это поле введено не корректно";
                StreetBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (HouseBox.Text.Length < 1)
            {
                HouseBox.ToolTip = "Это поле должно быть заполнено";
                HouseBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (ApartmentBox.Text.Length < 1)
            {
                ApartmentBox.ToolTip = "Это поле должно быть заполнено";
                ApartmentBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (PhonenumberBox.Text.Contains("_"))
            {
                PhonenumberBox.ToolTip = "Введите полный номер телефона";
                PhonenumberBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (DatePicker.SelectedDate == null)
            {
                DatePicker.ToolTip = "Это поле должно быть заполнено";
                DatePicker.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (TimePicker.SelectedTime == null)
            {
                TimePicker.ToolTip = "Это поле должно быть заполнено";
                TimePicker.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if(fiiled)
            {
                SecondPage.Visibility = Visibility.Visible;
                TabControl.SelectedIndex = 1;
            }
        }

        private void PrevSecond_Click(object sender, RoutedEventArgs e)
        {
            TabControl.SelectedIndex = 0;
        }

        private void NextSecond_Click(object sender, RoutedEventArgs e)
        {
            bool fiiled = true;
            if (WeightBox.Text.Length < 1)
            {
                WeightBox.ToolTip = "Это поле должно быть заполнено";
                WeightBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (WeightBox.Text != "" && WeightBox.Text != null)
            {
                if (double.Parse(WeightBox.Text) > 10000)
                {
                    WeightBox.ToolTip = "Слишком большой вес!";
                    WeightBox.Background = Brushes.DarkRed;
                    fiiled = false;
                }
            }
            if (VolumeBox.Text.Length < 1 || VolumeBox.Text == "0")
            {
                VolumeBox.ToolTip = "Это поле должно быть заполнено положительным числом";
                VolumeBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (VolumeBox.Text != "" && VolumeBox.Text != null)
            {
                if (double.Parse(VolumeBox.Text) > 40)
                {
                    VolumeBox.ToolTip = "Слишком большой объём!";
                    VolumeBox.Background = Brushes.DarkRed;
                    fiiled = false;
                }
            }
            if (WidthBox.Text == "" || WidthBox.Text == "0")
            {
                WidthBox.ToolTip = "Это поле должно быть заполнено положительным числом";
                WidthBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (LengthBox.Text == "" || LengthBox.Text == "0")
            {
                LengthBox.ToolTip = "Это поле должно быть заполнено положительным числом";
                LengthBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (HeightBox.Text == "" || HeightBox.Text == "0")
            {
                HeightBox.ToolTip = "Это поле должно быть заполнено положительным числом";
                HeightBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (fiiled)
            {
                ThirdPage.Visibility = Visibility.Visible;
                TabControl.SelectedIndex = 2;
            }
        }

        private void PrevThird_Click(object sender, RoutedEventArgs e)
        {
            TabControl.SelectedIndex = 1;
        }

        private void NextThird_Click(object sender, RoutedEventArgs e)
        {
            bool fiiled = true;
            if (AddresseeStreetBox.Text.Length < 2)
            {
                AddresseeStreetBox.ToolTip = "Это поле введено не корректно";
                AddresseeStreetBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeHouseBox.Text.Length < 1)
            {
                AddresseeHouseBox.ToolTip = "Это поле должно быть заполнено";
                AddresseeHouseBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeApartmentBox.Text.Length < 1)
            {
                AddresseeApartmentBox.ToolTip = "Это поле должно быть заполнено";
                AddresseeApartmentBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeNameBox.Text.Length < 1)
            {
                AddresseeNameBox.ToolTip = "Это поле должно быть заполнено";
                AddresseeNameBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseeLastNameBox.Text.Length < 1)
            {
                AddresseeLastNameBox.ToolTip = "Это поле должно быть заполнено";
                AddresseeLastNameBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (AddresseePhonenumberBox.Text.Contains("_"))
            {
                PhonenumberBox.ToolTip = "Введите полный номер телефона";
                PhonenumberBox.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (DatePicker2.SelectedDate == null)
            {
                DatePicker2.ToolTip = "Это поле должно быть заполнено";
                DatePicker2.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (TimePicker2.SelectedTime == null)
            {
                TimePicker2.ToolTip = "Это поле должно быть заполнено";
                TimePicker2.Background = Brushes.DarkRed;
                fiiled = false;
            }
            if (fiiled)
            {
                FourthPage.Visibility = Visibility.Visible;
                TabControl.SelectedIndex = 3;
                ToSumUp();
            }
        }

        string senderAddress, senderPhonenumber, senderDate,
            senderTime, deliveryAddress,
            addresseeName, addresseePhonenumber,
            deliveryDate, deliveryTime;

        double weight, volume, width, length, height, price;

        List<string> AddServices;

        private void ToSumUp()
        {
            AddServices = new List<string>();

            senderAddress = $"ул. {StreetBox.Text}, дом {HouseBox.Text}, кв. {ApartmentBox.Text}";
            SenderAddress.Text = senderAddress;

            SenderPhonenumber.Text = PhonenumberBox.Text;
            senderPhonenumber = PhonenumberBox.Text;

            SenderDate.Text = DatePicker.SelectedDate.Value.ToShortDateString();
            senderDate = SenderDate.Text;

            SenderTime.Text = TimePicker.SelectedTime.Value.ToShortTimeString();
            senderTime = SenderTime.Text;

            deliveryAddress = $"ул. {AddresseeStreetBox.Text}, дом {AddresseeHouseBox.Text}, кв. {AddresseeApartmentBox.Text}";
            AddresseeAddress.Text = deliveryAddress;

            AddresseeName.Text = $"{AddresseeNameBox.Text} {AddresseeLastNameBox.Text}";
            addresseeName = AddresseeName.Text;

            AddresseePhonenumber.Text = AddresseePhonenumberBox.Text;
            addresseePhonenumber = AddresseePhonenumber.Text;

            DeliveryDate.Text = DatePicker2.SelectedDate.Value.ToShortDateString();
            deliveryDate = DeliveryDate.Text;

            DeliveryTime.Text = TimePicker2.SelectedTime.Value.ToShortTimeString();
            deliveryTime = DeliveryTime.Text;

            Weight.Text = WeightBox.Text;
            weight = double.Parse(WeightBox.Text);

            Volume.Text = VolumeBox.Text;

            volume = double.Parse(VolumeBox.Text);

            if (WidthBox.Text != "" && WidthBox.Text != null)
            {
                width = double.Parse(WidthBox.Text);
            }
            if (LengthBox.Text != "" && LengthBox.Text != null)
            {
                length = double.Parse(LengthBox.Text);
            }
            if (HeightBox.Text != "" && HeightBox.Text != null)
            {
                height = double.Parse(HeightBox.Text);
            }


            string addInfo = "";
            if (PlacerButton.IsChecked.Value) { addInfo = "Россыпь"; AddServices.Add("Россыпь"); } else { addInfo = "Паллет"; AddServices.Add("Паллет"); }
            if (add1.IsChecked.Value) { addInfo += $", {add1.Content}"; AddServices.Add(add1.Content.ToString()); }
            if (add2.IsChecked.Value) { addInfo += $", {add2.Content}"; AddServices.Add(add2.Content.ToString()); }
            if (add3.IsChecked.Value) { addInfo += $", {add3.Content}"; AddServices.Add(add3.Content.ToString()); }
            if (add4.IsChecked.Value) { addInfo += $", {add4.Content}"; AddServices.Add(add4.Content.ToString()); }
            if (add5.IsChecked.Value) { addInfo += $", {add5.Content}"; AddServices.Add(add5.Content.ToString()); }
            if (add6.IsChecked.Value) { addInfo += $", {add6.Content}"; AddServices.Add(add6.Content.ToString()); }
            if (add7.IsChecked.Value) { addInfo += $", {add7.Content}"; AddServices.Add(add7.Content.ToString()); }
            if (add8.IsChecked.Value) { addInfo += $", {add8.Content}"; AddServices.Add(add8.Content.ToString()); }
            AddInfo.Text = addInfo;

            double priceT = GetPrice();
            Price.Text = priceT.ToString() + " руб.";
            price = priceT;
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

        private void WeightBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;
        }

        private void VolumeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void WidthBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void LengthBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void HeightBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains(',')) e.Handled = true;

        }

        private void AddresseeHouseBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains('/')) e.Handled = true;

        }

        private void AddresseeApartmentBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains('/')) e.Handled = true;

        }

        private void HouseBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains('/')) e.Handled = true;

        }

        private void ApartmentBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.Contains('/')) e.Handled = true;

        }

        

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VolumeBox.Text = (double.Parse(WidthBox.Text) * double.Parse(LengthBox.Text) * double.Parse(HeightBox.Text)).ToString();
            }
            catch { }
        }

        private void StreetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StreetBox.ToolTip = null;
            StreetBox.Background = Brushes.Transparent;
        }

        private void HouseBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HouseBox.ToolTip = null;
            HouseBox.Background = Brushes.Transparent;
        }

        private void ApartmentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApartmentBox.ToolTip = null;
            ApartmentBox.Background = Brushes.Transparent;
        }

        private void PhonenumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhonenumberBox.ToolTip = null;
            PhonenumberBox.Background = Brushes.Transparent;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker.ToolTip = null;
            DatePicker.Background = Brushes.Transparent;
            DatePicker2.DisplayDateStart = DatePicker.SelectedDate;
        }

        private void TimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            TimePicker.ToolTip = null;
            TimePicker.Background = Brushes.Transparent;
        }

        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WeightBox.ToolTip = null;
            WeightBox.Background = Brushes.Transparent;
        }

        private void VolumeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VolumeBox.ToolTip = null;
            VolumeBox.Background = Brushes.Transparent;
        }

        private void WidthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WidthBox.ToolTip = null;
            WidthBox.Background = Brushes.Transparent;
        }

        private void LengthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LengthBox.ToolTip = null;
            LengthBox.Background = Brushes.Transparent;
        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HeightBox.ToolTip = null;
            HeightBox.Background = Brushes.Transparent;
        }

        private void AddresseeStreetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeStreetBox.ToolTip = null;
            AddresseeStreetBox.Background = Brushes.Transparent;
        }

        private void AddresseeHouseBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeHouseBox.ToolTip = null;
            AddresseeHouseBox.Background = Brushes.Transparent;
        }

        private void AddresseeApartmentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeApartmentBox.ToolTip = null;
            AddresseeApartmentBox.Background = Brushes.Transparent;
        }

        private void AddresseeNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeNameBox.ToolTip = null;
            AddresseeNameBox.Background = Brushes.Transparent;
        }

        private void AddresseeLastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseeLastNameBox.ToolTip = null;
            AddresseeLastNameBox.Background = Brushes.Transparent;
        }

        private void AddresseePhonenumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddresseePhonenumberBox.ToolTip = null;
            AddresseePhonenumberBox.Background = Brushes.Transparent;
        }

        private void DatePicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker2.ToolTip = null;
            DatePicker2.Background = Brushes.Transparent;
        }

        private void TimePicker2_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            TimePicker2.ToolTip = null;
            TimePicker2.Background = Brushes.Transparent;
        }
        private void CheckOver_Click(object sender, RoutedEventArgs e)
        {
            NextThird_Click(sender, e);
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabControl.SelectedIndex == 1)
            {
                NextFirst_Click(sender, e);
            }
            if (TabControl.SelectedIndex == 2)
            {
                NextSecond_Click(sender, e);
            }
            if (TabControl.SelectedIndex == 3)
            {
                NextThird_Click(sender, e);
            }
        }

        private void PrevFourth_Click(object sender, RoutedEventArgs e)
        {
            TabControl.SelectedIndex = 2;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;

            await Task.Run(() => PushData());

            mainWindow.GridMain.Children.Clear();
            mainWindow.GridMain.Children.Add(new HomeControl(CurrentClient, mainWindow));
        }
        private void PushData()
        {
            try
            {
                string timeStamp = DateTime.Now.ToString();
                Order order = new Order(CurrentClient.id, senderAddress, senderPhonenumber, 
                    senderDate, senderTime, deliveryAddress, 
                    addresseeName, addresseePhonenumber, deliveryDate, 
                    deliveryTime, timeStamp, "requested",
                    weight, volume, width, length, height, price, AddServices);
                using (db)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }

                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "Заявка успешно подана.", "Ожидайте когда с вами свяжется менеджер для уточнения деталей.", true);
                    myMessageBox.ShowDialog();
                });
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    myMessageBox.ShowDialog();
                });
            }
            //MessageBox.Show("Вы успешно зарегистрированы!");
        }
    }
}
