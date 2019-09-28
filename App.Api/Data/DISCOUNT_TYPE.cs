using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class DISCOUNT_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISCOUNT_TYPE()
        {
            this.DISCOUNTs = new HashSet<DISCOUNT>();
        }

        public int DISCT_ID { get; set; }
        public string DISCT_NAME { get; set; }
        public Nullable<int> DISCT_CHECK { get; set; }
        public string DISCT_DES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISCOUNT> DISCOUNTs { get; set; }
    }
}