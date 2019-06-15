using INTEREST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.Interfaces
{
    public interface IMessageService : IDisposable
    {
        IEnumerable<MessageDTO> GetAllMessages(int id, ref int pageNumber, int pageSize, out int totalPages);

        bool CreateMessage(CreateMessageDTO createMessageDTO);

        bool DeleteMessage(DeleteMessageDTO deleteMessageDTO);

        string GetMessage(EditMessageDTO EditMessageDTO);

        string EditMessageConfirm(EditMessageDTO EditMessageDTO);
    }
}
