﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CountryName
    {
        public List<Currency> currencies { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}
