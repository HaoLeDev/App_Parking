﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class GAME_SPORT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GAME_SPORT()
        {
            this.USER_INFO = new HashSet<USER_INFO>();
        }

        public int GS_ID { get; set; }
        public string GS_NAME { get; set; }
        public Nullable<int> GS_LIMIT { get; set; }
        public string GS_DES { get; set; }
        public Nullable<bool> GS_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_INFO> USER_INFO { get; set; }
    }
}