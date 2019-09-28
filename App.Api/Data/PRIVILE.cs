using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class PRIVILE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRIVILE()
        {
            this.ACCOUNTS = new HashSet<ACCOUNT>();
            this.VISIBLECONTROLS = new HashSet<VISIBLECONTROL>();
        }

        public int PRI_ID { get; set; }
        public string PRI_DESCRIPTION { get; set; }
        public Nullable<bool> PRI_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT> ACCOUNTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIBLECONTROL> VISIBLECONTROLS { get; set; }
    }
}