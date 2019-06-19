using INTEREST.DAL.EF;
using System;


namespace INTEREST.DAL.Entities
{
    public class Message : BaseEntity
    {
        public int InternalId { get; set; }

        //public int UserProfileId { get; set; }
        //public virtual UserProfile UserProfile { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string MessageText { get; set; }
        public virtual DateTime MessageTime { get; set; }

        public int StatusMessageId { get; set; }
        public virtual StatusMessage StatusMessage { get; set; }
    }
}

