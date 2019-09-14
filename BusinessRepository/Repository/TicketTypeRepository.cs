using BusinessRepository.IRepository;
using DA.IRepositoryDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRepository.Repository
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        ITicketTypeRepositoryDA _TicketTypeRepository;
        public TicketTypeRepository()
        {
            _TicketTypeRepository = new ITicketTypeRepositoryDA();
        }
        public string Insert
    }
}
