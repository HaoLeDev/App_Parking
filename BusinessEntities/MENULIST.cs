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
    
    public partial class MENULIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENULIST()
        {
            this.VISIBLECONTROLS = new HashSet<VISIBLECONTROL>();
        }

        public int MNU_ID { get; set; }
        public string MNU_NAME { get; set; }
        public string MNU_DISPLAY { get; set; }
        public string MNU_PARENT { get; set; }
        public Nullable<bool> IS_MENU { get; set; }
        public string URL { get; set; }
        public string ICON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIBLECONTROL> VISIBLECONTROLS { get; set; }
    }
}
