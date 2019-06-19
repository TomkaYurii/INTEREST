using INTEREST.DAL.EF;

namespace INTEREST.DAL.Entities
{
    public class Photo : BaseEntity
    {
            public string URL { get; set; }
            public virtual UserProfile UserProfile { get; set; }
            public virtual Event Event { get; set; }
    }
 }
