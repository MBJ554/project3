using Desktop.Callers;
using Desktop.Models;
using System;
using System.Windows;

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
                ClinicCaller clinicCaller = new ClinicCaller();
                LoginCaller loginCaller = new LoginCaller();
                var practitioner = loginCaller.GetByLogin(txtEmail.Text, txtPassword.Password);
                if (practitioner != null)
                {
                    GlobalLoginInfo.UserId = practitioner.Id;
                    GlobalLoginInfo.FullName = practitioner.FirstName + " " + practitioner.LastName;
                    GlobalLoginInfo.Clinic = clinicCaller.GetById(practitioner.Clinic);
                    GlobalLoginInfo.ClinicId = GlobalLoginInfo.Clinic.Id;
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }
        }
    }
}