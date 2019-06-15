using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class EventController : Controller
    {
        IEventService _eventService;
        IUserService _userService;
        IUserProfileService _userProfileService;


        private readonly IMapper _mapper;

        public EventController(IEventService eventService, 
                                IUserService userService,
                                IUserProfileService userProfileService,
                                IMapper mapper)
        {
            _eventService = eventService;
            _userService = userService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Regex regex = new Regex(@"\r\n");
                model.EventText = regex.Replace(model.EventText, "");
                model.EventText = model.EventText.Trim();

                UserProfileDTO userprofile = await _userProfileService.FindUserProfileByUserName(User.Identity.Name);
                model.UserId = userprofile.GetUser.Id;
    

                var createEventDto = _mapper.Map<CreateEventDTO>(model);
                _eventService.CreateEvent(createEventDto);

                return RedirectToAction("CreateEvent");
            }
            return View(model);
        }


        //[Authorize]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult CreateMessage(CreateMessageViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.MessageText = RegularMessage(model.MessageText);
        //        model.UserId = User.Identity.GetUserId();
        //        var createMessageDto = Mapper.Map<DTOCreateMessageViewModel>(model);
        //        if (!MessageService.CreateMessage(createMessageDto))
        //            return HttpNotFound();

        //        return RedirectToAction("ReadMessages", new { id = model.IdTheme, page = model.Page });
        //    }
        //    return HttpNotFound();
        //}







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
