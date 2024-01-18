using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.SeedData;

public static class PlanSeedData
{
    public static List<Plan> Plans()
    {
        User? user = UserSeedData.Users().FirstOrDefault();
        return new List<Plan>()
        {
            new Plan
            {
                Id = Guid.NewGuid(),
                Title = "Test Workout",
                Description = "Workout description",
                SessionsPerWeek = 3,
                DurationInWeeks = 4,
                CreatedAt = DateTime.Now,
                CreatorId = user.Id,
                Creator = user,
                Sessions = SessionSeedData.Sessions()
            }
        };
    }
}
