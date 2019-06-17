namespace INTEREST.DAL.Entities
{
    public class UserCategory
    {
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
