using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.SeedData
{
    public static class WorkoutSeedData
    {
        public static List<Workout> Workouts()
        {
            User? user = UserSeedData.Users().FirstOrDefault();
            return new List<Workout>()
            {
                new Workout
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Workout",
                    Description = "Workout description",
                    TargetMuscle = TargetedMuscle.QUADS,
                    CreationTime = DateTime.Now,
                    CreatorId = user.Id,
                    Creator = user,
                    Exercises = ExerciseSeedData.Exercises()
                }
            };
        }
    }
}
