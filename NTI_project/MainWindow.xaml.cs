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
    public partial class MainWindow : Window
    {
        Client CurrentClient;
        public MainWindow(Client client)
        {
            InitializeComponent();
            CurrentClient = client;
            UserControl usc = new HomeControl(CurrentClient, this);
            GridMain.Children.Add(usc);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
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
            myMessageBox.Show();
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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new HomeControl(CurrentClient, this);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new CreateOrderControl(CurrentClient, this);
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.LoginButton_Click(sender, e);
            registrationWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserControl usc = new Account("client", CurrentClient.id);
            GridMain.Children.Clear();
            GridMain.Children.Add(usc);
        }
    }
}
