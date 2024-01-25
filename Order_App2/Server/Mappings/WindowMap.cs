using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Mappings
{
	public class WindowMap : IEntityTypeConfiguration<Window>
    {
        public void Configure(EntityTypeBuilder<Window> builder)
        {
            builder.HasKey(x => x.WindowId);
            builder.Property(x => x.WindowId).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.QuantityOfWindows).HasColumnName("QuantityOfWindows");
            builder.HasOne(x => x.Order).WithMany(x => x.Windows).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

