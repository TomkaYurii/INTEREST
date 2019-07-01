using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INTEREST.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<UserProfileCategory> UserProfileCategories { get; set; }
        public virtual IEnumerable<CategoryEvent> CategoryEvents { get; set; }
    }
}
