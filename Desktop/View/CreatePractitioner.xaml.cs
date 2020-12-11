using Desktop.Models;
using Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreatePractitioner.xaml
    /// </summary>
    public partial class CreatePractitioner : Page
    {

        private ViewModelCreatePractitioner viewModelCreatePractitioner;



        public ViewModelCreatePractitioner ViewModelCreatePratitioner
        {
            get
            {
                return viewModelCreatePractitioner;
            }
            set
            {
                viewModelCreatePractitioner = value;
            }
        }

        public CreatePractitioner()
        {

            viewModelCreatePractitioner = new ViewModelCreatePractitioner();
            InitializeComponent();
            DataContext = viewModelCreatePractitioner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (checkValues())
            {
               
                viewModelCreatePractitioner.Practitioner.ClinicId = GlobalLoginInfo.ClinicId;
                viewModelCreatePractitioner.Practitioner.GenerateSalt();
                viewModelCreatePractitioner.Practitioner.PasswordHash = password.Password;
                viewModelCreatePractitioner.Create();
            }
        }

        private bool checkValues()
        {
            bool res = true;
            string message = "";
            if (!(viewModelCreatePractitioner.checkPhoneNo(mobil.Text)))
            {
                message += "- Nummeret skal være 8 cifre langt og må kun indeholde tal";
                res = false;
            }
            if (!(viewModelCreatePractitioner.checkFirstName(fornavn.Text)))
            {
                message += " - For kort fornavn";
                res = false;
            }
            if (!(viewModelCreatePractitioner.checkLastName(efternavn.Text)))
            {
                message += " - For kort efternavn";
                res = false;
            }
            if (!viewModelCreatePractitioner.checkPassword(password.Password))
            {
                message += " - For kort kode";
                res = false;
            }
            if (!viewModelCreatePractitioner.checkEmail(email.Text))
            {
                message += " - For kort Email";
                res = false;
            }
            //if (vmpc.CheckEmailIsTaken(email.Text)) {
            //    message += " - Mailen er taget af en anden bruger";
            //    res = false;
            //}
            if (res == false)
            {
                MessageBox.Show(message, "Fejl Besked");
            }
            return res;
        }


        public bool numbersOnly(String checkString)
        {

            Regex reg = new Regex("^[0-9]+$");

            return reg.IsMatch(checkString);
        }

        private void fornavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(viewModelCreatePractitioner.checkFirstName(fornavn.Text)))
            {
                firstNameErrorBox.Content = " - For kort fornavn";
                firstNameErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                firstNameErrorBox.Content = "";
                firstNameErrorBox.Foreground = Brushes.White;
            }
        }

        private void efternavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(viewModelCreatePractitioner.checkLastName(efternavn.Text)))
            {
                lastNameErrorBox.Content = " - For kort efternavn";
                lastNameErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                lastNameErrorBox.Content = "";
                lastNameErrorBox.Foreground = Brushes.White;
            }
        }

        private void mobil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(viewModelCreatePractitioner.checkPhoneNo(mobil.Text)))
            {
                mobileErrorBox.Content = " - ugyldigt nummer";
                mobileErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                mobileErrorBox.Content = "";
                mobileErrorBox.Foreground = Brushes.White;
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!viewModelCreatePractitioner.checkEmail(email.Text))
            {
                emailErrorBox.Content = " - Email er for kort";
                emailErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                emailErrorBox.Content = "";
                emailErrorBox.Foreground = Brushes.White;
            }
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(password.Password.Length > 6))
            {
                passwordErrorBox.Content = " - For kort kode";
                passwordErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                passwordErrorBox.Content = "";
                passwordErrorBox.Foreground = Brushes.White;
            }
        }

       
        
    }
}
