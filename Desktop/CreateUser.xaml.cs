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
        private CityCaller cc;
        private List<City> cities;

        public CreateUser()
        {

            cc = new CityCaller();
            cities = (List<City>)cc.GetAll();
            InitializeComponent();
            DataContext = new DataContextForCreateUser();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public static implicit operator UserControl(CreateUser v)
        {
            throw new NotImplementedException();
        }

        private void zipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zipCode.Text.Length == 4) {
                if (numbersOnly(zipCode.Text))
                {
                    
                    setCity(zipCode.Text);
                }
            }
        }

        public bool numbersOnly(String checkString) {

            Regex reg = new Regex("^[0-9]+$");
            
            return reg.IsMatch(checkString);
        }

        private void setCity(string zipCode) {

            City c = cc.GetByZipCode(zipCode);
            city.Text = c.city;      
        }

    }
}