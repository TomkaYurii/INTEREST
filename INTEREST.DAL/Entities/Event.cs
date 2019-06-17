using INTEREST.DAL.EF;
using System;
using System.Collections.Generic;

namespace INTEREST.DAL.Entities
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string EventText { get; set; }
        public DateTime EventTime { get; set; }
        public Location Location { get; set; }

        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public IList<Photo> Photos { get; set; }
        public IList<CategoryEvent> CategoryEvents { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
