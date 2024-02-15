using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class ExerciseTemplateConfiguration : IEntityTypeConfiguration<ExerciseTemplate>
{
    public void Configure(EntityTypeBuilder<ExerciseTemplate> builder)
    {
        // Required fields
        builder.Property(exerciseTemplate => exerciseTemplate.Id).IsRequired();
        builder.Property(exerciseTemplate => exerciseTemplate.Title).IsRequired().HasMaxLength(40);
        builder.Property(exerciseTemplate => exerciseTemplate.Description).IsRequired();
        builder.Property(exerciseTemplate => exerciseTemplate.Equipment).IsRequired();
        builder.Property(exerciseTemplate => exerciseTemplate.CreatorId).IsRequired();

        // ExerciseTemplate has a many-to-many relationship with Media
        builder.HasMany(exerciseTemplate => exerciseTemplate.Medias)
            .WithMany(media => media.ExerciseTemplates)
            .UsingEntity<Dictionary<string, object>>(
                "ExerciseTemplateMedia",
                j => j
                    .HasOne<Media>()
                    .WithMany()
                    .HasForeignKey("MediaId")
                    .HasConstraintName("FK_ExerciseTemplateMedia_Media_MediaId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<ExerciseTemplate>()
                    .WithMany()
                    .HasForeignKey("ExerciseTemplateId")
                    .HasConstraintName("FK_ExerciseTemplateMedia_ExerciseTemplate_ExerciseTemplateId")
                    .OnDelete(DeleteBehavior.ClientCascade));

        // ExerciseTemplate has a many-to-one relationship with User
        builder.HasOne(exerciseTemplate => exerciseTemplate.Creator)
            .WithMany(user => user.ExerciseTemplates)
            .HasForeignKey(exerciseTemplate => exerciseTemplate.CreatorId);

        // ExerciseTemplate has a one-to-many relationship with Rating
        builder.HasMany(exerciseTemplate => exerciseTemplate.Ratings)
            .WithOne(rating => rating.ExerciseTemplate)
            .HasForeignKey(rating => rating.ExerciseTemplateId);

        //builder.HasData(ExerciseTemplateSeedData.ExerciseTemplates());
    }
}