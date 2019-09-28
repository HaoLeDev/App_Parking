using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class VISIBLECONTROL
    {
        public int VI_ID { get; set; }
        public Nullable<int> PRI_ID { get; set; }
        public Nullable<int> MNU_ID { get; set; }

        public virtual MENULIST MENULIST { get; set; }
        public virtual PRIVILE PRIVILE { get; set; }
    }
}