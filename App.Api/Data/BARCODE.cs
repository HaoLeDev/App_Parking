﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class BARCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BARCODE()
        {
            this.DETAIL_SALE = new HashSet<DETAIL_SALE>();
            this.IO_INFO = new HashSet<IO_INFO>();
        }

        public long BAR_ID { get; set; }
        public Nullable<int> CT_ID { get; set; }
        public Nullable<int> TYPEID { get; set; }
        public Nullable<int> ZONE_ID { get; set; }
        public string BAR_NO { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> ACC_ID { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<bool> USED { get; set; }

        public virtual CARD_TYPE CARD_TYPE { get; set; }
        public virtual TICKET_TYPE TICKET_TYPE { get; set; }
        public virtual ZONE ZONE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_SALE> DETAIL_SALE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IO_INFO> IO_INFO { get; set; }
    }
}