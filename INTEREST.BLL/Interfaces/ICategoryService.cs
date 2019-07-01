using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface ICategoryService
    {
        List<Category> Categories();
        Task<OperationDetails> AddCategoryAsync(string title);
        Task<OperationDetails> DeleteCategoryAsync(int id);

        List<string> CategoriesOfEvent(int id);
        List<Category> CategoriesOfUser(string profileID);
        Task<OperationDetails> AddCategoriesToUser(UserCategoryDTO model);
    }
}
