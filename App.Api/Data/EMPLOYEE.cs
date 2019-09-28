using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.ACCOUNTS = new HashSet<ACCOUNT>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT> ACCOUNTS { get; set; }
        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}