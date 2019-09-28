using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class IO_INFO
    {
        public long IO_ID { get; set; }
        public Nullable<System.DateTime> IO_TIME { get; set; }
        public Nullable<int> CONTROLLER_ID { get; set; }
        public Nullable<int> CA_ID { get; set; }
        public Nullable<long> BAR_ID { get; set; }
        public Nullable<int> TFA_ID { get; set; }

        public virtual BARCODE BARCODE { get; set; }
        public virtual CARD_NO CARD_NO { get; set; }
        public virtual CONTROLLER CONTROLLER { get; set; }
        public virtual TIME_FRAME_ACTIVE TIME_FRAME_ACTIVE { get; set; }
    }
}