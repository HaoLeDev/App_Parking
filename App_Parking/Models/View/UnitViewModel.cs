using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Parking.Models.View
{
    public class UnitViewModel
    {
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_NAME { get; set; }
        public string UNIT_DES { get; set; }
        public Nullable<bool> UNIT_STATUS { get; set; }
        public string  strUNIT_STATUS {
            get
            {
                return UNIT_STATUS.HasValue== true && UNIT_STATUS==true ? "<span class='label label-success'>Kích hoạt</span>" : "<span class='label label-danger'>Chưa kích hoạt</span>";
            }
        }

    }
}