using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserProfileService _userProfileService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IEventService eventService,
                                IUserProfileService userProfileService,
                                IMessageService messageService,
                                IMapper mapper)
        {
            _eventService = eventService;
            _messageService = messageService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Messages(int event_id, int page)
        {
            List<SubscribersViewModel> subscribers = new List<SubscribersViewModel>();
            subscribers = _mapper.Map<List<SubscribersDTO>, List<SubscribersViewModel>>(_eventService.AllInfoAboutSubscribers(event_id));

            int pageSize = 5;

            List<MessageViewModel> messages = new List<MessageViewModel>();
            messages = _mapper.Map<List<MessageDTO>, List<MessageViewModel>>(_messageService.GetAllMessages(event_id));


            var count = messages.Count();
            var items = messages.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexMessageViewModel viewModel = new IndexMessageViewModel
            {
                EventId = event_id,
                PageViewModel = pageViewModel,
                Messages = items,
                Subscribers = subscribers
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateMessage(int event_id)
        {
            CreateMessageViewModel model = new CreateMessageViewModel
            {
                EventId = event_id
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateMessage(CreateMessageViewModel model, int event_id)
        {
            if (ModelState.IsValid)
            {
                model.MessageText = RegularMessage(model.MessageText);
                var user = _userProfileService.GetUserByName(User.Identity.Name);
                model.ProdileId = user.ProfileId;

                var createMessageDto = _mapper.Map<CreateMessageViewModel, CreateMessageDTO>(model);
                _messageService.CreateMessage(createMessageDto);
            }
            return RedirectToAction("Messages", "Message", new { event_id, page = 1 });
        }

        [Authorize]
        public ActionResult DeleteMessage(int event_id, int internal_id)
        {
            _messageService.DeleteMessage(event_id, internal_id);
            return RedirectToAction("Messages", "Message", new { event_id, page = 1 });
        }

        private string RegularMessage(string messageText)
        {
            Regex regex = new Regex(@"(\s)*$", RegexOptions.Multiline);
            messageText = regex.Replace(messageText, "");
            regex = new Regex(@"^(\s)*", RegexOptions.Multiline);
            messageText = regex.Replace(messageText, "");
            return messageText;
        }

    }
}
