using Desktop.Callers;
using Desktop.Models;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {

        private DataContextForCreateUser dcfcu;

      

        public DataContextForCreateUser DCFCU { get 
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

            dcfcu = new DataContextForCreateUser();
            InitializeComponent();
            DataContext = dcfcu;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dcfcu.Customer.Password = password.Password;
            Clinic cl = (Clinic)ClinicList.SelectedItem;
            dcfcu.Customer.ClinicId = cl.Id;
            dcfcu.CUC.Create(dcfcu.Customer);
        }

        public static implicit operator UserControl(CreateUser v)
        {
            throw new NotImplementedException();
        }

        //private void zipCode_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (zipCode.Text.Length == 4) {
        //        if (numbersOnly(zipCode.Text))
        //        {
                    
        //            setCity(zipCode.Text);
        //        }
        //    }
        //}

        public bool numbersOnly(String checkString) {

            Regex reg = new Regex("^[0-9]+$");
            
            return reg.IsMatch(checkString);
        }

        private void setCity(string zipCode) {

            City c = dcfcu.CC.GetByZipCode(zipCode);
                city.Text = c.CityName;
 
                
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
    }
}