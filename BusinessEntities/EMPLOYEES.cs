using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EMPLOYEES
    {
        public int EM_ID { get; set; }
        public Nullable<int> DEP_ID { get; set; }
        public string EM_NAME { get; set; }
        public string EM_CODE { get; set; }
        public string PHONE { get; set; }
        public string IDENTITY_NUMBER { get; set; }
        public string SEX { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public byte[] IMAGE { get; set; }
        public Nullable<bool> EM_STATUS { get; set; }

        public virtual ICollection<ACCOUNTS> ACCOUNTS { get; set; }
        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
