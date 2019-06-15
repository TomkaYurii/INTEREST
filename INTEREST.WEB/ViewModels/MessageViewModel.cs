using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class MessageViewModel
    {
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
