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

namespace NTI_project
{
    /// <summary>
    /// Логика взаимодействия для CourierLoginWindow.xaml
    /// </summary>
    public partial class CourierLoginWindow : Window
    {
        AppContext db;
        Courier CurrentCourier;
        public CourierLoginWindow()
        {
            InitializeComponent();
            db = new AppContext();
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
        private void recover_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            recover_Button.Background = Brushes.Transparent;
        }
        private void close_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            close_Button.Background = Brushes.Transparent;
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

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string pass = PasswordBox.Password.Trim();

            if (login.Length < 5)
            {
                LoginBox.ToolTip = "Логин должен состоять из не менее 5 символов!";
                LoginBox.Background = Brushes.DarkRed;
            }
            if (pass.Length < 5)
            {
                PasswordBox.ToolTip = "Пароль должен состоять из не менее 5 символов!";
                PasswordBox.Background = Brushes.DarkRed;
            }
            else
            {
                LoginBox.ToolTip = null;
                LoginBox.Background = Brushes.Transparent;
                PasswordBox.ToolTip = null;
                PasswordBox.Background = Brushes.Transparent;

                loadborder.Visibility = Visibility.Visible;

                bool result = false;

                await Task.Run(() => result = Login(login, pass));

                if (result)
                {
                    CourierMainWindow mainWindow = new CourierMainWindow(CurrentCourier);
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    loadborder.Visibility = Visibility.Hidden;
                }
            }
        }
        private bool Login(string login, string pass)
        {
            try
            {
                Courier authCourier = null;
                using (db)
                {
                    authCourier = db.Couriers.Where(courier => courier.Login == login && courier.Password == pass).FirstOrDefault();
                }
                if (authCourier != null)
                {
                    CurrentCourier = authCourier;
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


        private void LoginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down) { PasswordBox.Focus(); }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginBox.Background = Brushes.Transparent;
            LoginBox.ToolTip = null;
        }

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down) { LoginBox.Focus(); }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox.Background = Brushes.Transparent;
            PasswordBox.ToolTip = null;
        }
    }
}
