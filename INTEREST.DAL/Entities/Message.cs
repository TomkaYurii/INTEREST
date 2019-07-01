using INTEREST.DAL.EF;
using System;
using System.ComponentModel.DataAnnotations;

namespace INTEREST.DAL.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int InternalId { get; set; }


        public string MessageText { get; set; }
        public virtual DateTime MessageTime { get; set; }

        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

