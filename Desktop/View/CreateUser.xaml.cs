using Desktop.Callers;
using Desktop.Models;
using Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {

        private ViewModelCreateCustomer dcfcu;

      

        public ViewModelCreateCustomer DCFCU { get 
            {
                return dcfcu;
            } 
            set 
            {
                dcfcu = value;
            } 
        }

        public CreateUser()
        {

            dcfcu = new ViewModelCreateCustomer();
            InitializeComponent();
            DataContext = dcfcu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dcfcu.Customer.PasswordHash = password.Password;

            if (checkValues()) {
               
                    Clinic cl = (Clinic)ClinicList.SelectedItem;
                    dcfcu.Customer.ClinicId = cl.Id;
                    dcfcu.Create(dcfcu.Customer);
                
            }
           
           
           
        }

        private bool checkValues() { 
        bool res = true;
            string message = "";
            if (!dcfcu.checkPhoneNo(mobil.Text)) {
                message += "- Nummeret skal være 8 cifre langt og må kun indeholde tal";
                res = false;  
            }
            if (dcfcu.setCity(postnr.Text).Equals(null))
            {
                message += " - Postnummeret findes ikke";
                res = false;
            }
            if(!dcfcu.checkFirstName(fornavn.Text))
            {
                message += " - For kort fornavn";
                res = false;
            }
            if(!dcfcu.checkLastName(efternavn.Text))
            {
                message += " - For kort efternavn";
                res = false;
            }
            if (!dcfcu.checkPassword(password.Password)) 
            {
                message += " - For kort kode";
                res = false;
            }
            if (!(dcfcu.setClinic((Clinic)ClinicList.SelectedItem))) 
            {
                message += " - Vælg en klinik";
                res = false;
            }
            if (res == false) {
                MessageBox.Show(message, "Fejl Besked");
            }
            return res;
        }

      

        private async void postnr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dcfcu.checkZipCode(postnr.Text))
            {
                    await dcfcu.setCity(postnr.Text);
            }
        }

        private void postnr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(dcfcu.checkZipCode(postnr.Text)) && dcfcu.setCity(postnr.Text) != null)
            {
                zipCodeErrorBox.Text += " - Postnummeret findes ikke";
                zipCodeErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                zipCodeErrorBox.Text = "";
                zipCodeErrorBox.Foreground = Brushes.White;
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!dcfcu.checkEmail(email.Text))
            {
                emailErrorBox.Text = " - Email er for kort";
                emailErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                emailErrorBox.Text = "";
                emailErrorBox.Foreground = Brushes.White;
            }
        }

        private void mobil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!dcfcu.checkPhoneNo(mobil.Text))
            {
                mobileErrorBox.Text = " - Nummeret skal være 8 cifre langt og må kun indeholde tal";
                mobileErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                mobileErrorBox.Text = "";
                mobileErrorBox.Foreground = Brushes.White;
            }
        }

        private void efternavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!dcfcu.checkLastName(efternavn.Text))
            {
                lastNameErrorBox.Text = " - For kort efternavn";
                lastNameErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                lastNameErrorBox.Text = "";
                lastNameErrorBox.Foreground = Brushes.White;
            }
        }

        private void fornavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!dcfcu.checkFirstName(fornavn.Text))
            {
                firstNameErrorBox.Text = " - For kort fornavn";
                firstNameErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                firstNameErrorBox.Text = "";
                firstNameErrorBox.Foreground = Brushes.White;
            }
        }

        private void adresse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(adresse.Text.Length > 2))
            {
                addressErrorBox.Text = " - For kort adresse";
                addressErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                addressErrorBox.Text = "";
                addressErrorBox.Foreground = Brushes.White;
            }
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!dcfcu.checkPassword(password.Password))
            {
                passwordErrorBox.Text = " - For kort kode";
                passwordErrorBox.Foreground = Brushes.Red;
            }
            else {
                passwordErrorBox.Text = "";
                passwordErrorBox.Foreground = Brushes.White;
            }
        }

        private void ClinicList_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(dcfcu.setClinic((Clinic)ClinicList.SelectedItem)))
            {
                clinicErrorBox.Text = "Vælg en klinik";
                clinicErrorBox.Foreground = Brushes.Red;
            }
            else 
            {
                clinicErrorBox.Text = "";
                clinicErrorBox.Foreground = Brushes.White;
            }
        }

     
    }
}