using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class FilterEventsViewModel
    {
        public string SelectedTitle { get; private set; }

        public FilterEventsViewModel(string title)
        {
            SelectedTitle = title;
        }
    }
}
