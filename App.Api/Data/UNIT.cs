﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class UNIT
    {
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_NAME { get; set; }
        public string UNIT_DES { get; set; }
        public Nullable<bool> UNIT_STATUS { get; set; }
    }
}