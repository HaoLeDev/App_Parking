using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class TICKET_SALE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TICKET_SALE()
        {
            this.DETAIL_SALE = new HashSet<DETAIL_SALE>();
        }

        public long TS_ID { get; set; }
        public Nullable<long> SN_ID { get; set; }
        public Nullable<int> NUMBER { get; set; }
        public Nullable<long> PRICE { get; set; }
        public Nullable<long> PAY { get; set; }
        public Nullable<int> DISC_ID { get; set; }
        public Nullable<bool> IS_COMBO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_SALE> DETAIL_SALE { get; set; }
        public virtual DISCOUNT DISCOUNT { get; set; }
        public virtual SALE_NO SALE_NO { get; set; }
    }
}