using INTEREST.DAL.EF;

namespace INTEREST.DAL.Entities
{
    public class Photo : BaseEntity
    {
            public string URL { get; set; }

            public UserProfile UserProfile { get; set; }
            public string UserId { get; set; }
            public Event Event { get; set; }
            public string EventId { get; set; }
        }
    }
