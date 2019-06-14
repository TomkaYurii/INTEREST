using INTEREST.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.Interfaces
{
    public interface IMessageService : IDisposable
    {
        bool CreateMessage(CreateMessageDTO createMessageDTO);
    }
}
