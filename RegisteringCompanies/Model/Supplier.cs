﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Supplier
    {

        public Company Company { get; set; }

        public string Name { get; set; }

        public string Register { get; set; }

        public DateTime Date { get; set; }

        public string Telephone { get; set; }

    }
}