using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class MessageDTO
    {
        public int InternalId { get; set; }

        public string UserName { get; set; }

        public string MessageText { get; set; }
        public string Avatar { get; set; }

        public DateTime MessageTime { get; set; }
    }
}
