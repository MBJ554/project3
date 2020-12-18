using Desktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for CreatePractitioner.xaml
    /// </summary>
    public partial class CreatePractitioner : Page
    {
        private ViewModelCreatePractitioner viewModelCreatePractitioner;

        public CreatePractitioner()
        {
            viewModelCreatePractitioner = new ViewModelCreatePractitioner();
            InitializeComponent();
            DataContext = viewModelCreatePractitioner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModelCreatePractitioner.Practitioner.GenerateSalt();
            viewModelCreatePractitioner.Practitioner.PasswordHash = password.Password;
            try
            {
                if (viewModelCreatePractitioner.Create())
                {
                    MessageBox.Show("Brugeren er oprettet", "bruger oprettet");
                    this.NavigationService.Navigate("View/Home.xaml");
                }
                else
                {
                    ShowErrorMessage();
                }
            }
            catch
            {
                MessageBox.Show("Der gik noget galt", "Fejl besked");
            }
        }

        private void ShowErrorMessage()
        {
            string message = "";
            if (mobileErrorBox.Content != null)
            {
                message += mobileErrorBox.Content;
            }
            if (firstNameErrorBox.Content != null)
            {
                message += firstNameErrorBox.Content;
            }
            if (lastNameErrorBox.Content != null)
            {
                message += lastNameErrorBox.Content;
            }
            if (passwordErrorBox.Content != null)
            {
                message += passwordErrorBox.Content;
            }
            if (emailErrorBox.Content != null)
            {
                message += emailErrorBox.Content;
            }
            if (message != "")
            {
                MessageBox.Show(message, "Fejl Besked");
            }
        }
    }
}