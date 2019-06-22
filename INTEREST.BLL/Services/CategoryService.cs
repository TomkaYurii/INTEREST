using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork Database { get; set; }
        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        
        public List<Category> Categories() => Database.CategoryRepository.GetAll().ToList();

        
        public async Task<OperationDetails> AddCategoryAsync(string title)
        {
            foreach (var item in Database.CategoryRepository.GetAll())
            {
                if (item.Name == title)
                    return new OperationDetails(false, "We have this category", ""); ;
            }

            Database.CategoryRepository.Create(new Category() { Name = title });

            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteCategoryAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Category category = Database.CategoryRepository.GetById(id);
            if (category == null)
            {
                return new OperationDetails(false, "Not found", "");
            }
            var result = Database.CategoryRepository.Delete(category);
            await Database.SaveAsync();
            return new OperationDetails(result, "Not found", "");
        }



        public List<Category> CategoriesOfUser(string UserName)
        {
            return Database.CategoryRepository.UserCategories(UserName);
        }

        public async Task<OperationDetails> AddCategoriesToUser(UserCategoryDTO model)
        {
            foreach (var item in Database.UserProfileCategoryRepository.GetAll())
            {
                if (item.UserProfileId == model.Id)
                    Database.UserProfileCategoryRepository.Delete(item);
            }

            foreach (var item in model.Categories)
            {
                Database.UserProfileCategoryRepository.Create(new UserProfileCategory
                {
                    Category = Database.CategoryRepository.GetByTitle(item),
                    UserProfile = Database.UserProfileRepository.GetById(model.Id)
                }); 
                await Database.SaveAsync();
            }
            return new OperationDetails(true, "Ok", "");
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

