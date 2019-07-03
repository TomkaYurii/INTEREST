using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IMessageService
    {
        bool CreateMessage(CreateMessageDTO createMessageDTO);
        void DeleteMessage(int event_id, int internal_id);
        List<MessageDTO> GetAllMessages(int id);
    }
}
