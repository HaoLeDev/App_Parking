using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ACCOUNTS
    {
        public int ACC_ID { get; set; }
        public Nullable<int> PRI_ID { get; set; }
        public Nullable<int> EM_ID { get; set; }
        public string ACC_USERNAME { get; set; }
        public string ACC_PASSWORD { get; set; }
        public Nullable<bool> ACC_STATUS { get; set; }

        public virtual EMPLOYEES EMPLOYEES { get; set; }
        public virtual PRIVILES PRIVILES
        {
            get; set;
        }
    }
}
