using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Order_App2.Server.Mappings;
using Order_App2.Shared.Entities;

namespace Order_App2.Server.Models
{
	public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<SubElement> SubElements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region authentication mappings starts
            builder.ApplyConfiguration<Order>(new OrderMap());
            builder.ApplyConfiguration<Window>(new WindowMap());
            builder.ApplyConfiguration<SubElement>(new SubElementMap());
            #endregion
        }
       

    }
}

