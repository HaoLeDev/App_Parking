using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class MENULIST
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