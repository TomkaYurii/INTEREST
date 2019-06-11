using System;
using System.Collections.Generic;
using System.Text;

namespace INTERESTS.DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public string UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<CategoryEvent> CategoryEvents { get; set; }
    }
}
