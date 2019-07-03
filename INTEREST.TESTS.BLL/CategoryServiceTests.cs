using INTEREST.BLL.Services;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.TESTS.BLL
{
    class CategoryServiceTests
    {
        [Test]
        public async Task AddCategory_titleIsEmpty_ReturnFalse()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            var newCategory = new Category { Name = null };
            mock.Setup(uow => uow.CategoryRepository.Create(It.IsAny<Category>()));
            //act
            var result = await service.AddCategoryAsync(newCategory.Name);
            //asert
            Assert.IsFalse(result.Succedeed);

        }

    }
}
