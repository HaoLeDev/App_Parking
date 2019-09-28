using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class DEVICE_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEVICE_TYPE()
        {
            this.DEVICEs = new HashSet<DEVICE>();
        }

        public int DT_ID { get; set; }
        public string DT_NAME { get; set; }
        public string DT_CODE { get; set; }
        public string DT_DES { get; set; }
        public Nullable<bool> DT_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVICE> DEVICEs { get; set; }
    }
}