using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class ZONE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZONE()
        {
            this.BARCODEs = new HashSet<BARCODE>();
            this.CONTROLLERs = new HashSet<CONTROLLER>();
        }

        public int ZONE_ID { get; set; }
        public string ZONE_NAME { get; set; }
        public string ZONE_CODE { get; set; }
        public string ZONE_DES { get; set; }
        public Nullable<bool> ZONE_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BARCODE> BARCODEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTROLLER> CONTROLLERs { get; set; }
    }
}