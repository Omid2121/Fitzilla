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
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.Property(workout => workout.Id).IsRequired();
            builder.Property(workout => workout.Name).IsRequired().HasMaxLength(50);
            builder.Property(workout => workout.Description).IsRequired();
            builder.Property(workout => workout.CreatorId).IsRequired();

            builder.HasOne(workout => workout.Creator)
                .WithMany(user => user.Workouts)
                .HasForeignKey(workout => workout.CreatorId);

            builder.HasMany(workout => workout.Exercises)
                .WithOne(exercise => exercise.Workout)
                .HasForeignKey(exercise => exercise.WorkoutId);
        }
    }
}
