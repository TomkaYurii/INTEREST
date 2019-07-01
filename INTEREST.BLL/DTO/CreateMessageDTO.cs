using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class CreateMessageDTO
    {
        public int EventId { get; set; }

        public string MessageText { get; set; }

        public int ProfileId { get; set; }
    }
}
