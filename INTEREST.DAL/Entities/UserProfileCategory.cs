using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEREST.DAL.Entities
{
    public class UserProfileCategory
    {
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
