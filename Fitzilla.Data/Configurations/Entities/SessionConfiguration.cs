using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        // Required fields
        builder.Property(session => session.Id).IsRequired();
        builder.Property(session => session.Title).IsRequired().HasMaxLength(50);
        builder.Property(session => session.IsActive).IsRequired();
        builder.Property(session => session.PlanId).IsRequired();
        builder.Property(session => session.CreatorId).IsRequired();

        // Session has a one-to-many relationship with Plan
        builder.HasOne(session => session.Plan)
            .WithMany(plan => plan.Sessions)
            .HasForeignKey(session => session.PlanId);

        // Session has a many-to-one relationship with User
        builder.HasOne(session => session.Creator)
            .WithMany(user => user.Sessions)
            .HasForeignKey(session => session.CreatorId);

        // Session has a one-to-many relationship with Exercise
        builder.HasMany(session => session.Exercises)
            .WithOne(exercise => exercise.Session)
            .HasForeignKey(exercise => exercise.SessionId);
    }
}
