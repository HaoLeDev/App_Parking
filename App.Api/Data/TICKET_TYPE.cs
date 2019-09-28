﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class TICKET_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TICKET_TYPE()
        {
            this.BARCODEs = new HashSet<BARCODE>();
            this.CARD_NO = new HashSet<CARD_NO>();
            this.TICKET_PRICE = new HashSet<TICKET_PRICE>();
        }

        public int TYPEID { get; set; }
        public string TYPENAME { get; set; }
        public string TYPE_CODE { get; set; }
        public Nullable<int> TYPE_CHECK { get; set; }
        public string DESCRIPTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BARCODE> BARCODEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARD_NO> CARD_NO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET_PRICE> TICKET_PRICE { get; set; }
    }
}