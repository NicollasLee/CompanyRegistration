using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RegisterCompanyVM _MyViewModel;

        public MainWindow()
        {
            InitializeComponent();
            LoadViewContext();
        }

        public void LoadViewContext()
        {
            _MyViewModel = new RegisterCompanyVM();
            this.DataContext = _MyViewModel;
        }

        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            _MyViewModel.ListCompany.Add(_MyViewModel.SelectedCompany);
            _MyViewModel.NewCompany();
            _MyViewModel.UpdateContext();
        }

        private void SaveCommandSupiller(object sender, RoutedEventArgs e)
        {
            if (_MyViewModel.SelectedCompany.State == UF.PR && _MyViewModel.Age < 18)
            {
                string Warning = "It is not allowed to register a minor supplier in a company in Paraná";
                MessageBoxResult result = MessageBox.Show(Warning, "Question", MessageBoxButton.OK);
            }
            else
            {
                _MyViewModel.ListSuppiler.Add(_MyViewModel.SelectedSuppiler);
                _MyViewModel.NewSuppiler();
                _MyViewModel.UpdateContext();
            }
        }
    }
}
