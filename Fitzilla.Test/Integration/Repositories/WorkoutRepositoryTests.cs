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
    public class WorkoutRepositoryTests : GenericRepositoryTests<Plan>
    {
        protected override GenericRepository<Plan> Repo => UnitOfWork.Workouts;

        protected override Plan CreateModel()
        {
            return new Plan
            {
                Id = Guid.NewGuid(),
                Name = "New Workout",
                Description = "New description for workout",
                TargetMuscle = TargetedMuscle.SHOULDERS,
                CreatedAt = DateTime.Now,
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
                },
            };
        }
    }
}
