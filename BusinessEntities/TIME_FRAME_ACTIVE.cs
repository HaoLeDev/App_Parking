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
    
    public partial class TIME_FRAME_ACTIVE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIME_FRAME_ACTIVE()
        {
            this.IO_INFO = new HashSet<IO_INFO>();
        }
    
        public int TFA_ID { get; set; }
        public string TFA_NAME { get; set; }
        public Nullable<System.TimeSpan> TFA_FROM { get; set; }
        public Nullable<System.TimeSpan> TFA_TO { get; set; }
        public string TFA_DES { get; set; }
        public Nullable<bool> TFA_STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IO_INFO> IO_INFO { get; set; }
    }
}