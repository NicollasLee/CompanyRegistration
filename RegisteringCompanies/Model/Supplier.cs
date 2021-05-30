using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Supplier
    {

        public Company Company { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Person Type { get; set; }

        public int Age { get; set; }

        public string Date { get { return DateTime.Now.Date.Date.ToString("G"); } }

        public string Telephone { get; set; }

        public string RG { get; set; }

        public string DateOfBirth { get; set; }
    }
}
