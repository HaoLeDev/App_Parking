using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRepository.IRepository
{
    public interface ITicketTypeRepository
    {
        string Insert(TICKET_TYPE ticketType);
        string Update(TICKET_TYPE ticketType);
        string Delete(int id);
        List<TICKET_TYPE> GetAllByPaging(int pageNo, int pageSize, string keyword, ref int totalRow);
        TICKET_TYPE GetByIdTicketType(int id);
    }
}
