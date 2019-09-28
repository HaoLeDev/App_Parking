﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class CONTROLLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTROLLER()
        {
            this.DEVICEs = new HashSet<DEVICE>();
            this.IO_INFO = new HashSet<IO_INFO>();
        }

        public int CONTROLLER_ID { get; set; }
        public Nullable<int> ZONE_ID { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string CONTROLLER_IP { get; set; }
        public string CONTROLLER_CODE { get; set; }
        public string CONTROLLER_DESCRIPTION { get; set; }
        public Nullable<bool> CONTROLLER_STATUS { get; set; }

        public virtual ZONE ZONE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVICE> DEVICEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IO_INFO> IO_INFO { get; set; }
    }
}