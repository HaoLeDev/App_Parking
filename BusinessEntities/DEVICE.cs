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
    
    public partial class DEVICE
    {
        public int DEVICE_ID { get; set; }
        public string DEVICE_NAME { get; set; }
        public string DEVICE_CODE { get; set; }
        public Nullable<int> DT_ID { get; set; }
        public Nullable<int> CONTROLLER_ID { get; set; }
        public string DEVICE_MAC { get; set; }
        public Nullable<int> DEVICE_PORT { get; set; }
        public string DEVICE_DES { get; set; }
        public Nullable<bool> DEVICE_STATUS { get; set; }
    
        public virtual CONTROLLER CONTROLLER { get; set; }
        public virtual DEVICE_TYPE DEVICE_TYPE { get; set; }
    }
}
