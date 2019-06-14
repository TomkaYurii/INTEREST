using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.Services
{
    public class MessageService : IMessageService
    {
        IUnitOfWork Database { get; set; }
        public MessageService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public bool CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var message = Mapper.Map<Message>(createMessageDTO);
            return Database.MessageRepository.CreateMessage(message);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}