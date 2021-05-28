using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RegisterCompanyVM
    {


        public RegisterCompanyVM()
        {
            Company = new Company();




        }


        private List<Company> _listCompany = new List<Company>();
        public List<Company> ListCompany { get { return _listCompany; } set { _listCompany = value; } }

        private Company _company = new Company();
        public Company Company { get { return _company; } set { _company = value; } }

        private string _companyName;
        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                Company.CompanyName = value;
            }
        }
        

        public IEnumerable<UF> State
        {
            get
            {
                return Enum.GetValues(typeof(UF)).Cast<UF>();
            }
        }

        private string _cnpj;
        public string CNPJ
        {
            get
            {
                return _cnpj;
            }
            set
            {
                Company.CNPJ = value;
            }
        }





    }
}
