using INTEREST.DAL.EF;
using System.Collections.Generic;

namespace INTEREST.DAL.Entities
{
    public class StatusMessage : BaseEntity
    {
        // 1 - Create message.
        // 2 - Edit message.
        // 3 - Remove message.
        // 4 - Message removed by admin.

        public string StatusMessageText { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
