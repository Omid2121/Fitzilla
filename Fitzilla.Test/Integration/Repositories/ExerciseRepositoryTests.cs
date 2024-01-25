using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Repositories
{
    public class ExerciseRepositoryTests : GenericRepositoryTests<Exercise>
    {
        protected override GenericRepository<Exercise> Repository => throw new NotImplementedException();
        
        public ExerciseRepositoryTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        protected override Exercise CreateModel()
        {
            throw new NotImplementedException();
        }

        //protected override GenericRepository<Exercise> Repo => UnitOfWork.Exercises;

        //protected override Exercise CreateModel()
        //{
        //    return new Exercise()
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Test Exercise",
        //        Description = "Test Description",
        //        CreatedAt = DateTimeOffset.Now,
        //        CreatorId = Guid.NewGuid().ToString(),
        //        Creator = new User()
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            FirstName = "Test",
        //            LastName = "User",
        //            Email = "testmail@gmail.com",
        //            DateOfBirth = DateTime.Now,
        //            Gender = Gender.Male,
        //            Weight = 60, 
        //            Height = 160,
        //            Measurement = Measurement.Metric,

        //        }
        //    };
        //}
    }
}
