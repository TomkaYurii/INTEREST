using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        string GetMessage(Message message);
        IEnumerable<Message> GetAllMessages(int id);
        bool CreateMessage(Message message);
        Message FindMessagebyEventIdInteralId(int event_id, int internal_id);
    }
}
