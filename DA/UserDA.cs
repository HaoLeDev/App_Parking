using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class UserDA
    {
        TICKET_MANAGEREntities3 db = null;
        public UserDA()
        {
            db = new TICKET_MANAGEREntities3();
            db.Configuration.ProxyCreationEnabled = false;
        }
        public int Login(string userName, string password)
        {
            var result = db.ACCOUNTS.SingleOrDefault(a => a.ACC_USERNAME == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.ACC_PASSWORD == password)
                    return 1;
                else
                    return -2;
            }
        }
        public ACCOUNT GetById(string userName)
        {
            return db.ACCOUNTS.SingleOrDefault(x => x.ACC_USERNAME == userName);
        }
    }
}
