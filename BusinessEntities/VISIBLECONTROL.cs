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
    
    public partial class VISIBLECONTROL
    {
        public int VI_ID { get; set; }
        public Nullable<int> PRI_ID { get; set; }
        public Nullable<int> MNU_ID { get; set; }
    
        public virtual MENULIST MENULIST { get; set; }
        public virtual PRIVILE PRIVILE { get; set; }
    }
}