using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options) { }

        #region
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
