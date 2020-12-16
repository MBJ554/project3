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


        public CreateUser()
        {

            viewModelCreateCustomer = new ViewModelCreateCustomer();
            InitializeComponent();
            
            DataContext = viewModelCreateCustomer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModelCreateCustomer.Customer.GenerateSalt();
            viewModelCreateCustomer.Customer.PasswordHash = password.Password;        
            try
            {
                    if (viewModelCreateCustomer.Create())
                    {
                        MessageBox.Show("Brugeren er oprettet", "bruger oprettet");
                        this.NavigationService.Navigate("View/Home.xaml");
                    }
                    else {
                        ShowErrorMessage();
                    }
            }
                catch (Exception exception) {
                    MessageBox.Show("Der gik noget galt", "Fejl besked");
            }     
            
           
           
           
        }

        private void ShowErrorMessage() { 
            string message = "";
            if (mobileErrorBox.Content != null) {
                message += mobileErrorBox.Content;
            }
            if (zipCodeErrorBox.Content != null)
            {
                message += zipCodeErrorBox.Content;
            }
            if(firstNameErrorBox.Content != null)
            {
                message += firstNameErrorBox.Content;
            }
            if(lastNameErrorBox.Content != null)
            {
                message += lastNameErrorBox.Content;
            }
            if (passwordErrorBox.Content != null) 
            {
                message += passwordErrorBox.Content;
            }
            if (addressErrorBox.Content != null) 
            {
                message += addressErrorBox.Content;
            }
            if (message != "") {
                MessageBox.Show(message, "Fejl Besked");              
            }
        } 
     
    }
}