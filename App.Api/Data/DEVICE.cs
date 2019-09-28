using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class DEVICE
    {
        public int DEVICE_ID { get; set; }
        public string DEVICE_NAME { get; set; }
        public string DEVICE_CODE { get; set; }
        public Nullable<int> DT_ID { get; set; }
        public Nullable<int> CONTROLLER_ID { get; set; }
        public string DEVICE_MAC { get; set; }
        public Nullable<int> DEVICE_PORT { get; set; }
        public string DEVICE_DES { get; set; }
        public Nullable<bool> DEVICE_STATUS { get; set; }

        public virtual CONTROLLER CONTROLLER { get; set; }
        public virtual DEVICE_TYPE DEVICE_TYPE { get; set; }
    }
}