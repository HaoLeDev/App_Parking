using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class HOLIDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOLIDAY()
        {
            this.TICKET_PRICE = new HashSet<TICKET_PRICE>();
        }

        public int HOL_ID { get; set; }
        public string HOL_NAME { get; set; }
        public string HOL_FROM { get; set; }
        public string HOL_TO { get; set; }
        public Nullable<bool> HOL_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_PRICE> TICKET_PRICE { get; set; }
    }
}