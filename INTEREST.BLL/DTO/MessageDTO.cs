using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class MessageDTO
    {
        // Id Message in Event (#1, #2 ...)
        public int InternalId { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public bool Online { get; set; }

        public string MessageText { get; set; }

        // Time of message creation (edition, deletion).
        public DateTime MessageTime { get; set; }

        public string StatusMessage { get; set; }

        public int StatusMessageId { get; set; }
    }
}
