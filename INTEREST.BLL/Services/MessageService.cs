using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class MessageService : IMessageService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork uow,
            IMapper mapper)
        {
            this.Database = uow;
            _mapper = mapper;
        }

        public List<MessageDTO> GetAllMessages(int id)
        {
            List<MessageDTO> messages = new List<MessageDTO>();
            foreach (var item in Database.MessageRepository.GetAllMessages(id))
            {
                var avatar = Database.PhotoRepository.GetById(item.UserProfile.PhotoId.Value);
                MessageDTO message = new MessageDTO
                {
                    InternalId = item.InternalId,
                    MessageText = item.MessageText,
                    MessageTime = item.MessageTime,
                    UserName = item.UserProfile.User.UserName,
                    Avatar = avatar.URL
                };
                messages.Add(message);
            }
            //return Mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>> (Database.MessageRepository.GetAllMessages(id));
            return messages;
        }

        public bool CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<CreateMessageDTO, Message>(createMessageDTO);
            return Database.MessageRepository.CreateMessage(message);
        }
    }
}