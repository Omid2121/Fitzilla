using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.SeedData;

public class SessionSeedData
{
    public static List<Session> Sessions()
    {
        User? user = UserSeedData.Users().FirstOrDefault();
        return new List<Session>()
        {
            new Session
            {
                Id = Guid.NewGuid(),
                Title = "Test Workout",
                Description = "Workout description",
                TargetMuscle = TargetedMuscle.SHOULDERS,
                CreatedAt = DateTime.Now,
                CreatorId = user.Id,
                Creator = user,
                Exercises = ExerciseSeedData.Exercises()
            }
        };
    }
}
