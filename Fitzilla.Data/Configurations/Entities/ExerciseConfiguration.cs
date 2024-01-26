using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        // Required fields
        builder.Property(exercise => exercise.Id).IsRequired();
        builder.Property(exercise => exercise.Title).IsRequired().HasMaxLength(40);
        builder.Property(exercise => exercise.Set).IsRequired();
        builder.Property(exercise => exercise.Equipment).IsRequired();
        builder.Property(exercise => exercise.CreatorId).IsRequired();

        // Exercise has a one-to-many relationship with ExerciseRecord
        builder.HasMany(exercise => exercise.ExerciseRecords)
            .WithOne(exerciseRecord => exerciseRecord.Exercise)
            .HasForeignKey(exerciseRecord => exerciseRecord.ExerciseId);

        // Exercise has a many-to-many relationship with Media
        builder.HasMany(exercise => exercise.Medias)
            .WithMany(media => media.Exercises)
            .UsingEntity<Dictionary<string, object>>(
                "ExerciseMedia",
                j => j
                    .HasOne<Media>()
                    .WithMany()
                    .HasForeignKey("MediaId")
                    .HasConstraintName("FK_ExerciseMedia_Media_MediaId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Exercise>()
                    .WithMany()
                    .HasForeignKey("ExerciseId")
                    .HasConstraintName("FK_ExerciseMedia_Exercise_ExerciseId")
                    .OnDelete(DeleteBehavior.ClientCascade));

        // Exercise has a many-to-one relationship with Session
        builder.HasOne(exercise => exercise.Session)
            .WithMany(session => session.Exercises)
            .HasForeignKey(exercise => exercise.SessionId);

        // Exercise has a many-to-one relationship with User
        builder.HasOne(exercise => exercise.Creator)
            .WithMany(user => user.Exercises)
            .HasForeignKey(exercise => exercise.CreatorId);

        //builder.HasData(ExerciseSeedData.Exercises());
    }
}