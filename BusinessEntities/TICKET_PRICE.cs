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
    
    public partial class TICKET_PRICE
    {
        public int PRICE_ID { get; set; }
        public Nullable<int> CT_ID { get; set; }
        public Nullable<int> TYPEID { get; set; }
        public Nullable<int> ZONE_ID { get; set; }
        public Nullable<int> TF_ID { get; set; }
        public Nullable<int> HOL_ID { get; set; }
        public Nullable<int> WD_ID { get; set; }
        public Nullable<long> PRICE { get; set; }
        public string TEXT_PRICE { get; set; }
        public Nullable<bool> IS_COMBO { get; set; }
        public string ZONE_LIST_COMBO { get; set; }
        public Nullable<System.DateTime> APPLY_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> ACC_ID { get; set; }
    
        public virtual CARD_TYPE CARD_TYPE { get; set; }
        public virtual HOLIDAY HOLIDAY { get; set; }
        public virtual TICKET_TYPE TICKET_TYPE { get; set; }
        public virtual TIME_FRAME TIME_FRAME { get; set; }
        public virtual WEEKDAY WEEKDAY { get; set; }
    }
}
