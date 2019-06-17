using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDBContext db;

        public MessageRepository(AppDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Message> GetAllMessages(int id, ref int pageNumber, int pageSize, out int totalPages)
        {
            var selection = db.Messages.Where(i => i.EventId == id).OrderBy(o => o.InternalId)
                .Include(src => src.UserProfileId)
                .Include(src => src.StatusMessage)
                .ToList();

            totalPages = (int)Math.Ceiling((decimal)selection.Count() / pageSize);

            if (totalPages < 1)
                totalPages = 1;

            if (pageNumber < 1)
                pageNumber = 1;

            if (pageNumber > totalPages)
                pageNumber = totalPages;

            return selection.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public bool CreateMessage(Message message)
        {
            Event eventCurrent = db.Events.FirstOrDefault(x => x.Id == message.EventId);
            if (eventCurrent == null)
                return false;

            message.InternalId = db.Messages.Where(i => i.EventId == eventCurrent.Id).Count() + 1;
            message.StatusMessageId = 1;
            db.Messages.Add(message);
            db.Entry(message).State = EntityState.Added;
            db.SaveChanges();
            return true;
        }

        public bool DeleteMessage(Message message)
        {
            Message mesCurrent = db.Messages.FirstOrDefault(x => x.InternalId == message.InternalId && x.EventId == message.EventId);

            if (mesCurrent == null || mesCurrent.StatusMessageId == 3 || mesCurrent.StatusMessageId == 4)
                return false;

            // DeleteMessageConfirm.
            if (message.UserProfileId != null && message.UserProfileId != mesCurrent.UserProfileId)
                return false;

            if (message.UserProfileId == null)
                mesCurrent.StatusMessageId = 4;
            else
                mesCurrent.StatusMessageId = 3;

            mesCurrent.MessageText = "-";
            mesCurrent.MessageTime = DateTime.Now;
            db.Entry(mesCurrent).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public string GetMessage(Message message)
        {
            Message mesCurrent = db.Messages.FirstOrDefault(x => x.InternalId == message.InternalId && x.EventId == message.EventId);

            if (mesCurrent == null || mesCurrent.StatusMessageId == 3 || mesCurrent.StatusMessageId == 4)
                return null;
            else
                return mesCurrent.MessageText;
        }

        public string EditMessageConfirm(Message message)
        {
            Message mesCurrent = db.Messages.FirstOrDefault(x => x.InternalId == message.InternalId && x.EventId == message.EventId);

            if (mesCurrent == null || mesCurrent.StatusMessageId == 3 || mesCurrent.StatusMessageId == 4 || mesCurrent.UserProfileId != message.UserProfileId)
                return "Error (Click button \"Cancel\" to reload the page.)";

            if (message.MessageText == mesCurrent.MessageText)
                return "Editable message is the same as the original.";

            else
            {
                mesCurrent.StatusMessageId = 2;
                mesCurrent.MessageText = message.MessageText;
                mesCurrent.MessageTime = DateTime.Now;
                db.Entry(mesCurrent).State = EntityState.Modified;
                db.SaveChanges();
                return "True";
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
