using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class CARD_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARD_TYPE()
        {
            this.BARCODEs = new HashSet<BARCODE>();
            this.CARD_NO = new HashSet<CARD_NO>();
            this.TICKET_PRICE = new HashSet<TICKET_PRICE>();
        }
        public int CT_ID { get; set; }
        public string CT_NAME { get; set; }
        public string CT_CODE { get; set; }
        public string CT_DESCRIPTION { get; set; }
        public Nullable<bool> CT_STATUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BARCODE> BARCODEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARD_NO> CARD_NO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_PRICE> TICKET_PRICE { get; set; }
    }
}