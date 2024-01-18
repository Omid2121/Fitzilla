using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.SeedData;

public static class ExerciseSeedData
{
    public static List<Exercise> Exercises()
    {
        User? user = UserSeedData.Users().FirstOrDefault();
        return new List<Exercise>()
        {
            new Exercise
            {
                Id = Guid.NewGuid(),
                Title = "Test Exercise",
                Description = "Exercise description",
                Image = "ExerciseImage.png",
                Set = 3,
                Rep = 10,
                Weight = 60,
                CreatedAt = DateTime.Now,
                CreatorId = user.Id,
                Creator = user,
            }
        };
    }
}
