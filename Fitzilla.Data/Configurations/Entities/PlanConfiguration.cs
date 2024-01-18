using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        // Required fields
        builder.Property(plan => plan.Id).IsRequired();
        builder.Property(plan => plan.Title).IsRequired().HasMaxLength(50);
        builder.Property(plan => plan.SessionsPerWeek).IsRequired();
        builder.Property(plan => plan.DurationInWeeks).IsRequired();
        builder.Property(plan => plan.CreatorId).IsRequired();

        // Plan has a many-to-one relationship with User
        builder.HasOne(plan => plan.Creator)
            .WithMany(user => user.Plans)
            .HasForeignKey(plan => plan.CreatorId);

        // Plan has a one-to-many relationship with Session
        builder.HasMany(plan => plan.Sessions)
            .WithOne(session => session.Plan)
            .HasForeignKey(exercise => exercise.PlanId);

        builder.HasData(PlanSeedData.Plans());
    }
}
