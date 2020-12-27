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
using System.Windows.Shapes;
using MaterialDesignThemes;
using MaterialDesignColors;
using System.Data.Entity;
using System.Windows.Threading;
using System.Threading;
using System.Drawing;
using System.Windows.Interop;
using Brushes = System.Windows.Media.Brushes;

namespace NTI_project
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        AppContext db;
        Style defStyle;
        Client CurrentClient;

        string username_t, pass_t, email_t, name_t, lastname_t, organization_t;
        bool isPhysical_t, isLegal_t;

        public RegistrationWindow()
        {
            InitializeComponent();
            defStyle = RegistrationButton.Style;
            db = new AppContext();
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationButton.Style == defStyle)
            {
                RegistrationButton.Style = LoginButton.Style;
                LoginButton.Style = defStyle;
                ConPasswordBox.Visibility = Visibility.Hidden;
                EmailBox.Visibility = Visibility.Hidden;
                RegisterAndLoginButton.Content = "Войти";
                PanelReg.Visibility = Visibility.Collapsed;
                PanelLogin.Visibility = Visibility.Visible;
            }
        }

        public void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationButton.Style != defStyle)
            {
                LoginButton.Style = RegistrationButton.Style;
                RegistrationButton.Style = defStyle;
                ConPasswordBox.Visibility = Visibility.Visible;
                EmailBox.Visibility = Visibility.Visible;
                RegisterAndLoginButton.Content = "Зарегистрироваться";
                PanelLogin.Visibility = Visibility.Collapsed;
                PanelReg.Visibility = Visibility.Visible;
            }
        }

        private async void RegisterAndLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string pass = PasswordBox.Password.Trim();
            
            if (RegistrationButton.Style == defStyle) 
            {
                string name = NameBox.Text.Trim();
                string lastname = LastNameBox.Text.Trim();
                bool isPhysical = false;
                bool isLegal = false;
                if (PhysicalButton.IsChecked.Value)
                {
                    isPhysical = true;
                }
                else
                {
                    isLegal = true;
                }
                string organization = Organization.Text.Trim();
                string pass_2 = ConPasswordBox.Password.Trim();
                string email = EmailBox.Text.Trim();

                if (name.Length < 1)
                {
                    NameBox.ToolTip = "Это поле должно быть заполнено!";
                    NameBox.Background = Brushes.DarkRed;
                }
                if (lastname.Length < 1)
                {
                    LastNameBox.ToolTip = "Это поле должно быть заполнено!";
                    LastNameBox.Background = Brushes.DarkRed;
                }
                if (username.Length < 5)
                {
                    UsernameBox.ToolTip = "Логин должен состоять из не менее 5 символов!";
                    UsernameBox.Background = Brushes.DarkRed;
                }
                if (pass.Length < 5)
                {
                    PasswordBox.ToolTip = "Пароль должен состоять из не менее 5 символов!";
                    PasswordBox.Background = Brushes.DarkRed;
                }
                if (pass != pass_2 || pass_2 == "")
                {
                    ConPasswordBox.ToolTip = "Это поле введено не корректно!";
                    ConPasswordBox.Background = Brushes.DarkRed;
                }
                if (Organization.IsEnabled && organization.Length < 2)
                {
                    Organization.ToolTip = "Поле введено не корректно";
                    Organization.Background = Brushes.DarkRed;
                }
                if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
                {
                    EmailBox.ToolTip = "Это поле введено не корректно!";
                    EmailBox.Background = Brushes.DarkRed;
                }
                else
                {
                    NameBox.ToolTip = null;
                    NameBox.Background = Brushes.Transparent;
                    LastNameBox.ToolTip = null;
                    LastNameBox.Background = Brushes.Transparent;
                    Organization.ToolTip = null;
                    Organization.Background = Brushes.Transparent;
                    UsernameBox.ToolTip = null;
                    UsernameBox.Background = Brushes.Transparent;
                    PasswordBox.ToolTip = null;
                    PasswordBox.Background = Brushes.Transparent;
                    ConPasswordBox.ToolTip = null;
                    ConPasswordBox.Background = Brushes.Transparent;
                    EmailBox.ToolTip = null;
                    EmailBox.Background = Brushes.Transparent;

                    username_t = username;
                    pass_t = pass;
                    email_t = email;
                    organization_t = organization;
                    isPhysical_t = isPhysical;
                    isLegal_t = isLegal;
                    name_t = name;
                    lastname_t = lastname;

                    loadborder.Visibility = Visibility.Visible;

                    bool result = false;

                    await Task.Run(() => result = Register());

                    if (result)
                    {
                        MainWindow mainWindow = new MainWindow(CurrentClient);
                        this.Close();
                        mainWindow.Show();
                    }
                    else
                    {
                        loadborder.Visibility = Visibility.Hidden;
                    }

                }
            }
            else if (RegistrationButton.Style != defStyle)
            {
                username = UsernameLoginBox.Text.Trim();
                pass = PasswordLoginBox.Password.Trim();

                if (username.Length < 5)
                {
                    UsernameLoginBox.ToolTip = "Логин должен состоять из не менее 5 символов!";
                    UsernameLoginBox.Background = Brushes.DarkRed;
                }
                if (pass.Length < 5)
                {
                    PasswordLoginBox.ToolTip = "Пароль должен состоять из не менее 5 символов!";
                    PasswordLoginBox.Background = Brushes.DarkRed;
                }
                else
                {
                    UsernameLoginBox.ToolTip = null;
                    UsernameLoginBox.Background = Brushes.Transparent;
                    PasswordLoginBox.ToolTip = null;
                    PasswordLoginBox.Background = Brushes.Transparent;

                    username_t = username;
                    pass_t = pass;

                    loadborder.Visibility = Visibility.Visible;

                    bool result = false;

                    await Task.Run(() => result = Login());

                    if (result)
                    {
                        MainWindow mainWindow = new MainWindow(CurrentClient);
                        this.Close();
                        mainWindow.Show();
                    }
                    else
                    {
                        loadborder.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private bool Register()
        {
            try
            {
                Client client = new Client(username_t, pass_t, email_t, isPhysical_t, isLegal_t, name_t, lastname_t);
                using (db)
                {
                    if (db.Clients.Where(cl => cl.Username == username_t).Any())
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            MyMessageBox myMessageBox = new MyMessageBox(this, "Указанный логин занят.", true);
                            myMessageBox.ShowDialog();
                            UsernameBox.ToolTip = "Этот логин уже занят";
                            UsernameBox.Background = Brushes.DarkRed;
                            db = new AppContext();
                        });
                        return false;
                    }
                    else
                    {
                        db.Clients.Add(client);
                        db.SaveChanges();
                        CurrentClient = client;

                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            MyMessageBox myMessageBox = new MyMessageBox(this, "Вы успешно зарегистрированы!", true);
                            myMessageBox.ShowDialog();
                        });
                        return true;
                    }
                }
            }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    MyMessageBox myMessageBox = new MyMessageBox(this, "Ошибка подключения к базе данных.", true);
                    myMessageBox.ShowDialog();
                    db = new AppContext();
                });
                return false;
            }
        }
        private bool Login()
        {
            try
            {
                Client authUser = null;
                using (db)
                {
                    authUser = db.Clients.Where(user => user.Username == username_t && user.Password == pass_t).FirstOrDefault();
                }
                if (authUser != null)
                {
                    CurrentClient = authUser;
                    return true;
                }
                else
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        MyMessageBox myMessageBox = new MyMessageBox(this, "Неверный логин или пароль!", true);
                        myMessageBox.ShowDialog();
                        db = new AppContext();
                    });

                    //MessageBox.Show("Неверный логин или пароль!");
                    return false;
                }
        }
            catch
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    MyMessageBox myMessageBox = new MyMessageBox(this, "Ошибка подключения к базе данных.", true);
                    myMessageBox.ShowDialog();
                    db = new AppContext();
                });
                return false;
            }
        }


        private void UsernameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                PasswordBox.Focus();
            }
            if (e.Key == Key.Up)
            {
                if (Organization.IsEnabled)
                {
                    Organization.Focus();
                }
                else
                {
                    LastNameBox.Focus();
                }
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) { UsernameBox.Focus(); }
            if (RegistrationButton.Style == defStyle)
            {
                if (e.Key == Key.Down) { ConPasswordBox.Focus(); }
            }

        }

        private void ConPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) { PasswordBox.Focus(); }
            if (RegistrationButton.Style == defStyle)
            {
                if (e.Key == Key.Down) { EmailBox.Focus(); }
            }
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) { ConPasswordBox.Focus(); }
            if (e.Key == Key.Down) { NameBox.Focus(); }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                RegisterAndLoginButton_Click(sender, e);
            }
        }
        private void minus_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            minus_Button.Background = Brushes.RoyalBlue;
        }

        private void recover_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            recover_Button.Background = Brushes.RoyalBlue;
        }

        private void close_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            close_Button.Background = Brushes.RoyalBlue;
            
        }

        private void close_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MyMessageBox myMessageBox = new MyMessageBox(this, "Вы уверены, что хотите закрыть приложение?", false);
            myMessageBox.ShowDialog();
        }

        private void recover_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;

        }

        private void minus_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Toolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal; 
                this.Top = 0;
            }
            this.DragMove();
        }

        private void minus_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            minus_Button.Background = Brushes.LightGray;
        }

        private void recover_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            recover_Button.Background = Brushes.LightGray;
        }

        private void close_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            close_Button.Background = Brushes.LightGray;
        }

        private void minus_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            minus_Button.Background = Brushes.Transparent;
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

        private void LegalButton_Click(object sender, RoutedEventArgs e)
        {
            Organization.IsEnabled = true;
        }

        private void PhysicalButton_Click(object sender, RoutedEventArgs e)
        {
            Organization.Text = null;
            Organization.IsEnabled = false;
        }

        private void NameBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                LastNameBox.Focus();
            }
            if (e.Key == Key.Up)
            {
                EmailBox.Focus();
            }
        }

        private void LastNameBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Organization.IsEnabled)
            {
                if (e.Key == Key.Down)
                {
                    Organization.Focus();
                }
                if (e.Key == Key.Up)
                {
                    NameBox.Focus();
                }
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    UsernameBox.Focus();
                }
                if (e.Key == Key.Up)
                {
                    NameBox.Focus();
                }
            }
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

        private void Organization_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                UsernameBox.Focus();
            }
            if (e.Key == Key.Up)
            {
                LastNameBox.Focus();
            }
        }

        private void Organization_TextChanged(object sender, TextChangedEventArgs e)
        {
            Organization.Background = Brushes.Transparent;
            Organization.ToolTip = null;
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
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void UsernameLoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernameLoginBox.Background = Brushes.Transparent;
            UsernameLoginBox.ToolTip = null;
        }

        private void PasswordLoginBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordLoginBox.Background = Brushes.Transparent;
            PasswordLoginBox.ToolTip = null;
        }

        private void UsernameLoginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down) { PasswordLoginBox.Focus(); }
        }

        private void PasswordLoginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down) { UsernameLoginBox.Focus(); }
        }

        private void recover_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            recover_Button.Background = Brushes.Transparent;
        }

        private void close_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            close_Button.Background = Brushes.Transparent;
        }
    }
}
