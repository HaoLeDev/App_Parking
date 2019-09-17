using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Statistic
{
    public class statistic_Unit
    {
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_NAME { get; set; }
        public string UNIT_DES { get; set; }
        public Nullable<bool> UNIT_STATUS { get; set; }
    }
}
