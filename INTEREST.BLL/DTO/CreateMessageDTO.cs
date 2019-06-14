using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class CreateMessageDTO
    {
        public int IdEvent { get; set; }

        public string MessageText { get; set; }

        public string UserId { get; set; }
    }
}
