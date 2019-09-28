using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class WEEKDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WEEKDAY()
        {
            this.TICKET_PRICE = new HashSet<TICKET_PRICE>();
        }

        public int WD_ID { get; set; }
        public Nullable<int> WD_CHECK { get; set; }
        public string WD_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_PRICE> TICKET_PRICE { get; set; }
    }
}