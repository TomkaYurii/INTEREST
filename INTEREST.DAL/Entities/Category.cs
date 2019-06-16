using INTEREST.DAL.EF;
using System.Collections.Generic;

namespace INTEREST.DAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IList<UserCategory> UserCategories { get; set; }
        public IList<CategoryEvent> CategoryEvents { get; set; }
    }
}
