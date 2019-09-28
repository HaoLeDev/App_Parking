using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class DISCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISCOUNT()
        {
            this.TICKET_SALE = new HashSet<TICKET_SALE>();
        }

        public int DISC_ID { get; set; }
        public Nullable<int> DISCT_ID { get; set; }
        public Nullable<int> HOL_ID { get; set; }
        public Nullable<int> TF_ID { get; set; }
        public string DISC_NAME { get; set; }
        public string DISC_CODE { get; set; }
        public Nullable<int> DISC_VALUE { get; set; }
        public string DISC_DES { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> DISC_START { get; set; }
        public Nullable<System.DateTime> DISC_END { get; set; }
        public Nullable<bool> DISC_STATUS { get; set; }

        public virtual DISCOUNT_TYPE DISCOUNT_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_SALE> TICKET_SALE { get; set; }
    }
}