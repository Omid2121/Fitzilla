using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities
{
    public class ExerciseTemplateConfiguration : IEntityTypeConfiguration<ExerciseTemplate>
    {
        public void Configure(EntityTypeBuilder<ExerciseTemplate> builder)
        {
            // Required fields
            builder.Property(exerciseTemplate => exerciseTemplate.Id).IsRequired();
            builder.Property(exerciseTemplate => exerciseTemplate.Title).IsRequired().HasMaxLength(40);
            builder.Property(exerciseTemplate => exerciseTemplate.Description).IsRequired();
            builder.Property(exerciseTemplate => exerciseTemplate.MediaId).IsRequired();

            // ExerciseTemplate has a many-to-one relationship with Image
            builder.HasOne(exerciseTemplate => exerciseTemplate.Media)
                .WithMany(image => image.ExerciseTemplates)
                .HasForeignKey(exerciseTemplate => exerciseTemplate.MediaId);

        // ExerciseTemplate has a many-to-one relationship with User
        builder.HasOne(exerciseTemplate => exerciseTemplate.Creator)
            .WithMany(user => user.ExerciseTemplates)
            .HasForeignKey(exerciseTemplate => exerciseTemplate.CreatorId);

        builder.HasData(ExerciseTemplateSeedData.ExerciseTemplates());
    }
}
