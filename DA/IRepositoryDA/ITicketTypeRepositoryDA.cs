using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.IRepositoryDA
{
    public interface ITicketTypeRepositoryDA
    {
        string Insert(TICKET_TYPE ticketType);
        string Update(TICKET_TYPE ticketType);
        List<TICKET_TYPE> GetAllByPaging(int pageNo, int pageSize, string keyword, ref int totalRow);
        string Delete(int id);
        TICKET_TYPE GetById(int id);
        
    }
}
