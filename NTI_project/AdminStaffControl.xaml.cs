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
    /// Логика взаимодействия для AdminStaffControl.xaml
    /// </summary>
    public partial class AdminStaffControl : UserControl
    {
        AdminMainWindow adminMainWindow;
        AppContext db;
        int ID;
        public AdminStaffControl(AdminMainWindow admin)
        {
            InitializeComponent();
            db = new AppContext();
            this.adminMainWindow = admin;
            FillStaffGrid();
            comeBackButton.Visibility = Visibility.Collapsed;
        }
        public ObservableCollection<GridItemStaff> Items { get; set; } = new ObservableCollection<GridItemStaff>();
        public ObservableCollection<GridItemStaffOrder> OrderItems { get; set; } = new ObservableCollection<GridItemStaffOrder>();

        private async void FillStaffGrid()
        {
            loadborder.Visibility = Visibility.Visible;

            Items.Clear();

            List<Manager> managers = null;
            List<Courier> couriers = null;
            List<Storeman> storemen = null;

            await Task.Run(() => managers = GetManagers());

            await Task.Run(() => couriers = GetCouriers());
            
            await Task.Run(() => storemen = GetStoremen());

            foreach (Manager manager in managers)
            {
                Items.Add(new GridItemStaff
                {
                    ID = manager.id,
                    LastName = manager.Lastname,
                    Name = manager.Name,
                    Position = "Менеджер",
                    PhoneNumber = manager.Phonenumber,
                    Email = manager.Email
                });
            }
            foreach (Courier courier in couriers)
            {
                Items.Add(new GridItemStaff
                {
                    ID = courier.id,
                    LastName = courier.Lastname,
                    Name = courier.Name,
                    Position = "Курьер",
                    PhoneNumber = courier.Phonenumber
                });
            }
            foreach (Storeman storeman in storemen)
            {
                Items.Add(new GridItemStaff
                {
                    ID = storeman.id,
                    LastName = storeman.Lastname,
                    Name = storeman.Name,
                    Position = "Работник склада",
                    PhoneNumber = storeman.Phonenumber
                });
            }

            StaffGrid.ItemsSource = Items;

            loadborder.Visibility = Visibility.Hidden;
        }
        private List<Manager> GetManagers()
        {
            List<Manager> managers = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    managers = db.Managers.ToList();
                }
                return managers;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return managers;
            }
        }
        private List<Courier> GetCouriers()
        {
            List<Courier> couriers = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    couriers = db.Couriers.ToList();
                }
                return couriers;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return couriers;
            }
        }
        private List<Storeman> GetStoremen()
        {
            List<Storeman> storemen = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    storemen = db.Storemen.ToList();
                }
                return storemen;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return storemen;
            }
        }
        private void FillOrderGrid()
        {

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
            mainText.Text = "Сотрудники";
            FillStaffGrid();
            CurrentOrderPanel.Visibility = Visibility.Collapsed;
            NewStaff.Visibility = Visibility.Collapsed;
            GridPanel.Visibility = Visibility.Visible;
            comeBackButton.Visibility = Visibility.Collapsed;
            Email.Text = "...";
        }
        private void StaffGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (StaffGrid.SelectedIndex != -1)
            {
                int curId = (StaffGrid.SelectedItem as GridItemStaff).ID;
                string position = (StaffGrid.SelectedItem as GridItemStaff).Position;
                ID = curId;

                FillStaff(curId, position);

                if (position == "Менеджер")
                {
                    mainText.Text = $"Менеджер №{curId}";
                }
                else if (position == "Курьер")
                {
                    mainText.Text = $"Курьер №{curId}";
                }
                else if (position == "Работник склада")
                {
                    mainText.Text = $"Работник склада №{curId}";
                }

                GridPanel.Visibility = Visibility.Collapsed;
                NewStaff.Visibility = Visibility.Collapsed;
                CurrentOrderPanel.Visibility = Visibility.Visible;
                comeBackButton.Visibility = Visibility.Visible;
            }
        }
        private async void FillStaff(int id, string position)
        {
            loadborder.Visibility = Visibility.Visible;

            if (position == "Менеджер")
            {
                List<Manager> managers = null;
                await Task.Run(() => managers = GetManagers());
                Manager manager = managers.Where(m => m.id == id).FirstOrDefault();
                LastName.Text = manager.Lastname;
                Name.Text = manager.Name;
                Position.Text = "Менеджер";
                PhoneNumber.Text = manager.Phonenumber;
                Email.Text = manager.Email;
                FillOrdersManager(manager);
            }
            else if (position == "Курьер")
            {
                List<Courier> couriers = null;
                await Task.Run(() => couriers = GetCouriers());
                Courier courier = couriers.Where(c => c.id == id).FirstOrDefault();
                LastName.Text = courier.Lastname;
                Name.Text = courier.Name;
                Position.Text = "Курьер";
                PhoneNumber.Text = courier.Phonenumber;
                FillOrdersCourier(courier);
            }
            else if (position == "Работник склада")
            {
                List<Storeman> storemen = null;
                await Task.Run(() => storemen = GetStoremen());
                Storeman storeman = storemen.Where(s => s.id == id).FirstOrDefault();
                LastName.Text = storeman.Lastname;
                Name.Text = storeman.Name;
                Position.Text = "Работник склада";
                PhoneNumber.Text = storeman.Phonenumber;
                FillOrdersStoreman(storeman);
            }

            loadborder.Visibility = Visibility.Collapsed;
        }
        private void FillOrdersManager(Manager manager)
        {
            OrderItems.Clear();
            
            foreach (int id in manager.Orders)
            {
                db = new AppContext();
                string status = "";
                string st = "";
                using (db)
                {
                    st = db.Orders.Where(order => order.id == id).First().Status;
                }
                if (st == "requested")
                {
                    status = "Заявка подана";
                }
                else if (st == "processing")
                {
                    status = "Принят менеджером на обработку";
                }
                else if (st == "accepted")
                {
                    status = "Подтвержден менеджером";
                }
                else if (st == "paid")
                {
                    status = "Отправлен на выполнение";
                }
                else if (st == "pickup")
                {
                    status = "Курьер отправлен забирать заказ";
                }
                else if (st == "storage")
                {
                    status = "Доставлен на склад";
                }
                else if (st == "packaging")
                {
                    status = "Комплектуется";
                }
                else if (st == "packaged")
                {
                    status = "Укомплектован";
                }
                else if (st == "delivery")
                {
                    status = "Доставляется";
                }
                else if (st == "delivered")
                {
                    status = "Доставлен";
                }
                else if (st == "cancelled")
                {
                    status = "Отменен";
                }
                OrderItems.Add(new GridItemStaffOrder
                {
                    OrderNum = id,
                    Operation = "Обслуживание",
                    Status = status
                });
            }

            WorkerOrdersGrid.ItemsSource = OrderItems;

        }
        private void FillOrdersCourier(Courier courier)
        {
            OrderItems.Clear();

            foreach (string str in courier.Orders)
            {
                int id = int.Parse(str.Split('|')[0]);
                db = new AppContext();
                string status = "";
                string st = "";
                using (db)
                {
                    st = db.Orders.Where(order => order.id == id).First().Status;
                }
                string op = "";
                if (st == "requested")
                {
                    status = "Заявка подана";
                }
                else if (st == "processing")
                {
                    status = "Принят менеджером на обработку";
                }
                else if (st == "accepted")
                {
                    status = "Подтвержден менеджером";
                }
                else if (st == "paid")
                {
                    status = "Отправлен на выполнение";
                }
                else if (st == "pickup")
                {
                    status = "Курьер отправлен забирать заказ";
                }
                else if (st == "storage")
                {
                    status = "Доставлен на склад";
                }
                else if (st == "packaging")
                {
                    status = "Комплектуется";
                }
                else if (st == "packaged")
                {
                    status = "Укомплектован";
                }
                else if (st == "delivery")
                {
                    status = "Доставляется";
                }
                else if (st == "delivered")
                {
                    status = "Доставлен";
                }
                else if (st == "cancelled")
                {
                    status = "Отменен";
                }
                if (str.Split('|')[1] == "pickup")
                {
                    op = "Забор";
                }
                else
                {
                    op = "Доставка";
                }
                OrderItems.Add(new GridItemStaffOrder
                {
                    OrderNum = id,
                    Operation = op,
                    Status = status
                });
            }

            WorkerOrdersGrid.ItemsSource = OrderItems;

        }
        private void FillOrdersStoreman(Storeman storeman)
        {
            OrderItems.Clear();


            foreach (int id in storeman.Orders)
            {
                db = new AppContext();
                string st = "";
                string status = "";
                using (db)
                {
                    st = db.Orders.Where(order => order.id == id).First().Status;
                }
                if (st == "requested")
                {
                    status = "Заявка подана";
                }
                else if (st == "processing")
                {
                    status = "Принят менеджером на обработку";
                }
                else if (st == "accepted")
                {
                    status = "Подтвержден менеджером";
                }
                else if (st == "paid")
                {
                    status = "Отправлен на выполнение";
                }
                else if (st == "pickup")
                {
                    status = "Курьер отправлен забирать заказ";
                }
                else if (st == "storage")
                {
                    status = "Доставлен на склад";
                }
                else if (st == "packaging")
                {
                    status = "Комплектуется";
                }
                else if (st == "packaged")
                {
                    status = "Укомплектован";
                }
                else if (st == "delivery")
                {
                    status = "Доставляется";
                }
                else if (st == "delivered")
                {
                    status = "Доставлен";
                }
                else if (st == "cancelled")
                {
                    status = "Отменен";
                }
                OrderItems.Add(new GridItemStaffOrder
                {
                    OrderNum = id,
                    Operation = "Укомплектация",
                    Status = status
                });
            }

            WorkerOrdersGrid.ItemsSource = OrderItems;

        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            GridPanel.Visibility = Visibility.Collapsed;
            NewStaff.Visibility = Visibility.Visible;
            comeBackButton.Visibility = Visibility.Visible;
        }


        string username_t;
        string pass_t;
        string email_t;
        string name_t;
        string lastname_t;
        string phoneNumber_t;
        string position_t;


        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string pass = PasswordBox.Password.Trim();
            string name = NameBox.Text.Trim();
            string lastname = LastNameBox.Text.Trim();
            string pass_2 = ConPasswordBox.Password.Trim();

            string email = "";
            if (EmailBox.Visibility == Visibility.Visible)
            {
                email = EmailBox.Text.Trim();
            }

            string phoneNumber = PhonenumberBox.Text;

            string position = "";
            if(PositionBox.Text == "Менеджер")
            {
                position = "Менеджер";
            }
            if (PositionBox.Text == "Курьер")
            {
                position = "Курьер";
            }
            if (PositionBox.Text == "Работник склада")
            {
                position = "Работник склада";
            }

            bool fl = true;
            if (name.Length < 1)
            {
                NameBox.ToolTip = "Это поле должно быть заполнено!";
                NameBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (lastname.Length < 1)
            {
                LastNameBox.ToolTip = "Это поле должно быть заполнено!";
                LastNameBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (username.Length < 5)
            {
                UsernameBox.ToolTip = "Логин должен состоять из не менее 5 символов!";
                UsernameBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (pass.Length < 5)
            {
                PasswordBox.ToolTip = "Пароль должен состоять из не менее 5 символов!";
                PasswordBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (pass != pass_2 || pass_2 == "")
            {
                ConPasswordBox.ToolTip = "Это поле введено не корректно!";
                ConPasswordBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (EmailBox.Visibility == Visibility.Visible)
            {
                if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
                {
                    EmailBox.ToolTip = "Это поле введено не корректно!";
                    EmailBox.Background = Brushes.DarkRed;
                    fl = false;
                }
            }
            if (PhonenumberBox.Text.Contains("_"))
            {
                PhonenumberBox.ToolTip = "Введите полный номер телефона";
                PhonenumberBox.Background = Brushes.DarkRed;
                fl = false;
            }
            if (fl)
            {
                NameBox.ToolTip = null;
                NameBox.Background = Brushes.Transparent;
                LastNameBox.ToolTip = null;
                LastNameBox.Background = Brushes.Transparent;
                UsernameBox.ToolTip = null;
                UsernameBox.Background = Brushes.Transparent;
                PasswordBox.ToolTip = null;
                PasswordBox.Background = Brushes.Transparent;
                ConPasswordBox.ToolTip = null;
                ConPasswordBox.Background = Brushes.Transparent;
                EmailBox.ToolTip = null;
                EmailBox.Background = Brushes.Transparent;
                PhonenumberBox.ToolTip = null;
                PhonenumberBox.Background = Brushes.Transparent;

                position_t = position;
                username_t = username;
                pass_t = pass;
                email_t = email;
                name_t = name;
                lastname_t = lastname;
                phoneNumber_t = phoneNumber;

                loadborder.Visibility = Visibility.Visible;

                bool result = false;

                await Task.Run(() => result = Register());

                if (result)
                {
                    NewStaff.Visibility = Visibility.Collapsed;
                    GridPanel.Visibility = Visibility.Visible;
                    FillStaffGrid();
                }
                else
                {
                    loadborder.Visibility = Visibility.Hidden;
                }

            }
        }
        private bool Register()
        {
            try
            {
                if (position_t == "Менеджер")
                {
                    Manager manager = new Manager(name_t, lastname_t, username_t, pass_t, phoneNumber_t, email_t);
                    db = new AppContext();
                    using (db)
                    {
                        if(db.Managers.Where(m => m.Login == username_t).Any())
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Указанный логин занят.", true);
                                myMessageBox.ShowDialog();
                                UsernameBox.ToolTip = "Этот логин уже занят";
                                UsernameBox.Background = Brushes.DarkRed;
                                db = new AppContext();
                            });
                            return false;
                        }
                        else
                        {
                            db.Managers.Add(manager);
                            db.SaveChanges();
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Вы успешно зарегистрировали сотрудника!", true);
                                myMessageBox.ShowDialog();
                            });
                            return true;
                        }
                    }
                }
                else if (position_t == "Курьер")
                {
                    Courier courier = new Courier(name_t, lastname_t, username_t, pass_t, phoneNumber_t);
                    db = new AppContext();
                    using (db)
                    {
                        if (db.Couriers.Where(c => c.Login == username_t).Any())
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Указанный логин занят.", true);
                                myMessageBox.ShowDialog();
                                UsernameBox.ToolTip = "Этот логин уже занят";
                                UsernameBox.Background = Brushes.DarkRed;
                                db = new AppContext();
                            });
                            return false;
                        }
                        else
                        {
                            db.Couriers.Add(courier);
                            db.SaveChanges();
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Вы успешно зарегистрировали сотрудника!", true);
                                myMessageBox.ShowDialog();
                            });
                            return true;
                        }
                    }
                }
                else if (position_t == "Работник склада")
                {
                    Storeman storeman = new Storeman(name_t, lastname_t, username_t, pass_t, phoneNumber_t);
                    db = new AppContext();
                    using (db)
                    {
                        if (db.Storemen.Where(s => s.Login == username_t).Any())
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Указанный логин занят.", true);
                                myMessageBox.ShowDialog();
                                UsernameBox.ToolTip = "Этот логин уже занят";
                                UsernameBox.Background = Brushes.DarkRed;
                                db = new AppContext();
                            });
                            return false;
                        }
                        else
                        {
                            db.Storemen.Add(storeman);
                            db.SaveChanges();
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "", "Вы успешно зарегистрировали сотрудника!", true);
                                myMessageBox.ShowDialog();
                            });
                            return true;
                        }
                    }
                }
                else
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных!", "Перезагрузите программу!", true);
                        myMessageBox.ShowDialog();
                        db = new AppContext();
                    });
                    return false;
                }
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox myMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных!", "Перезагрузите программу!", true);
                    myMessageBox.ShowDialog();
                    db = new AppContext();
                });
                return false;
            }
        }
        private void PhoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhonenumberBox.Background = Brushes.Transparent;
            PhonenumberBox.ToolTip = null;
        }
   
        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernameBox.Background = Brushes.Transparent;
            UsernameBox.ToolTip = null;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox.Background = Brushes.Transparent;
            PasswordBox.ToolTip = null;
        }

        private void ConPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ConPasswordBox.Background = Brushes.Transparent;
            ConPasswordBox.ToolTip = null;
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailBox.Background = Brushes.Transparent;
            EmailBox.ToolTip = null;
        }
        

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameBox.Background = Brushes.Transparent;
            NameBox.ToolTip = null;
        }

        private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastNameBox.Background = Brushes.Transparent;
            LastNameBox.ToolTip = null;
        }

        private void PositionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PositionBox.SelectedItem == managerItem)
                {
                    EmailBox.Visibility = Visibility.Visible;
                }
                else
                {
                    EmailBox.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {

            }
        }
    }
    public class GridItemStaff
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class GridItemStaffOrder
    {
        public int OrderNum { get; set; }
        public string Operation { get; set; }
        public string Status { get; set; }
    }
}
