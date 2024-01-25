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
        builder.Property(macro => macro.GoalWeight).IsRequired();
        builder.Property(macro => macro.CycleStartDate).IsRequired();
        builder.Property(macro => macro.CycleEndDate).IsRequired();
        builder.Property(macro => macro.GoalType).IsRequired();
        builder.Property(macro => macro.ActivityLevel).IsRequired();
        builder.Property(macro => macro.NutritionInfoId).IsRequired();
        builder.Property(macro => macro.CreatorId).IsRequired();

        // Macro has a one-to-one relationship with NutritionInfo
        builder.HasOne(macro => macro.NutritionInfo)
            .WithOne(nutritionInfo => nutritionInfo.Macro)
            .HasForeignKey<Macro>(macro => macro.NutritionInfoId);

        // Macro has a many-to-one relationship with User
        builder.HasOne(macro => macro.Creator)
            .WithMany(user => user.Macros)
            .HasForeignKey(macro => macro.CreatorId);

        //builder.HasData(MacroSeedData.Macros());
    }
}
