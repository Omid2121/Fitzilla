using Fitzilla.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Configurations.Entities
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(exercise => exercise.Id).IsRequired();
            builder.Property(exercise => exercise.ExerciseTypeId).IsRequired();
            builder.Property(exercise => exercise.CreatorId).IsRequired();

            builder.HasOne(exercise => exercise.ExerciseType)
                .WithMany(exerciseType => exerciseType.Exercises)
                .HasForeignKey(exercise => exercise.ExerciseTypeId);

            builder.HasOne(exercise => exercise.Workout)
                .WithMany(workout => workout.Exercises)
                .HasForeignKey(exercise => exercise.WorkoutId);

            builder.HasOne(exercise => exercise.Creator)
                .WithMany(user => user.Exercises)
                .HasForeignKey(exercise => exercise.CreatorId);
        }
    }
}
