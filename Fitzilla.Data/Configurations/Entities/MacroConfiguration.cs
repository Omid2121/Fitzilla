using Fitzilla.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Configurations.Entities
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
        }
    }
}
