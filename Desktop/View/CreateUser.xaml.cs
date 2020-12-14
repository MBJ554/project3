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

        private ViewModelCreateCustomer viewModelCreateCustomer;

      

        public ViewModelCreateCustomer ViewModelCreateCustomer { get 
            {
                return viewModelCreateCustomer;
            } 
            set 
            {
                viewModelCreateCustomer = value;
            } 
        }

        public CreateUser()
        {

            viewModelCreateCustomer = new ViewModelCreateCustomer();
            InitializeComponent();
            DataContext = viewModelCreateCustomer;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            viewModelCreateCustomer.Customer.ClinicId = GlobalLoginInfo.Clinic.Id;
            viewModelCreateCustomer.Customer.GenerateSalt();
            viewModelCreateCustomer.Customer.PasswordHash = password.Password;
            bool check= await checkValues();
            if (check) {
                try
                {
                    viewModelCreateCustomer.Create();
                    MessageBox.Show("Brugeren er oprettet", "bruger oprettet");
                    this.NavigationService.Navigate("View/Home.xaml");


                }
                catch (Exception exception) {

                    MessageBox.Show("Der gik noget galt", "Fejl besked");
                }     
            }
           
           
           
        }

        private async Task<bool> checkValues() { 
        bool res = true;
            string message = "";
            if (!viewModelCreateCustomer.checkPhoneNo(mobil.Text)) {
                message += "- Nummeret skal være 8 cifre langt og må kun indeholde tal";
                res = false;  
            }
            bool checkZipCode = await viewModelCreateCustomer.checkZipCode(postnr.Text);
            if (!checkZipCode)
            {
                message += " - Postnummeret findes ikke";
                res = false;
            }
            if(!viewModelCreateCustomer.checkFirstName(fornavn.Text))
            {
                message += " - For kort fornavn";
                res = false;
            }
            if(!viewModelCreateCustomer.checkLastName(efternavn.Text))
            {
                message += " - For kort efternavn";
                res = false;
            }
            if (!viewModelCreateCustomer.checkPassword(password.Password)) 
            {
                message += " - For kort kode";
                res = false;
            }
            //if (dcfcu.CheckEmailIsTaken(email.Text)) {
            //    message += " - Mailen er taget af en anden bruger";
            //    res = false;
            //}
            if (res == false) {
                MessageBox.Show(message, "Fejl Besked");
            }
            return res;
        }

      

        private async void postnr_TextChanged(object sender, TextChangedEventArgs e)
        {
            await viewModelCreateCustomer.checkZipCode(postnr.Text);
        }

        private async void postnr_LostFocus(object sender, RoutedEventArgs e)
        {
            bool checkZipCode = await viewModelCreateCustomer.checkZipCode(postnr.Text);
            if (!checkZipCode)
            {
                zipCodeErrorBox.Content += " - Postnummeret findes ikke";
                zipCodeErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                zipCodeErrorBox.Content = "";
                zipCodeErrorBox.Foreground = Brushes.White;
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!viewModelCreateCustomer.CheckEmailIsValid(email.Text))
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

        private void mobil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!viewModelCreateCustomer.checkPhoneNo(mobil.Text))
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

        private void efternavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!viewModelCreateCustomer.checkLastName(efternavn.Text))
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

        private void fornavn_LostFocus(object sender, RoutedEventArgs e)
            {
            if(!viewModelCreateCustomer.checkFirstName(fornavn.Text))
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

        private void adresse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(adresse.Text.Length > 2))
            {
                addressErrorBox.Content = " - For kort adresse";
                addressErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                addressErrorBox.Content = "";
                addressErrorBox.Foreground = Brushes.White;
            }
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!viewModelCreateCustomer.checkPassword(password.Password))
            {
                passwordErrorBox.Content = " - For kort kode";
                passwordErrorBox.Foreground = Brushes.Red;
            }
            else {
                passwordErrorBox.Content = "";
                passwordErrorBox.Foreground = Brushes.White;
            }
        }
     
    }
}