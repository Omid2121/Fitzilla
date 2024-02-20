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
            builder.Property(rating => rating.Value).HasMaxLength(5).IsRequired();
            builder.Property(rating => rating.Comment).IsRequired();
            builder.Property(rating => rating.CreatorId).IsRequired();

            // Rating has a many-to-one relationship with ExerciseTemplate
            builder.HasOne(rating => rating.ExerciseTemplate)
                .WithMany(exerciseTemplate => exerciseTemplate.Ratings)
                .HasForeignKey(rating => rating.ExerciseTemplateId);

            // Rating has a many-to-one relationship with User
            builder.HasOne(rating => rating.Creator)
                .WithMany(user => user.Ratings)
                .HasForeignKey(rating => rating.CreatorId);
        }
    }
}
