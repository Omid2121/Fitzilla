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
    public class ExerciseRecordConfiguration : IEntityTypeConfiguration<ExerciseRecord>
    {
        public void Configure(EntityTypeBuilder<ExerciseRecord> builder)
        {
            // Required fields
            builder.Property(exerciseRecord => exerciseRecord.Id).IsRequired();
            builder.Property(exerciseRecord => exerciseRecord.Rep).IsRequired();
            builder.Property(exerciseRecord => exerciseRecord.Weight).IsRequired();
            builder.Property(exerciseRecord => exerciseRecord.ExerciseId).IsRequired();

            // ExerciseRecord has a many-to-one relationship with Exercise
            builder.HasOne(exerciseRecord => exerciseRecord.Exercise)
                .WithMany(exercise => exercise.ExerciseRecords)
                .HasForeignKey(exerciseRecord => exerciseRecord.ExerciseId);
        }
    }
}
