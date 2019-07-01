using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDBContext context) : base(context)
        {
        }

        public string GetMessage(Message message)
        {
            Message mesCurrent = context.Messages.FirstOrDefault(x => x.InternalId == message.InternalId && x.EventId == message.EventId);
            return mesCurrent.MessageText;
        }

        public IEnumerable<Message> GetAllMessages(int id)
        {
            return context.Messages.Where(i => i.EventId == id).OrderByDescending(o => o.InternalId)
                .Include(src => src.UserProfile)
                    .ThenInclude(u => u.User)
                .ToList();
        }

        public bool CreateMessage(Message message)
        {
            Event eventCurrent = context.Events.FirstOrDefault(x => x.Id == message.EventId);
            if (eventCurrent == null)
                return false;

            message.InternalId = context.Messages.Where(i => i.EventId == eventCurrent.Id).Count() + 1;
            context.Messages.Add(message);
            context.Entry(message).State = EntityState.Added;
            context.SaveChanges();
            return true;
        }


    }
}
