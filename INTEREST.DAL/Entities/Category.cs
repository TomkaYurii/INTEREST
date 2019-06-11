using System;
using System.Collections.Generic;
using System.Text;

namespace INTERESTS.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserCategory> UserCategories { get; set; }
        public IList<CategoryEvent> CategoryEvents { get; set; }
    }
}
