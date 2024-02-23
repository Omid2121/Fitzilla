using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities;

public class MacroConfiguration : IEntityTypeConfiguration<Macro>
{
    public void Configure(EntityTypeBuilder<Macro> builder)
    {
        // Required fields
        builder.Property(macro => macro.Id).IsRequired();
        builder.Property(macro => macro.Title).IsRequired().HasMaxLength(50);
        builder.Property(macro => macro.CreatedAt).IsRequired();
        builder.Property(macro => macro.GoalWeight).IsRequired();
        builder.Property(macro => macro.CycleStartDate).IsRequired();
        builder.Property(macro => macro.CycleEndDate).IsRequired();
        builder.Property(macro => macro.GoalType).IsRequired();
        builder.Property(macro => macro.ActivityLevel).IsRequired();
        builder.Property(macro => macro.Calorie).IsRequired();
        builder.Property(macro => macro.ProteinAmount).IsRequired();
        builder.Property(macro => macro.ProteinPercentage).IsRequired();
        builder.Property(macro => macro.CarbohydrateAmount).IsRequired();
        builder.Property(macro => macro.CarbohydratePercentage).IsRequired();
        builder.Property(macro => macro.FatAmount).IsRequired();
        builder.Property(macro => macro.FatPercentage).IsRequired();
        builder.Property(macro => macro.CreatorId).IsRequired();

        // Macro has a many-to-one relationship with User
        builder.HasOne(macro => macro.Creator)
            .WithMany(user => user.Macros)
            .HasForeignKey(macro => macro.CreatorId);
    }
}
