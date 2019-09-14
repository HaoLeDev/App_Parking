using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PRIVILES
    {
        public int PRI_ID { get; set; }
        public string PRI_DESCRIPTION { get; set; }
        public Nullable<bool> PRI_STATUS { get; set; }

        public virtual ICollection<ACCOUNTS> ACCOUNTS { get; set; }
        public virtual ICollection<VISIBLECONTROLS> VISIBLECONTROLS { get; set; }
    }
}
