using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _MyViewModel.AvailableListCompany.Add(_MyViewModel.SelectedCompany);
            _MyViewModel.NewCompany();
            _MyViewModel.UpdateContext();
        }

        private void SaveCommandSupiller(object sender, RoutedEventArgs e)
        {
            if (_MyViewModel.AvailableListCompany.Count > 0)
            {

                if (_MyViewModel.SelectedCompany.State == UF.PR && _MyViewModel.Age < 18 && _MyViewModel.SelectedSuppiler.Type == Person.Fisica)
                {
                    string Warning = "In the state of Paraná, minors are prohibited.";
                    MessageBoxResult result = MessageBox.Show(Warning, "Warning", MessageBoxButton.OK);
                }
                else
                {
                    
                    _MyViewModel.AvailableListSuppiler.Add(_MyViewModel.SelectedSuppiler);
                    _MyViewModel.NewSuppiler();
                    _MyViewModel.NewCompany();
                    _MyViewModel.UpdateContext();
                }
            }
        }

        private void SearchCommand(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_MyViewModel.Write))
            {
                List<Supplier> FiltredListSupillers = new List<Supplier>();

                FiltredListSupillers = _MyViewModel.AvailableListSuppiler.Where(p => p.Name.ToUpper().Contains(_MyViewModel.Write) || p.RG.ToUpper().Contains(_MyViewModel.Write) || p.Telephone.ToUpper().Contains(_MyViewModel.Write)
                || p.Type.ToString().ToUpper().Contains(_MyViewModel.Write) || p.Age.ToString().ToUpper().Contains(_MyViewModel.Write) || p.Code.ToUpper().Contains(_MyViewModel.Write) || p.Company.CompanyName.ToUpper().Contains(_MyViewModel.Write)
                || p.Date.ToUpper().Contains(_MyViewModel.Write) || p.DateOfBirth.ToUpper().Contains(_MyViewModel.Write)).ToList();

                _MyViewModel.AvailableListSuppiler = new ObservableCollection<Supplier>(FiltredListSupillers);
                _MyViewModel.UpdateContext();
            }
        }
    }
}
