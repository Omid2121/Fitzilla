using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(exercise => exercise.Id).IsRequired();
            builder.Property(exercise => exercise.CreatorId).IsRequired();

            builder.HasOne(exercise => exercise.Workout)
                .WithMany(workout => workout.Exercises)
                .HasForeignKey(exercise => exercise.WorkoutId);

            builder.HasOne(exercise => exercise.Creator)
                .WithMany(user => user.Exercises)
                .HasForeignKey(exercise => exercise.CreatorId);

            builder.HasData(ExerciseSeedData.Exercises());
        }
    }
}
