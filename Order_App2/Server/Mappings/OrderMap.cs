using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Mappings
{
	public class OrderMap : IEntityTypeConfiguration<Order>
    {
		public void Configure(EntityTypeBuilder<Order> builder)
		{
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.State).HasColumnName("State");
        }
	}
}

