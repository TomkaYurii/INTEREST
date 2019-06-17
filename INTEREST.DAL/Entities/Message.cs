using INTEREST.DAL.EF;
using System;


namespace INTEREST.DAL.Entities
{
    public class Message : BaseEntity
    {
        public int InternalId { get; set; }

        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string MessageText { get; set; }

        public int StatusMessageId { get; set; }
        public StatusMessage StatusMessage { get; set; }
        public DateTime MessageTime { get; set; }
    }
}

