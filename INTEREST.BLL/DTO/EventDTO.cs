using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    class EventDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string EventText { get; set; }

        // Time of message creation/edition
        public DateTime EventTime { get; set; }
    }
}
