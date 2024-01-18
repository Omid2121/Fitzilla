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
    public class MacroRepositoryTests : GenericRepositoryTests<Macro>
    {
        protected override GenericRepository<Macro> Repo => UnitOfWork.Macros;

        protected override Macro CreateModel()
        {
            return new Macro
            {
                Id = Guid.NewGuid(),
                Title = "New Macro",
                ConsumeType = GoalType.SURPLUS,
                Intensity = ActivityLevel.LIGHTLY_ACTIVE,
                Calorie = 3000,
                Protein = 50,
                Carbohydrate = 200,
                Fat = 80,
                CreatedAt = DateTime.Now,
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
