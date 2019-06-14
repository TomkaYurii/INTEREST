using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        //Event MessageHeader(int id);

        IEnumerable<Message> GetAllMessages(int id, ref int pageNumber, int pageSize, out int totalPages);

        bool CreateMessage(Message message);

        bool DeleteMessage(Message message);

        string GetMessage(Message message);

        string EditMessageConfirm(Message message);
    }
}
