using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ViewModel
{
    public class RegisterCompanyVM : Model.Others.ObjectNotification
    {

        public RegisterCompanyVM()
        {
            NewCompany();
            NewSuppiler();


            UpdateContext();
        }

        private Company _selectedCompany = new Company();
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;
                SelectedSuppiler.Company = SelectedCompany;
                OnPropertyChanged();
            }
        }

        private Supplier _selectedSuppiler = new Supplier();
        public Supplier SelectedSuppiler
        {
            get
            {
                return _selectedSuppiler;
            }
            set
            {
                _selectedSuppiler = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Company> _availableListCompany = new ObservableCollection<Company>();
        public ObservableCollection<Company> AvailableListCompany { get { return _availableListCompany; } set { _availableListCompany = value; OnPropertyChanged(); } }

        private ObservableCollection<Supplier> _availableListSuppiler = new ObservableCollection<Supplier>();
        public ObservableCollection<Supplier> AvailableListSuppiler { get { return _availableListSuppiler; } set { _availableListSuppiler = value; OnPropertyChanged(); } }

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


        public IEnumerable<Person> Type
        {
            get
            {
                return Enum.GetValues(typeof(Person)).Cast<Person>();
            }
        }

        public Person SelectedType
        {
            get
            {
                return SelectedSuppiler.Type;
            }
            set
            {
                SelectedSuppiler.Type = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEnabledInformation));
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

        public string RG
        {
            get
            {
                return SelectedSuppiler.RG;
            }
            set
            {
                SelectedSuppiler.RG = value;
                OnPropertyChanged();
            }
        }

        public string DateOfBirth
        {
            get
            {
                return SelectedSuppiler.DateOfBirth;
            }
            set
            {
                SelectedSuppiler.DateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Welcome { get { return GetWelcome(); } }

        private bool _isEnabledInformation;
        public bool IsEnabledInformation
        {
            get
            {
                return SelectedType == Person.Fisica ? _isEnabledInformation = true : _isEnabledInformation = false;
            }
            set
            {
                _isEnabledInformation = value;
                OnPropertyChanged();
            }
        }


        public void NewSuppiler()
        {
            SelectedSuppiler = new Supplier();
        }

        public void NewCompany()
        {
            SelectedCompany = new Company();
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
            OnPropertyChanged(nameof(SelectedType));
            OnPropertyChanged(nameof(Type));

            OnPropertyChanged(nameof(AvailableListCompany));
            OnPropertyChanged(nameof(AvailableListSuppiler));

            OnPropertyChanged(nameof(CompanyName));
            OnPropertyChanged(nameof(CNPJ));

            OnPropertyChanged(nameof(SuppilerName));
            OnPropertyChanged(nameof(Code));
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Telephone));
            OnPropertyChanged(nameof(RG));
            OnPropertyChanged(nameof(DateOfBirth));

            OnPropertyChanged(nameof(IsEnabledInformation));
        }

    }
}
