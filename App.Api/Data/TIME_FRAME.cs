using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class TIME_FRAME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIME_FRAME()
        {
            this.TICKET_PRICE = new HashSet<TICKET_PRICE>();
        }

        public int TF_ID { get; set; }
        public string TF_NAME { get; set; }
        public Nullable<int> TF_CHECK { get; set; }
        public Nullable<System.TimeSpan> TF_FROM { get; set; }
        public Nullable<System.TimeSpan> TF_TO { get; set; }
        public string TF_DES { get; set; }
        public Nullable<bool> TF_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_PRICE> TICKET_PRICE { get; set; }
    }
}