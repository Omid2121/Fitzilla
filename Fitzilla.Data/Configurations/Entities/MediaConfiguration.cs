using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.Entities
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            // Required fields
            builder.Property(media => media.Id).IsRequired();
            builder.Property(media => media.Title).IsRequired().HasMaxLength(50);
            builder.Property(media => media.ImageUrl).IsRequired();
            builder.Property(media => media.CreatorId).IsRequired();

            // Media has a many-to-one relationship with User
            builder.HasOne(media => media.Creator)
                .WithMany(user => user.Medias)
                .HasForeignKey(image => image.CreatorId);

            // Media has a one-to-many relationship with ExerciseTemplate
            builder.HasMany(media => media.ExerciseTemplates)
                .WithOne(exerciseTemplate => exerciseTemplate.Media)
                .HasForeignKey(exerciseTemplate => exerciseTemplate.MediaId);

            // Media has a one-to-many relationship with Exercise
            builder.HasMany(media => media.Exercises)
                .WithOne(exercise => exercise.Media)
                .HasForeignKey(exercise => exercise.MediaId);
        }
    }
}
