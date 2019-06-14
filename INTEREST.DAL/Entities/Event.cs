using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventText { get; set; }
        public DateTime EventTime { get; set; }
        public string Location { get; set; }

        public string UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<CategoryEvent> CategoryEvents { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
