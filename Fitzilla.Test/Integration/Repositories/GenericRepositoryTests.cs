using Fitzilla.DAL.Models;
using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Repositories
{
    public abstract class GenericRepositoryTests<T> : WebApiApplication where T : class, IEntity
    {
        protected GenericRepositoryTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected abstract GenericRepository<T> Repository { get; }

        protected abstract T CreateModel();

        [Fact]
        public async void GetAll_ShouldReturnAllEntities()
        {
            // Arrange

            // Act
            var result =await Repository.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async void GetPagedList_ShouldReturnPagedEntities()
        {
            // Arrange
            RequestParams requestParams = new()
            {
                PageNumber = 1,
                PageSize = 10,
            };

            // Act
            var result = await Repository.GetPagedList(requestParams);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async void Get_ShouldReturnEntityById()
        {
            // Arrange

            // Act
            var result = await Repository.Get(entity => entity.Id == CreateModel().Id);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Insert_ShouldAddEntity()
        {
            // Arrange

            // Act
            await Repository.Insert(CreateModel());

            // Assert
            var result = await Repository.Get(entity => entity.Id == CreateModel().Id);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void InsertRange_ShouldAddMultipleEntities()
        {
            // Arrange
            var entities = new List<T> { CreateModel() };

            // Act
            await Repository.InsertRange(entities);

            // Assert
            var result = await Repository.Get(entity => entity.Id == entities[0].Id);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Delete_ShouldRemoveEntity()
        {
            // Arrange
            var entity = CreateModel();
            await Repository.Insert(entity); 

            // Act
            await Repository.Delete(entity.Id);

            // Assert
            var result = Repository.Get(e => e.Id == entity.Id);
            result.Should().BeNull();
        }

        [Fact]
        public async void DeleteRange_ShouldRemoveMultipleEntities()
        {
            // Arrange
            var entities = new List<T> { CreateModel() };
            await Repository.InsertRange(entities);

            // Act
            Repository.DeleteRange(entities);

            // Assert
            var result = await Repository.Get(entity => entity.Id == entities[0].Id);
            result.Should().BeNull();
        }

        [Fact]
        public async void Update_ShouldUpdateEntity()
        {
            // Arrange
            var entity = CreateModel();
            await Repository.Insert(entity);

            // Act
            Repository.Update(entity);

            // Assert
            // Check if the entity has been updated in the repository
            var result = Repository.Get(e => e.Id == entity.Id);
        }

        //[Fact]
        //public async void Search_ShouldReturnMatchingEntities()
        //{
        //    // Arrange
        //    string searchKeyword = "Example"; // Provide a search keyword

        //    // Act
        //    var result = await Repository.Search(entity => entity.Name.Contains(searchKeyword));

        //    // Assert
        //    Assert.NotNull(result);
        //    // Add specific assertions for Search() here
        //}

        [Fact]
        public async void Insert_WithValidExpression_AddEntity()
        {
            // Arrange
            var entity = CreateModel();
            var entitiesBefore = Repository.GetAll().Result;
            // Act
            await Repository.Insert(entity);

            await UnitOfWork.Save();
            // Assert
            IList<T> entitiesAfter = Repository.GetAll().Result;

            Assert.Contains(entitiesAfter, e => e.Id == entity.Id);
            Assert.Equal(entitiesBefore.Count + 1, entitiesAfter.Count);
        }
    }
}
