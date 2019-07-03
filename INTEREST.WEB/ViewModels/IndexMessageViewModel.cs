using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class IndexMessageViewModel
    {
        public int EventId { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public List <SubscribersViewModel> Subscribers { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
