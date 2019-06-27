using INTEREST.DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INTEREST.DAL.Entities
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string EventText { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int? UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }


        public virtual IEnumerable<CategoryEvent> CategoryEvents { get; set; }
        public virtual IEnumerable<UserProfileEvent> UserProfileEvents { get; set; }


        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
