using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class TIME_FRAME_ACTIVE
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