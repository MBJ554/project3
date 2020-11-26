using Desktop.Models;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*   private void btnCreateUser(object sender, RoutedEventArgs e)
            {
                Main.Content = new CreateUser();
            }

            private void BtnClickClinic(object sender, RoutedEventArgs e)
            {
                Main.Content = new RehabProgram();
            }

            private void home(object sender, RoutedEventArgs e)
            {
                Main.Content = new Home();
            }

            private void Image_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Main.Content = new Home();
            } */

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

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

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Home();
        }

        

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new CreateUser();
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new CreatePractitioner();
        }
    }
}
