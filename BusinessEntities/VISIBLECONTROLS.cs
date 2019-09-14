using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class VISIBLECONTROLS
    {
        public int VI_ID { get; set; }
        public Nullable<int> PRI_ID { get; set; }
        public Nullable<int> MNU_ID { get; set; }

        public virtual MENULIST MENULIST { get; set; }
        public virtual PRIVILES PRIVILES { get; set; }
    }
}
