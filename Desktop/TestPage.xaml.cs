using Desktop.ViewModels;
using System.Windows.Controls;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            DataContext = new ViewModelCreateCustomer();
        }
    }
}