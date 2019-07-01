using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Entities
{
    public class UserProfileEvent
    {
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
