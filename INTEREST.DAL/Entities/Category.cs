using System.Collections.Generic;

namespace INTEREST.DAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<UserProfileCategory> UserProfileCategories { get; set; }
        public virtual IEnumerable<CategoryEvent> CategoryEvents { get; set; }
    }
}
