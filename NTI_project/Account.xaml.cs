using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : UserControl
    {
        AppContext db;

        string POSITION;
        int ID;
        public Account(string position, int id)
        {
            InitializeComponent();

            db = new AppContext();

            this.POSITION = position;
            this.ID = id;

            if (position == "client")
            {
                FillClient(id);
                icon.Kind = PackIconKind.User;
            }
            if (position == "manager")
            {
                FillManager(id);
                icon.Kind = PackIconKind.UserBadge;
            }
            if (position == "courier")
            {
                FillCourier(id);
                icon.Kind = PackIconKind.Truck;
            }
            if (position == "storeman")
            {
                FillStoreman(id);
                icon.Kind = PackIconKind.Warehouse;
            }
            if (position == "admin")
            {
                FillAdmin(id);
                icon.Kind = PackIconKind.ComputerClassic;
            }
        }
        private async void FillClient(int id)
        {
            loadborder.Visibility = Visibility.Visible;

            Client client = null;

            await Task.Run(() => client = GetClient(id));

            Position.Text = "Клиент";
            Name.Text = client.Name + " " + client.Lastname;
            Login.Text = client.Username;

            EmailPanel.Visibility = Visibility.Visible;
            Email.Text = client.Email;

            loadborder.Visibility = Visibility.Collapsed;
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
        private async void FillManager(int id)
        {
            loadborder.Visibility = Visibility.Visible;

            Manager manager = null;

            await Task.Run(() => manager = GetManager(id));

            Position.Text = "Менеджер";
            Name.Text = manager.Name + " " + manager.Lastname;
            Login.Text = manager.Login;

            EmailPanel.Visibility = Visibility.Visible;
            Email.Text = manager.Email;

            NumberPanel.Visibility = Visibility.Visible;
            Number.Text = manager.Phonenumber;

            loadborder.Visibility = Visibility.Collapsed;
        }
        private Manager GetManager(int id)
        {
            Manager manager = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    manager = db.Managers.Where(m => m.id == id).FirstOrDefault();
                }
                return manager;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return manager;
            }
        }
        private async void FillCourier(int id)
        {
            loadborder.Visibility = Visibility.Visible;

            Courier courier = null;

            await Task.Run(() => courier = GetCourier(id));

            Position.Text = "Курьер";
            Name.Text = courier.Name + " " + courier.Lastname;
            Login.Text = courier.Login;
            
            NumberPanel.Visibility = Visibility.Visible;
            Number.Text = courier.Phonenumber;

            loadborder.Visibility = Visibility.Collapsed;
        }
        private Courier GetCourier(int id)
        {
            Courier courier = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    courier = db.Couriers.Where(c => c.id == id).FirstOrDefault();
                }
                return courier;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return courier;
            }
        }
        private async void FillStoreman(int id)
        {
            loadborder.Visibility = Visibility.Visible;

            Storeman storeman = null;

            await Task.Run(() => storeman = GetStoreman(id));

            Position.Text = "Работник склада";
            Name.Text = storeman.Name + " " + storeman.Lastname;
            Login.Text = storeman.Login;

            NumberPanel.Visibility = Visibility.Visible;
            Number.Text = storeman.Phonenumber;

            loadborder.Visibility = Visibility.Collapsed;
        }
        private Storeman GetStoreman(int id)
        {
            Storeman storeman = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    storeman = db.Storemen.Where(s => s.id == id).FirstOrDefault();
                }
                return storeman;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return storeman;
            }
        }
        private async void FillAdmin(int id)
        {
            loadborder.Visibility = Visibility.Visible;

            Admin admin = null;

            await Task.Run(() => admin = GetAdmin(id));

            Position.Text = "Администратор";
            Name.Text = "Admin";
            Login.Text = admin.Login;
            NamePanel.Visibility = Visibility.Collapsed;

            loadborder.Visibility = Visibility.Collapsed;
        }
        private Admin GetAdmin(int id)
        {
            Admin admin = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    admin = db.Admins.Where(a => a.id == id).FirstOrDefault();
                }
                return admin;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return admin;
            }
        }

        private void ChangeLoginButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeLoginGrid.Visibility = Visibility.Visible;
        }

        private async void ApplyChangeLogin_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;

            if (NewLogin.Text.Length < 5)
            {
                NewLogin.Background = Brushes.DarkRed;
                NewLogin.ToolTip = "Логин должен содержать от 5 знаков.";
            }
            else 
            {
                string newLogin = NewLogin.Text;
                if(POSITION == "client")
                {
                    List<Client> clients = null;
                    await Task.Run(() => clients = GetClients());
                    if(clients.Where(cl => cl.Username == newLogin).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Данный логин уже занят.", true);
                            ctrlMessageBox.ShowDialog();
                            NewLogin.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushClientLogin(newLogin));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Логин успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillClient(ID);
                        ChangeLoginGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "manager")
                {
                    List<Manager> managers = null;
                    await Task.Run(() => managers = GetManagers());
                    if (managers.Where(cl => cl.Login == newLogin).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Данный логин уже занят.", true);
                            ctrlMessageBox.ShowDialog();
                            NewLogin.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushManagerLogin(newLogin));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Логин успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillManager(ID);
                        ChangeLoginGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "courier")
                {
                    List<Courier> couriers = null;
                    await Task.Run(() => couriers = GetCouriers());
                    if (couriers.Where(cl => cl.Login == newLogin).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Данный логин уже занят.", true);
                            ctrlMessageBox.ShowDialog();
                            NewLogin.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushCourierLogin(newLogin));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Логин успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillCourier(ID);
                        ChangeLoginGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "storeman")
                {
                    List<Storeman> storemen = null;
                    await Task.Run(() => storemen = GetStoremen());
                    if (storemen.Where(cl => cl.Login == newLogin).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Данный логин уже занят.", true);
                            ctrlMessageBox.ShowDialog();
                            NewLogin.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushStoremanLogin(newLogin));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Логин успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillStoreman(ID);
                        ChangeLoginGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "admin")
                {
                    List<Admin> admins = null;
                    await Task.Run(() => admins = GetAdmins());
                    if (admins.Where(cl => cl.Login == newLogin).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Данный логин уже занят.", true);
                            ctrlMessageBox.ShowDialog();
                            NewLogin.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushAdminLogin(newLogin));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Логин успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillAdmin(ID);
                        ChangeLoginGrid.Visibility = Visibility.Collapsed;
                    }
                }
            }
            loadborder.Visibility = Visibility.Collapsed;
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
        private void PushClientLogin(string login)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Clients.Where(cl => cl.id == ID).FirstOrDefault().Username = login;
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
        private List<Manager> GetManagers()
        {
            List<Manager> managers = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    managers = db.Managers.ToList<Manager>();
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
        private void PushManagerLogin(string login)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Managers.Where(m => m.id == ID).FirstOrDefault().Login = login;
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
        private List<Courier> GetCouriers()
        {
            List<Courier> couriers = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    couriers = db.Couriers.ToList<Courier>();
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
        private void PushCourierLogin(string login)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Couriers.Where(m => m.id == ID).FirstOrDefault().Login = login;
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
        private List<Storeman> GetStoremen()
        {
            List<Storeman> storemen = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    storemen = db.Storemen.ToList<Storeman>();
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
        private void PushStoremanLogin(string login)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Storemen.Where(m => m.id == ID).FirstOrDefault().Login = login;
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
        private List<Admin> GetAdmins()
        {
            List<Admin> admins = null;
            try
            {
                db = new AppContext();
                using (db)
                {
                    admins = db.Admins.ToList<Admin>();
                }
                return admins;
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "Ошибка подключения к базе данных.", "Перезагрузите программу.", true);
                    ctrlMessageBox.ShowDialog();
                });
                return admins;
            }
        }
        private void PushAdminLogin(string login)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Admins.Where(m => m.id == ID).FirstOrDefault().Login = login;
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

        private void NewLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewLogin.Background = Brushes.Transparent;
            NewLogin.ToolTip = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangePassGrid.Visibility = Visibility.Visible;
        }

        private void OldPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            OldPass.Background = Brushes.Transparent;
            OldPass.ToolTip = null;
        }

        private void NewPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewPass.Background = Brushes.Transparent;
            NewPass.ToolTip = null;
        }

        private async void ApplyChangePass_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;
            bool fl = true;
            if (NewPass.Text.Length < 5)
            {
                NewPass.Background = Brushes.DarkRed;
                NewPass.ToolTip = "Пароль должен содержать от 5 знаков.";
                fl = false;
            }
            if(OldPass.Text == NewPass.Text)
            {
                NewPass.Background = Brushes.DarkRed;
                NewPass.ToolTip = "Вы ввели одинаковые пароли";
                fl = false;
            }
            if(fl)
            {
                string newPass = NewPass.Text;
                if (POSITION == "client")
                {
                    Client client = null;
                    await Task.Run(() => client = GetClient(ID));
                    if (client.Password != OldPass.Text)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Вы ввели неверный старый пароль!", true);
                            ctrlMessageBox.ShowDialog();
                            OldPass.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushClientPassword(newPass));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Пароль успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillClient(ID);
                        ChangePassGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "manager")
                {
                    Manager manager = null;
                    await Task.Run(() => manager = GetManager(ID));
                    if (manager.Password != OldPass.Text)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Вы ввели неверный старый пароль!", true);
                            ctrlMessageBox.ShowDialog();
                            OldPass.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushManagerPassword(newPass));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Пароль успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillManager(ID);
                        ChangePassGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "courier")
                {
                    Courier courier = null;
                    await Task.Run(() => courier = GetCourier(ID));
                    if (courier.Password != OldPass.Text)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Вы ввели неверный старый пароль!", true);
                            ctrlMessageBox.ShowDialog();
                            OldPass.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushCourierPassword(newPass));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Пароль успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillCourier(ID);
                        ChangePassGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "storeman")
                {
                    Storeman storeman = null;
                    await Task.Run(() => storeman = GetStoreman(ID));
                    if (storeman.Password != OldPass.Text)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Вы ввели неверный старый пароль!", true);
                            ctrlMessageBox.ShowDialog();
                            OldPass.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushStoremanPassword(newPass));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Пароль успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillStoreman(ID);
                        ChangePassGrid.Visibility = Visibility.Collapsed;
                    }
                }
                if (POSITION == "admin")
                {
                    Admin admin = null;
                    await Task.Run(() => admin = GetAdmin(ID));
                    if (admin.Password != OldPass.Text)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Вы ввели неверный старый пароль!", true);
                            ctrlMessageBox.ShowDialog();
                            OldPass.Background = Brushes.DarkRed;
                        });
                    }
                    else
                    {
                        await Task.Run(() => PushAdminPassword(newPass));

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Пароль успешно изменен!", true);
                            ctrlMessageBox.ShowDialog();
                        });
                        FillAdmin(ID);
                        ChangePassGrid.Visibility = Visibility.Collapsed;
                    }
                }
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private void PushClientPassword(string pass)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Clients.Where(cl => cl.id == ID).FirstOrDefault().Password = pass;
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
        private void PushManagerPassword(string pass)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Managers.Where(m => m.id == ID).FirstOrDefault().Password = pass;
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
        private void PushCourierPassword(string pass)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Couriers.Where(c => c.id == ID).FirstOrDefault().Password = pass;
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
        private void PushStoremanPassword(string pass)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Storemen.Where(s => s.id == ID).FirstOrDefault().Password = pass;
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
        private void PushAdminPassword(string pass)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Admins.Where(a => a.id == ID).FirstOrDefault().Password = pass;
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

        private void ChangeNumberButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumberGrid.Visibility = Visibility.Visible;
        }

        private async void ApplyChangeNumber_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;

            bool fl = true;
            if (NewNumber.Text == Number.Text)
            {
                NewNumber.Background = Brushes.DarkRed;
                NewNumber.ToolTip = "Вы ввели старый номер телефона";
                fl = false;
            }
            if (NewNumber.Text.Contains("_"))
            {
                NewNumber.Background = Brushes.DarkRed;
                NewNumber.ToolTip = "Введите полный номер телефона";
                fl = false;
            }
            if(fl)
            {
                string newNumber = NewNumber.Text;
                if (POSITION == "manager")
                {
                    await Task.Run(() => PushManagerNumber(newNumber));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Номер успешно изменен!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillManager(ID);
                    ChangeNumberGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "courier")
                {
                    await Task.Run(() => PushCourierNumber(newNumber));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Номер успешно изменен!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillCourier(ID);
                    ChangeNumberGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "storeman")
                {
                    await Task.Run(() => PushStoremanNumber(newNumber));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Номер успешно изменен!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillStoreman(ID);
                    ChangeNumberGrid.Visibility = Visibility.Collapsed;
                }
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private void PushManagerNumber(string number)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Managers.Where(m => m.id == ID).FirstOrDefault().Phonenumber = number;
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
        private void PushCourierNumber(string number)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Couriers.Where(c => c.id == ID).FirstOrDefault().Phonenumber = number;
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
        private void PushStoremanNumber(string number)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Storemen.Where(s => s.id == ID).FirstOrDefault().Phonenumber = number;
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

        private void ChangeEmailButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeEmailGrid.Visibility = Visibility.Visible;
        }

        private async void ApplyChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;

            bool fl = true;
            if (NewEmail.Text == Email.Text)
            {
                NewEmail.Background = Brushes.DarkRed;
                NewEmail.ToolTip = "Вы ввели старую почту";
                fl = false;
            }
            if (NewEmail.Text.Length < 5 || !NewEmail.Text.Contains("@") || !NewEmail.Text.Contains("."))
            {
                NewEmail.Background = Brushes.DarkRed;
                NewEmail.ToolTip = "Неверный формат введенных данных!";
                fl = false;
            }
            if (fl)
            {
                string newEmail = NewEmail.Text;
                if (POSITION == "client")
                {
                    await Task.Run(() => PushClientEmail(newEmail));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Электронная почта успешно изменена!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillClient(ID);
                    ChangeEmailGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "manager")
                {
                    await Task.Run(() => PushManagerEmail(newEmail));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Электронная почта успешно изменена!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillManager(ID);
                    ChangeEmailGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "admin")
                {
                    await Task.Run(() => PushAdminEmail(newEmail));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Электронная почта успешно изменена!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillAdmin(ID);
                    ChangeEmailGrid.Visibility = Visibility.Collapsed;
                }
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private void PushClientEmail(string email)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Clients.Where(m => m.id == ID).FirstOrDefault().Email = email;
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
        private void PushManagerEmail(string email)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Managers.Where(c => c.id == ID).FirstOrDefault().Email = email;
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
        private void PushAdminEmail(string email)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Admins.Where(s => s.id == ID).FirstOrDefault().Email = email;
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
        private void NewEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewEmail.Background = Brushes.Transparent;
            NewEmail.ToolTip = null;
        }

        private void NewNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewNumber.Background = Brushes.Transparent;
            NewNumber.ToolTip = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeNameGrid.Visibility = Visibility.Visible;
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameBox.ToolTip = null;
            NameBox.Background = Brushes.Transparent;
        }

        private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastNameBox.ToolTip = null;
            LastNameBox.Background = Brushes.Transparent;
        }

        private async void ApplyChangeName_Click(object sender, RoutedEventArgs e)
        {
            loadborder.Visibility = Visibility.Visible;

            bool fl = true;
            if (NameBox.Text.Length < 1)
            {
                NameBox.Background = Brushes.DarkRed;
                NameBox.ToolTip = "Данные введены некорректно!";
                fl = false;
            }
            if (LastNameBox.Text.Length < 1)
            {
                LastNameBox.Background = Brushes.DarkRed;
                LastNameBox.ToolTip = "Данные введены некорректно!";
                fl = false;
            }
            if (fl)
            {
                string name = NameBox.Text;
                string lastname = LastNameBox.Text;
                if (POSITION == "client")
                {
                    await Task.Run(() => PushClientName(name, lastname));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Имя и фамилия успешно изменены!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillClient(ID);
                    ChangeNameGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "manager")
                {
                    await Task.Run(() => PushManagerName(name, lastname));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Имя и фамилия успешно изменены!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillManager(ID);
                    ChangeNameGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "courier")
                {
                    await Task.Run(() => PushCourierName(name, lastname));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Имя и фамилия успешно изменены!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillCourier(ID);
                    ChangeNameGrid.Visibility = Visibility.Collapsed;

                }
                if (POSITION == "storeman")
                {
                    await Task.Run(() => PushStoremanName(name, lastname));

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        CtrlMessageBox ctrlMessageBox = new CtrlMessageBox(this, "", "Имя и фамилия успешно изменены!", true);
                        ctrlMessageBox.ShowDialog();
                    });
                    FillStoreman(ID);
                    ChangeNameGrid.Visibility = Visibility.Collapsed;

                }
            }
            loadborder.Visibility = Visibility.Collapsed;
        }
        private void PushClientName(string name, string lastname)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Clients.Where(c => c.id == ID).FirstOrDefault().Name = name;
                    db.Clients.Where(c => c.id == ID).FirstOrDefault().Lastname = lastname;
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
        private void PushCourierName(string name, string lastname)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Couriers.Where(c => c.id == ID).FirstOrDefault().Name = name;
                    db.Couriers.Where(c => c.id == ID).FirstOrDefault().Lastname = lastname;
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
        private void PushManagerName(string name, string lastname)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Managers.Where(c => c.id == ID).FirstOrDefault().Name = name;
                    db.Managers.Where(c => c.id == ID).FirstOrDefault().Lastname = lastname;
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
        private void PushStoremanName(string name, string lastname)
        {
            try
            {
                db = new AppContext();
                using (db)
                {
                    db.Storemen.Where(c => c.id == ID).FirstOrDefault().Name = name;
                    db.Storemen.Where(c => c.id == ID).FirstOrDefault().Lastname = lastname;
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
}
