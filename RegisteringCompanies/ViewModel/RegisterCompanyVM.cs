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


        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;


                if (AvailableListCompany.Count > 0)
                {
                    SelectedSuppiler.Company = string.IsNullOrEmpty(_selectedCompany.CompanyName) ? SelectedSuppiler.Company : _selectedCompany;
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedSuppiler));
            }
        }

        private Supplier _selectedSuppiler;
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

        public ObservableCollection<Supplier> AssistantList = new ObservableCollection<Supplier>();

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
                OnPropertyChanged(nameof(RG));
                OnPropertyChanged(nameof(DateOfBirth));
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

                return SelectedType != Person.Fisica ? SelectedSuppiler.RG = string.Empty : SelectedSuppiler.RG;

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
                return SelectedType != Person.Fisica ? SelectedSuppiler.DateOfBirth = string.Empty : SelectedSuppiler.DateOfBirth;
            }
            set
            {
                SelectedSuppiler.DateOfBirth = value;
                OnPropertyChanged();
            }
        }

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

        private string _write;
        public string Write
        {
            get
            {
                return _write;
            }
            set
            {
                _write = value;

                if (string.IsNullOrEmpty(_write))
                {
                    AvailableListSuppiler = AssistantList;
                }

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
            OnPropertyChanged(nameof(Write));

            OnPropertyChanged(nameof(IsEnabledInformation));
        }

    }
}
