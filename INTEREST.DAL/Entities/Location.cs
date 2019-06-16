using INTEREST.DAL.EF;

namespace INTEREST.DAL.Entities
{
    public class Location : BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
