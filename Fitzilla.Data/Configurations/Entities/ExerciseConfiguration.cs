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
            // Required fields
            builder.Property(exercise => exercise.Id).IsRequired();
            builder.Property(exercise => exercise.Title).IsRequired().HasMaxLength(40);
            builder.Property(exercise => exercise.Set).IsRequired();
            builder.Property(exercise => exercise.Rep).IsRequired();
            builder.Property(exercise => exercise.Weight).IsRequired();
            builder.Property(exercise => exercise.MediaId).IsRequired();
            builder.Property(exercise => exercise.CreatorId).IsRequired();

            // Exercise has a many-to-one relationship with Image
            builder.HasOne(exercise => exercise.Media)
                .WithMany(image => image.Exercises)
                .HasForeignKey(exercise => exercise.MediaId);

            // Exercise has a many-to-one relationship with Session
            builder.HasOne(exercise => exercise.Session)
                .WithMany(session => session.Exercises)
                .HasForeignKey(exercise => exercise.SessionId);

            // Exercise has a many-to-one relationship with User
            builder.HasOne(exercise => exercise.Creator)
                .WithMany(user => user.Exercises)
                .HasForeignKey(exercise => exercise.CreatorId);

            builder.HasData(ExerciseSeedData.Exercises());
        }
    }
}
