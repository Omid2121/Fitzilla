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
            builder.Property(exerciseTemplate => exerciseTemplate.Id).IsRequired();
            builder.Property(exerciseTemplate => exerciseTemplate.Name).IsRequired().HasMaxLength(50);
            builder.Property(exerciseTemplate => exerciseTemplate.Description).IsRequired();

            builder.HasOne(exerciseTemplate => exerciseTemplate.Creator)
                .WithMany(user => user.ExerciseTemplates)
                .HasForeignKey(exerciseTemplate => exerciseTemplate.CreatorId);

            builder.HasData(ExerciseTemplateSeedData.ExerciseTemplates());
        }
    }
}
