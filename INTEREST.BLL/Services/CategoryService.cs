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


        //

        //public Category Get(int id) => Database.CategoryRepository.GetById(id);


        //public async Task<OperationDetails> EditAsync(Category categoty)
        //{
        //    if (categoty.Id == 0)
        //    {
        //        return new OperationDetails(false, "Id field is '0'", "");
        //    }

        //    Category oldCategory = Database.CategoryRepository.GetById(categoty.Id);
        //    if (oldCategory == null)
        //    {
        //        return new OperationDetails(false, "Not found", "");
        //    }

        //    oldCategory.Name = categoty.Name;

        //    await Database.SaveAsync();

        //    return new OperationDetails(true, "", "");
        //}



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

