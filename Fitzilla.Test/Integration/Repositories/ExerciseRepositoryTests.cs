using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Repositories;

public class ExerciseRepositoryTests(ITestOutputHelper testOutputHelper) : GenericRepositoryTests<Exercise>(testOutputHelper)
{
    protected override GenericRepository<Exercise> Repository => UnitOfWork.Exercises;

    User user = new();
    Guid exerciseId = Guid.NewGuid();
    protected override Exercise CreateModel()
    {
        return new Exercise()
        {
            Id = exerciseId,
            Title = "Test Exercise",
            Description = "Test Description",
            CreatedAt = DateTimeOffset.Now,
            Set = 3,
            CreatorId = user.Id,
            Creator = user,
            Equipment = Equipment.Barbell,
            TargetMuscles = new List<TargetMuscle> { TargetMuscle.Abdominals, TargetMuscle.MiddleBack },
            ExerciseRecords = new List<ExerciseRecord>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Rep = 10,
                    Weight = 50,
                    ExerciseId = exerciseId,
                },
            }
        };
    }
}
