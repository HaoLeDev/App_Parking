using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            this.EMPLOYEES = new HashSet<EMPLOYEE>();
        }

        public int DEP_ID { get; set; }
        public string DEP_NAME { get; set; }
        public string DEP_DESCRIPTION { get; set; }
        public Nullable<bool> DEP_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEES { get; set; }
    }
}