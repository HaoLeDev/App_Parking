//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETAIL_SALE
    {
        public long DTS_ID { get; set; }
        public Nullable<long> TS_ID { get; set; }
        public Nullable<int> CA_ID { get; set; }
        public Nullable<long> BAR_ID { get; set; }
        public Nullable<long> DTS_PRICE { get; set; }
        public Nullable<long> DTS_PAY { get; set; }
    
        public virtual BARCODE BARCODE { get; set; }
        public virtual CARD_NO CARD_NO { get; set; }
        public virtual TICKET_SALE TICKET_SALE { get; set; }
    }
}
