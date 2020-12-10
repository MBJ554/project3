using Desktop.Callers;
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
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                LoginCaller loginCaller = new LoginCaller();
                var practitioner = loginCaller.GetByLogin(txtEmail.Text, txtPassword.Password);
                if (practitioner != null)
                {
                    GlobalLoginInfo.UserId = practitioner.Id;
                    GlobalLoginInfo.FullName = practitioner.FirstName + " " + practitioner.LastName;
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }
        }
    }
}
