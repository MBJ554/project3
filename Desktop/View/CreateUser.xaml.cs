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
            dcfcu.Customer.Password = password.Password;

            if (checkValues()) {
               
                    Clinic cl = (Clinic)ClinicList.SelectedItem;
                    dcfcu.Customer.ClinicId = cl.Id;
                    dcfcu.CUC.Create(dcfcu.Customer);
                
            }
           
           
           
        }

        private bool checkValues() { 
        bool res = true;
            string message = "";
            if (!numbersOnly(mobil.Text)  || mobil.Text.Length != 8) {
                message += "- Nummeret skal være 8 cifre langt og må kun indeholde tal";
                res = false;  
            }
            if (!setCity(postnr.Text))
            {
                message += " - Postnummeret findes ikke";
                res = false;
            }
            if(!(fornavn.Text.Length > 1))
            {
                message += " - For kort fornavn";
                res = false;
            }
            if(!(efternavn.Text.Length > 1))
            {
                message += " - For kort efternavn";
                res = false;
            }
            if (!(password.Password.Length > 6)) 
            {
                message += " - For kort kode";
                res = false;
            }
            if ((Clinic)ClinicList.SelectedItem == null) 
            {
                message += " - Vælg en klinik";
                res = false;
            }
            if (res == false) {
                MessageBox.Show(message, "Fejl Besked");
            }
            return res;
        }

       

       

        public bool numbersOnly(String checkString) {

            Regex reg = new Regex("^[0-9]+$");
            
            return reg.IsMatch(checkString);
        }

        private bool setCity(string zipCode) {
            bool res = false;
            City c = dcfcu.CC.GetByZipCode(zipCode);
            if (c != null) {
                if (c.CityName != null) 
                {
                    city.Text = c.CityName;
                    res = true;
                }            
            }
            return res;
        }

        private void postnr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (postnr.Text.Length == 4)
            {
                if (numbersOnly(postnr.Text))
                {

                    setCity(postnr.Text);
                }
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(email.Text.Length > 8))
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
            if (!numbersOnly(mobil.Text) || mobil.Text.Length != 8)
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
            if(!(efternavn.Text.Length > 2))
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
            if(!(fornavn.Text.Length > 2))
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
            if (!(password.Password.Length > 6))
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
            if ((Clinic)ClinicList.SelectedItem == null)
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

        private void postnr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!setCity(postnr.Text))
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
    }
}