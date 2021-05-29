﻿using System;
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

        public int Age { get; set; }

        public string Date { get { return DateTime.Now.Date.ToString(); } }

        public string Telephone { get; set; }
        

    }
}
