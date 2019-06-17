using INTEREST.DAL.EF;

namespace INTEREST.DAL.Entities
{
    public class Photo : BaseEntity
    {
            public string URL { get; set; }

            public int? UserProfileId { get; set; }
            public UserProfile UserProfile { get; set; }

            public int EventId { get; set; }
            public Event Event { get; set; }

        }
    }
