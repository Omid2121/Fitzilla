using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Tests.Integration.Repositories
{
    public class ExerciseRepositoryTests : GenericRepositoryTests<Exercise>
    {
        protected override GenericRepository<Exercise> Repo => UnitOfWork.Exercises;

        protected override Exercise CreateModel()
        {
            return new Exercise()
            {
                Id = Guid.NewGuid(),
                Title = "Test Exercise",
                Description = "Test Description",
                Image = "image.png",
                Set = 3,
                Rep = 10,
                Weight = 60,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                CreatorId = Guid.NewGuid().ToString(),
                Creator = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Test",
                    LastName = "User",
                    Email = "",
                    DateOfBirth = DateTime.Now,
                    Gender = "Male",
                    Weight = 60, 
                    Height = 160,
                    Measurement = Measurement.METRIC,

                }
            };
        }

    }
}
