using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Parking.Models
{
    public class TicketTypeModel
    {
        public int TYPEID { get; set; }
        public string TYPENAME { get; set; }
        public string TYPE_CODE { get; set; }
        public Nullable<int> TYPE_CHECK { get; set; }
        public string DESCRIPTIONS { get; set; }
    }
}