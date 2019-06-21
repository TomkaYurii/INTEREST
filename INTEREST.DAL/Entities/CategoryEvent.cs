using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Entities
{
    public class CategoryEvent : BaseEntity
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
