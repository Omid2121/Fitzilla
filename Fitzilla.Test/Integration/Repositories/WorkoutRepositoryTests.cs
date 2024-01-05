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
    public class WorkoutRepositoryTests : GenericRepositoryTests<Workout>
    {
        protected override GenericRepository<Workout> Repo => UnitOfWork.Workouts;

        protected override Workout CreateModel()
        {
            return new Workout
            {
                Id = Guid.NewGuid(),
                Name = "New Workout",
                Description = "New description for workout",
                TargetMuscle = TargetedMuscle.SHOULDERS,
                CreationTime = DateTime.Now,
                Creator = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Test",
                    LastName = "User",
                    Email = "",
                    Birth = DateTime.Now,
                    Gender = "Male",
                    Weight = 60,
                    Height = 160,
                    Measurement = Measurement.METRIC,
                },
            };
        }
    }
}
