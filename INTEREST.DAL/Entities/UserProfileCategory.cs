namespace INTEREST.DAL.Entities
{
    public class UserProfileCategory : BaseEntity
    {
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
