using System.ComponentModel.DataAnnotations.Schema;

namespace INTEREST.DAL.Entities
{
    public class CategoryEvent
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
