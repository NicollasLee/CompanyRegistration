using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            if (string.IsNullOrEmpty(_MyViewModel.SelectedCompany.CompanyName) || string.IsNullOrEmpty(_MyViewModel.SelectedCompany.CNPJ))
            {
                string Warning = "Please fill in all the fields..";
                MessageBoxResult result = MessageBox.Show(Warning, "Warning", MessageBoxButton.OK);
            }
            else
            {
                _MyViewModel.AvailableListCompany.Add(_MyViewModel.SelectedCompany);
                _MyViewModel.SelectedSuppiler.Company = _MyViewModel.AvailableListCompany.Select(P => _MyViewModel.SelectedCompany).FirstOrDefault();

                _MyViewModel.NewCompany();
                _MyViewModel.UpdateContext();
            }
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

                string[] filter = _MyViewModel.Write.Trim().Split(' ');

                List<Supplier> FiltredListSupillers = new List<Supplier>();
                _MyViewModel.AssistantList = _MyViewModel.AvailableListSuppiler;

                for (int i = 0; i < filter.Length; i++)
                {

                    FiltredListSupillers = _MyViewModel.AvailableListSuppiler.Where(p => p.Name.ToUpper().Contains(filter[i].ToUpper()) || p.RG.ToUpper().Contains(filter[i].ToUpper()) ||
                    p.Telephone.ToUpper().Contains(filter[i].ToUpper()) || p.Type.ToString().ToUpper().Contains(filter[i].ToUpper()) || p.Age.ToString().ToUpper().Contains(filter[i].ToUpper())
                    || p.Code.ToUpper().Contains(filter[i].ToUpper()) || p.Company.CompanyName.ToUpper().Contains(filter[i].ToUpper()) || p.Date.ToString().ToUpper().Contains(filter[i].ToUpper())
                    || p.DateOfBirth.ToUpper().Contains(filter[i].ToUpper())).ToList();
                }


                _MyViewModel.AvailableListSuppiler = new ObservableCollection<Supplier>(FiltredListSupillers);


            }
        }

        private void DeleteCommand(object sender, RoutedEventArgs e)
        {
            if (_MyViewModel.SelectedSuppiler != null)
            {
                if (_MyViewModel.AvailableListSuppiler.Count == 1)
                {
                    _MyViewModel.AvailableListSuppiler.Remove(_MyViewModel.AvailableListSuppiler[0]);
                }
                else
                {
                    _MyViewModel.AvailableListSuppiler.Remove(_MyViewModel.SelectedSuppiler);
                }
                _MyViewModel.NewSuppiler();
                _MyViewModel.UpdateContext();
            }
        }

        private void DeleteAllCommand(object sender, RoutedEventArgs e)
        {

            string Warning = "Are you sure you want to delete all suppliers?";
            MessageBoxResult result = MessageBox.Show(Warning, "Question", MessageBoxButton.YesNoCancel);

            if (result == MessageBoxResult.Yes)
            {
                _MyViewModel.AvailableListSuppiler.Clear();
                _MyViewModel.NewSuppiler();
                _MyViewModel.UpdateContext();
            }
        }

    }
}
