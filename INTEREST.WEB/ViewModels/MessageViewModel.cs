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

        public string MessageText { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime MessageTime { get; set; }
    }
}
