using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Context
{
    public class PandaDbcontext:DbContext
    {
        public PandaDbcontext() : base("PandaEntities") { }
        public DbSet<Account> Accounts { get; set; }
    }
}
