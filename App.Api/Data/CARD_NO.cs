using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class CARD_NO
    {
        public CARD_NO()
        {
            this.DETAIL_SALE = new HashSet<DETAIL_SALE>();
            this.IO_INFO = new HashSet<IO_INFO>();
        }

        public int CA_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public string CA_NO { get; set; }
        public string CA_NUMBER { get; set; }
        public Nullable<int> CT_ID { get; set; }
        public Nullable<int> TYPEID { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<bool> CA_STATUS { get; set; }
        public Nullable<bool> CA_ACTIVE { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> APPLY_DATE { get; set; }
        public Nullable<System.DateTime> EXPRIED_DATE { get; set; }
        public Nullable<bool> CA_DAMAGED { get; set; }
        public Nullable<bool> CA_LOST { get; set; }
        public Nullable<bool> USING { get; set; }
        public Nullable<bool> ALLOW_SYNCHRONIZED { get; set; }
        public string ZONE_LIST { get; set; }
        public Nullable<int> ACC_ID { get; set; }

        public virtual CARD_TYPE CARD_TYPE { get; set; }
        public virtual TICKET_TYPE TICKET_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_SALE> DETAIL_SALE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IO_INFO> IO_INFO { get; set; }
    }
}