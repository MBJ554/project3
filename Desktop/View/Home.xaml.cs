using Desktop.ViewModels;
using System;
using System.Windows.Controls;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            DataContext = new ViewModelHome();
        }

        public static implicit operator UserControl(Home v)
        {
            throw new NotImplementedException();
        }
    }
}