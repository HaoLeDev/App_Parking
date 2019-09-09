using BusinessEntities;
using BusinessObject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class UserDA
    {
        PandaDbcontext db = null;
        public UserDA()
        {
            db = new PandaDbcontext();
        }
        public int Login(string userName, string password)
        {
            var result = db.Accounts.SingleOrDefault(a => a.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == password)
                    return 1;
                else
                    return -2;
            }
        }
        public Account GetById(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.UserName == userName);
        }
    }
}
