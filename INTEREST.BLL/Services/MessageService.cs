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

        public IEnumerable<MessageDTO> GetAllMessages(int id, ref int pageNumber, int pageSize, out int totalPages)
        {
            return Mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>
                (Database.MessageRepository.GetAllMessages(id, ref pageNumber, pageSize, out totalPages));
        }

        public bool CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var message = Mapper.Map<Message>(createMessageDTO);
            return Database.MessageRepository.CreateMessage(message);
        }

        public bool DeleteMessage(DeleteMessageDTO deleteMessageDTO)
        {
            var message = Mapper.Map<Message>(deleteMessageDTO);
            return Database.MessageRepository.DeleteMessage(message);
        }

        public string GetMessage(EditMessageDTO editMessageDTO)
        {
            var message = Mapper.Map<Message>(editMessageDTO);
            return Database.MessageRepository.GetMessage(message);
        }

        public string EditMessageConfirm(EditMessageDTO editMessageDTO)
        {
            var message = Mapper.Map<Message>(editMessageDTO);
            return Database.MessageRepository.EditMessageConfirm(message);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}