using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class SelectCategoriesViewModel
    {
        public List<string> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
