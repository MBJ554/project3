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

        private ViewModelCreatePractitioner vmpc;



        public ViewModelCreatePractitioner VMPC
        {
            get
            {
                return vmpc;
            }
            set
            {
                vmpc = value;
            }
        }

        public CreatePractitioner()
        {

            vmpc = new ViewModelCreatePractitioner();
            InitializeComponent();
            DataContext = vmpc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vmpc.Practitioner.Password = password.Password;

            if (checkValues())
            {

                Clinic cl = (Clinic)ClinicList.SelectedItem;
                vmpc.Practitioner.ClinicId = cl.Id;
                vmpc.Create(vmpc.Practitioner);

            }
        }

        private bool checkValues()
        {
            bool res = true;
            string message = "";
            if (!(vmpc.checkPhoneNo(mobil.Text)))
            {
                message += "- Nummeret skal være 8 cifre langt og må kun indeholde tal";
                res = false;
            }
            if (!(vmpc.checkFirstName(fornavn.Text)))
            {
                message += " - For kort fornavn";
                res = false;
            }
            if (!(vmpc.checkLastName(efternavn.Text)))
            {
                message += " - For kort efternavn";
                res = false;
            }
            if (!vmpc.checkPassword(password.Password))
            {
                message += " - For kort kode";
                res = false;
            }
            if (!vmpc.checkEmail(email.Text))
            {
                message += " - For kort Email";
                res = false;
            }
            if (!(vmpc.setClinic((Clinic)ClinicList.SelectedItem)))
            {
                message += " - Vælg en klinik";
                res = false;
            }
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
            if (!(vmpc.checkFirstName(fornavn.Text)))
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

        private void efternavn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(vmpc.checkLastName(efternavn.Text)))
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

        private void mobil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(vmpc.checkPhoneNo(mobil.Text)))
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

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!vmpc.checkEmail(email.Text))
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

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(password.Password.Length > 6))
            {
                passwordErrorBox.Text = " - For kort kode";
                passwordErrorBox.Foreground = Brushes.Red;
            }
            else
            {
                passwordErrorBox.Text = "";
                passwordErrorBox.Foreground = Brushes.White;
            }
        }

        private void ClinicList_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(vmpc.setClinic((Clinic)ClinicList.SelectedItem)))
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
