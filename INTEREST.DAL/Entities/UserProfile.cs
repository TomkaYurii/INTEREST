using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INTEREST.DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }
        public String Gender { get; set; }
        

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int? PhotoId { get; set; }
        public virtual Photo Avatar { get; set; }


        public virtual IEnumerable<UserProfileCategory> UserProfileCategories { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }


        public bool Online { get; set; }
        public DateTime TimeLogin { get; set; }
    }
}
