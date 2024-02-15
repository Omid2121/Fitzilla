using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            // Required fields
            builder.Property(rating => rating.Id).IsRequired();
            builder.Property(rating => rating.RatingValue).IsRequired();
            builder.Property(rating => rating.Comment).IsRequired();
            builder.Property(rating => rating.CreatorId).IsRequired();
            builder.Property(rating => rating.ExerciseTemplateId).IsRequired();

            // Rating has a many-to-one relationship with ExerciseTemplate
            builder.HasOne(rating => rating.ExerciseTemplate)
                .WithMany(exerciseTemplate => exerciseTemplate.Ratings)
                .HasForeignKey(rating => rating.ExerciseTemplateId);
        }
    }
}
