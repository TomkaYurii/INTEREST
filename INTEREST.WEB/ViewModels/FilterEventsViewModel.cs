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
        public string SelectedAuthor { get; private set; }
        public string SelectedCountry{ get; private set; }
        public string SelectedCity { get; private set; }

        public FilterEventsViewModel(string title, string username, string country, string city)
        {
            SelectedTitle = title;
            SelectedAuthor = username;
            SelectedCountry = country;
            SelectedCity = city;
        }
    }
}
