using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Data
{
    public class ACCOUNT
    {
        public int ACC_ID { get; set; }
        public Nullable<int> PRI_ID { get; set; }
        public Nullable<int> EM_ID { get; set; }
        public string ACC_USERNAME { get; set; }
        public string ACC_PASSWORD { get; set; }
        public Nullable<bool> ACC_STATUS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual PRIVILE PRIVILE { get; set; }
    }
}