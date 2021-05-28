using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class RegisterCompanyVM : Model.Others.ObjectNotification
    {


        public RegisterCompanyVM()
        {
            NewCompany();
            UpdateContext();
        }

        private RegistrationOfCompanies _registration = new RegistrationOfCompanies();
        public RegistrationOfCompanies Registration { get { return _registration; } set { _registration = value; OnPropertyChanged(); } }

        public ObservableCollection<Company> ListCompany { get { return Registration.ListCompany; } }
        public ObservableCollection<Supplier> ListSuppiler { get { return Registration.ListSuppiler; } }

        public Company SelectedCompany
        {
            get
            {
                return Registration.Company;
            }
            set
            {
                Registration.Company = value;
                SelectedSuppiler.Company = SelectedCompany;
                OnPropertyChanged();
            }
        }

        public Supplier SelectedSuppiler { get { return Registration.Supplier; } set { Registration.Supplier = value; OnPropertyChanged(); } }

        public string CompanyName
        {
            get
            {
                return SelectedCompany.CompanyName;
            }
            set
            {
                SelectedCompany.CompanyName = value;
                OnPropertyChanged();
            }
        }


        public IEnumerable<UF> State
        {
            get
            {
                return Enum.GetValues(typeof(UF)).Cast<UF>();
            }
        }

        public string CNPJ
        {
            get
            {
                return SelectedCompany.CNPJ;
            }
            set
            {
                SelectedCompany.CNPJ = value;
                OnPropertyChanged();
            }
        }

        public string SuppilerName
        {
            get
            {
                return SelectedSuppiler.Name;
            }
            set
            {
                SelectedSuppiler.Name = value;
                OnPropertyChanged();
            }
        }

        public string Code
        {
            get
            {
                return SelectedSuppiler.Code;
            }
            set
            {
                SelectedSuppiler.Code = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                return SelectedSuppiler.Age;
            }
            set
            {
                SelectedSuppiler.Age = value;
                OnPropertyChanged();
            }
        }


        public string Date
        {
            get
            {
                return SelectedSuppiler.Date;
            }
        }

        public string Telephone
        {
            get
            {
                return SelectedSuppiler.Telephone;
            }
            set
            {
                SelectedSuppiler.Telephone = value;
                OnPropertyChanged();
            }
        }

        public string Welcome { get { return GetWelcome(); } }

        public void NewSuppiler()
        {
            SelectedSuppiler = new Supplier();
        }


        public void NewCompany()
        {
            SelectedCompany = new Company();
            SelectedCompany.State = UF.SC;
        }

        public string GetWelcome()
        {
            int hora = DateTime.Now.Hour;

            if (hora > 6 && hora < 12)
            {
                return "Good morning,";
            }
            else if (hora >= 12 && hora < 18)
            {
                return "Good afternoon,";
            }
            else
            {
                return "Good night,";
            }
        }


        public void UpdateContext()
        {
            OnPropertyChanged(nameof(SelectedCompany));
            OnPropertyChanged(nameof(SelectedSuppiler));
            OnPropertyChanged(nameof(Registration));
            OnPropertyChanged(nameof(ListCompany));
            OnPropertyChanged(nameof(ListSuppiler));

            OnPropertyChanged(nameof(CompanyName));
            OnPropertyChanged(nameof(CNPJ));

            OnPropertyChanged(nameof(SuppilerName));
            OnPropertyChanged(nameof(Code));
            OnPropertyChanged(nameof(Telephone));
        }

    }
}
