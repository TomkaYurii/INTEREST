using INTEREST.BLL.Services;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.TESTS.BLL
{
    class CategoryServiceTests
    {
        [Test]
        public async Task CategoryService_AddCategory_Create_TitleIsEmpty_ReturnFalse()
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
        [Test]
        public async Task CategoryService_Create_TitleIsNotEmpty_RetunTrue()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            Category newCategory = new Category { Name = "test_name" };
            mock.Setup(uow => uow.CategoryRepository.Create(It.IsAny<Category>()));
            // Act
            var result = await service.AddCategoryAsync(newCategory.Name);
            // Assert
            Assert.IsTrue(result.Succedeed);
        }


        [Test]
        public async Task CategoryService_DeleteItemIfNotExist_RetunFalse()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            var newCategory = new Category { Name = null };
            mock.Setup(x => x.CategoryRepository.Delete(It.IsAny<Category>()));
            //act
            var result = await service.DeleteCategoryAsync(1);
            //asert
            Assert.IsFalse(result.Succedeed);

        }
        //[Test]
        //public async Task CategoryService_DeleteCategory_ReturnTrue()
        //{
        //    //arrange
        //    var mock = new Mock<IUnitOfWork>();
        //    var service = new CategoryService(mock.Object);
        //    mock.Setup(uow => uow.CategoryRepository.GetById(1))
        //        .Returns(new Category() { Id = 1, Name = "test_category" });
        //    //act
        //    var result = await service.DeleteCategoryAsync(1);
        //    //assert
        //    Assert.IsTrue(result.Succedeed);
        //}

        [Test]
        public void CategoryService_Categories_ReturnList_True()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            mock.Setup(uow => uow.CategoryRepository.GetAll())
                .Returns(GetTestCategory().AsQueryable());
            //act
            var result = service.Categories();
            //assert
            Assert.IsNotEmpty(result);
        }
        private List<Category> GetTestCategory()
        {
            var categories = new List<Category> {
            new Category { Id = 1, Name = "Test_1" },
            new Category { Id = 2,Name="Test_2"},
            };
            return categories;
        }

    }
}
