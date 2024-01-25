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
    public class NutritionInfoConfiguration : IEntityTypeConfiguration<NutritionInfo>
    {
        public void Configure(EntityTypeBuilder<NutritionInfo> builder)
        {
            // Required fields
            builder.Property(nutritionInfo => nutritionInfo.Id).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.Calorie).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.ProteinAmount).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.ProteinPercentage).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.CarbohydrateAmount).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.CarbohydratePercentage).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.FatAmount).IsRequired();
            builder.Property(nutritionInfo => nutritionInfo.FatPercentage).IsRequired();

            // NutritionInfo has a one-to-one relationship with Macro
            builder.HasOne(nutritionInfo => nutritionInfo.Macro)
                .WithOne(macro => macro.NutritionInfo)
                .HasForeignKey<NutritionInfo>(nutritionInfo => nutritionInfo.MacroId);
        }
    }
}
