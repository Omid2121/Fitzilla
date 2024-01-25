using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        // Required fields
        builder.Property(media => media.Id).IsRequired();
        builder.Property(media => media.Title).IsRequired().HasMaxLength(50);
        builder.Property(media => media.FilePath).IsRequired();
        builder.Property(media => media.CreatorId).IsRequired();

        // Media has a many-to-one relationship with User
        builder.HasOne(media => media.Creator)
            .WithMany(user => user.Medias)
            .HasForeignKey(image => image.CreatorId);

        // Media has a many-to-many relationship with ExerciseTemplate
        builder.HasMany(media => media.ExerciseTemplates)
            .WithMany(exerciseTemplate => exerciseTemplate.Medias)
            .UsingEntity<Dictionary<string, object>>(
                "ExerciseTemplateMedia",
                j => j
                    .HasOne<ExerciseTemplate>()
                    .WithMany()
                    .HasForeignKey("ExerciseTemplateId")
                    .HasConstraintName("FK_ExerciseTemplateMedia_ExerciseTemplate_ExerciseTemplateId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Media>()
                    .WithMany()
                    .HasForeignKey("MediaId")
                    .HasConstraintName("FK_ExerciseTemplateMedia_Media_MediaId")
                    .OnDelete(DeleteBehavior.ClientCascade));

        // Media has a many-to-many relationship with Exercise
        builder.HasMany(media => media.Exercises)
            .WithMany(exercise => exercise.Medias)
            .UsingEntity<Dictionary<string, object>>(
                "ExerciseMedia",
                j => j
                    .HasOne<Exercise>()
                    .WithMany()
                    .HasForeignKey("ExerciseId")
                    .HasConstraintName("FK_ExerciseMedia_Exercise_ExerciseId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Media>()
                    .WithMany()
                    .HasForeignKey("MediaId")
                    .HasConstraintName("FK_ExerciseMedia_Media_MediaId")
                    .OnDelete(DeleteBehavior.ClientCascade));
    }
}
