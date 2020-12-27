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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
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
            //if (MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //    this.Close();
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

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerLoginWindow managerLoginWindow = new ManagerLoginWindow();
            managerLoginWindow.Show();
            this.Close();
        }

        private void Courier_Click(object sender, RoutedEventArgs e)
        {
            CourierLoginWindow courierLoginWindow = new CourierLoginWindow();
            courierLoginWindow.Show();
            this.Close();
        }

        private void StorageWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            StoremanLoginWindow storemanLoginWindow = new StoremanLoginWindow();
            storemanLoginWindow.Show();
            this.Close();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginWindow adminLoginWindow = new AdminLoginWindow();
            adminLoginWindow.Show();
            this.Close();
        }
    }
}
