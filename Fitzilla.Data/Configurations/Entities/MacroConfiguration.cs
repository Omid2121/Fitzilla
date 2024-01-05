using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitzilla.DAL.Configurations.Entities
{
    public class MacroConfiguration : IEntityTypeConfiguration<Macro>
    {
        public void Configure(EntityTypeBuilder<Macro> builder)
        {
            builder.Property(macro => macro.Id).IsRequired();
            builder.Property(macro => macro.Name).IsRequired().HasMaxLength(50); 
            builder.Property(macro => macro.ConsumeType).IsRequired();
            builder.Property(macro => macro.Intensity).IsRequired();
            builder.Property(macro => macro.CreatorId).IsRequired();

            builder.HasOne(macro => macro.Creator)
                .WithMany(user => user.Macros)
                .HasForeignKey(macro => macro.CreatorId);

            builder.HasData(MacroSeedData.Macros());
        }
    }
}
