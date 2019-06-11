using System;
using System.Collections.Generic;
using System.Text;

namespace INTERESTS.DAL.Entities
{
    public class Photo
        {
            public int Id { get; set; }
            public string URL { get; set; }

            public UserProfile UserProfile { get; set; }
            public string UserId { get; set; }
            public Event Event { get; set; }
            public string EventId { get; set; }
        }
    }
