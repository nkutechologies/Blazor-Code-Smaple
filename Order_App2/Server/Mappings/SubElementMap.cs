using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Mappings
{
	public class SubElementMap : IEntityTypeConfiguration<SubElement>
    {
        public void Configure(EntityTypeBuilder<SubElement> builder)
        {
            builder.HasKey(x => x.SubElementId);
            builder.Property(x => x.SubElementId).ValueGeneratedOnAdd();

            builder.Property(c => c.Element).HasColumnName("Element");
            builder.Property(c => c.Type).HasColumnName("Type");
            builder.Property(c => c.Width).HasColumnName("Width");
            builder.Property(c => c.Height).HasColumnName("Height");
            builder.HasOne(x => x.Window).WithMany(x => x.SubElements).HasForeignKey(x => x.WindowId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

