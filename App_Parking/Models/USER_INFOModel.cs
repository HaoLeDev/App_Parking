using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Parking.Models
{
    public class USER_INFOModel
    {
        public int USER_ID { get; set; }
        public Nullable<int> USER_TYPEID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_CODE { get; set; }
        public string PHONE { get; set; }
        public string IDENTITY_NUMBER { get; set; }
        public string SEX { get; set; }
        public Nullable<System.DateTime> USER_BIRTH { get; set; }
        public string ADDRESS { get; set; }
        public byte[] IMAGE { get; set; }
        public string EMAIL { get; set; }
        public string NOTE { get; set; }
        public Nullable<bool> USER_STATUS { get; set; }
        public Nullable<int> REDEEM_POINTS { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
    }
}