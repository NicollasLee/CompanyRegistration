using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RegistrationOfCompanies
    {

        public RegistrationOfCompanies()
        {
            Company = new Company();
            Supplier = new Supplier();

        }

        private ObservableCollection<Company> _listCompany = new ObservableCollection<Company>();
        public ObservableCollection<Company> ListCompany { get { return _listCompany; } set { _listCompany = value; } }

        private ObservableCollection<Supplier> _listSuppiler = new ObservableCollection<Supplier>();
        public ObservableCollection<Supplier> ListSuppiler { get { return _listSuppiler; } set { _listSuppiler = value; } }

        public Company Company { get; set; }

        public Supplier Supplier { get; set; }

        public UF State { get; set; }

        public string CompanyName { get; set; }

        public string CNPJ { get; set; }


    }
}
