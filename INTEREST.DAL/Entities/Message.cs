using System;


namespace INTEREST.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int InternalId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string MessageText { get; set; }

        public int StatusMessageId { get; set; }
        public StatusMessage StatusMessage { get; set; }
        public DateTime MessageTime { get; set; }
    }
}

